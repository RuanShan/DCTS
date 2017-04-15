﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private static void InitializeNationList()
        {
            nationList = db.Nations.Where(o => o.enabled).ToList();        
        }
        private static void InitializeCityList()
        {
            cityList = db.Cities.Where(o => o.enabled).ToList();
        }
    }
}