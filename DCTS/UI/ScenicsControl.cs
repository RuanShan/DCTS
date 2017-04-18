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
using DCTS.Uti;
using DCTS.Bus;

namespace DCTS.UI
{
    
    public partial class ScenicsControl : UserControl
    {
        public ScenicsControl()
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
        }

        public void BeginActive()
        {
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            int offset = 0;
            int pageSize = 5000;
            using (var ctx = new DctsEntities())
            {

                var query = ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Scenic).OrderBy(o => o.id).Skip(offset).Take(pageSize);
                var list = this.entityDataSource1.CreateView(query);
                this.dataGridView.DataSource = list;
            }
            // 初始化查询条件
            var nationList = DCTS.DB.GlobalCache.NationList;
            var nations = nationList.Select(o => new MockEntity { Id = o.id, ShortName= o.code ,FullName = o.title }).ToList();
            nations.Insert(0, new MockEntity { Id = 0, ShortName = "", FullName = "所有" });
            this.nationComboBox.DisplayMember = "FullName";
            this.nationComboBox.ValueMember = "ShortName";
            this.nationComboBox.DataSource = nations;

        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var form = new NewScenicForm();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                InitializeDataGridView();
            }
        }

        private void nationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string code = nationComboBox.SelectedValue.ToString();

            var cityList = DCTS.DB.GlobalCache.CityList;
            cityList = cityList.Where(o => o.nationCode == code).ToList();
            var cities = cityList.Select(o => new MockEntity { Id = o.id,  FullName = o.title }).ToList();
            cities.Insert(0, new MockEntity { Id = 0,  FullName = "所有" });

            this.cityComboBox.DisplayMember = "FullName";
            this.cityComboBox.ValueMember = "Id";
            this.cityComboBox.DataSource = cities;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = dataGridView.Columns[e.ColumnIndex];

            if (column == editColumn1)
            {
                var row = dataGridView.Rows[e.RowIndex];

                var model = row.DataBoundItem as ComboLocation;

                var form = new EditScenicForm(model.id);
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    BeginActive();
                }
            }
            else if (column == deleteColumn)
            {
                var row = dataGridView.Rows[e.RowIndex];
                var model = row.DataBoundItem as ComboLocation;
                string msg = string.Format("确定删除景点<{0}>？", model.title);

                if (MessageHelper.DeleteConfirm(msg))
                {

                    ComboLoactionBusiness.Delete(model.id);

                    BeginActive();
                }
            }
        }
    }
}
