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

namespace DCTS.UI
{
    public partial class DinningsControl : UserControl
    {
        private Hashtable dataGridChanges = null;

        private SortableBindingList<ComboLocation> sortabledinningsOrderList;
        int RowRemark = 0;
        //private List<ComboLocation> dinningsOrderList;
        IBindingList dinningsOrderList = null;
        public DinningsControl()
        {
            InitializeComponent();
            this.dataGridChanges = new Hashtable();
        }

        public void BeginActive()
        {
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            int offset = 0;
            int pageSize = 5000;
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            //using (var ctx = new DctsEntities())
            {

                var query = ctx.ComboLocations.OrderBy(o => o.id).Skip(offset).Take(pageSize);
                var list = this.entityDataSource1.CreateView(query);
                sortabledinningsOrderList = new SortableBindingList<ComboLocation>(query.ToList());
                this.bindingSource1.DataSource = this.sortabledinningsOrderList;
                dataGridView.DataSource = this.bindingSource1;

            }

        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var form = new NewDinningsForm();
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
            ApplyFilter();

        }
        private void ApplyFilter()
        {
            string filter = "";
            if (this.textBox1.Text.Length > 0)
            {
                //filter += "(餐厅名称=" + this.textBox1.Text + ")";
                 filter += " (餐厅名称 ='" + this.textBox1.Text + "')";
             
            }
            if (this.comboBox2.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                //filter += "(国家=" + this.comboBox2.Text + ")";
                filter += "(国家 =" + "'" + comboBox3.Text + "'" + ")";
            }
            if (this.comboBox3.Text.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter += " AND ";
                }
                //filter += "(城市=" + this.comboBox3.Text + ")";
                filter += "(城市 =" + "'" + comboBox3.Text + "'" + ")";
            }
 
            this.bindingSource1.Filter = filter;
 
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new NewDinningsForm();
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
      

    }
}
