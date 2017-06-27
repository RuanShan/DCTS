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
    public partial class NewScenicForm : BaseModalForm
    {
        public bool Saved { get; set; }

        public NewScenicForm()
        {
            InitializeComponent();
            InitializeDataSource();
            Saved = false;
        }

        public void InitializeDataSource()
        {
           
        }

       

        private void saveButton_Click(object sender, EventArgs e)
        {

            try
            {
                using (var ctx = new DctsEntities())
                {


                    ComboLocation scenic = new ComboLocation();

                    scenic.ltype = (int)ComboLocationEnum.Scenic;
                    this.scenicFormControl1.FillModelByForm(scenic);

                    ComboLoactionBusiness.Validate(scenic);

                    ctx.ComboLocations.Add(scenic);
                    string imgPath = scenic.img;
                    if (scenic.img.Length > 0)
                    {
                        string imgFileName = Path.GetFileName(imgPath);
                        scenic.img = imgFileName;
                    }
                    
                    ctx.SaveChanges();
                    //拷贝图片需要对象ID，所以这样先创建对象，再拷贝图片
                    if (scenic.img.Length > 0)
                    {             
                        string copyToPath = EntityPathConfig.LocationImagePath(scenic);
                        File.Copy(imgPath, copyToPath, true);
                    }
                    Saved = true;
                    this.Close();
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
