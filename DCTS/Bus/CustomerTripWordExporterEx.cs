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

                //copy templates/base as template
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
                        var runPattern = cell.Descendants<Run>().Last();
                        var titles = locations.Select(o => o.ComboLocation.title).Distinct().ToArray();
                        for (int j = 0; j < titles.Count(); j++)
                        {
                            var t = titles[j];
                            var runCopy = runPattern.CloneNode(true) as Run;
                            WordTemplateHelper.ReplaceText<Run>(runCopy, "%day_location%", t);
                            if (j > 0)
                            {
                                runPattern.InsertBeforeSelf(new Break());
                            }
                            runPattern.InsertBeforeSelf(runCopy);                            
                        }
                        runPattern.Remove();
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

                        string path = EntityPathConfig.LocationImagePath(location);
                        if (image != null && File.Exists(path))
                        {
                            var b = new WindowsBitmap(path);


                            image.FeedData(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                            // Save this Bitmap back into the document using a Create\Write stream.
                            //b.Save(img.GetStream(FileMode.Create, FileAccess.Write), System.Drawing.Imaging.ImageFormat.Png);
                        }
                    }
                    duplicated.Save();
                }

                this.filledTemplates.Add(duplicated);
                this.filledTemplateStreams.Add(stream);
                //document.InsertDocument(duplicated);
            }

        }

        //https://www.codeproject.com/articles/187928/imageupdater
        
        public void UpdateImage(Dictionary<string, MemoryStream> tagValueDict)
        {
            foreach (var pair in tagValueDict)
            {
                var tagID = pair.Key;
                var imageStream = pair.Value;

                //foreach (SdtElement sdtElement in _mainDocPart.Document.Body.Descendants<SdtElement>())
                //{
                //    string relID = GetImageRelID(sdtElement, tagID);
                //    if (!string.IsNullOrEmpty(relID))
                //    {
                //        // Get size of image
                //        int imageWidth;
                //        int imageHeight;
                //        GetPlaceholderImageSize(_mainDocPart.Document.Body.Descendants<Drawing>(), relID, out imageWidth, out imageHeight);

                //        UpdateImagePart(relID, imageStream, imageWidth, imageHeight);

                //        break;
                //    }
                //}
            }
        }


        //上面的代码用于在某个 sdt 元素下面查找匹配内容控件ID所使用的图像资源id。然后我们根据该资源id来获取placeholder image的大小：
        internal static void GetPlaceholderImageSize(IEnumerable<Drawing> drawingList, string relID, out int width, out int height)
        {
            width = -1;
            height = -1;

            // Loop through all Drawing elements in the document
            foreach (Drawing d in drawingList)
            {
                // Loop through all the pictures (Blip) in the document
                //if (d.Descendants<Blip>().ToList().Any(b => b.Embed.ToString() == relID))
                //{
                //    // The document size is in EMU. 1 pixel = 9525 EMU

                //    // The size of the image placeholder is located in the EXTENT element
                //    Extent e = d.Descendants<Extent>().FirstOrDefault();
                //    if (null != e)
                //    {
                //        width = (int)(e.Cx / 9525);
                //        height = (int)(e.Cy / 9525);
                //    }

                //    if (width == -1)
                //    {
                //        // The size of the image is located in the EXTENTS element
                //        Extents e2 = d.Descendants<Extents>().FirstOrDefault();
                //        if (null != e2)
                //        {
                //            width = (int)(e2.Cx / 9525);
                //            height = (int)(e2.Cy / 9525);
                //        }
                //    }
                //}
            }
        }
        //获取到大小信息之后，我们就可以使用资源id以及图像大小信息，替换图像来替换具体的placeholder图像了。
        private void UpdateImagePart(string relID, MemoryStream imageStream, int width, int height)
        {
            //var originalBitmap = Image.FromStream(imageStream);
            //var bitmap = originalBitmap;
            //// resize image
            //if (width != -1)
            //{
            //    bitmap = new Bitmap(originalBitmap, width, height);
            //}

            //// Save image data to ImagePart
            //var stream = new MemoryStream();
            //bitmap.Save(stream, originalBitmap.RawFormat);

            //// Get the ImagePart
            //var imagePart = (ImagePart)_mainDocPart.GetPartById(relID);

            //// Create a writer to the ImagePart
            //var writer = new BinaryWriter(imagePart.GetStream());

            //// Overwrite the current image in the docx file package
            //writer.Write(stream.ToArray());

            //// Close the ImagePart
            //writer.Close();
        }
    }
}
