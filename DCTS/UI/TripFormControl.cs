using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCTS.UI
{
    public partial class TripFormControl : UserControl
    {
        public TripFormControl()
        {
            InitializeComponent();
        }

        public void FillModelByForm(Trip trip)
        {
            trip.title = this.titleTextBox.Text;
            trip.days = Convert.ToInt32(this.daysNumericUpDown.Value);

            trip.memo = this.memoTextBox.Text;             
        }

        public void FillFormByModel(Trip trip)
        {

            this.titleTextBox.Text = trip.title;
            this.daysNumericUpDown.Value = trip.days;
            this.memoTextBox.Text = trip.memo;
        }
    }
}
