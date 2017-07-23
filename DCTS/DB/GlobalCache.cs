using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DCTS.DB
{
    public class GlobalCache
    {
        static List<Nation> nationList = null;
        static List<City> cityList = null;
        static ComboLocation flightLocation = null;
        static ComboLocation rentalLocation = null;
        static ComboLocation trainLocation = null;

        public static List<Nation> NationList
        {
            get
            {
                // 暂时不要緩存，用戶可能随时添加
                { InitializeNationList(); }

                return nationList;
            }
        }

        public static List<City> CityList
        {
            get
            {
                // 暂时不要緩存，用戶可能随时添加
                { InitializeCityList(); }

                return cityList;
            }
        }

        public static ComboLocation FlightLocation
        {
            get
            {
                if (flightLocation == null)
                { InitializeLocations(); }
                return flightLocation;
            }
        }
        public static ComboLocation RentalLocation
        {
            get
            {
                if (rentalLocation == null)
                { InitializeLocations(); }
                return rentalLocation;
            }
        }
        public static ComboLocation TrainLocation
        {
            get
            {
                if (trainLocation == null)
                { InitializeLocations(); }
                return trainLocation;
            }
        }

        public static List<MockEntity> LocationTypeList
        {
            get
            {
                return (new[]{ 
                    new MockEntity{ Id = (int)ComboLocationEnum.Blank, ShortName="空白页", FullName = "空白页" },
                    new MockEntity{ Id = (int)ComboLocationEnum.Scenic,ShortName="景点", FullName = "景点" },
                    new MockEntity{ Id = (int)ComboLocationEnum.Hotel, ShortName="住宿",FullName = "住宿" },
                    new MockEntity{ Id = (int)ComboLocationEnum.Dining, ShortName="餐厅",FullName = "餐厅" },
                    new MockEntity{ Id = (int)ComboLocationEnum.Airport, ShortName="机场",FullName = "机场" },
                }.ToList());
            }
        }
        public static List<MockEntity> Supplier_LocationTypeList
        {
            get
            {
            
                return (new[]{ 
                    new MockEntity{ Id = (int)SupplierEnum.Flight, ShortName="航空公司", FullName = "航空公司" },
                    new MockEntity{ Id = (int)SupplierEnum.Train,ShortName="交通公司", FullName = "交通公司" },
                    new MockEntity{ Id = (int)SupplierEnum.Insurance,ShortName="保险公司", FullName = "保险公司" },
                    new MockEntity{ Id = (int)SupplierEnum.Rental, ShortName="租车公司",FullName = "租车公司" },
                    new MockEntity{ Id = (int)SupplierEnum.WIFI, ShortName="WIFI",FullName = "WIFI" },
                
                }.ToList());
            }
        }

        private static void InitializeNationList()
        {
            // remove staic db, it cause error No connection string named 'DctsEntities' could be found in the application config file. 
            using (var db = new DctsEntities())
            {
                var nations = db.ComboLocations.Where(o => o.nation != null).Select(o => o.nation).Distinct().ToList();
                nationList = nations.Select(o => new Nation() { title = o, code = o }).ToList();
            }
        }
        private static void InitializeCityList()
        {
            using (var db = new DctsEntities())
            {
                var cities = db.ComboLocations.Where(o => o.nation != null && o.city != null && o.city != string.Empty).Select(o => new { o.city, o.nation }).Distinct().ToList();
                cityList = cities.Select(o => new City() { title = o.city, nationCode = o.nation }).ToList();
            }
        }

        private static void InitializeLocations()
        {
            using (var db = new DctsEntities())
            {
                flightLocation = db.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Flight).First();
                rentalLocation = db.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Rental).First();
                trainLocation = db.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Train).First();
            }
        }

    }


}
