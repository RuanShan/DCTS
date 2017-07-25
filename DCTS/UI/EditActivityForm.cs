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
                string imgFullPath = activity.image_path;

                if (imgFullPath.StartsWith(EntityPathHelper.ImageBasePath))
                {
                    string relativeImagePath = imgFullPath.Substring(EntityPathHelper.ImageBasePath.Length);
                    activity.image_path = relativeImagePath;
                }
                else {
                    // 用户选择素材目录之外的图片
                    string imgFileName = Path.GetFileName(imgFullPath);
                    activity.image_path = imgFileName;
                    string copyToPath = EntityPathHelper.LocationImagePathEx(activity);
                    File.Copy(imgFullPath, copyToPath, true);
                }
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
