using DCTS.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTS.Bus
{
    class WordTemplateHelper
    {
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

        public static string DisplayDayLocations(List<DayLocation> locations)
        {
            var titles = locations.Select(o => o.ComboLocation.title).Distinct().ToArray();

            return string.Join("|", titles);
        }
        public static string DisplayDayHotel(List<DayLocation> locations)
        {
            var titles = locations.Where(o=>o.ComboLocation.ltype == (int) ComboLocationEnum.Hotel).Select(o => o.ComboLocation.title).Distinct().ToArray();

            return string.Join("|", titles);
        }        
    }
}
