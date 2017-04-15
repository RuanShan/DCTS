﻿using System;
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
    public partial class NewDinningsForm : BaseModalForm
    {
        public NewDinningsForm()
        {
            InitializeComponent();
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
                var obj = ctx.Dinings.Create();
                obj.nation = this.nationComboBox.Text;
                obj.city = this.cityComboBox.Text;
                obj.area = this.titleTextBox.Text;
                obj.dishes = this.textBox1.Text;
                obj.img = this.imgPathTextBox.Text;
                obj.latlng = this.latlngTextBox.Text;
                obj.reach = this.textBox2.Text;
                obj.address = this.localAddressTextBox.Text;
                obj.recommendedDishes = this.textBox3.Text;
                obj.tips = this.textBox6.Text;
                obj.title = this.localTitleTextBox.Text;

                //obj.opentime = this.openAtDateTimePicker.Text;
                //obj.closetime = this.closeAtDateTimePicker.Text;
               

                //obj.memo = this.memoTextBox.Text;
                ctx.Dinings.Add(obj);
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
    }
}
