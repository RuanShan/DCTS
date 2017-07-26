using DCTS.DB;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTS.Bus
{
    class WordTemplateHelper
    {
        //https://blogs.msdn.microsoft.com/ericwhite/2008/10/26/how-to-use-altchunk-for-document-assembly/
        //https://stackoverflow.com/questions/11615774/merge-multiple-word-documents-into-one-using-openxml-and-xelement
        public static void MergeDoc(List<MemoryStream> streams, WordprocessingDocument destination)
        {

                    MainDocumentPart mainPart = destination.MainDocumentPart;

                    for (int i = 0; i < streams.Count; i++)
                    {
                        string altChunkId = "AltChunkId" + i;
                        var stream = streams[i];
                        var chunk = mainPart.AddAlternativeFormatImportPart(
                            AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                        stream.Seek(0, SeekOrigin.Begin);
                        chunk.FeedData(stream);
                        
                        AltChunk altChunk = new DocumentFormat.OpenXml.Wordprocessing.AltChunk();
                        altChunk.Id = altChunkId;
                        //new page
                        if (i > 0)
                        {
                            mainPart.Document.Body.AppendChild(new Paragraph(new Run(new Break() { Type = BreakValues.Page })));
                        }
                        //next document
                        mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<Paragraph>().Last());
                    }
                    mainPart.Document.Save();

        }

        public static void AddPageBreak(WordprocessingDocument document)
        {
            //https://stackoverflow.com/questions/2795315/create-page-break-using-openxml
            Paragraph pageBreakParagraph = new Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Break() { Type = BreakValues.Page }));

            document.MainDocumentPart.Document.Body.Append(pageBreakParagraph);
        }

        // return relid
        public static string InsertPicture(WordprocessingDocument document, string fileName)
        {

            MainDocumentPart mainPart = document.MainDocumentPart;

            ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);

            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                imagePart.FeedData(stream);
            }

            return mainPart.GetIdOfPart(imagePart);
        }

        public static void ReplaceText(WordprocessingDocument doc, string key, string val)
        {
            var body = doc.MainDocumentPart.Document.Body;
            foreach (var text in body.Descendants<Text>())
            {
                if (text.Text.Contains(key))
                {
                    text.Text = text.Text.Replace(key, val);
                    break;
                }
            }
        }

        public static void ReplaceText<T>(T node, string key, string val) where T : OpenXmlElement
        {
            if (val == null)
            {
                val = string.Empty;
            }
            foreach (var text in node.Descendants<Text>())
            {
                if (text.Text.Contains(key))
                {
                    text.Text = text.Text.Replace(key, val);
                    break;
                }
            }
        }

        public static void ReplaceText<T>(T node, string key, IEnumerable<string> lines) where T : OpenXmlElement
        {
             
            foreach (var run in node.Descendants<Run>())
            {
                if (run.InnerText.Contains(key))
                {
                    int i = 0;
                    foreach (var line in lines)
                    {
                        var cloned = run.CloneNode(true) as Run;
                        WordTemplateHelper.ReplaceText<Run>(cloned, key, line);

                        if (i > 0)
                        {
                            run.InsertBeforeSelf(  (new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Break() { Type = BreakValues.TextWrapping })));
                        }
                        run.InsertBeforeSelf(cloned);
                        i++;
                    }
                    if (i > 0)
                    {
                        run.Remove();
                    }

                    break;
                }
            }
        }

        //Open Xml SDK Word模板开发最佳实践(Best Practice)
        //http://www.cnblogs.com/pengzhen/p/3823980.html?utm_source=tuicool&utm_medium=referral
        public static void ReplaceTextWithProperty<T>( WordprocessingDocument doc, string[] keys, T entity)
        {
            var body = doc.MainDocumentPart.Document.Body;
            var type = entity.GetType();
            string entityName = type.BaseType.Name.ToLower();
            // combolocation 太长了， 省略
            string prefix = entityName == "combolocation" ? string.Empty : (entityName + "_");
            //Trip => trip
            foreach (string key in keys)
            {
                var val = type.GetProperty(key).GetValue(entity);
                string s = val == null ? string.Empty : val.ToString();

                string wrappedKey = "%" + prefix + key + "%";

                WordTemplateHelper.ReplaceText(doc, wrappedKey, s);

            }
        }

        //https://www.codeproject.com/articles/187928/imageupdater
        /// <summary>
        /// Updates the image in an image placeholder
        /// </summary>
        /// <param name="placeholderName">Image placeholder tag name</param>
        /// <param name="newImage">physical path to the new image file</param>
        public static void UpdateImage(WordprocessingDocument doc, string imageRelID, string newImage)
        {
            // Get the id of the image placeholder
            string relId = imageRelID;

            // Get the Imagepart
            ImagePart imagePart = (ImagePart)doc.MainDocumentPart.GetPartById(relId);

            imagePart.FeedData(File.Open(newImage, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));

        }
        //上面的代码用于在某个 sdt 元素下面查找匹配内容控件ID所使用的图像资源id。然后我们根据该资源id来获取placeholder image的大小：
        internal static void GetPlaceholderImageSize(WordprocessingDocument doc, string relID, out int width, out int height)
        {
            width = -1;
            height = -1;

            // Loop through all Drawing elements in the document
            foreach (Drawing d in doc.MainDocumentPart.Document.Descendants<Drawing>().ToList())
            {
                // Loop through all the pictures (Blip) in the document
                if (d.Descendants<DocumentFormat.OpenXml.Drawing.Blip>().ToList().Any(b => b.Embed.ToString() == relID))
                {
                    // The document size is in EMU. 1 pixel = 9525 EMU

                    // The size of the image placeholder is located in the EXTENT element
                    Extent e = d.Descendants<Extent>().FirstOrDefault();
                    if (null != e)
                    {
                        width = (int)(e.Cx / 9525);
                        height = (int)(e.Cy / 9525);
                    }

                    if (width == -1)
                    {
                        // The size of the image is located in the EXTENTS element
                        var e2 = d.Descendants<DocumentFormat.OpenXml.Drawing.Extents>().FirstOrDefault();
                        if (null != e2)
                        {
                            width = (int)(e2.Cx / 9525);
                            height = (int)(e2.Cy / 9525);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Resize the image in an image placeholder
        /// </summary>
        /// <param name="placeholderName">Image placeholder tag name</param>
        /// <param name="newImage">physical path to the new image file</param>
        /// <param name="resizeMode">调整图片尺寸模式 1.保持宽度，保持比例，2.保持高度，保持比例</param>
        public static void ResizeImage(WordprocessingDocument doc, string imageRelID, string newImage, int resizeMode = 1)
        {
            // Get the id of the image placeholder
            string relID = imageRelID;

            // Load the new image into a bitmap object
            Bitmap bitmap = new Bitmap(newImage);
            Image img = bitmap;
            int width = 0; int height = 0;
            GetPlaceholderImageSize(doc, imageRelID, out width, out height);
            float newWidth = width; //宽度保持一致
            float newHeight = newWidth*img.Height / img.Width ;    //设置高度保持比例
            if (resizeMode == 2)
            { 
            }

            // Loop through all Drawing elements in the document
            foreach (Drawing d in doc.MainDocumentPart.Document.Descendants<Drawing>().ToList())
            {
                // Loop through all the pictures (Blip) in the document
                foreach (var b in d.Descendants<DocumentFormat.OpenXml.Drawing.Blip>().ToList())
                {
                    // Have we found the correct pciture?
                    if (b.Embed.ToString() == relID)
                    {
                        // Yes we have

                        // The size of the image placeholder is located in the EXTENT element
                        Extent e = d.Descendants<Extent>().FirstOrDefault();

                        // The document expects the size in EMU. 1 pixel = 9525 EMU
                        long imageWidthEMU = (long)(newWidth * 9525);
                        long imageHeightEMU = (long)(newHeight * 9525);

                        // change the size of the image placeholder
                        e.Cx = imageWidthEMU;
                        e.Cy = imageHeightEMU;


                        // The size of the image is located in the EXTENTS element
                        var e2 = d.Descendants<DocumentFormat.OpenXml.Drawing.Extents>().FirstOrDefault();

                        // change the size of the image itself
                        e2.Cx = imageWidthEMU;
                        e2.Cy = imageHeightEMU;

                        break;
                        // save the changes
                        //mainDocPart.Document.Save();
                    }
                }
            }
        }

        public static string DisplayOpeningHours(ComboLocation location)
        {
            string str = string.Empty;
            if (location.open_at != null && location.close_at != null)
            {
                str = String.Format("{0:HH:mm}-{1:HH:mm}", location.open_at, location.close_at);
            }

            return str;
        }

        public static string DisplayStartAndEndDate(Trip trip)
        {
            string str = string.Empty;
            if (trip.start_at != null )
            {
                var end_at = trip.start_at.Value.AddDays(trip.days - 1);
                //2017年6月1日~6月15日                
                str = String.Format("{0:yyyy年M月d日}~{1:M月d日}", trip.start_at, end_at);
            }

            return str;
        }

        public static string DisplayStartAndEndDate(Ticket ticket)
        {
            string str = string.Empty;
            if (ticket.start_at != null)
            {
                var end_at = ticket.start_at.GetValueOrDefault(DateTime.Now).AddDays(ticket.days - 1);
                //2017.06.07-06.09            
                str = String.Format("{0:yyyy.MM.dd}~{1:MM.dd}", ticket.start_at, end_at);
            }

            return str;
        }

        public static string DisplayDayCities( List<DayLocation> locations)
        {
            var cities = locations.Select(o => o.ComboLocation.city).Distinct().ToArray();

            return string.Join("|",cities);
        }

        public static string DisplayDayLocations(List<DayLocation> locations, string seperator="|")
        {
            var titles = locations.Select(o => o.ComboLocation).Where(o=>o.ltype != (int) ComboLocationEnum.Blank).Select(o=>o.title).Distinct().ToArray();

            return string.Join("|", titles);
        }
        public static string DisplayDayHotel(List<DayLocation> locations)
        {
            var titles = locations.Where(o=>o.ComboLocation.ltype == (int) ComboLocationEnum.Hotel).Select(o => o.ComboLocation.title).Distinct().ToArray();

            return string.Join("|", titles);
        }

        public static string DisplayLongWeekDay(DateTime date)
        {
            return String.Format("{0:dddd}", date);
        }
        public static string DisplayDate(DateTime date)
        {
            return String.Format("{0:yyyy年MM月dd日}", date);
        }
        public static string DisplayTime(DateTime time)
        {
            return String.Format("{0:HH:mm}", time);
        }

        
    }
}
