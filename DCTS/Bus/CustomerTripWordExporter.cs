using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novacode;
using DCTS.DB;
using System.IO;
using WindowsBitmap = System.Drawing.Bitmap;

namespace DCTS.Bus
{
    class CustomerTripWordExporter
    {
        long TripId {get; set;}

        Trip trip;
        List<TripDay> days;
        List<DayLocation> dayLocations;


        public CustomerTripWordExporter(long trip_id)
        {
            TripId = trip_id;

            using (var ctx = new DctsEntities())
            {
                trip = ctx.Trips.Find(TripId);
                days = trip.TripDays.ToList();
                dayLocations = ctx.DayLocations.Include("TripDay").Include("ComboLocation").Where(o => o.trip_id == TripId).OrderBy(o => o.TripDay.day).ThenBy(o => o.position).ToList(); 
            }
        }



        public bool ExportWord( )
        {

            
            string[] locationKeys = {
                // location
                "nation","city", "area", "title", "local_title", "address", "local_address", "latlng", "route", "contact", "tips",
                              // 景点
                                "open_at", "close_at", "ticket",
                               //住宿
                               "room", "dinner", "wifi", "parking", "reception", "kitchen",
                               // 
                               "recommended_dishes"
                            };
            string[] specKeys = { "t_startend", "openning_hours" };
            var wrappedKeys = locationKeys.Select(o => "%" + o + "%").ToList();

            using (var db = new DctsEntities())
            {
                var tripSumaryTemplate = DocX.Load(LocationTemplate.TripSumaryPath);
                var daySumaryTemplate = DocX.Load(LocationTemplate.DaySumaryPath);
                //copy templates/base as template
                string layout = LocationTemplate.LayoutRelativePath;
                string tripPath = EntityPathConfig.TripWordFilePath(this.TripId);
                File.Copy(layout, tripPath,true);


                using (DocX document = DocX.Load(tripPath))
                {
                    // 处理路书行程概要
                    List<ComboLocation> handledLocations = new List<ComboLocation>();
                    DocX filledSumary= HandleTripSummary(tripSumaryTemplate);

                    document.InsertDocument(filledSumary);
                    document.InsertSectionPageBreak();


                    foreach (var day in this.dayLocations)
                    {
                        //处理每天行程概要
                        var location = day.ComboLocation;
                        string templatePath = string.Empty;

                        if (day.ComboLocation.ltype == (int)ComboLocationEnum.Blank)
                        {
                            document.InsertSectionPageBreak();
                            continue;
                        }
                        else if (day.ComboLocation.ltype == (int)ComboLocationEnum.Scenic)
                        {
                            templatePath =  LocationTemplate.ScenicDetailPath;

                        }
                        else if (day.ComboLocation.ltype == (int)ComboLocationEnum.Dining)
                        {
                            templatePath = LocationTemplate.DinningDetailPath;

                        }
                        else if (day.ComboLocation.ltype == (int)ComboLocationEnum.Hotel)
                        {
                            templatePath = LocationTemplate.HotelDetailPath;

                        }
                        if (templatePath.Length == 0)
                        {
                            continue;
                        }

                        using (DocX template = DocX.Load(templatePath))
                        {
                            var type = location.GetType();

                            var duplicated = template.Copy();

                            foreach (string key in locationKeys)
                            {
                                var val = type.GetProperty(key).GetValue(location);
                                string s = val == null ? string.Empty : val.ToString();
                                string wrappedKey = "%" + key + "%";
                                duplicated.ReplaceText(wrappedKey, s);
                            }
                            foreach (string key in specKeys)
                            {
                                string wrappedKey = "%" + key + "%";

                                if (key == "openning_hours")
                                {

                                    duplicated.ReplaceText(wrappedKey, ComboLoactionBusiness.DisplayOpeningHours(location));

                                }
                            }

                            if (duplicated.Images.Count >= 2)
                            {
                                if (location.img.Length > 0)
                                {
                                    Image img = duplicated.Images[0];

                                    string path = EntityPathConfig.LocationImagePath(location);
                                    if (File.Exists(path))
                                    {
                                        var b = new WindowsBitmap(path);
                                        // Save this Bitmap back into the document using a Create\Write stream.
                                        b.Save(img.GetStream(FileMode.Create, FileAccess.Write), System.Drawing.Imaging.ImageFormat.Png);
                                    }
                                }
                            }

                            if (handledLocations.Count > 0)
                            {
                                document.InsertSectionPageBreak();
                            }

                            document.InsertDocument(duplicated);
                            handledLocations.Add(location);
                        }
                        //添加一些基本对象，如段落等
                        document.Save();//保存
                    }
                }

                var trip = db.Trips.Find(TripId);

                trip.word_created_at = DateTime.Now;

                db.SaveChanges();
            }
            return true;
        }

