using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTS.DB
{
    // join DayLocation + ComboLocation
    class DayLocationView
    {
        // DayLocation.id
        public int id {get; set;} 
        public int ltype { get; set; }
    
        public int location_id {get; set;}
        public int position {get; set;}
        public string title { get; set; }
        public DateTime? start_at { get; set; }
    }
}
