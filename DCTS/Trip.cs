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
    
    public partial class Trip
    {
        public Trip()
        {
            this.TripDays = new HashSet<Day>();
        }
    
        public long id { get; set; }
        public string title { get; set; }
        public string memo { get; set; }
        public int days { get; set; }
        public Nullable<System.DateTime> word_created_at { get; set; }
    
        public virtual ICollection<Day> TripDays { get; set; }
    }
}
