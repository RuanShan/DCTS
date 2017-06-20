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
    public partial class CustomersControl : UserControl
    {
        private Hashtable dataGridChanges = null;
        private static string NoOptionSelected = "所有";
        private List<Customer> CustomerList = null;
        private SortableBindingList<Customer> sortabledinningsOrderList;

        string sqlfilter = "";
        public CustomersControl()
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


        }

        private void InitializeDataGridView11()
        {
            this.pager1.PageCurrent = 1;
            this.pager1.PageSize = 24;
            int offset = 0;

            int pageSize = 50;

            var ctx = this.entityDataSource1.DbContext as DctsEntities;

            {
                CustomerList = new List<Customer>();
                var query = ctx.Customers.OrderBy(o => o.id).Skip(offset).Take(pageSize);
                CustomerList = query.ToList();

                var list = this.entityDataSource1.CreateView(query);
                sortabledinningsOrderList = new SortableBindingList<Customer>(query.ToList());
                this.bindingSource1.DataSource = this.sortabledinningsOrderList;
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = this.bindingSource1;

            }


            pager1.Bind();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var form = new NewCustomerForm("create", null);
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
                var stockrecs = (from s in ctx.Customers
                                 where oids.Contains(s.id)
                                 select s).ToList();
                ctx.Customers.RemoveRange(stockrecs);
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

            var title = this.keywordTextBox.Text;
            string conditions = "";
            List<MySqlParameter> condition_params = new List<MySqlParameter>();

            if (title.Length > 0)
            {
                if (conditions.Length > 0)
                {
                    conditions += " AND ";
                }
                //conditions += "(`title`= @title)";
                conditions += "(`name`LIKE '%" + @title + "%')";
            }

            #region  new
            condition_params.Add(new MySqlParameter("@title", name));

            int limit = pager1.PageSize;
            int offset = (pager1.PageCurrent > 1 ? pager1.OffSet(pager1.PageCurrent - 1) : 0);
            int count = 0;
            using (var ctx = new DctsEntities())
            {
                if (conditions.Length > 0)
                {
                    conditions = " WHERE " + conditions;
                }

                string sqlCount = string.Format(" SELECT count(*) FROM Customer {0}", conditions);
                count = ctx.Database.SqlQuery<int>(sqlCount, condition_params.ToArray()).First();
                string sql = string.Format(" SELECT * FROM Customer {0} LIMIT {1} OFFSET {2}", conditions, limit, offset);
                CustomerList = ctx.Database.SqlQuery<Customer>(sql, condition_params.ToArray()).ToList();
                count = CustomerList.Count;

                sqlfilter = string.Format(" SELECT * FROM Customer " + conditions.Replace("@name", "'" + title.ToString() + "'"));

                sortabledinningsOrderList = new SortableBindingList<Customer>(CustomerList.ToList());
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



        private int pager1_EventPaging(EventPagingArg e)
        {

            int count = InitializeDataGridView(e.PageCurrent);
            return count;
        }

        private void 修改ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int i = this.dataGridView.CurrentRow.Index;
            Customer selectedItem = CustomerList[i];
            var form = new NewCustomerForm("Edit", selectedItem);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                InitializeDataGridView();
            }
        }

        private void btdown_Click(object sender, EventArgs e)
        {
            string strFileName = String.Empty;

            saveFileDialog1.FileName = "客户" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                strFileName = saveFileDialog1.FileName.ToString();
            }
            if (strFileName.Length > 0)
            {
                using (var ctx = new DctsEntities())
                {
                    string sql = BuildSql();

                    DataTable dataTable = ctx.DataTable(sql);
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        if (ComboLocationSchema.CustomterCnNameDictionary.ContainsKey(col.ColumnName))
                        {
                            col.ColumnName = ComboLocationSchema.CustomterCnNameDictionary[col.ColumnName];
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
            string title = (this.keywordTextBox.Text != NoOptionSelected ? this.keywordTextBox.Text : string.Empty);

            int count = 0;
            int pageSize = pager1.PageSize;

            using (var ctx = new DctsEntities())
            {
                //分页需要数据总数
                count = Count(title);

                var list = Paginate(ComboLocationEnum.Hotel, pageCurrent, pageSize, title);

                this.dataGridView.DataSource = list;
            }
            return count;
        }
        private static List<Customer> Paginate(ComboLocationEnum locationType, int currentPage = 1, int pageSize = 25, string title = "")
        {
            if (currentPage == 0)
            {
                currentPage = 1;
            }
            List<Customer> list = new List<Customer>();

            using (var ctx = new DctsEntities())
            {

                var query = ctx.Customers.Where(o => o.name != "");

                if (title.Length > 0)
                {
                    query = query.Where(o => o.name.Contains(title));
                }

                if (pageSize > 0)
                {
                    int offset = (currentPage - 1) * pageSize;
                    // order is required before skip
                    query = query.OrderBy(o => o.id).Skip(offset).Take(pageSize);
                }
                list = query.ToList();

            }
            return list;
        }
        private static int Count(string title)
        {
            int count = 0;
            using (var ctx = new DctsEntities())
            {
                var query = ctx.Customers.AsQueryable();

                if (title.Length > 0)
                {
                    query = query.Where(o => o.name.Contains(title));
                }
                count = query.Count();
            }
            return count;
        }
        // 根据当前选择条件，构造查询语句
        private string BuildSql()
        {

            string sql = string.Empty;

            var title = this.keywordTextBox.Text;
            string conditions = "";


            if (title.Length > 0)
            {
                conditions = conditions + " AND " + string.Format("(`name` like '%{0}%')", title);
            }

            if (conditions.Length > 0)
            {
                conditions = " WHERE " + conditions;
            }
            sql = string.Format(" SELECT * FROM Customers " + conditions);
            return sql;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = dataGridView.Columns[e.ColumnIndex];

            if (column == editColumn1)
            {
                var row = dataGridView.Rows[e.RowIndex];

                var model = row.DataBoundItem as Customer;

                var form = new NewCustomerForm("Edit", model);
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    BeginActive();
                }
            }
            else if (column == deleteColumn1)
            {
                var row = dataGridView.Rows[e.RowIndex];
                var model = row.DataBoundItem as Customer;
                string msg = string.Format("确定删除<{0}>？", model.name);

                if (MessageHelper.DeleteConfirm(msg))
                {
                    ComboLoactionBusiness.Customer_Delete(model.id);
                    BeginActive();
                }
            }



        }

        private void CustomersControl_Resize(object sender, EventArgs e)
        {  //                                                   id
            //name.Width = dataGridView.ClientSize.Width - 60 - 100 * 3 - 280 - 200 - 100 - 60 * 2 - 3;
            //是否包含滚动条
            //if (!(this.dataGridView.DisplayedRowCount(false) == this.dataGridView.RowCount))
            {
            //    name.Width -= 18;
            }

        }
    }
}
