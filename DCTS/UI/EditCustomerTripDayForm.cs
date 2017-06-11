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
    public partial class EditCustomerTripDayForm : BaseModalForm
    {
        public long ModelId { get; set; }
        TripDay model;

        public EditCustomerTripDayForm(long id)
        {
            InitializeComponent();
            ModelId = id;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            //this.tripDayFormControl1.FillModelByForm(this.model);
            ctx.SaveChanges();
        }

        private void EditTripForm_Load(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            this.model = ctx.TripDays.Find(ModelId);
            //this.tripDayFormControl1.FillFormByModel(this.model);
        }


       
    }
}
