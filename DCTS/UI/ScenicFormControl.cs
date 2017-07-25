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
    public partial class ScenicFormControl : UserControl
    {
        long scenicId;
        public ScenicFormControl()
        {
            InitializeComponent();
            scenicId = 0;
        }

        // 不要在构造函数中调用，会导致DCTSEntity无法找到数据库连接字符串。
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

        public void FillFormByModel(ComboLocation scenic)
        {

            var nationList = DCTS.DB.GlobalCache.NationList;

            this.nationComboBox.DisplayMember = "title";
            this.nationComboBox.ValueMember = "code";
            this.nationComboBox.DataSource = nationList;


            // 查询图片是否存在时使用
            this.scenicId = scenic.id;


            if (scenic.nation.Length > 0)
            {
                this.nationComboBox.Text = scenic.nation;
            }
            if (scenic.city.Length > 0)
            {
                this.cityComboBox.Text = scenic.city;
            }

            if (scenic.title.Length > 0)
            {
                this.titleTextBox.Text = scenic.title;
            }

            if (scenic.local_title != null)
            {
                this.localTitleTextBox.Text = scenic.local_title;
            }

            if (scenic.latlng.Length > 0)
            {
                this.latlngTextBox.Text = scenic.latlng;
            }

            if (scenic.ticket != null)
            {
                this.ticketTextBox.Text = scenic.ticket;
            }

            if (scenic.open_at != null)
            {
                //this.openAtDateTimePicker.Value = (DateTime)scenic.open_at;
            }
            if (scenic.open_close_more != null)
            {
                this.openCloseTextBox.Text = scenic.open_close_more;
            }

            if (scenic.tips.Length > 0)
            {
                this.tipsTextBox.Text = scenic.tips;
            }
            if (scenic.local_address.Length > 0)
            {
                this.localAddressTextBox.Text = scenic.local_address;
            }
            if (scenic.route != null)
            {
                this.routeTextBox.Text = scenic.route;
            }

            //处理图片
            if (scenic.image_path!=null && scenic.image_path.Length > 0)
            {
                if (scenic.id > 0 )
                {
                    this.imgPathTextBox.Text = scenic.image_path;
                    string localPath = EntityPathHelper.LocationImagePathEx(scenic);
                    pictureBox1.ImageLocation = localPath;
                }
            }
        }

        public ComboLocation FillModelByForm(ComboLocation scenic)
        {
            scenic.title = this.titleTextBox.Text;
            scenic.local_title = this.localTitleTextBox.Text;

            scenic.nation = this.nationComboBox.Text;
            scenic.city = this.cityComboBox.Text;
            scenic.latlng = this.latlngTextBox.Text;
            scenic.ticket = this.ticketTextBox.Text;
            //scenic.open_at = this.openAtDateTimePicker.Value;
            //scenic.close_at = this.closeAtDateTimePicker.Value;
            scenic.tips = this.tipsTextBox.Text;
            scenic.local_address = this.localAddressTextBox.Text;
            scenic.route = this.routeTextBox.Text;
            scenic.image_path = this.imgPathTextBox.Text;
            scenic.open_close_more = this.openCloseTextBox.Text;
            return scenic;
        }

        private void findFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = EntityPathHelper.ImageBasePath;
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

            if (hasImg )
            {
                //var db = this.entityDataSource1.DbContext as DctsEntities;


                imgFileName = Path.GetFileName(imgFilePath);
                // 检查选择图片是否是素材目录下的，原有数据是相对路径
                // 如果是，直接设置image_path,image_name, 
                // 如果不是，需要检查素材目录下是否存在，
                //      如果存在 提示文件已存在，是否覆盖
                //      如果不存在，直接拷贝到素材目录下

                if (Path.IsPathRooted(imgFilePath) && !imgFilePath.StartsWith(EntityPathHelper.ImageBasePath))
                {
                    string targetPath = Path.Combine(EntityPathHelper.ImageBasePath, imgFileName);

                    existSameImage = File.Exists(targetPath);
                }
                if (existSameImage)
                {
                    this.errorProvider1.SetError(this.imgPathTextBox, string.Format("文件名<{0}>已存在, 请使用其他文件名！", imgFileName));
                }
                else
                {
                    this.errorProvider1.SetError(this.imgPathTextBox, string.Empty);
                }
            }
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
           
                bool hastitle = (titleTextBox.Text.Length > 0);
                if (hastitle)
                {
                    if (this.titleTextBox.Text.Length > 120)
                    {
                        errorProvider1.SetError(titleTextBox, String.Format("名称的长度过长，应少于120个字。", titleTextBox.Text));
                    }
                    else {
                        errorProvider1.SetError(titleTextBox, "");                    
                    }                    
                }
            
        }
    }
}
