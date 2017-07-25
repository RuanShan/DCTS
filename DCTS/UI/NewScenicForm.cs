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
            Saved = false;
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
                    ComboLoactionBusiness.ProcessImage(scenic);
                    
                    ctx.ComboLocations.Add(scenic);
                   
                    ctx.SaveChanges();
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

        private void NewScenicForm_Load(object sender, EventArgs e)
        {
            this.scenicFormControl1.InitializeDataSource();
        }


    }
}
