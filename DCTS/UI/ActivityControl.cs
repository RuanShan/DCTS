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

    public partial class ActivityControl : UserControl
    {
        private static string NoOptionSelected = "所有";
        private List<ComboLocation> ActivityList = null;
        private SortableBindingList<ComboLocation> sortabledinningsOrderList;
        string sqlfilter = "";

        public ActivityControl()
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            pager1.PageCurrent = 1;
        }

        public void BeginActive()
        {
            InitializeDataSource();
            pager1.Bind();
        }


        // 初始化控件的数据源
        private void InitializeDataSource()
        {

            // 初始化查询条件
            var nationList = DCTS.DB.GlobalCache.NationList;
            var nations = nationList.Select(o => new MockEntity { Id = o.id, ShortName = o.code, FullName = o.title }).ToList();
            nations.Insert(0, new MockEntity { Id = 0, ShortName = "", FullName = "所有" });
            this.nationComboBox.DisplayMember = "FullName";
            this.nationComboBox.ValueMember = "ShortName";
            this.nationComboBox.DataSource = nations;

        }




        private void newButton_Click(object sender, EventArgs e)
        {
            var form = new NewActivityForm();
            form.ShowDialog();

            if (form.Saved)
            {
                //更新当前页面，以便显示新添加的数据
                pager1.Bind();
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

                var form = new EditActivityForm(model.id);
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    BeginActive();
                }
            }
            else if (column == deleteColumn)
            {
                var row = dataGridView.Rows[e.RowIndex];
                var model = row.DataBoundItem as ComboLocation;
                string msg = string.Format("确定删除<{0}>？", model.title);

                if (MessageHelper.DeleteConfirm(msg))
                {
                    try
                    {
                        var ctx = this.entityDataSource1.DbContext as DctsEntities;
                                          
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
            int count = InitializeDataGridView(e.PageCurrent);
            return count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pager1.PageCurrent = 1;
            pager1.Bind();
        }

        private int FindDataSources()
        {
            sqlfilter = "";

            var nation = nationComboBox.Text;
            var city = this.cityComboBox.Text;
            var title = this.keywordTextBox.Text;

            string conditions = "";//s.ltype =(int)ComboLocationEnum.Dining
            List<MySqlParameter> condition_params = new List<MySqlParameter>();
            var ltype = (int)ComboLocationEnum.Activity;


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
                ActivityList = ctx.Database.SqlQuery<ComboLocation>(sql, condition_params.ToArray()).ToList();
                sqlfilter = string.Format(" SELECT * FROM combolocations " + conditions.Replace("@ltype", ltype.ToString()).Replace("@nation", "'" + nation.ToString() + "'").Replace("@city", "'" + city.ToString() + "'").Replace("@title", "'" + title.ToString() + "'"));
                sortabledinningsOrderList = new SortableBindingList<ComboLocation>(ActivityList.ToList());
                this.bindingSource1.DataSource = this.sortabledinningsOrderList;
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = this.bindingSource1;

            }


            return count;


            #endregion
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;
            if (dataGridView.Columns[e.ColumnIndex] == this.imgColumn1)
            {
                if (e.RowIndex < grid.Rows.Count)
                {
                    ComboLocation selectedItem = grid.Rows[e.RowIndex].DataBoundItem as ComboLocation;
             

                    if (selectedItem.image_path != null && selectedItem.image_path.Length > 0)
                    {
                        string lcoalPath = EntityPathHelper.LocationImagePathEx(selectedItem);

                        e.Value = GetImage1(lcoalPath);
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


        private void ScenicsControl_Resize(object sender, EventArgs e)
        {
            //                                                   id                                           word
            titleColumn1.Width = dataGridView.ClientSize.Width - 60 - 100 * 3 - 280 - 200 - 100 - 60 * 2 - 3 -100;
            //是否包含滚动条
            if (!(this.dataGridView.DisplayedRowCount(false) == this.dataGridView.RowCount))
            {
                titleColumn1.Width -= 18;
            }

        }

        private void exportExcelButton_Click(object sender, EventArgs e)
        {

            string strFileName = String.Empty;

            saveFileDialog1.FileName = "活动" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                strFileName = saveFileDialog1.FileName.ToString();
            }
            if (strFileName.Length > 0)
            {
                using (var ctx = new DctsEntities())
                {

                    // string sql = "SELECT * FROM combolocations";
                    string sql = BuildSql();

                    DataTable dataTable = ctx.DataTable(sql);
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        if (ComboLocationSchema.LocationCnNameDictionary.ContainsKey(col.ColumnName))
                        {
                            col.ColumnName = ComboLocationSchema.LocationCnNameDictionary[col.ColumnName];
                        }
                    }

                    var stream = ExcelUtility.RenderDataTableToExcel(dataTable);

                    ExcelUtility.WriteSteamToFile(stream, strFileName);
                }
            }
        }


        // 初始化DataGridView的数据源, 分页事件调用
        private int InitializeDataGridView(int pageCurrent = 1)
        {
            string nation = (this.nationComboBox.Text != NoOptionSelected ? this.nationComboBox.Text : string.Empty);
            string city = (this.cityComboBox.Text != NoOptionSelected ? this.cityComboBox.Text : string.Empty);
            string title = (this.keywordTextBox.Text != NoOptionSelected ? this.keywordTextBox.Text : string.Empty);

            int count = 0;
            int pageSize = pager1.PageSize;

            using (var ctx = new DctsEntities())
            {
                //分页需要数据总数
                count = ComboLoactionBusiness.Count(ComboLocationEnum.Activity, nation, city, title);

                var list = ComboLoactionBusiness.Paginate(ComboLocationEnum.Activity, pageCurrent, pageSize, nation, city, title);

                this.dataGridView.DataSource = list;
            }
            return count;
        }

        // 根据当前选择条件，构造查询语句
        private string BuildSql()
        {
            var ltype = (int)ComboLocationEnum.Activity;

            string sql = string.Empty;
            var nation = this.nationComboBox.Text;
            var city = this.cityComboBox.Text;
            var title = this.keywordTextBox.Text;
            string conditions = string.Format("(`ltype`= {0})", ltype);


            if (nation.Length > 0 && nation != NoOptionSelected)
            {
                conditions = conditions + " AND " + string.Format("`nation`='{0}'", nation);
            }
            if (city.Length > 0 && city != NoOptionSelected)
            {
                conditions = conditions + " AND " + string.Format("`city`='{0}'", city);
            }
            if (title.Length > 0)
            {
                conditions = conditions + " AND " + string.Format("(`title` like '%{0}%')", title);
            }
    
            if (conditions.Length > 0)
            {
                conditions = " WHERE " + conditions;
            }
            sql = string.Format(" SELECT * FROM combolocations " + conditions);
            return sql;
        }

    }
}
