using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTS.Bus
{
    class TripBusiness
    {
        public static void Delete(long tripId)
        {
            using (var ctx = new DctsEntities())
            {
                var trip = ctx.Trips.Find( tripId );

                ctx.Trips.Remove(trip);

                ctx.SaveChanges();
            }
        
        }

        public static void AddLocation(long tripId, int day, long locationId)
        {
            using (var ctx = new DctsEntities())
            {
                int count = ctx.Days.Where(o => o.tripId == tripId && o.day == day).Count();
                var dayModel = ctx.Days.Create();

                dayModel.day = day;
                dayModel.tripId = tripId;
                dayModel.position = count + 1;
                dayModel.locationId = locationId;
                ctx.Days.Add(dayModel);
                ctx.SaveChanges();
            }
                
        }

        public static void DeleteDay(long tripId, int day)
        {
            using (var ctx = new DctsEntities())
            {
                var trip = ctx.Trips.Find(tripId);
                var listByDay = ctx.Days.Where(o => o.tripId == tripId && o.day == day).ToList();

                string sqlFormat = "UPDATE days SET `day`=`day`-1 WHERE `tripId`={0} && `day`>{1}";
                string sql = String.Format(sqlFormat, tripId, day);
                ctx.Days.RemoveRange(listByDay);
                ctx.Database.ExecuteSqlCommand(sql);

                trip.days -= 1;
                ctx.SaveChanges();
            }
        }
    }
}
