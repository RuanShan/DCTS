using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTS.Bus
{
    class TripDbHelper
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
    }
}
