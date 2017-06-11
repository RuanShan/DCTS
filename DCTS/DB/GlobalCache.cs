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
        static DctsEntities db = new DctsEntities();

        public static List<Nation> NationList
        {
            get
            {
                if (nationList == null)
                { InitializeNationList(); }

                return nationList;
            }
        }

        public static List<City> CityList
        {
            get
            {
                if (cityList == null)
                { InitializeCityList(); }

                return cityList;
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
                    new MockEntity{ Id = (int)SupplierEnum.Air, ShortName="航空公司", FullName = "航空公司" },
                    new MockEntity{ Id = (int)SupplierEnum.Insurance,ShortName="保险公司", FullName = "保险公司" },
                    new MockEntity{ Id = (int)SupplierEnum.Rental, ShortName="租车公司",FullName = "租车公司" },
                    new MockEntity{ Id = (int)SupplierEnum.WIFI, ShortName="WIFI",FullName = "WIFI" },
                
                }.ToList());
            }
        }
        private static void InitializeNationList()
        {
            nationList = db.Nations.ToList();
        }
        private static void InitializeCityList()
        {
            cityList = db.Cities.ToList();
        }
    }


}
