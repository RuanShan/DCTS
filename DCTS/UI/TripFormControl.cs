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

            
        }

        public void FillFormByModel(Trip trip)
        {

            this.titleTextBox.Text = trip.title;
            this.daysNumericUpDown.Value = trip.days;
            this.memoTextBox.Text = trip.memo;
            //读取图片位置

            string fullPath = EntityPathHelper.LocationImagePathEx(trip);
            imgPathTextBox.Text = trip.image_path;
            pictureBox1.ImageLocation = fullPath;
             
        }

        private void findFileButton_Click(object sender, EventArgs e)
        {
            var form = new SelectSystemfile();
            form.ShowDialog();
            {                 
                if (form.selectedImage.Length > 0)
                {
                    imgPathTextBox.Text = form.selectedImage;
                    pictureBox1.ImageLocation = form.selectedImageAbsolutePath;
                }
            }
        }
    }
}
