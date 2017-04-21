using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTS.DB
{
    // 餐厅 
    class DiningLocation
    {
        // copy from Model.tt/ComboLocation
        public long id { get; set; }
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

        public string dishes { get; set; }
        public string recommended_dishes { get; set; }
        public string tips { get; set; }


        public string DisplayOpeningHours
        {
            get {
                string display = String.Empty;
                if (open_at != null && close_at != null)
                {                    
                    display = String.Format("{0:HH:mm}-{1:HH:mm}", open_at, close_at);
                }
                return display;
            }
        }
    }
}
