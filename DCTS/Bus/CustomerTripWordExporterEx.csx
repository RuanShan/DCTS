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
        List<DayLocation> days;

        public CustomerTripWordExporterEx(long trip_id)
        {
            TripId = trip_id;

            using (var ctx = new DctsEntities())
            {
                trip = ctx.Trips.Find(TripId);
                days = ctx.DayLocations.Include("TripDay").Include("ComboLocation").Where(o => o.trip_id == TripId).OrderBy(o => o.TripDay.day).ThenBy(o => o.position).ToList(); 
            }
        }



        public bool ExportWord( )
        {
             var sources = new List<WordprocessingDocument>();


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

            using (var db = new DctsEntities())
            {
                //copy templates/base as template
                string layout = LocationTemplate.LayoutRelativePath;
                string tripPath = EntityPathConfig.TripWordFilePath(this.TripId);
                File.Copy(layout, tripPath,true);
                using (WordprocessingDocument document = WordprocessingDocument.Open(tripPath, true) )
                {
                    List<ComboLocation> handledLocations = new List<ComboLocation>();
                    List<WordprocessingDocument> templates = new List<WordprocessingDocument>();
                    List<MemoryStream> streams = new List<MemoryStream>();

                    foreach (var day in this.days)
                    {
                        var location = day.ComboLocation;
                        var locationType = (ComboLocationEnum)location.ltype;
                        string templatePath = LocationTemplate.GetPath( location);

                        
                        if (templatePath.Length == 0)
                        {
                            continue;
                        }
                        
                        using (var template = WordprocessingDocument.Open(templatePath, false))
                        {

                            var type = location.GetType();
                            var stream = new MemoryStream();
                            var duplicated = template.Clone(stream,true) as WordprocessingDocument;
                           //https://stackoverflow.com/questions/19094388/openxml-replace-text-in-all-document
                            
                            if (  locationType != ComboLocationEnum.Blank)
                            {
                                WordTemplateHelper.ReplaceTextWithProperty<ComboLocation>( duplicated, locationKeys,location);

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
                                    if (image!=null && File.Exists(path))
                                    {
                                        var b = new WindowsBitmap(path);
                                         
                                     
                                        image.FeedData( File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                                        // Save this Bitmap back into the document using a Create\Write stream.
                                        //b.Save(img.GetStream(FileMode.Create, FileAccess.Write), System.Drawing.Imaging.ImageFormat.Png);
                                    }
                                }
                                duplicated.Save();
                            }
                            
                            templates.Add( duplicated );
                            streams.Add(stream);
                            //document.InsertDocument(duplicated);
                        }
                        //添加一些基本对象，如段落等
                    }
                   //合并文档

                    WordTemplateHelper.MergeDoc(streams, document);

                    document.Save();//保存

                }

                var trip = db.Trips.Find(TripId);

                trip.word_created_at = DateTime.Now;

                db.SaveChanges();
            }
            return true;
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
