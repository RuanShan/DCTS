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
    
    public partial class Ticket
    {
        public int id { get; set; }
        public int daylocation_id { get; set; }
        public int customer_id { get; set; }
        public int supplier_id { get; set; }
        public string num { get; set; }
        public string route { get; set; }
        public string memo { get; set; }
        public string requirement { get; set; }
        public string service_no { get; set; }
        public Nullable<bool> overlay { get; set; }
        public Nullable<System.DateTime> start_at { get; set; }
        public Nullable<System.DateTime> end_at { get; set; }
        public string from_place { get; set; }
        public string to_place { get; set; }
        public string rules { get; set; }
        public string title { get; set; }
        public int days { get; set; }
        public string breakfirst { get; set; }
        public string parking { get; set; }
        public string baggage_weight_limit { get; set; }
        public int trip_id { get; set; }
        public int overlay_sign { get; set; }
        public int from_location_id { get; set; }
        public int to_location_id { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public int ttype { get; set; }
        public string city { get; set; }
        public string room { get; set; }
        public string from_address { get; set; }
        public string to_address { get; set; }
        public string from_latlng { get; set; }
        public string to_latlng { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
