using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using DCTS.CustomComponents;
using System.Collections;
using DCTS.DB;
using MySql.Data.MySqlClient;
using System.IO;
using DCTS.Bus;
using DCTS.Uti;

namespace DCTS.UI
{
    public partial class HotelListControl : UserControl
    {
        private Hashtable dataGridChanges = null;
        private static string NoOptionSelected = "所有";
        private List<ComboLocation> hotelList = null;
        private SortableBindingList<ComboLocation> sortabledinningsOrderList;
        int RowRemark = 0;
        string sqlfilter = "";
        public HotelListControl()
        {
            InitializeComponent();
            this.dataGridChanges = new Hashtable();
            // pager1.Bind();
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

        private void InitializeDataGridView11()
        {
            this.pager1.PageCurrent = 1;
            this.pager1.PageSize = 24;
            int offset = 0;

            int pageSize = 50;

            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            //using (var ctx = new DctsEntities())
            {
                hotelList = new List<ComboLocation>();
                var query = ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Hotel).OrderBy(o => o.id).Skip(offset).Take(pageSize);
                hotelList = query.ToList();
                //  var query = ctx.ComboLocations.OrderBy(o => o.id).Skip(offset).Take(pageSize);
                var list = this.entityDataSource1.CreateView(query);
                sortabledinningsOrderList = new SortableBindingList<ComboLocation>(query.ToList());
                this.bindingSource1.DataSource = this.sortabledinningsOrderList;
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = this.bindingSource1;

            }
            var nationList = DCTS.DB.GlobalCache.NationList;

            // 初始化查询条件
            var nations = nationList.Select(o => new MockEntity { Id = o.id, ShortName = o.code, FullName = o.title }).ToList();
            nations.Insert(0, new MockEntity { Id = 0, ShortName = "", FullName = "所有" });
            this.nationComboBox.DisplayMember = "FullName";
            this.nationComboBox.ValueMember = "ShortName";
            this.nationComboBox.DataSource = nations;
            pager1.Bind();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var form = new NewHotelForm("create", null);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                InitializeDataGridView();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" 确定删除 ?", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
            }
            else
                return;
            var oids = GetOrderIdsBySelectedGridCell();
            using (var ctx = new DctsEntities())
            {
                var stockrecs = (from s in ctx.ComboLocations
                                 where oids.Contains(s.id)
                                 select s).ToList();
                ctx.ComboLocations.RemoveRange(stockrecs);
                ctx.SaveChanges();

            }
            InitializeDataGridView();
        }
        private List<long> GetOrderIdsBySelectedGridCell()
        {

            List<long> order_ids = new List<long>();
            var rows = GetSelectedRowsBySelectedCells(dataGridView);
            foreach (DataGridViewRow row in rows)
            {
                var Diningorder = row.DataBoundItem as ComboLocation;
                order_ids.Add(Diningorder.id);
            }

            return order_ids;
        }
        private IEnumerable<DataGridViewRow> GetSelectedRowsBySelectedCells(DataGridView dgv)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                rows.Add(cell.OwningRow);
            }
            return rows.Distinct();
        }

        private void btfind_Click(object sender, EventArgs e)
        {
            pager1.PageCurrent = 1;
            pager1.Bind();
        }
        private int FindDataSources1()
        {
            sqlfilter = "";
            var nation = nationComboBox.Text;
            var city = this.cityComboBox.Text;
            var title = this.keywordTextBox.Text;
            string conditions = "";//s.ltype =(int)ComboLocationEnum.Dining
            List<MySqlParameter> condition_params = new List<MySqlParameter>();
            var ltype = (int)ComboLocationEnum.Hotel;


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
                hotelList = ctx.Database.SqlQuery<ComboLocation>(sql, condition_params.ToArray()).ToList();
                count = hotelList.Count;

                sqlfilter = string.Format(" SELECT * FROM combolocations " + conditions.Replace("@ltype", ltype.ToString()).Replace("@nation", "'" + nation.ToString() + "'").Replace("@city", "'" + city.ToString() + "'").Replace("@title", "'" + title.ToString() + "'"));
                //DinningList = (from s in ctx.ComboLocations
                //               where s.title == title
                //               select s).ToList();
                sortabledinningsOrderList = new SortableBindingList<ComboLocation>(hotelList.ToList());
                this.bindingSource1.DataSource = this.sortabledinningsOrderList;
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = this.bindingSource1;

            }


            return count;


            #endregion
        }


        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView.Rows[e.RowIndex];
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString();
            var new_cell_value = row.Cells[e.ColumnIndex].Value;
            var original_cell_value = dataGridChanges[cell_key];
            // original_cell_value could null
            //Console.WriteLine(" original = {0} {3}, new ={1} {4}, compare = {2}, {5}", original_cell_value, new_cell_value, original_cell_value == new_cell_value, original_cell_value.GetType(), new_cell_value.GetType(), new_cell_value.Equals(original_cell_value));
            if (new_cell_value == null && original_cell_value == null)
            {
                dataGridChanges.Remove(cell_key + "_changed");
            }
            else if ((new_cell_value == null && original_cell_value != null) || (new_cell_value != null && original_cell_value == null) || !new_cell_value.Equals(original_cell_value))
            {
                dataGridChanges[cell_key + "_changed"] = new_cell_value;
            }
            else
            {
                dataGridChanges.Remove(cell_key + "_changed");
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            #region  new
            if (dataGridView.Columns[e.ColumnIndex] == this.imgColumn1)
            {
                if (hotelList != null && e.RowIndex < hotelList.Count)
                {

                    ComboLocation selectedItem = dataGridView.Rows[e.RowIndex].DataBoundItem as ComboLocation;
                    long folername = selectedItem.id / 1000;
                    if (selectedItem.img != null && selectedItem.img != "")
                    {
                      
                        string lcoalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\data\\images\\location_" + ComboLocationEnum.Hotel.ToString().ToLower() + "\\" + folername + "\\", selectedItem.img);
                        e.Value = GetImage1(lcoalPath);
                    }
                }
            }

            #endregion

        }
        public System.Drawing.Image GetImage1(string path)
        {
            //C:\mysteap\work_office\ProjectOut\RuanShanLvYou\DCTS\DCTS\bin\Debug\\data\images\locations\0\QQ截图20170105225656.png
            //C:\mysteap\work_office\ProjectOut\RuanShanLvYou\DCTS\DCTS\bin\Debug\data\images\location_scenic\0
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

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow dgrSingle = dataGridView.Rows[e.RowIndex];
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString();

            if (!dataGridChanges.ContainsKey(cell_key))
            {
                dataGridChanges[cell_key] = dgrSingle.Cells[e.ColumnIndex].Value;
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

        private int pager1_EventPaging(EventPagingArg e)
        {

            int count = InitializeDataGridView(e.PageCurrent);
            return count;
        }

        private void 修改ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int i = this.dataGridView.CurrentRow.Index;
            ComboLocation selectedItem = hotelList[i];
            var form = new NewHotelForm("Edit", selectedItem);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                InitializeDataGridView();
            }
        }

        private void btdown_Click(object sender, EventArgs e)
        {
            string strFileName = String.Empty;

            saveFileDialog1.FileName = "酒店" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
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
                count = ComboLoactionBusiness.Count(ComboLocationEnum.Hotel, nation, city, title);

                var list = ComboLoactionBusiness.Paginate(ComboLocationEnum.Hotel, pageCurrent, pageSize, nation, city, title);

                this.dataGridView.DataSource = list;
            }
            return count;
        }

        // 根据当前选择条件，构造查询语句
        private string BuildSql()
        {
            var ltype = (int)ComboLocationEnum.Hotel;

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

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = dataGridView.Columns[e.ColumnIndex];

            if (column == editColumn1)
            {
                var row = dataGridView.Rows[e.RowIndex];

                var model = row.DataBoundItem as ComboLocation;

                var form = new NewHotelForm("Edit", model);
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    BeginActive();
                }
            }
            else if (column == deleteColumn1)
            {
                var row = dataGridView.Rows[e.RowIndex];
                var model = row.DataBoundItem as ComboLocation;
                string msg = string.Format("确定删除餐厅<{0}>？", model.title);

                if (MessageHelper.DeleteConfirm(msg))
                {
                    ComboLoactionBusiness.Delete(model.id);
                    BeginActive();
                }
            }



        }

        private void HotelListControl_Resize(object sender, EventArgs e)
        {  //                                                   id
            titleColumn1.Width = dataGridView.ClientSize.Width - 60 - 100 * 3 - 280 - 200 - 100 - 60 * 2 - 3;
            //是否包含滚动条
            if (!(this.dataGridView.DisplayedRowCount(false) == this.dataGridView.RowCount))
            {
                titleColumn1.Width -= 18;
            }

        }
    }
}
