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
    public partial class TripDayFormControl : UserControl
    {
        public TripDayFormControl()
        {
            InitializeComponent();
        }

        public void FillModelByForm(TripDay trip)
        {
            trip.title = this.titleTextBox.Text;

            trip.tips = this.tipsTextBox.Text;

            trip.schedule = this.scheduleTextBox.Text;
        }

        public void FillFormByModel(TripDay trip)
        {

            this.titleTextBox.Text = trip.title;
            this.tipsTextBox.Text = trip.tips;
            this.scheduleTextBox.Text = trip.schedule;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TripDayFormControl_Load(object sender, EventArgs e)
        {

        }
    }
}
