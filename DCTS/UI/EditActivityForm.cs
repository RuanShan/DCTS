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

            string imgFilePath = activity.img;

            bool hasImg = (activity.img != originalActivity.img);
            if (hasImg)
            {

                string imgFileName = Path.GetFileName(imgFilePath);

                activity.img = imgFileName;
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

            if (hasImg)
            {
                string copyToPath = EntityPathConfig.LocationImagePath(activity);
                File.Copy(imgFilePath, copyToPath, true);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        private void EditScenicForm_Load(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;

            this.activity = ctx.ComboLocations.Find(ActivityId);
            this.originalActivity = new ComboLocation() { img = activity.img, word = activity.word };
            this.activityFormControl1.FillFormByModel(activity);


        }
    }
}
