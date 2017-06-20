using DCTS.Bus;
using DCTS.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCTS.UI
{
    public partial class NewActivityForm : BaseModalForm
    {
        public bool Saved { get; set; }

        public NewActivityForm()
        {
            InitializeComponent();
            InitializeDataSource();
            Saved = false;
        }

        public void InitializeDataSource()
        {
            this.activityFormControl1.InitializeDataSource();
        }

       

        private void saveButton_Click(object sender, EventArgs e)
        {

            try
            {
                using (var ctx = new DctsEntities())
                {


                    ComboLocation activity = new ComboLocation();

                    activity.ltype = (int)ComboLocationEnum.Activity;
                    this.activityFormControl1.FillModelByForm(activity);

                    ComboLoactionBusiness.Validate(activity);

                    ctx.ComboLocations.Add(activity);
                   
                    ctx.SaveChanges();

                    if (activity.img.Length > 0)
                    {
                        string imgPath = activity.img;
                        string imgFileName = Path.GetFileName(imgPath);
                        activity.img = imgFileName;
                        string copyToPath = EntityPathConfig.LocationImagePath(activity);
                        File.Copy(imgPath, copyToPath);
                    }
                    if (activity.word.Length > 0)
                    {
                        string wordPath = activity.word;
                        string imgFileName = Path.GetFileName(wordPath);
                        activity.word = imgFileName;

                        string copyToPath = EntityPathConfig.LocationWordPath(activity);

                        File.Copy(wordPath, copyToPath);
                    }
                    Saved = true;
                }
            }
            catch (DbEntityValidationException exception)
            {
                MessageBox.Show(exception.Message);
            }

        }



        private void cancelButton_Click(object sender, EventArgs e)
        {

        }


    }
}
