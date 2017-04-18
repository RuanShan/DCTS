using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTS.DB
{
    class EntityPathConfig
    {
        private static void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }

    public class LocationTemplate
    {
        public static string TemplatePath = "templates";

        public static string DinningDetailName = "dining-detail.docx";
        public static string ScenicDetailName = "scenic-detail.docx";
        public static string HotelDetailName = "hotel-detail.docx";

        public static string DinningDetailRelativePath { 
            get {
                CreateFolder(TemplatePath);
                string path = Path.Combine(TemplatePath, DinningDetailName);
                return path;
            } 
        }
        public static string ScenicDetailRelativePath { 
            get {
                CreateFolder(TemplatePath);
                string path = Path.Combine(TemplatePath, ScenicDetailName);
                return path;                 
            } 
        }
        public static string HotelDetailRelativePath { 
            get {
                CreateFolder(TemplatePath);
                string path = Path.Combine(TemplatePath, HotelDetailName); 
                return path;                     
            } 
        }


        private static void CreateFolder( string path )
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
