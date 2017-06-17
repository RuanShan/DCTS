using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCTS.CustomComponents;
using DCTS.DB;

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

            using (var ctx = new DctsEntities())
            {
                var location = ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.PageImage).First();

                var query = ctx.LocationImages.Where(o => o.location_id == (int)location.id && o.name == imgPathTextBox.Text);
                List<LocationImage> list = query.ToList();
                trip.cover_id = list[0].id;
            }
        }

        public void FillFormByModel(Trip trip)
        {

            this.titleTextBox.Text = trip.title;
            this.daysNumericUpDown.Value = trip.days;
            this.memoTextBox.Text = trip.memo;
            //读取图片位置
            using (var ctx = new DctsEntities())
            {
                var query = ctx.LocationImages.Where(o => o.id == trip.cover_id);
                if (query.Count() > 0)
                {
                    string ImageLocation = EntityPathConfig.newlocationimagepath(query.ToList()[0]);
                    imgPathTextBox.Text = query.ToList()[0].name;
                    pictureBox1.ImageLocation = ImageLocation;
                }

            }
        }

        private void findFileButton_Click(object sender, EventArgs e)
        {
            var form = new SelectSystemfile();
            form.ShowDialog();


            //if (form.ShowDialog() == DialogResult.Yes)
            {
                List<string> reference = form.listfile;
                if (reference.Count > 0)
                {
                    imgPathTextBox.Text = reference[0];

                    pictureBox1.ImageLocation = reference[1];
                }


            }
        }
    }
}
