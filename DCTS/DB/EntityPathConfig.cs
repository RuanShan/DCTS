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
            get
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
                CreateFolder(path);
                return path;
            }
        }

        public static string WordBasePath
        {
            get
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "words");
                CreateFolder(path);
                return path;
            }
        }
        public static string LocationWordBasePath(ComboLocation location)
        {
            ComboLocationEnum type = (ComboLocationEnum)location.ltype;
            string path = Path.Combine(WordBasePath, "location_" + type.ToString().ToLower());
            CreateFolder(path);
            return path;
        }


        public static string LocationWordPath(ComboLocation location)
        {

            string basePath = LocationWordBasePath(location);
            string folderPath = Path.Combine(basePath, (location.id / 1000 * 1000).ToString());

            CreateFolder(folderPath);

            string fullPath = Path.Combine(folderPath, location.word);

            return fullPath;
        }


        public static string ImageBasePath
        {
            get
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "images");
                CreateFolder(path);
                return path;
            }
        }


        public static string LocationImageBasePath(ComboLocation location)
        {
            ComboLocationEnum type = (ComboLocationEnum)location.ltype;
            string path = Path.Combine(ImageBasePath, "location_" + type.ToString().ToLower());
            CreateFolder(path);
            return path;
        }
        public static string newlocationimagebasepath(LocationImage location)
        {
          //  ComboLocationEnum type = (ComboLocationEnum)location.location_id;
            ComboLocationEnum type = ComboLocationEnum.PageImage;

            string path = Path.Combine(ImageBasePath, "location_" + type.ToString().ToLower());
            CreateFolder(path);
            return path;
        }


        public static string LocationImagePath(ComboLocation location)
        {

            string basePath = LocationImageBasePath(location);
            string folderPath = Path.Combine(basePath, (location.id / 1000 * 1000).ToString());

            CreateFolder(folderPath);

            string fullPath = Path.Combine(folderPath, location.img);

            return fullPath;
        }
        public static string newlocationimagepath(LocationImage location)
        {

            string basePath = newlocationimagebasepath(location);
            string folderPath = Path.Combine(basePath, (location.id / 1000 * 1000).ToString());

            CreateFolder(folderPath);

            string fullPath = Path.Combine(folderPath, location.name);

            return fullPath;
        }
        public static string Supplier_LocationImagePath(Supplier location)
        {

            string basePath = Supplier_LocationImageBasePath(location);
            string folderPath = Path.Combine(basePath, (location.id / 1000 * 1000).ToString());

            CreateFolder(folderPath);

            string fullPath = Path.Combine(folderPath, location.img);

            return fullPath;
        }
        public static string Supplier_LocationImageBasePath(Supplier location)
        {
            SupplierEnum type = (SupplierEnum)location.stype;
            string path = Path.Combine(ImageBasePath, "location_" + type.ToString().ToLower());
            CreateFolder(path);
            return path;
        }



        public static string TripWordFolderPath(long tripId)
        {

            string basePath = @"data\export\words";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, basePath, (tripId / 1000).ToString());
            CreateFolder(path);
            return path;
        }

        public static string TripWordFilePath(long tripId, string style = "")
        {
            return Path.Combine(TripWordFolderPath(tripId), string.Format("{0}{1}.docx", tripId, style));
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

        public static string LayoutlName = "layout.docx";
        public static string DinningDetailName = "dining-detail.docx";
        public static string ScenicDetailName = "scenic-detail.docx";
        public static string HotelDetailName = "hotel-detail.docx";
        public static string TripSumaryName = "trip-summary.docx";
        public static string DaySumaryName = "day-summary.docx";


        public static string GetPath(ComboLocation location)
        {
            ComboLocationEnum type = (ComboLocationEnum)location.ltype;
            if (location.word != null)
            {
                string path = EntityPathConfig.LocationWordPath(location);
                if( File.Exists( path ))
                {
                    return path;
                }
            }

            return GetPath(type);

        }
        public static string GetPath(ComboLocationEnum type)
        {
            string name = BuildTemplateNameByLocationType(type);
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TemplatePath, name);
        }

        public static string LayoutRelativePath
        {
            get
            {
                string path = Path.Combine(TemplatePath, LayoutlName);
                return path;
            }
        }
        public static string TripSumaryRelativePath
        {
            get
            {
                return Path.Combine(TemplatePath, TripSumaryName);
            }
        }
        public static string TripSumaryPath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TripSumaryRelativePath);
            }
        }

        public static string DaySumaryRelativePath
        {
            get
            {
                return Path.Combine(TemplatePath, DaySumaryName);
            }
        }

        public static string DaySumaryPath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DaySumaryRelativePath);
            }
        }


        public static string DinningDetailRelativePath
        {
            get
            {
                return Path.Combine(TemplatePath, DinningDetailName);
            }
        }

        public static string DinningDetailPath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DinningDetailRelativePath);
            }
        }

        public static string ScenicDetailRelativePath
        {
            get
            {
                return Path.Combine(TemplatePath, ScenicDetailName);
            }
        }

        public static string ScenicDetailPath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ScenicDetailRelativePath);
            }
        }

        public static string HotelDetailRelativePath
        {
            get
            {
                return Path.Combine(TemplatePath, HotelDetailName);
            }
        }

        public static string HotelDetailPath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, HotelDetailRelativePath);
            }
        }

        private static void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private static string BuildTemplateNameByLocationType(ComboLocationEnum type)
        {
            return "location_" + type.ToString().ToLower() + ".docx";

        }
    }

    public class SqlPath
    {

        public static string BasePath
        {
            get
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sql");
                return path;
            }
        }

        public static string SetupSql
        {
            get
            {
                return Path.Combine(BasePath, "setup.sql");
            }
        }
        public static string SeedSql
        {
            get
            {
                return Path.Combine(BasePath, "seed.sql");
            }
        }
    }
}
