﻿using DCTS.Bus;
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
    public partial class EditScenicForm : BaseModalForm
    {
        public int ScenicId { get; set; }
        public bool Saved { get; set; }

        ComboLocation scenic;
        ComboLocation originalScenic;

        public EditScenicForm(int scenicId)
        {
            InitializeComponent();
            ScenicId = scenicId;
            Saved = false;

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                var ctx = this.entityDataSource1.DbContext as DctsEntities;
            
                this.scenicFormControl1.FillModelByForm(this.scenic);

                ComboLoactionBusiness.Validate(scenic);

                string imgFilePath = scenic.img;

                bool newImg = (scenic.img != originalScenic.img);
                if (newImg)
                {
                    string imgFileName = Path.GetFileName(imgFilePath);
                    scenic.img = imgFileName;
                    string copyToPath = EntityPathConfig.LocationImagePath(scenic);
                    File.Copy(imgFilePath, copyToPath, true);
                }
            
                ctx.SaveChanges();
                Saved = true;

                this.Close();
            }
            catch (DbEntityValidationException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        private void EditScenicForm_Load(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;

            this.scenic = ctx.ComboLocations.Find(ScenicId);
            this.originalScenic = new ComboLocation() { img = scenic.img };
            this.scenicFormControl1.FillFormByModel(scenic);


        }
    }
}
