using DCTS.Bus;
using DCTS.DB;
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
    public partial class EditActivityForm : BaseModalForm
    {
        public long ActivityId { get; set; }

        ComboLocation activity;
        ComboLocation originalActivity;

        public EditActivityForm(long activityId)
        {
            InitializeComponent();
            ActivityId = activityId;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;

            this.activityFormControl1.FillModelByForm(this.activity);


            bool newImg = (activity.image_path != originalActivity.image_path);
            if (newImg)
            {
                ComboLoactionBusiness.ProcessImage(activity);

            }
            //word
            string wordFilePath = activity.word;

            bool hasword = (activity.word != originalActivity.word);
            if (hasword)
            {

                string wordFileName = Path.GetFileName(wordFilePath);

                activity.word = wordFileName;
            }

            ctx.SaveChanges();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        private void EditScenicForm_Load(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;

            this.activity = ctx.ComboLocations.Find(ActivityId);
            this.originalActivity = new ComboLocation() { image_path = activity.image_path, word = activity.word };
            this.activityFormControl1.FillFormByModel(activity);


        }
    }
}
