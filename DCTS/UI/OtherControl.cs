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
    public partial class OtherControl : UserControl
    {
        private Hashtable dataGridChanges = null;
        private static string NoOptionSelected = "所有";
        private List<ComboLocation> nationlList = null;
        private SortableBindingList<ComboLocation> sortabledinningsOrderList;
        int RowRemark = 0;
        string sqlfilter = "";
        public OtherControl()
        {
            InitializeComponent();
            this.dataGridChanges = new Hashtable();
            dataGridView.AutoGenerateColumns = false;
        }

        public void BeginActive()
        {
            InitializeDataGridView();
        }
        
        private void newButton_Click(object sender, EventArgs e)
        {
            var form = new NewNationForm("create", null);
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

        private void 修改ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int i = this.dataGridView.CurrentRow.Index;
            ComboLocation selectedItem = nationlList[i];
            var form = new NewNationForm("Edit", selectedItem);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                InitializeDataGridView();
            }
        }

        private void btdown_Click(object sender, EventArgs e)
        {

            string strFileName = String.Empty;


            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择下载路径";


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                strFileName = dialog.SelectedPath;
            }

            if (strFileName.Length > 0)
            {
                using (var ctx = new DctsEntities())
                {
                    List<ComboLocation> list = ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Country && o.nation != null).ToList();
                    foreach (ComboLocation item in list)
                    {
                        string copyToPath = EntityPathConfig.TripWordFilePath(item.id);
                        if (File.Exists(copyToPath))
                            File.Copy(copyToPath, strFileName + "\\" + item.id.ToString() + ".docx");
                    }
                }
            }
            MessageBox.Show("下载完成！");

        }

        // 初始化DataGridView的数据源, 
        private int InitializeDataGridView(int pageCurrent = 1)
        {
            string title = (this.keywordTextBox.Text != NoOptionSelected ? this.keywordTextBox.Text : string.Empty);

            int[] otherLocationType = { (int)ComboLocationEnum.Letter, (int)ComboLocationEnum.Preparation, (int)ComboLocationEnum.Google };


            using (var ctx = new DctsEntities())
            {
                List<ComboLocation> list = ctx.ComboLocations.Where(o => otherLocationType.Contains( o.ltype )).ToList();
                  
                // var list = Paginate(pageCurrent, pageSize, title);

                this.dataGridView.DataSource = list;
            }
            return 1;
        }
        private static int Count(ComboLocationEnum locationType, string title)
        {
            int count = 0;
            using (var ctx = new DctsEntities())
            {
                var query = ctx.ComboLocations.AsQueryable();
                if ((int)locationType > 0)
                {
                    query = query.Where(o => o.ltype == (int)ComboLocationEnum.Country);

                }

                if (title.Length > 0)
                {
                    query = query.Where(o => o.nation.Contains(title));
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
                conditions = conditions + " AND " + string.Format("(`nation` like '%{0}%')", title);
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

            if (column == this.downloadColumn1)
            {
                var row = dataGridView.Rows[e.RowIndex];

                var model = row.DataBoundItem as ComboLocation;

                var form = new NewNationForm("Edit", model);
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    BeginActive();
                }
            }
            else if (column == this.uploadColumn1)
            {
                var row = dataGridView.Rows[e.RowIndex];
                var model = row.DataBoundItem as ComboLocation;
                string msg = string.Format("确定删除<{0}>？", model.title);

                if (MessageHelper.DeleteConfirm(msg))
                {
                    ComboLoactionBusiness.Delete(model.id);
                    BeginActive();
                }
            }



        }

        private void NationsControl_Resize(object sender, EventArgs e)
        {  //                                                   id
            nationColumn1.Width = dataGridView.ClientSize.Width - 60 - 100 * 3 - 280 - 200 - 100 - 60 * 2 - 3;
            //是否包含滚动条
            if (!(this.dataGridView.DisplayedRowCount(false) == this.dataGridView.RowCount))
            {
                nationColumn1.Width -= 18;
            }

        }
    }
}
