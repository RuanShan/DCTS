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

            string imgFilePath = activity.image_path;

            bool hasImg = (activity.image_path != originalActivity.image_path);
            if (hasImg)
            {
                string imagePath = activity.image_path;

                if (imagePath.StartsWith(EntityPathHelper.ImageBasePath))
                {
                    string relativeImagePath = imagePath.Substring(EntityPathHelper.ImageBasePath.Length);
                    activity.image_path = relativeImagePath;
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

            if (hasImg)
            {
                bool newImg = (activity.image_path != originalActivity.image_path);
                if (newImg)
                {
                    string imagePath = activity.image_path;
                    //用户选择了素材目录的其他图片
                    if (imagePath.StartsWith(EntityPathHelper.ImageBasePath))
                    {
                        string relativeImagePath = imagePath.Substring(EntityPathHelper.ImageBasePath.Length);
                        activity.image_path = relativeImagePath;
                    }
                    else
                    { // 用户选择素材目录之外的图片
                        string imgFileName = Path.GetFileName(imagePath);
                        activity.image_path = imgFileName;
                        string copyToPath = EntityPathHelper.LocationImagePathEx(activity);
                        File.Copy(imgFilePath, copyToPath, true);
                    }
                }
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
