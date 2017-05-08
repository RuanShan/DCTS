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
    public partial class NewScenicForm : BaseModalForm
    {
        public NewScenicForm()
        {
            InitializeComponent();
            InitializeDataSource();
        }

        public void InitializeDataSource()
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            var nationList = DCTS.DB.GlobalCache.NationList;
            {
                this.nationComboBox.DisplayMember = "title";
                this.nationComboBox.ValueMember = "code";
                this.nationComboBox.DataSource = nationList;
                //var query = ctx.Scenics.OrderBy(o => o.id).Skip(offset).Take(pageSize);
                //var list = this.entityDataSource1.CreateView(query);
                //this.dataGridView.DataSource = list;
            }
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

        private void saveButton_Click(object sender, EventArgs e)
        {

            using (var ctx = new DctsEntities())
            {
                try
                {

                    string imgFilePath = this.imgPathTextBox.Text;
                    string imgFileName = "";
                    bool hasImg = (imgFilePath.Length > 0);
                    bool existSameImage = false;
                    bool nameishave = false;
                    if (hasImg)
                    {
                        imgFileName = Path.GetFileName(imgFilePath);

                        ComboLocation lastLocation = ctx.ComboLocations.OrderByDescending(o => o.id).FirstOrDefault();
                        if (lastLocation != null)
                        {
                            long newId = lastLocation.id + 1;

                            long idStart = newId / 1000 * 1000;
                            long idEnd = idStart + 1000;
                            existSameImage = (ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Scenic && o.img == imgFileName && o.id > idStart && o.id < idEnd).Count() > 0);
                        }
                        if (existSameImage)
                        {
                            MessageBox.Show(string.Format("文件名<{0}>已在, 请使用其他文件名！", imgFileName));
                            return;
                        }
                    }
                    bool hastitle = (titleTextBox.Text.Length > 0);
                    if (hastitle)
                    {
                        ComboLocation lastLocation = ctx.ComboLocations.OrderByDescending(o => o.id).FirstOrDefault();
                        if (lastLocation != null)
                            nameishave = (ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Hotel && o.title == titleTextBox.Text).Count() > 0);
                    }

                    var obj = ctx.ComboLocations.Create();
                    obj.ltype = (int)ComboLocationEnum.Scenic;
                    obj.title = this.titleTextBox.Text;
                    obj.nation = this.nationComboBox.Text;
                    obj.city = this.cityComboBox.Text;
                    obj.latlng = this.latlngTextBox.Text;
                    obj.ticket = this.ticketTextBox.Text;
                    obj.open_at = this.openAtDateTimePicker.Value;
                    obj.close_at = this.closeAtDateTimePicker.Value;
                    obj.tips = this.tipsTextBox.Text;
                    obj.local_address = this.localAddressTextBox.Text;
                    obj.route = this.routeTextBox.Text;
                    obj.img = imgFileName;
                    ctx.ComboLocations.Add(obj);
                    if (nameishave == false && this.titleTextBox.Text.Length <= 100)
                        ctx.SaveChanges();
                    else
                    {
                        MessageBox.Show("错误：请检查名称的长度或是否已存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (hasImg)
                    {
                        string copyToPath = EntityPathConfig.LocationImagePath(obj);
                        File.Copy(imgFilePath, copyToPath);
                    }

                }
                catch (Exception exception)
                {
                    throw;
                }
            }

        }

        private void findFileButton_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "PNG(*.png)JPEG(*.jpg,*.jpeg,*.jpe,*.jfif)GIF(*.gif)BMP(*.bmp)|*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.gif;*.bmp"; //文件类型
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.imgPathTextBox.Text = openFileDialog1.FileName;
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

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
                        nameishave = (ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Scenic && o.title == titleTextBox.Text).Count() > 0);

                    if (nameishave == true || this.titleTextBox.Text.Length > 100)
                        errorProvider1.SetError(titleTextBox, String.Format("错误：请检查名称的长度或是否已存在 {0}", titleTextBox.Text));


                }
            }
        }
    }
}
