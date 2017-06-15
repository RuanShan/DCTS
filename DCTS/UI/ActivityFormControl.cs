using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCTS.DB;
using System.IO;

namespace DCTS.UI
{
    public partial class ActivityFormControl : UserControl
    {
        long activityId;
        DctsEntities db;
        public ActivityFormControl()
        {
            InitializeComponent();
            db = new DctsEntities();
            activityId = 0;
        }

        public void InitializeDataSource()
        {
            var nationList = DCTS.DB.GlobalCache.NationList;

            this.nationComboBox.DisplayMember = "title";
            this.nationComboBox.ValueMember = "code";
            this.nationComboBox.DataSource = nationList;
          

        }

        private void nationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string code = nationComboBox.SelectedValue.ToString();

            var cityList = DCTS.DB.GlobalCache.CityList;
            cityList = cityList.Where(o => o.nationCode == code).ToList();
            this.cityComboBox.DisplayMember = "title";
            this.cityComboBox.ValueMember = "id";
            this.cityComboBox.DataSource = cityList;

        }

        public void FillFormByModel(ComboLocation activity)
        {
            // 查询图片是否存在时使用
            this.activityId = activity.id;

            InitializeDataSource();

            if (activity.nation.Length > 0)
            {
                this.nationComboBox.Text = activity.nation;
            }
            if (activity.city.Length > 0)
            {
                this.cityComboBox.Text = activity.city;
            }

            if (activity.title.Length > 0)
            {
                this.titleTextBox.Text = activity.title;
            }

            if (activity.local_title != null)
            {
                this.localTitleTextBox.Text = activity.local_title;
            }

            if (activity.latlng.Length > 0)
            {
                this.latlngTextBox.Text = activity.latlng;
            }

            if (activity.ticket != null)
            {
                this.ticketTextBox.Text = activity.ticket;
            }

            if (activity.open_at != null)
            {
                //this.openAtDateTimePicker.Value = (DateTime)scenic.open_at;
            }
            if (activity.close_at != null)
            {
                //this.closeAtDateTimePicker.Value = (DateTime)scenic.close_at;
            }

            if (activity.tips.Length > 0)
            {
                this.tipsTextBox.Text = activity.tips;
            }
            if (activity.local_address.Length > 0)
            {
                this.localAddressTextBox.Text = activity.local_address;
            }
            if (activity.route != null)
            {
                this.routeTextBox.Text = activity.route;
            }

            //处理图片
            if (activity.img.Length > 0)
            {
                if (activity.id > 0)
                {
                    this.imgPathTextBox.Text = activity.img;
                    string lcoalPath = EntityPathConfig.LocationImagePath(activity);
                    pictureBox1.ImageLocation = lcoalPath;
                }
            }
        }

        public ComboLocation FillModelByForm(ComboLocation activity)
        {
            activity.title = this.titleTextBox.Text;
            activity.local_title = this.localTitleTextBox.Text;

            activity.nation = this.nationComboBox.Text;
            activity.city = this.cityComboBox.Text;
            activity.latlng = this.latlngTextBox.Text;
            activity.ticket = this.ticketTextBox.Text;
            //scenic.open_at = this.openAtDateTimePicker.Value;
            //scenic.close_at = this.closeAtDateTimePicker.Value;
            activity.tips = this.tipsTextBox.Text;
            activity.local_address = this.localAddressTextBox.Text;
            activity.route = this.routeTextBox.Text;
            activity.img = this.imgPathTextBox.Text;
            return activity;
        }

        private void ScenicFormControl_Load(object sender, EventArgs e)
        {

        }

        private void findFileButton_Click(object sender, EventArgs e)
        {
            //openFileDialog1.Filter = "PNG(*.png)JPEG(*.jpg,*.jpeg,*.jpe,*.jfif)GIF(*.gif)BMP(*.bmp)|*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.gif;*.bmp"; //文件类型
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.imgPathTextBox.Text = openFileDialog1.FileName;
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void imgPathTextBox_TextChanged(object sender, EventArgs e)
        {
            string imgFilePath = this.imgPathTextBox.Text;
            string imgFileName = "";
            bool hasImg = (imgFilePath.Length > 0);
            bool existSameImage = false;

            if (hasImg && imgFilePath != "\"\"")
            {

                imgFileName = Path.GetFileName(imgFilePath);

                ComboLocation lastLocation = db.ComboLocations.OrderByDescending(o => o.id).FirstOrDefault();
                if (lastLocation != null)
                {
                    existSameImage = (db.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Activity && o.img == imgFileName && o.id != activityId).Count() > 0);
                }
                if (existSameImage)
                {
                    this.errorProvider1.SetError(this.imgPathTextBox, string.Format("文件名<{0}>已在, 请使用其他文件名！", imgFileName));
                }
                else
                {
                    this.errorProvider1.SetError(this.imgPathTextBox, string.Empty);
                }
            }
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            using (var ctx = new DctsEntities())
            {
                bool nameishave = false;
                bool hastitle = (titleTextBox.Text.Length > 0);
                if (hastitle)
                {
                    ComboLocation lastLocation = ctx.ComboLocations.OrderByDescending(o => o.id).FirstOrDefault();
                    if (lastLocation != null)
                        nameishave = (ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Activity && o.title == titleTextBox.Text).Count() > 0);

                    if (activityId == 0)
                    {
                        if (nameishave == true || this.titleTextBox.Text.Length > 100)
                            errorProvider1.SetError(titleTextBox, String.Format("错误：请检查名称的长度或是否已存在 {0}", titleTextBox.Text));
                    }
                    else
                    {
                        if (this.titleTextBox.Text.Length > 100)
                            errorProvider1.SetError(titleTextBox, String.Format("错误：请检查名称的长度 {0}", titleTextBox.Text));
                    }
                }
            }
        }
    }
}
