using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using DCTS.DB;
using System.IO;
using WindowsBitmap = System.Drawing.Bitmap;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DCTS.Bus
{
    //http://www.cnblogs.com/kesalin/archive/2012/04/18/open_xml_word.html
    class CustomerTripWordExporterEx
    {
        long TripId {get; set;}

        Trip trip;
        List<TripDay> days;
        List<DayLocation> dayLocations;
        List<WordprocessingDocument> filledTemplates;
        List<MemoryStream> filledTemplateStreams = new List<MemoryStream>();

        public CustomerTripWordExporterEx(long trip_id)
        {
            TripId = trip_id;

            using (var ctx = new DctsEntities())
            {
                trip = ctx.Trips.Find(TripId);
                days = trip.TripDays.ToList();
                dayLocations = ctx.DayLocations.Include("TripDay").Include("ComboLocation").Where(o => o.trip_id == TripId).OrderBy(o => o.TripDay.day).ThenBy(o => o.position).ToList();
            }

            filledTemplates = new List<WordprocessingDocument>();
            filledTemplateStreams = new List<MemoryStream>();
        }



        public bool ExportWord( )
        {
            var sources = new List<WordprocessingDocument>();

            using (var db = new DctsEntities())
            {
                var tripSumaryTemplate = WordprocessingDocument.Open(LocationTemplate.TripSumaryPath,false);
                var daySumaryTemplate = WordprocessingDocument.Open(LocationTemplate.DaySumaryPath, false);

                //cloned templates/base as template
                string layout = LocationTemplate.LayoutRelativePath;
                string tripPath = EntityPathConfig.TripWordFilePath(this.TripId);
                File.Copy(layout, tripPath,true);

                using (WordprocessingDocument document = WordprocessingDocument.Open(tripPath, true) )
                {
                    // 处理路书行程概要

                    HandleTripSummary(tripSumaryTemplate);

                    foreach (var day in this.days)
                    {
                        HandleDaySummary(daySumaryTemplate, day);
                        //处理每天行程概要
						var daylocations = dayLocations.Where(o => o.day_id == day.id).ToList();

                        foreach (var dl in daylocations)
                        {

							HandleLocation(  dl );
                        }
                    }
                   //合并文档
                    WordTemplateHelper.MergeDoc(filledTemplateStreams, document);
                    document.Save();//保存
                }

                var trip = db.Trips.Find(TripId);

                trip.word_created_at = DateTime.Now;

                daySumaryTemplate.Close();
                tripSumaryTemplate.Close();
                db.SaveChanges();
            }
            return true;
        }


        // params
        //   doc: 添加行程概览到路书
        public void HandleTripSummary(WordprocessingDocument template)
        {
            string[] tripKeys = { "days" };
            string[] specKeys = { "trip_startend", "trip_dayLocations" };
            var stream = new MemoryStream();
            var tripSumary = template.Clone(stream, true) as WordprocessingDocument;

            WordTemplateHelper.ReplaceTextWithProperty<Trip>(tripSumary, tripKeys, trip);

            foreach (string key in specKeys)
            {
                string wrappedKey = "%" + key + "%";
                if (key == "trip_startend")
                {
                    WordTemplateHelper.ReplaceText(tripSumary, wrappedKey, WordTemplateHelper.DisplayStartAndEndTime(trip));
                }
            }

            var mainDoc = tripSumary.MainDocumentPart.Document;
            //look for one specific table here
            Table dayTable = mainDoc.Body.Descendants<Table>().FirstOrDefault();
            if (dayTable != null)
            {
                //Row 0 and 1 are Headers
                //Row 2 is pattern
                var rows = dayTable.Elements<TableRow>().ToList();
                if (rows.Count > 2)
                {
                    //get the Pattern row for duplication
                    var rowPattern = rows.Last();
                    //
                    for (int i = 0; i < this.days.Count; i++)
                    {
                        var day = days[i];
                        var date = trip.start_at.GetValueOrDefault().AddDays(day.day - 1);
                        var locations = this.dayLocations.Where(o => o.day_id == day.id).ToList();
                        //InsertRow performs a copy, so we get markup in new line ready for replacements

                        var rowCopy = rowPattern.CloneNode(true) as TableRow;

                        WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "%day_day%", day.day.ToString());
                        WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "%day_date%", String.Format("{0:yyyyMMdd}", date));
                        WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "%day_weekday%",  String.Format("{0:ddd}", date));
                        WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "%day_cities%", WordTemplateHelper.DisplayDayCities(locations));

                        var cell = rowCopy.Elements<TableCell>().ElementAt(3);
                        var pattern = cell.Descendants<Paragraph>().Last();
                        var titles = locations.Select(o => o.ComboLocation.title).Distinct().ToArray();
                        for (int j = 0; j < titles.Count(); j++)
                        {
                            var t = titles[j];
                            var cloned = pattern.CloneNode(true) as Paragraph;
                            WordTemplateHelper.ReplaceText<Paragraph>(cloned, "%day_location%", t);
                            //if (j > 0)
                            //{
                            //    pattern.InsertBeforeSelf(new Break());
                            //}
                            pattern.InsertBeforeSelf(cloned);                            
                        }
                        pattern.Remove();
                        WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "%day_hotel%", WordTemplateHelper.DisplayDayHotel(locations));

                        dayTable.AppendChild(rowCopy);
                    }

                    //pattern row is at the end now, can be removed from table
                    rowPattern.Remove();

                }
            }
            else
            {
                Console.WriteLine("\tError, couldn't find table with caption ORDER_TABLE in document");
            }
            tripSumary.Save();

            this.filledTemplates.Add(tripSumary);
            this.filledTemplateStreams.Add(stream);
            
        }

        public void HandleDaySummary(WordprocessingDocument template, TripDay day)
        {
            string[] keys = { "day" };
            string[] specKeys = { "day_date", "day_locations", "day_lweekday" };
            var stream = new MemoryStream();
            var sumary = template.Clone(stream, true) as WordprocessingDocument;
			//替换一般属性
            WordTemplateHelper.ReplaceTextWithProperty<TripDay>(sumary, keys, day);
			//替换特殊文本
			var date = this.trip.start_at.GetValueOrDefault().AddDays(day.day - 1);
            var locations = this.dayLocations.Where(o => o.day_id == day.id).ToList();

            foreach (string key in specKeys)
            {
                string wrappedKey = "%" + key + "%";
                if (key == "day_date")//2017年6月1日
                {
                    WordTemplateHelper.ReplaceText(sumary, wrappedKey, WordTemplateHelper.DisplayDate( date));
                }
                if (key == "day_lweekday")//星期四
                {					
                    WordTemplateHelper.ReplaceText(sumary, wrappedKey, WordTemplateHelper.DisplayLongWeekDay(date ));
                }
                if (key == "day_locations")//北京-阿姆斯特丹-罗马
                {
                    WordTemplateHelper.ReplaceText(sumary, wrappedKey, WordTemplateHelper.DisplayDayLocations(locations, "-"));
                }
            }
            var mainDoc = sumary.MainDocumentPart.Document;

			Table dayTable = mainDoc.Body.Descendants<Table>().LastOrDefault();
            if (dayTable != null)
            {
                //Row 0 is pattern
                var rows = dayTable.Elements<TableRow>().ToList();
                if (rows.Count > 0)
                {
                    //get the Pattern row for duplication
                    var rowPattern = rows.Last();
                    for (int i = 0; i < locations.Count; i++)
                    {
                        var dl = locations[i];
                        if (dl.ComboLocation.ltype == (int)ComboLocationEnum.Blank) 
                        {
                            continue;
                        }
						var start_at = dl.start_at.GetValueOrDefault();
                        var schedule = ((dl.schedule != null) && (dl.schedule.Length > 0)) ? dl.schedule : dl.ComboLocation.title;

                        var rowCopy = rowPattern.CloneNode(true) as TableRow;
                        WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "LocationStartAt", String.Format("{0:HH:mm}", start_at));
                        WordTemplateHelper.ReplaceText<TableRow>(rowCopy, "LocationSchedule", schedule);
                        dayTable.AppendChild(rowCopy);
                    }
                    rowPattern.Remove();
                }
            }
            sumary.Save();

            this.filledTemplates.Add(sumary);
            this.filledTemplateStreams.Add(stream);
        }


        public void HandleLocation( DayLocation dayLocation)
        {
            string[] locationKeys = {"nation","city", "area", "title", "local_title", "address", "local_address", "latlng", "route", "contact", "tips",
                              // 景点
                                "open_at", "close_at", "ticket",
                               //住宿
                               "room", "dinner", "wifi", "parking", "reception", "kitchen",
                               // 
                               "recommended_dishes"
                            };
            string[] specKeys = { "openning_hours" };
            var wrappedKeys = locationKeys.Select(o => "%" + o + "%").ToList();

            var location = dayLocation.ComboLocation;
            var locationType = (ComboLocationEnum)location.ltype;
            string templatePath = LocationTemplate.GetPath(location);

            if (templatePath.Length == 0)
            {
                return;
            }

            using (var template = WordprocessingDocument.Open(templatePath, false))
            {

                var type = location.GetType();
                var stream = new MemoryStream();
                var duplicated = template.Clone(stream, true) as WordprocessingDocument;
                //https://stackoverflow.com/questions/19094388/openxml-replace-text-in-all-document

                if (locationType != ComboLocationEnum.Blank)
                {
                    WordTemplateHelper.ReplaceTextWithProperty<ComboLocation>(duplicated, locationKeys, location);

                    foreach (string key in specKeys)
                    {
                        string wrappedKey = "%" + key + "%";

                        if (key == "openning_hours")
                        {
                            WordTemplateHelper.ReplaceText(duplicated, wrappedKey, ComboLoactionBusiness.DisplayOpeningHours(location));
                        }
                    }
                    if (location.img.Length > 0)
                    {
                        var image = duplicated.MainDocumentPart.ImageParts.ElementAtOrDefault(0);
                        //Image img = duplicated.Images[0];

                        string imagePath = EntityPathConfig.LocationImagePath(location);
                        if (image != null && File.Exists(imagePath))
                        {
                            string relID = duplicated.MainDocumentPart.GetIdOfPart(image);
                            //image.FeedData(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                            WordTemplateHelper.UpdateImage(duplicated, relID, imagePath);
                            WordTemplateHelper.ResizeImage(duplicated, relID, imagePath);

                        }
                    }
                    duplicated.Save();
                }

                this.filledTemplates.Add(duplicated);
                this.filledTemplateStreams.Add(stream);
                //document.InsertDocument(duplicated);
            }

        }



        

    }
}
