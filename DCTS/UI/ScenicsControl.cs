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
using MySql.Data.MySqlClient;
using DCTS.CustomComponents;
using System.IO;


namespace DCTS.UI
{

    public partial class ScenicsControl : UserControl
    {
        private static string NoOptionSelected = "所有";
        private List<ComboLocation> ScenicslList = null;
        private SortableBindingList<ComboLocation> sortabledinningsOrderList;

        public ScenicsControl()
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            pager1.Bind();
        }

        public void BeginActive()
        {
            InitializeDataGridView();
            pager1.Bind();
        }

        private void InitializeDataGridView()
        {
            this.pager1.PageCurrent = 1;
            this.pager1.PageSize = 25;

            int offset = 0;
            int pageSize = 50;
            using (var ctx = new DctsEntities())
            {

                var query = ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Scenic).OrderBy(o => o.id).Skip(offset).Take(pageSize);
                var list = this.entityDataSource1.CreateView(query);
                this.dataGridView.DataSource = list;
                //bew 
                //ScenicslList = query.ToList();
                //sortabledinningsOrderList = new SortableBindingList<ComboLocation>(query.ToList());
                //this.bindingSource1.DataSource = this.sortabledinningsOrderList;
                //dataGridView.AutoGenerateColumns = false;
                //dataGridView.DataSource = this.bindingSource1;
            }
            // 初始化查询条件
            var nationList = DCTS.DB.GlobalCache.NationList;
            var nations = nationList.Select(o => new MockEntity { Id = o.id, ShortName = o.code, FullName = o.title }).ToList();
            nations.Insert(0, new MockEntity { Id = 0, ShortName = "", FullName = "所有" });
            this.nationComboBox.DisplayMember = "FullName";
            this.nationComboBox.ValueMember = "ShortName";
            this.nationComboBox.DataSource = nations;

            pager1.Bind();

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
            var cities = cityList.Select(o => new MockEntity { Id = o.id, FullName = o.title }).ToList();
            cities.Insert(0, new MockEntity { Id = 0, FullName = "所有" });

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
                    try
                    {
                        var ctx = this.entityDataSource1.DbContext as DctsEntities;
                        //var day = model.Days.FirstOrDefault();                         
                        ComboLoactionBusiness.Delete(model.id);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                    BeginActive();
                }
            }
        }

        private int pager1_EventPaging(CustomComponents.EventPagingArg e)
        {
            int count = FindDataSources();
            return count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FindDataSources();
            pager1.Bind();
        }
        private int FindDataSources()
        {

            var nation = nationComboBox.Text;
            var city = this.cityComboBox.Text;
            var title = this.textBox1.Text;

            string conditions = "";//s.ltype =(int)ComboLocationEnum.Dining
            List<MySqlParameter> condition_params = new List<MySqlParameter>();
            var ltype = (int)ComboLocationEnum.Scenic;


            if (ltype > 0)
            {
                if (conditions.Length > 0)
                {
                    conditions += " AND ";
                }
                conditions += "(`ltype`= @ltype)";
            }
            if (nation != NoOptionSelected)
            {
                if (nation.Length > 0)
                {
                    if (conditions.Length > 0)
                    {
                        conditions += " AND ";
                    }
                    conditions += "(`nation`= @nation)";
                }
            }
            if (city != NoOptionSelected)
            {
                if (city.Length > 0)
                {
                    if (conditions.Length > 0)
                    {
                        conditions += " AND ";
                    }
                    conditions += "(`city`= @city)";
                }
            }
            if (title.Length > 0)
            {
                if (conditions.Length > 0)
                {
                    conditions += " AND ";
                }
                //conditions += "(`title`= @title)";
                conditions += "(`title`LIKE '%" + @title + "%')";
            }



            #region  new
            condition_params.Add(new MySqlParameter("@ltype", ltype));
            condition_params.Add(new MySqlParameter("@nation", nation));
            condition_params.Add(new MySqlParameter("@city", city));
            condition_params.Add(new MySqlParameter("@title", title));

            int limit = pager1.PageSize;
            int offset = (pager1.PageCurrent > 1 ? pager1.OffSet(pager1.PageCurrent - 1) : 0);
            int count = 0;
            using (var ctx = new DctsEntities())
            {
                if (conditions.Length > 0)
                {
                    conditions = " WHERE " + conditions;
                }

                string sqlCount = string.Format(" SELECT count(*) FROM combolocations {0}", conditions);
                count = ctx.Database.SqlQuery<int>(sqlCount, condition_params.ToArray()).First();
                string sql = string.Format(" SELECT * FROM combolocations {0} LIMIT {1} OFFSET {2}", conditions, limit, offset);
                ScenicslList = ctx.Database.SqlQuery<ComboLocation>(sql, condition_params.ToArray()).ToList();


                sortabledinningsOrderList = new SortableBindingList<ComboLocation>(ScenicslList.ToList());
                this.bindingSource1.DataSource = this.sortabledinningsOrderList;
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = this.bindingSource1;

            }


            return count;


            #endregion
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (e.RowIndex < ScenicslList.Count)
                {
                    ComboLocation selectedItem = ScenicslList[e.RowIndex];
                    long folername = selectedItem.id / 1000;
                    if (selectedItem.img != null && selectedItem.img != "" && selectedItem.img != "\"\"")
                    {
                        string lcoalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\data\\images\\location_" + ComboLocationEnum.Scenic.ToString().ToLower() + "\\" + folername + "\\", selectedItem.img);

                        //string lcoalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\data\\images\\locations\\" + folername + "\\", selectedItem.img);
                        if (e.ColumnIndex == 2)
                        {
                            e.Value = GetImage1(lcoalPath);

                        }
                    }
                }
            }
        }
        public System.Drawing.Image GetImage1(string path)
        {

            if (File.Exists(path))
            {

                System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);
                System.Drawing.Image result = System.Drawing.Image.FromStream(fs);

                fs.Close();

                return result;
            }
            else
                return null;


        }

    }
}
