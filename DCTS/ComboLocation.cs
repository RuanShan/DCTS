//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DCTS
{
    using System;
    using System.Collections.Generic;
    
    public partial class ComboLocation
    {
        public ComboLocation()
        {
            this.img = "\"\"";
            this.DayLocations = new HashSet<DayLocation>();
        }
    
        public int id { get; set; }
        public int ltype { get; set; }
        public string nation { get; set; }
        public string city { get; set; }
        public string area { get; set; }
        public string title { get; set; }
        public string local_title { get; set; }
        public string img { get; set; }
        public string address { get; set; }
        public string local_address { get; set; }
        public string latlng { get; set; }
        public string route { get; set; }
        public string contact { get; set; }
        public Nullable<System.DateTime> open_at { get; set; }
        public Nullable<System.DateTime> close_at { get; set; }
        public string ticket { get; set; }
        public string room { get; set; }
        public string dinner { get; set; }
        public string wifi { get; set; }
        public string parking { get; set; }
        public string reception { get; set; }
        public string kitchen { get; set; }
        public string dishes { get; set; }
        public string recommended_dishes { get; set; }
        public string tips { get; set; }
        public string open_close_more { get; set; }
    
        public virtual ICollection<DayLocation> DayLocations { get; set; }
    }
}
