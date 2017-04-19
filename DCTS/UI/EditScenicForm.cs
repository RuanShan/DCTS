﻿using DCTS.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public long ScenicId { get; set; }

        ComboLocation scenic;
        ComboLocation originalScenic;

        public EditScenicForm( long scenicId)
        {
            InitializeComponent();
            ScenicId = scenicId;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            
            this.scenicFormControl1.FillModelByForm(this.scenic);

            string imgFilePath = scenic.img;

            bool hasImg = (scenic.img != originalScenic.img);
            if (hasImg)
            {

                string imgFileName = Path.GetFileName(imgFilePath);

                scenic.img = imgFileName;
            }
            
            ctx.SaveChanges();

            if (hasImg)
            {
                string copyToPath = EntityPathConfig.LocationImagePath(scenic);
                File.Copy(imgFilePath, copyToPath, true);
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
