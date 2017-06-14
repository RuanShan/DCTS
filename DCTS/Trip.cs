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
            this.DayLocations = new HashSet<DayLocation>();
            this.TripDays = new HashSet<TripDay>();
            this.TripCustomers = new HashSet<TripCustomer>();
        }
    
        public int id { get; set; }
        public string title { get; set; }
        public string memo { get; set; }
        public int days { get; set; }
        public Nullable<System.DateTime> word_created_at { get; set; }
        public int customer_id { get; set; }
        public Nullable<System.DateTime> start_at { get; set; }
        public Nullable<System.DateTime> end_at { get; set; }
        public int cover_id { get; set; }
    
        public virtual ICollection<DayLocation> DayLocations { get; set; }
        public virtual ICollection<TripDay> TripDays { get; set; }
        public virtual ICollection<TripCustomer> TripCustomers { get; set; }
    }
}
