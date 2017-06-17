using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTS.DB
{
    class FlightTicket
    {
        public int customer_id { get; set; }
        public int supplier_id { get; set; }
        public string num { get; set; }
        public DateTime start_at { get; set; }
        public DateTime end_at { get; set; }
        public int from_airport_id { get; set; }
        public int to_airport_id { get; set; } 
    }
}
