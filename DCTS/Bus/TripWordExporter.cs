﻿using System;
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
    class TripWordExporter
    {
        long TripId {get; set;}

        Trip trip;
        List<Day> days;

        public TripWordExporter( long tripId)
        {
            TripId = tripId;

            using (var ctx = new DctsEntities())
            {
                trip = ctx.Trips.Find(TripId);
                days = ctx.Days.Include("ComboLocation").Where(o => o.tripId == TripId).OrderBy(o => o.day).ThenBy(o => o.position).ToList(); 
            }
        }



        public bool ExportWord( )
        {


            string[] txtKeys = {"nation","city", "area", "title", "local_title", "address", "local_address", "latlng", "route", "contact", "tips",
                              // 景点
                                "open_at", "close_at", "ticket",
                               //住宿
                               "room", "dinner", "wifi", "parking", "reception", "kitchen",
                               // 
                               "recommended_dishes"
                            };
            string[] specKeys = { "openning_hours" };
            var wrappedKeys = txtKeys.Select(o => "%" + o + "%").ToList();

            using (var db = new DctsEntities())
            {

                using (DocX document = DocX.Create(EntityPathConfig.TripWordFilePath(this.TripId)))
                {
                    List<ComboLocation> handledLocations = new List<ComboLocation>();

                    foreach (var day in this.days)
                    {
                        var location = day.ComboLocation;
                        string templatePath = string.Empty;

                        if (day.ComboLocation.ltype == (int)ComboLocationEnum.Blank)
                        {
                            document.InsertSectionPageBreak();
                            continue;
                        }
                        else if (day.ComboLocation.ltype == (int)ComboLocationEnum.Scenic)
                        {
                            templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LocationTemplate.ScenicDetailRelativePath);

                        }
                        else if (day.ComboLocation.ltype == (int)ComboLocationEnum.Dining)
                        {
                            templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LocationTemplate.DinningDetailRelativePath);

                        }
                        else if (day.ComboLocation.ltype == (int)ComboLocationEnum.Hotel)
                        {
                            templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LocationTemplate.HotelDetailRelativePath);

                        }
                        if (templatePath.Length == 0)
                        {
                            continue;
                        }

                        using (DocX template = DocX.Load(templatePath))
                        {
                            var type = location.GetType();

                            var duplicated = template.Copy();

                            foreach (string key in txtKeys)
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

                                    duplicated.ReplaceText(wrappedKey, ComboLoactionBusiness.DisplayOpenningHours(location));

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
         
    }
}
