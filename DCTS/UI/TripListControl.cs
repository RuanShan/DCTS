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
    using DCTS.Bus;
    using DCTS.Uti;

    public partial class TripListControl : UserControl, CustomControlInterface
    {
        public event EventHandler CommandRequestEvent;
  
        public TripListControl()
        {
            InitializeComponent();
            this.tripDataGridView.AutoGenerateColumns = false;
            
        }

        public void BeginActive()
        {
            InitializeTripDataGridView();
        }

        private void InitializeTripDataGridView()
        {
            int offset = 0;
            int pageSize = 5000;
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            //using (var ctx = new DctsEntities())
            {

                var query = ctx.Trips.OrderBy(o=>o.id).Skip(offset).Take(pageSize);
                var list = this.entityDataSource1.CreateView(query);
                tripDataGridView.DataSource = list;
            }

        }


        private void addTripButton_Click(object sender, EventArgs e)
        {
            var form = new NewTripForm();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                InitializeTripDataGridView();
            }
        }

        private void tripDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = tripDataGridView.Columns[e.ColumnIndex];

            if (column == editTripColumn1)
            {
                var row = tripDataGridView.Rows[e.RowIndex];
                var trip = row.DataBoundItem as Trip;

                var eventArgs = new CommandRequestEventArgs( CommandRequestEnum.EditTrip, trip.id );                 
                this.CommandRequestEvent(this, eventArgs);
             }
            else if (column == copyTripColumn1)
            {
                MessageBox.Show("copy");

            }
            else if (column == deleteTripColumn1)
            {
                var row = tripDataGridView.Rows[e.RowIndex];
                var trip = row.DataBoundItem as Trip;
                string msg = string.Format("确定删除行程<{0}>", trip.title);

                if (MessageHelper.DeleteConfirm(msg))
                {

                    TripBusiness.Delete(trip.id);

                    BeginActive();
                }
            }

        }

        private void exportWordButton_Click(object sender, EventArgs e)
        {
            new TripWordExporter(SelectedTripId).ExportWord();
        }


        private long SelectedTripId
        {
            get
            {
                long id = 0;
                var row = tripDataGridView.CurrentRow;
                if (row != null)
                {
                    var trip = row.DataBoundItem as Trip;
                    if (trip != null)
                    {
                        id = trip.id;
                    }
                }

                return id;
            }
        }

    }
}
