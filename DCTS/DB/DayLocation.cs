using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTS.DB
{
    class DayLocation
    {
        public long dayId {get; set;}
        public int ltype { get; set; }
    
        public long locationId {get; set;}
        public int position {get; set;}
        public string title {get; set;}
    }
}
