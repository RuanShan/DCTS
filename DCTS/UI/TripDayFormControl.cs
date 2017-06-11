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
        int trip_Id = 0;
        TripDay TripItem;

        public TripDayFormControl()
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            pager1.PageCurrent = 1;

        }
        public void BeginActive()
        {
            pager1.Bind();

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
            string title = (this.keywordTextBox.Text != NoOptionSelected ? this.keywordTextBox.Text : string.Empty);

            int count = 0;
            int pageSize = pager1.PageSize;

            using (var ctx = new DctsEntities())
            {
                //分页需要数据总数
                count = Count(TripItem.id, title);

                var list = Paginate(pageCurrent, pageSize, title);

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
        private static List<Schedule> Paginate(int currentPage = 1, int pageSize = 25, string title = "")
        {
            // 如果数据为0，分页控件，设置currentPage = 0; 这回导致下面查询异常
            if (currentPage <= 0)
            {
                currentPage = 1;
            }
            List<Schedule> list = new List<Schedule>();

            using (var ctx = new DctsEntities())
            {

                var query = ctx.Schedules.Where(o => o.tripday_id != null);


                if (title.Length > 0)
                {
                    query = query.Where(o => o.title.Contains(title));
                }

                if (pageSize > 0)
                {
                    int offset = (currentPage - 1) * pageSize;

                    query = query.OrderBy(o => o.start_at).Skip(offset).Take(pageSize);
                }
                list = query.ToList();

            }
            return list;
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

        private int pager1_EventPaging(CustomComponents.EventPagingArg e)
        {
            int count = InitializeDataGridView(e.PageCurrent);
            return count;
        }

        private void btfind_Click(object sender, EventArgs e)
        {
            pager1.PageCurrent = 1;
            pager1.Bind();
        }

    }
}
