using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DCTS.Bus
{
    class TripBusiness
    {
        public static Trip Duplicate(long trip_id, int customer_id=0)
        {
            Trip clonedTrip = null;
            using (var ctx = new DctsEntities())
            {
                var trip = ctx.Trips.Find(trip_id);
                clonedTrip = new Trip(){ days = trip.days, title = "(复制)"+trip.title, memo = trip.memo };
                clonedTrip.customer_id = customer_id;

                var days = ctx.TripDays.Include("DayLocations").Where(o => o.trip_id == trip.id).ToList();

                var clonedDays = days.Select(o => new TripDay() { day = o.day, title = o.title, memo = o.memo, DayLocations = o.DayLocations.Select(d => new DayLocation() { day = d.day, location_id = d.location_id, position = d.position }).ToList() }).ToList();

                var clonedDayLocations = trip.DayLocations.Select(o => new DayLocation() { day = o.day, location_id = o.location_id, position = o.position }).ToList();
                clonedTrip.TripDays = clonedDays;
                //clonedTrip.DayLocations.Concat(clonedDayLocations);
                ctx.Trips.Add(clonedTrip);
                ctx.SaveChanges();
                //clonedDays.ForEach(delegate(TripDay day) { day.trip_id = clonedTrip.id; });
                //ctx.TripDays.AddRange( clonedDays );
                //ctx.SaveChanges();
            }
            return clonedTrip;
        }

        public static void Delete(long trip_id)
        {
            using (var ctx = new DctsEntities())
            {
                //Include("TripDays").Include("DayLocations")
                var trip = ctx.Trips.Where( o=>o.id == trip_id ).First();

                string sqlRemoveDays = string.Format("DELETE FROM TripDays WHERE TripDays.trip_id={0}", trip_id);
                string sqlRemoveLocations = string.Format("DELETE FROM DayLocations WHERE DayLocations.trip_id={0}", trip_id);
                ctx.Database.ExecuteSqlCommand(sqlRemoveLocations);
                ctx.Database.ExecuteSqlCommand(sqlRemoveDays);
                ctx.Trips.Remove(trip);
                ctx.SaveChanges();
            }
        
        }

        public static DayLocation AddLocation(int day_id, int location_id)
        {
            DayLocation dayLocation = null;

            using (var ctx = new DctsEntities())
            {
                var tripDay = ctx.TripDays.Include("DayLocations").Where( o=> o.id == day_id).First();

                int count = tripDay.DayLocations.Count();

                dayLocation = ctx.DayLocations.Create();

                dayLocation.day_id = day_id;
                dayLocation.trip_id = tripDay.trip_id;
                dayLocation.position = count + 1;
                dayLocation.location_id = location_id;
                ctx.DayLocations.Add(dayLocation);
                ctx.SaveChanges();
            }

            return dayLocation;    
        }
        public static void DeleteDayLocation(long dayId)
        {
            using (var ctx = new DctsEntities())
            {

                var dayModel = ctx.DayLocations.Find(dayId);
                int count = ctx.DayLocations.Where(o => o.day_id == dayModel.day_id).Count();
                // 移動到最後，然後刪除
                UpdateDayLocationPosition(dayId, count);

                ctx.DayLocations.Remove(dayModel);
                ctx.SaveChanges();
            }

        }
        public static void DeleteDay(int dayId)
        {
            using (var ctx = new DctsEntities())
            {
                var tripDay = ctx.TripDays.Include("DayLocations").Where(o => o.id == dayId).First();
                var trip = ctx.Trips.Find(tripDay.trip_id);
                
                // 修正刪除后的排序
                string sqlFormat = "UPDATE TripDays SET `day`=`day`-1 WHERE `trip_id`={0} && `day`>{1}";
                string sql = String.Format(sqlFormat, tripDay.trip_id, tripDay.day);
                ctx.TripDays.Remove(tripDay);
                ctx.Database.ExecuteSqlCommand(sql);

                trip.days -= 1;
                ctx.SaveChanges();
            }
        }


        public static TripDay AddDay(long trip_id, int afterDay = 0)
        {
            TripDay tripDay;

            using (var ctx = new DctsEntities())
            {
                var trip = ctx.Trips.Find(trip_id);

                tripDay = ctx.TripDays.Create();
                tripDay.title = string.Format("第{0}天", afterDay+1);
                tripDay.day = afterDay + 1;
                
                if (afterDay > 0)
                {
                    string sqlFormat = "UPDATE TripDays SET `day`=`day`+1 WHERE `trip_id`={0} && `day`>{1}";
                    string sql = String.Format(sqlFormat, trip_id, afterDay);
                    ctx.Database.ExecuteSqlCommand(sql);
                }
                trip.days += 1;
                trip.TripDays.Add(tripDay);
                ctx.SaveChanges();
            }
            return tripDay;
        }

        public static void MoveDayPosition(long trip_id, int day, int newDay)
        {
            using (var ctx = new DctsEntities())
            {
                var tripDay = ctx.TripDays.Where(o => o.trip_id == trip_id && o.day == day).First();

                if (day < newDay) // move down
                {
                    string sqlFormat = "UPDATE TripDays SET `day`=`day`-1 WHERE `trip_id`={0} &&  `day`> {1} && `day`<= {2}";
                    string sql = String.Format(sqlFormat, trip_id, day, newDay);
                    ctx.Database.ExecuteSqlCommand(sql);
                }
                else
                { // move up
                    string sqlFormat = "UPDATE TripDays SET `day`=`day`+1 WHERE `trip_id`={0} &&  `day`>= {1} && `day`< {2}";
                    string sql = String.Format(sqlFormat, trip_id, newDay, day );
                    ctx.Database.ExecuteSqlCommand(sql);
                }


                tripDay.day = newDay;
                
                ctx.SaveChanges();

            }
        }

        public static void UpdateDayLocationPosition(long dayId, int position)
        {
            using (var ctx = new DctsEntities())
            {
                var dayLocation = ctx.DayLocations.Find(dayId);
                if (dayLocation.position < position) // move down
                {
                    string sqlFormat = "UPDATE DayLocations SET `position`=`position`-1 WHERE `day_id`={0} && `position`> {1} && `position`<= {2}";
                    string sql = String.Format(sqlFormat, dayLocation.day_id, dayLocation.position, position);
                    ctx.Database.ExecuteSqlCommand(sql);
                }
                else { // move up
                    string sqlFormat = "UPDATE DayLocations SET `position`=`position`+1 WHERE `day_id`={0} && `position`>= {1} && `position`< {2}";
                    string sql = String.Format(sqlFormat, dayLocation.day_id, position, dayLocation.position);
                    ctx.Database.ExecuteSqlCommand(sql);
                }
                dayLocation.position = position;
                ctx.SaveChanges();

            }
        }
    }
}
