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
        public static string DataBasePath
        {
            get {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
                CreateFolder(path);
                return path;                
            }
        }

        public static string ImageBasePath
        {
            get {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "images");
                CreateFolder(path);
                return path;                
            }
        }

        public static string ScenicLocationImageBasePath
        {
            get {
                string path = Path.Combine( ImageBasePath, "location_" + ComboLocationEnum.Scenic.ToString().ToLower());
                CreateFolder(path);
                return path;
            }
        }

        public static string DiningLocationImageBasePath
        {
            get
            {
                string path = Path.Combine(ImageBasePath, "location_" + ComboLocationEnum.Dining.ToString().ToLower());
                CreateFolder(path);
                return path;
            }
        }

        public static string HotelLocationImageBasePath
        {
            get
            {
                string path = Path.Combine(ImageBasePath, "location_" + ComboLocationEnum.Hotel.ToString().ToLower());
                CreateFolder(path);
                return path;
            }
        }

        public  static string LocationImagePath( ComboLocation location )
        {
            string basePath = ScenicLocationImageBasePath;
            string folderPath = Path.Combine(basePath, (location.id / 1000 * 1000).ToString());

            CreateFolder(folderPath);

            string fullPath = Path.Combine(folderPath, location.img);

            return fullPath;
        }
        public static string LocationDiningImagePath(ComboLocation location)
        {
            string basePath = DiningLocationImageBasePath;
            string folderPath = Path.Combine(basePath, (location.id / 1000 * 1000).ToString());

            CreateFolder(folderPath);

            string fullPath = Path.Combine(folderPath, location.img);

            return fullPath;
        }
        public static string LocationHotelImagePath(ComboLocation location)
        {
            string basePath = DiningLocationImageBasePath;
            string folderPath = Path.Combine(basePath, (location.id / 1000 * 1000).ToString());

            CreateFolder(folderPath);

            string fullPath = Path.Combine(folderPath, location.img);

            return fullPath;
        }
        public static string TripWordFolderPath(long tripId)
        {
            
            string basePath = @"data\export\words";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, basePath, (tripId / 1000).ToString());
            CreateFolder(path);
            return path;
        }

        public static string TripWordFilePath(long tripId)
        { 
            return Path.Combine(TripWordFolderPath(tripId), string.Format("{0}.docx", tripId));
        }

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
