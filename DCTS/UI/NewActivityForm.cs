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

                    string imgPath = activity.image_path;
                    if (activity.image_path != null && activity.image_path.Length > 0)
                    {
                        string imgFileName = Path.GetFileName(imgPath);
                        activity.img = imgFileName;
                    }


                    ctx.SaveChanges();

                    if (activity.image_path != null && activity.image_path.Length > 0)
                    {
                        //string imgPath = activity.image_path;
                        //string imgFileName = Path.GetFileName(imgPath);
                        //activity.img = imgFileName;
                        //string copyToPath = EntityPathHelper.LocationImagePath(activity);
                        //File.Copy(imgPath, copyToPath);

                        //拷贝图片需要对象ID，所以这样先创建对象，再拷贝图片
                        //if (activity.img.Length > 0)
                        {
                            string copyToPath = EntityPathHelper.LocationImagePath(activity);
                            File.Copy(imgPath, copyToPath, true);
                        }


                    }
                    if (activity.word.Length > 0)
                    {
                        string wordPath = activity.word;
                        string wordFileName = Path.GetFileName(wordPath);
                        activity.word = wordFileName;

                        string copyToPath = EntityPathHelper.LocationWordPath(activity);

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
