using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCTS.UI
{
    public partial class NewCusotmerTripForm : BaseModalForm
    {

        public NewCusotmerTripForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            using (var ctx = new DctsEntities())
            {

                var trip = new Trip();
               

                
                for( int i=0; i<trip.days;i++)
                {
                    var tripDay = new TripDay();
                    tripDay.day = i + 1;
                    tripDay.title = String.Format("第{0}天", i + 1);
                    trip.TripDays.Add(tripDay);
                    //ctx.TripDays.Add(tripDay);
                }
                ctx.Trips.Add(trip);
                ctx.SaveChanges();
            }
        }
    }
}
