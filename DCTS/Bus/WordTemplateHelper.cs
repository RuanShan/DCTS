using DCTS.DB;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
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

        public static void ReplaceText(WordprocessingDocument doc, string key, string val)
        {
            var body = doc.MainDocumentPart.Document.Body;
            foreach (var text in body.Descendants<Text>())
            {
                if (text.Text.Contains(key))
                {
                    text.Text = text.Text.Replace(key, val);
                }
            }
        }

        public static void ReplaceText<T>(T node, string key, string val) where T : OpenXmlElement
        {

            foreach (var text in node.Descendants<Text>())
            {
                if (text.Text.Contains(key))
                {
                    text.Text = text.Text.Replace(key, val);
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


        public static string DisplayOpeningHours(ComboLocation location)
        {
            string str = string.Empty;
            if (location.open_at != null && location.close_at != null)
            {
                str = String.Format("{0:HH:mm}-{1:HH:mm}", location.open_at, location.close_at);
            }

            return str;
        }

        public static string DisplayStartAndEndTime(Trip trip)
        {
            string str = string.Empty;
            if (trip.start_at != null && trip.end_at != null)
            {
                //2017年6月1日~6月15日                
                str = String.Format("{0:yyyy年M月d日}~{1:M月d日}", trip.start_at, trip.end_at);
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

        
    }
}
