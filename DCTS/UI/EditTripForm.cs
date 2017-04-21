using DCTS.CustomComponents;
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
    public partial class EditTripForm : BaseModalForm
    {
        public long TripId { get; set; }
        Trip trip;

        public EditTripForm( long tripId )
        {
            InitializeComponent();
            TripId = tripId;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            this.tripFormControl1.FillModelByForm(this.trip);
            ctx.SaveChanges();
        }

        private void EditTripForm_Load(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;

            this.trip = ctx.Trips.Find(TripId);
            this.tripFormControl1.FillFormByModel(trip);
        }


       
    }
}
