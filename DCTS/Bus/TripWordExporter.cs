﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novacode;
using DCTS.DB;
using System.IO;

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



        public void ExportWord( )
        {


            string[] txtKeys = {"nation","city", "area", "title", "local_title", "address", "local_address", "latlng", "route", "contact",
                              // 景点
                                "open_at", "close_at", "ticket",
                               //住宿
                               "room", "dinner", "wifi", "parking", "reception", "kitchen"
                            };

            var wrappedKeys = txtKeys.Select(o => "%" + o + "%").ToList();

            using (DocX document = DocX.Create(WordFilePath() ))
            {
                foreach( var day in this.days)
                {
                    var location = day.ComboLocation;
                    string templatePath = string.Empty;
                    if (day.ComboLocation.ltype == (int)ComboLocationEnum.Scenic)
                    {
                        templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LocationTemplate.ScenicDetailRelativePath );

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
                            string val = type.GetProperty(key).GetValue(location).ToString();
                            string wrappedKey = "%" + key + "%";
                            duplicated.ReplaceText(wrappedKey, val);
                        }

                        document.InsertDocument(duplicated);
                        //添加一些基本对象，如段落等
                        document.Save();//保存
                    }
                }
            }

        }

        // data/export/words/
        public string WordFilePath()
        {
            string basePath = "data/export/words";
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, basePath, (TripId / 1000).ToString());
        }
    }
}