using DCTS.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                    ctx.ComboLocations.Add(obj);
                    ctx.SaveChanges();
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
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
