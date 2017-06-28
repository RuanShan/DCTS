using DCTS.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTS.Bus
{

    class TicketBusiness
    {
        public static Ticket FillTitle(Ticket ticket, List<ComboLocation> relatedLocations)
        {
            //改进 票务标题，生成doc时使用 “大连-广州 CZ3607 1500-1845”
            if (ticket.ttype == (int)SupplierEnum.Flight)
            {
                var fromAirport = relatedLocations.FirstOrDefault(o => o.id == ticket.from_location_id);
                var toAirport = relatedLocations.FirstOrDefault(o => o.id == ticket.to_location_id);
                if ((fromAirport != null) && (toAirport != null))
                {
                    ticket.title = string.Format("{0}-{1} {2} {3:HHmm}-{4:HHmm}", fromAirport.city, toAirport.city, ticket.num, ticket.start_at, ticket.end_at);
                }
            }
            return ticket;
        }
    }

  
}
