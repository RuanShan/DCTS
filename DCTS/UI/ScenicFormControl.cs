using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCTS.UI
{
    public partial class ScenicFormControl : UserControl
    {
        public ScenicFormControl()
        {
            InitializeComponent();
           
        }

        public void InitializeDataSource()
        {
                var nationList = DCTS.DB.GlobalCache.NationList;
            
                this.nationComboBox.DisplayMember = "title";
                this.nationComboBox.ValueMember = "code";
                this.nationComboBox.DataSource = nationList;
                //var query = ctx.Scenics.OrderBy(o => o.id).Skip(offset).Take(pageSize);
                //var list = this.entityDataSource1.CreateView(query);
                //this.dataGridView.DataSource = list;
            
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

        public void FillFormByModel( ComboLocation scenic)
        {
            InitializeDataSource();

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
                this.openAtDateTimePicker.Value = (DateTime)scenic.open_at;
            }
            if (scenic.close_at != null)
            {
                this.closeAtDateTimePicker.Value = (DateTime)scenic.close_at;
            }

            if (scenic.tips.Length > 0)
            {
                this.tipsTextBox.Text = scenic.tips;
            }
            if (scenic.local_address.Length > 0)
            {
                this.localAddressTextBox.Text = scenic.local_address;
            }
            if (scenic.route!=null)
            {
                this.routeTextBox.Text = scenic.route;
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
            scenic.open_at = this.openAtDateTimePicker.Value;
            scenic.close_at = this.closeAtDateTimePicker.Value;
            scenic.tips = this.tipsTextBox.Text;
            scenic.local_address = this.localAddressTextBox.Text;
            scenic.route = this.routeTextBox.Text;
            return scenic;
        }

        private void ScenicFormControl_Load(object sender, EventArgs e)
        {
            
        }

        private void findFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PNG(*.png)JPEG(*.jpg,*.jpeg,*.jpe,*.jfif)GIF(*.gif)BMP(*.bmp)|*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.gif;*.bmp"; //文件类型
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.imgPathTextBox.Text = openFileDialog1.FileName;
            }
        }
    }
}
