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
    public partial class AirportControl : UserControl
    {
        private Hashtable dataGridChanges = null;
        private static string NoOptionSelected = "所有";
        private List<ComboLocation> nationlList = null;
        private SortableBindingList<ComboLocation> sortabledinningsOrderList;
        int RowRemark = 0;
        string sqlfilter = "";
        public AirportControl()
        {
            InitializeComponent();
            this.dataGridChanges = new Hashtable();
            // pager1.Bind();
            dataGridView.AutoGenerateColumns = false;
            pager1.PageCurrent = 1;
        }

        public void BeginActive()
        {
            pager1.Bind();

        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var form = new NewAirportForm("create", null);
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
            if (dataGridView.Columns[e.ColumnIndex] == this.word)
            {
                if (nationlList != null && e.RowIndex < nationlList.Count)
                {

                    ComboLocation selectedItem = dataGridView.Rows[e.RowIndex].DataBoundItem as ComboLocation;

                    long folername = selectedItem.id / 1000;
                    if (selectedItem.img != null && selectedItem.img != "")
                    {

                        string lcoalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\data\\export\\words" + "\\" + folername + "\\", selectedItem.img);
                        e.Value = lcoalPath;
                    }
                }
            }

            #endregion

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
         
        // 初始化DataGridView的数据源, 分页事件调用
        private int InitializeDataGridView(int pageCurrent = 1)
        {
            string title = (this.keywordTextBox.Text != NoOptionSelected ? this.keywordTextBox.Text : string.Empty);

            int count = 0;
            int pageSize = pager1.PageSize;

            using (var ctx = new DctsEntities())
            {
                //分页需要数据总数
                count = Count(ComboLocationEnum.Flight, title);

                var list = Paginate(pageCurrent, pageSize, title);

                this.dataGridView.DataSource = list;
            }
            return count;
        }
        private static int Count(ComboLocationEnum locationType, string title)
        {
            int count = 0;
            using (var ctx = new DctsEntities())
            {
                var query = ctx.ComboLocations.AsQueryable();
                if ((int)locationType > 0)
                {
                    query = query.Where(o => o.ltype == (int)ComboLocationEnum.Flight);

                }

                if (title.Length > 0)
                {
                    query = query.Where(o => o.nation.Contains(title));
                }
                count = query.Count();
            }
            return count;
        }
        private static List<ComboLocation> Paginate(int currentPage = 1, int pageSize = 25, string title = "")
        {
            // 如果数据为0，分页控件，设置currentPage = 0; 这回导致下面查询异常
            if (currentPage <= 0)
            {
                currentPage = 1;
            }
            List<ComboLocation> list = new List<ComboLocation>();

            using (var ctx = new DctsEntities())
            {

                var query = ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Airport && o.title != null);


                if (title.Length > 0)
                {
                    query = query.Where(o => o.title.Contains(title));
                }

                if (pageSize > 0)
                {
                    int offset = (currentPage - 1) * pageSize;

                    query = query.OrderBy(o => o.id).Skip(offset).Take(pageSize);
                }
                list = query.ToList();

            }
            return list;
        }

        // 根据当前选择条件，构造查询语句
        private string BuildSql()
        {

            string sql = string.Empty;
            var title = this.keywordTextBox.Text;
            string conditions = "";

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

                var form = new NewAirportForm("Edit", model);
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    BeginActive();
                }
            }
            else if (column == deleteColumn1)
            {
                var row = dataGridView.Rows[e.RowIndex];
                var model = row.DataBoundItem as ComboLocation;
                string msg = string.Format("确定删除机场<" + model.title + ">？", model.nation);

                if (MessageHelper.DeleteConfirm(msg))
                {
                    ComboLoactionBusiness.Delete(model.id);
                    BeginActive();
                }
            }
            if (column == this.uploadColumn1)
            {
                var row = dataGridView.Rows[e.RowIndex];
                string strFileName = String.Empty;

                var model = row.DataBoundItem as ComboLocation;
                //openFileDialog1.Filter = "DOCX(*.doc,*.docx)|*.doc;*.docx"; //文件类型
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    strFileName = openFileDialog1.FileName;
                }


                if (strFileName.Length > 0)
                {
                    using (var ctx = new DctsEntities())
                    {
                        ComboLocation lastLocation = ctx.ComboLocations.OrderByDescending(o => o.id).FirstOrDefault();
                        if (lastLocation != null)
                        {
                            long newId = lastLocation.id + 1;

                            long idStart = newId / 1000 * 1000;
                            long idEnd = idStart + 1000;
                            bool existSamedoc = (ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Flight && o.word == openFileDialog1.SafeFileName && o.id > idStart && o.id < idEnd).Count() > 0);
                            if (existSamedoc)
                            {
                                MessageBox.Show(string.Format("文件名<" + openFileDialog1.SafeFileName + ">已在, 请使用其他文件名！", model.word));
                                return;
                            }
                        }
                        bool hasDoc = (openFileDialog1.FileName.Length > 0);
                        string docFilePath = this.openFileDialog1.FileName;

                        ComboLocation obj = ctx.ComboLocations.Find(Convert.ToInt32(model.id));
                        obj.title = model.title;
                        obj.ltype = model.ltype;
                        obj.tips = model.tips;
                        obj.word = openFileDialog1.SafeFileName;
                        if (hasDoc)
                        {

                            string copyToPath = EntityPathConfig.LocationWordPath(obj);
                            if (!File.Exists(copyToPath))
                                File.Copy(docFilePath, copyToPath, true);
                        }
                        ctx.SaveChanges();
                    }
                }
                BeginActive();

            }
            else if (column == this.downloadColumn1)
            {
                string strFileName = String.Empty;

                var row = dataGridView.Rows[e.RowIndex];
                var model = row.DataBoundItem as ComboLocation;

                saveFileDialog1.FileName = model.word;
                if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    strFileName = saveFileDialog1.FileName.ToString();
                }

                if (strFileName.Length > 0)
                {
                    using (var ctx = new DctsEntities())
                    {
                        List<ComboLocation> list = ctx.ComboLocations.Where(o => o.ltype == model.ltype && o.nation == model.nation).ToList();
                        foreach (ComboLocation item in list)
                        {
                            string copyToPath = EntityPathConfig.LocationWordPath(item);
                            if (File.Exists(copyToPath))
                            {
                                File.Copy(copyToPath, strFileName);
                                MessageBox.Show("下载完成！");
                            }
                        }
                    }
                }
            }


        }

        private void NationsControl_Resize(object sender, EventArgs e)
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
