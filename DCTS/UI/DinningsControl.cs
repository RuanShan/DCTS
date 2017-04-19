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

namespace DCTS.UI
{
    public partial class DinningsControl : UserControl
    {
        private Hashtable dataGridChanges = null;
        private static string NoOptionSelected = "所有";
        private SortableBindingList<ComboLocation> sortabledinningsOrderList;
        int RowRemark = 0;
        //private List<ComboLocation> dinningsOrderList;
        IBindingList dinningsOrderList = null;
        private List<ComboLocation> DinningList = null;
        public DinningsControl()
        {
            InitializeComponent();
            this.dataGridChanges = new Hashtable();
        }

        public void BeginActive()
        {
            InitializeDataGridView();
            pager2.Bind();
            // InitControlsProperties();

        }

        private void InitializeDataGridView()
        {
            this.pager2.PageCurrent = 1;

            int offset = 0;
            int pageSize = 5000;
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            //using (var ctx = new DctsEntities())
            {
                DinningList = new List<ComboLocation>();

                // var query = ctx.ComboLocations.OrderBy(o => o.id).Skip(offset).Take(pageSize);
                var query = ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Dining).OrderBy(o => o.id).Skip(offset).Take(pageSize);
                DinningList = query.ToList();

                var list = this.entityDataSource1.CreateView(query);
                sortabledinningsOrderList = new SortableBindingList<ComboLocation>(query.ToList());
                this.bindingSource1.DataSource = this.sortabledinningsOrderList;
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = this.bindingSource1;

            }

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
            var form = new NewDinningsForm("create", null);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                InitializeDataGridView();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            //ApplyFilter();
            FindDataSources();
            pager2.Bind();

        }
        private void ApplyFilter()
        {
            string filter = "";
            if (this.textBox1.Text.Length > 0)
            {
                //filter += "(餐厅名称=" + this.textBox1.Text + ")";
                filter += " (餐厅名称 ='" + this.textBox1.Text + "')";

            }
            if (this.nationComboBox.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                //filter += "(国家=" + this.comboBox2.Text + ")";
                filter += "(国家 =" + "'" + cityComboBox.Text + "'" + ")";
            }
            if (this.cityComboBox.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                //filter += "(城市=" + this.comboBox3.Text + ")";
                filter += "(城市 =" + "'" + cityComboBox.Text + "'" + ")";
            }

            this.bindingSource1.Filter = filter;

        }

        private int FindDataSources()
        {


            var nation = nationComboBox.Text;
            var city = this.cityComboBox.Text;
            var title = this.textBox1.Text;

            string conditions = "";//s.ltype =(int)ComboLocationEnum.Dining
            List<MySqlParameter> condition_params = new List<MySqlParameter>();

            var ltype = (int)ComboLocationEnum.Dining;


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
                // conditions += "(`title`= @title)";
                conditions += "(`title`LIKE '%" + @title + "%')";
                // conditions += "(`title`LIKE '%2%')";

            }



            #region  new
            condition_params.Add(new MySqlParameter("@ltype", ltype));
            condition_params.Add(new MySqlParameter("@nation", nation));
            condition_params.Add(new MySqlParameter("@city", city));
            condition_params.Add(new MySqlParameter("@title", title));

            int limit = pager2.PageSize;
            int offset = (pager2.PageCurrent > 1 ? pager2.OffSet(pager2.PageCurrent - 1) : 0);
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
                DinningList = ctx.Database.SqlQuery<ComboLocation>(sql, condition_params.ToArray()).ToList();

                //DinningList = (from s in ctx.ComboLocations
                //               where s.title == title
                //               select s).ToList();
                sortabledinningsOrderList = new SortableBindingList<ComboLocation>(DinningList.ToList());
                this.bindingSource1.DataSource = this.sortabledinningsOrderList;
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = this.bindingSource1;

            }
            return count;


            #endregion
        }


        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = this.dataGridView.CurrentRow.Index;
            ComboLocation selectedItem = DinningList[i];

            //ComboLocation selectedItem = DinningList.Find(i => i.id == o.自社コード);

            var form = new NewDinningsForm("Edit", selectedItem);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                InitializeDataGridView();
            }
        }


        private void btsave_Click(object sender, EventArgs e)
        {
            if (dataGridChanges.Count > 0)
            {
                entityDataSource1.SaveChanges();
            }
            dataGridChanges.Clear();
            //InitializeDataSource(ShipNO);
            InitializeDataGridView();
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
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString() + "_changed";

            if (dataGridChanges.ContainsKey(cell_key))
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
            }

            //添加图片
            int i = this.dataGridView.CurrentRow.Index;
            if (i < DinningList.Count)
            {
                ComboLocation selectedItem = DinningList[i];
                long folername = selectedItem.id / 1000;
                if (selectedItem.img != null && selectedItem.img != "")
                {

                    string lcoalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\data\\images\\locations\\" + folername + "\\", selectedItem.img);
                    if (e.ColumnIndex == 5)
                    {
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

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow dgrSingle = dataGridView.Rows[e.RowIndex];
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString();

            if (!dataGridChanges.ContainsKey(cell_key))
            {
                dataGridChanges[cell_key] = dgrSingle.Cells[e.ColumnIndex].Value;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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

        private void DinningsControl_Load(object sender, EventArgs e)
        {

        }

        private void pager2_Load(object sender, EventArgs e)
        {
            // this.pager2.ResetText = "";

        }
        private int pager2_EventPaging(EventPagingArg e)
        {
            int count = InitializeOrderData();
            return count;
        }
        private int InitializeOrderData()
        {


            int limit = pager2.PageSize;
            int offset = (pager2.PageCurrent > 1 ? pager2.OffSet(pager2.PageCurrent - 1) : 0);
            int count = 0;
            //using (var ctx = new GODDbContext())
            //{
            //    if (conditions.Length > 0)
            //    {
            //        conditions = " WHERE " + conditions;
            //    }
            //    string sqlCount = string.Format(" SELECT count(*) FROM t_orderdata {0}", conditions);
            //    count = ctx.Database.SqlQuery<int>(sqlCount, condition_params.ToArray()).First();
            //    string sql = string.Format(" SELECT * FROM t_orderdata {0} LIMIT {1} OFFSET {2}", conditions, limit, offset);
            //    orderList = ctx.Database.SqlQuery<v_pendingorder>(sql, condition_params.ToArray()).ToList();
            //}
            //orderListBindingList = new SortableBindingList<v_pendingorder>(orderList);
            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.DataSource = orderListBindingList;

            return count;

        }

        private int pager2_EventPaging_1(EventPagingArg e)
        {
            int count = FindDataSources();
            return count;
        }

    }
}
