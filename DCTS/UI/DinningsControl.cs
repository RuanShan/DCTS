using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

                var query = ctx.Scenics.OrderBy(o => o.id).Skip(offset).Take(pageSize);
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
            //string Caipiaomingcheng = this.label2.Text.ToString();
            //clsAllnew BusinessHelp = new clsAllnew();

            //BusinessHelp.delete_CaiPiaoData(QiHao, Caipiaomingcheng);
            InitializeDataGridView();
        }
    }
}
