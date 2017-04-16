using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCTS.DB;

namespace DCTS.UI
{
    public partial class NewHotelForm : BaseModalForm
    {
        public NewHotelForm()
        {
            InitializeComponent();
            InitializeDataSource();

        }

        public void InitializeDataSource()
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (var ctx = new DctsEntities())
            {
                var obj = ctx.ComboLocations.Create();
                obj.ltype = (int)ComboLocationEnum.Hotel;
                obj.nation = this.nationComboBox.Text;
                obj.city = this.cityComboBox.Text;
                obj.title = this.titleTextBox.Text;
                obj.local_title = this.localTitleTextBox.Text;
                obj.img = this.imgPathTextBox.Text;
                //  obj.ticket = this.tickettime.Text;
                obj.open_at = Convert.ToDateTime(this.openAtDateTimePicker.Text);
                obj.close_at = Convert.ToDateTime(this.closeAtDateTimePicker.Text);
                obj.room = room.Text;
                obj.dinner = moringTextBox.Text;
                obj.latlng = latlng.Text;
                obj.address = address.Text;
                obj.local_address = local_address.Text;
                obj.contact = contact.Text;
                obj.wifi = wifi.Text;
                obj.parking = parking.Text;
                obj.reception = reception.Text;
                obj.kitchen = kitchen.Text;

                ctx.ComboLocations.Add(obj);
                ctx.SaveChanges();
            }

        }

        private void findFileButton_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "PNG(*.png)|*.png|JPEG(*.jpg,*.jpeg,*.jpe,*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|GIF(*.gif)|*.gif"; //文件类型
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.imgPathTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void NewDinningsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
