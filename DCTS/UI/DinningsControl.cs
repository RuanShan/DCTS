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

namespace DCTS.UI
{
    public partial class DinningsControl : UserControl
    {
        int RowRemark = 0;
        public DinningsControl()
        {
            InitializeComponent();
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

                var query = ctx.Dinings.OrderBy(o => o.id).Skip(offset).Take(pageSize);
                var list = this.entityDataSource1.CreateView(query);
                this.dataGridView.DataSource = list;
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
            if (RowRemark >= dataGridView.Rows.Count)
            {
                RowRemark = RowRemark - 1;
            }
            string candianmingcheng = this.dataGridView.Rows[RowRemark].Cells["titleColumn1"].EditedFormattedValue.ToString();
            var oids = GetOrderIdsBySelectedGridCell();
            using (var ctx = new DctsEntities())
            {
                var stockrecs = (from s in ctx.Dinings
                                 where oids.Contains(s.id)
                                 select s).ToList();
                ctx.Dinings.RemoveRange(stockrecs);
                ctx.SaveChanges();

                //deletedCount = stockrecs.Count;
                //this.stockList.RemoveAll(s => deletedStockNumList.Contains(s.納品書番号));

            }
            InitializeDataGridView();
        }
        private List<long> GetOrderIdsBySelectedGridCell()
        {

            List<long> order_ids = new List<long>();
            var rows = GetSelectedRowsBySelectedCells(dataGridView);
            foreach (DataGridViewRow row in rows)
            {
                var Diningorder = row.DataBoundItem as Dining;
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

    }
}
