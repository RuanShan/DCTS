﻿using System;
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


        public static void AddDay(long tripId, int afterDay=0)
        {
            using (var ctx = new DctsEntities())
            {
                var trip = ctx.Trips.Find(tripId);

                if (afterDay > 0)
                {
                    string sqlFormat = "UPDATE days SET `day`=`day`+1 WHERE `tripId`={0} && `day`>{1}";
                    string sql = String.Format(sqlFormat, tripId, afterDay);
                    ctx.Database.ExecuteSqlCommand(sql);
                }
                trip.days += 1;
                ctx.SaveChanges();
            }
        }

        public static void UpdateDayLocationPosition(long dayId, int position)
        {
            using (var ctx = new DctsEntities())
            {
                var day = ctx.Days.Find(dayId);
                if (day.position < position) // move down
                {
                    string sqlFormat = "UPDATE days SET `position`=`position`-1 WHERE `tripId`={0} && `day`={1} && `position`> {2} && `position`<= {3}";
                    string sql = String.Format(sqlFormat, day.tripId, day.day, day.position, position);
                    ctx.Database.ExecuteSqlCommand(sql);
                }
                else { // move up
                    string sqlFormat = "UPDATE days SET `position`=`position`+1 WHERE `tripId`={0} && `day`={1} && `position`>= {2} && `position`< {3}";
                    string sql = String.Format(sqlFormat, day.tripId, day.day, position, day.position);
                    ctx.Database.ExecuteSqlCommand(sql);
                }
                day.position = position;
                ctx.SaveChanges();

            }
        }
    }
}
