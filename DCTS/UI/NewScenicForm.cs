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
                var obj = ctx.Scenics.Create();
                obj.title = this.titleTextBox.Text;
                //obj.memo = this.memoTextBox.Text;
                ctx.Scenics.Add(obj);
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

        }
    }
}