        // params
        //   doc: 添加行程概览到路书
        public DocX HandleTripSummary(DocX template )
        {
            string[] tripKeys = {"days"};

            string[] specKeys = { "trip_startend", "trip_dayLocations" };

            var tripSumary = template.Copy();

            ReplaceTextWithProperty<Trip>(tripSumary, tripKeys, trip);

            foreach (string key in specKeys)
            {
                string wrappedKey = "%" + key + "%";

                if (key == "trip_startend")
                {
                    tripSumary.ReplaceText(wrappedKey, WordTemplateHelper.DisplayStartAndEndTime(trip));
                }
            }

            //look for one specific table here
            Table orderTable = tripSumary.Tables.First();
            if (orderTable != null)
            {
                //Row 0 and 1 are Headers
                //Row 2 is pattern
                if (orderTable.RowCount > 2)
                {
                    //get the Pattern row for duplication
                    Row orderRowPattern = orderTable.Rows[2];
                    //

                    for (int i = 0; i < this.days.Count; i++)
                    {
                        var day = days[i];
                        var date =  trip.start_at.GetValueOrDefault().AddDays( day.day -1);
                        var locations = dayLocations.Where(o => o.day_id == day.id).ToList();
                        //InsertRow performs a copy, so we get markup in new line ready for replacements
                        Row newOrderRow = orderTable.InsertRow(orderRowPattern, 2 + i);
                        newOrderRow.Cells[0].ReplaceText("%day_day%",  day.day.ToString());
                        newOrderRow.Cells[1].ReplaceText("%day_date%", String.Format("{0:yyyyMMdd}", date));
                        newOrderRow.Cells[1].ReplaceText("%day_weekday%", String.Format("{0:ddd}", date));
                        newOrderRow.Cells[2].ReplaceText("%day_cities%", WordTemplateHelper.DisplayDayCities(locations));
                        var titles = locations.Select(o => o.ComboLocation.title).Distinct().ToArray();
                        Novacode.List titleList = null;
                        for( int j=0; j< titles.Count(); j++)
                        {
                            var t = titles[j];
                            if( j==0)
                            {
                               titleList = template.AddList(t, 0, ListItemType.Numbered);
                            }else{
                               template.AddListItem(titleList, t);
                            }
                        }
                        if( titleList != null)
                        {
                            
                            newOrderRow.Cells[3].InsertList(titleList);
                        }

                        newOrderRow.ReplaceText("%day_hotel%", WordTemplateHelper.DisplayDayHotel(locations));
                    }

                    //pattern row is at the end now, can be removed from table
                    orderRowPattern.Remove();

                }
            }
            else
            {
                Console.WriteLine("\tError, couldn't find table with caption ORDER_TABLE in document");
            }
            return tripSumary;
        }

        private void ReplaceTextWithProperty<T>(Novacode.DocX doc, string[] keys, T entity)
        {
            var type = entity.GetType();
            string entityName = type.BaseType.Name.ToLower();
            //Trip => trip
            foreach (string key in keys)
            {
                var val = type.GetProperty(key).GetValue(entity);
                string s = val == null ? string.Empty : val.ToString();
                string wrappedKey = "%" + entityName + "_" + key + "%";
                doc.ReplaceText(wrappedKey, s);
            }
        }

        private void ReplaceTextWithProperty<T>( Novacode.Row doc, string[] keys, T entity)
        {
            var type = entity.GetType();
            string entityName = type.BaseType.Name.ToLower();
            //Trip => trip
            foreach (string key in keys)
            {
                var val = type.GetProperty(key).GetValue(entity);
                string s = val == null ? string.Empty : val.ToString();
                string wrappedKey = "%" + entityName + "_" + key + "%";
                doc.ReplaceText(wrappedKey, s);
            }
        }       
    }
}
