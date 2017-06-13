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
using System.Collections;
using DCTS.Uti;
using DCTS.Bus;

namespace DCTS.UI
{
    public partial class TripDayFormControl : UserControl
    {
        private Hashtable dataGridChanges = null;
        private static string NoOptionSelected = "所有";
        TripDay TripItem;

        public TripDayFormControl()
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;

        }
        public void BeginActive()
        {

        }
        public void FillModelByForm(TripDay trip)
        {
            trip.title = this.titleTextBox.Text;

            trip.tips = this.tipsTextBox.Text;
            TripItem = trip;

            //  trip.schedule = this.scheduleTextBox.Text;

        }

        public void FillFormByModel(TripDay trip)
        {
            TripItem = trip;
            this.titleTextBox.Text = trip.title;
            this.tipsTextBox.Text = trip.tips;
            //this.scheduleTextBox.Text = trip.schedule;
            InitializeDataGridView();


        }
        
        private void TripDayFormControl_Load(object sender, EventArgs e)
        {

        }
        
        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var ctx = this.entityDataSource2.DbContext as DctsEntities;
            if (ctx != null && e.RowIndex>-1)
            {        
                var row = dataGridView.Rows[e.RowIndex];
                var model = row.DataBoundItem as Schedule;
                using (var ctx1 = new DctsEntities())
                {
                    Schedule obj = ctx1.Schedules.Find(Convert.ToInt32(model.id));
                    obj.title = model.title;
                    obj.tripday_id = model.tripday_id;
                    obj.start_at = model.start_at;
                    obj.updated_at = DateTime.Now;
                    ctx1.SaveChanges();
                }
            }
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        // 初始化DataGridView的数据源, 分页事件调用
        private int InitializeDataGridView(int pageCurrent = 1)
        {
            int count = 0;

            using (var ctx = new DctsEntities())
            {

                var list = ctx.Schedules.Where(o => o.tripday_id == TripItem.id);

                this.dataGridView.DataSource = list;
            }
            return count;
        }
        private static int Count(int tyid, string title)
        {
            int count = 0;
            using (var ctx = new DctsEntities())
            {
                var query = ctx.Schedules.AsQueryable();
                if (tyid > 0)
                {
                    query = query.Where(o => o.tripday_id == tyid);

                }

                if (title.Length > 0)
                {
                    query = query.Where(o => o.title.Contains(title));
                }
                count = query.Count();
            }
            return count;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            if (TripItem == null || TripItem.trip_id == null)
                return;

            var form = new NewScheduleForm("create", null, TripItem);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                InitializeDataGridView();
            }
        }
        
        private void TripDayFormControl_Resize(object sender, EventArgs e)
        {
            //                                                   id
            titleColumn1.Width = dataGridView.ClientSize.Width - 60 - 100 * 3 - 280 - 200 - 100 - 60 * 2 - 3;
            //是否包含滚动条
            if (!(this.dataGridView.DisplayedRowCount(false) == this.dataGridView.RowCount))
            {
                titleColumn1.Width += 158;
            }

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = dataGridView.Columns[e.ColumnIndex];

       
            if (column == deleteColumn1)
            {
                var row = dataGridView.Rows[e.RowIndex];
                var model = row.DataBoundItem as Schedule;
                string msg = string.Format("确定删除国家<{0}>？", model.title);

                if (MessageHelper.DeleteConfirm(msg))
                {
                    ComboLoactionBusiness.Schedules_Delete(model.id);
                    BeginActive();
                }
            }
        }



        private void btfind_Click(object sender, EventArgs e)
        {

        }

    }
}
