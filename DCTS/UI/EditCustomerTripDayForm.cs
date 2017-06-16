using DCTS.CustomComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCTS.DB;

namespace DCTS.UI
{
    public partial class EditCustomerTripDayForm : BaseModalForm
    {
        public int ModelId { get; set; }
        TripDay Model { get; set; }
        List<Schedule> scheduleList;
        List<Schedule> deletedScheduleList;

        public EditCustomerTripDayForm(int id)
        {
            InitializeComponent();
            this.scheduleDataGridView.AutoGenerateColumns = false;
            ModelId = id;
            deletedScheduleList = new List<Schedule>();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;

            this.FillModelByForm(this.Model);
            ctx.Schedules.RemoveRange(deletedScheduleList);
            ctx.Schedules.AddRange(scheduleList.Where(o => o.id == 0));
            ctx.SaveChanges();
            this.Close();
        }

        private void EditTripForm_Load(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;

            this.Model = ctx.TripDays.Find(ModelId);
            this.FillFormByModel(this.Model);
            this.Text = string.Format("编辑<{0}>", Model.title);
        }

        // 初始化DataGridView的数据源, 分页事件调用
        private int InitializeDataGridView(int pageCurrent = 1)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;

            scheduleList = ctx.Schedules.Where(o => o.tripday_id == ModelId).ToList();

            bindingSource1.DataSource = this.scheduleList;
            this.scheduleDataGridView.DataSource = bindingSource1;
            
            return 0;
        }

        public void FillModelByForm(TripDay tripDay)
        {
            Model.title = this.titleTextBox.Text;

            Model.tips = this.tipsTextBox.Text;
            using (var ctx = new DctsEntities())
            {
                var location = ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.PageImage).First();
                var query = ctx.LocationImages.Where(o => o.location_id == (int)location.id && o.name == imgPathTextBox.Text);
                List<LocationImage> list = query.ToList();
                Model.cover_id = list[0].id;
            }
            Model = tripDay;
            //  trip.schedule = this.scheduleTextBox.Text;
        }

        public void FillFormByModel(TripDay tripDay)
        {
            Model = tripDay;
            this.titleTextBox.Text = Model.title;
            this.tipsTextBox.Text = Model.tips;
            //this.scheduleTextBox.Text = trip.schedule;
            InitializeDataGridView();

        }

        private void EditCustomerTripDayForm_Resize(object sender, EventArgs e)
        {
            titleColumn.Width = scheduleDataGridView.ClientSize.Width - 140 - 3;

        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var trip = this.Model.Trip;
            var startAt = trip.start_at.Value.AddDays( this.Model.day -1 );
            Schedule newSchedule = new Schedule() { tripday_id= Model.id, start_at = startAt, created_at = DateTime.Now };
            this.bindingSource1.Add(newSchedule);
            this.scheduleDataGridView.Refresh();
        }

        private void delScheduleButton_Click(object sender, EventArgs e)
        {
            var schedule = GetSelectedSchedule();

            if (schedule != null)
            {
                deletedScheduleList.Add(schedule);
                bindingSource1.Remove(schedule);
                this.scheduleDataGridView.Refresh();
            }

        }


        private Schedule GetSelectedSchedule()
        {
            Schedule schedule = null;
            var row = scheduleDataGridView.CurrentRow;
            if (row != null)
            {
                schedule = row.DataBoundItem as Schedule;
            }
            return schedule;
        }

        private void moveUpButton2_Click(object sender, EventArgs e)
        {
            var schedule = GetSelectedSchedule();

            if (schedule != null)
            {
                int idx = bindingSource1.IndexOf(schedule);
                if (idx > 0)
                {
                    bindingSource1.Remove(schedule);
                    bindingSource1.Insert(idx - 1, schedule);
                    this.bindingSource1.Position = idx - 1;
                    this.scheduleDataGridView.Refresh();
                }
            }
        }

        private void moveDownButton1_Click(object sender, EventArgs e)
        {
            var schedule = GetSelectedSchedule();

            if (schedule != null)
            {
                int idx = bindingSource1.IndexOf(schedule);
                if (idx < bindingSource1.Count-1)
                {
                    bindingSource1.Remove(schedule);
                    bindingSource1.Insert(idx + 1, schedule);
                    this.bindingSource1.Position = idx + 1;
                    this.scheduleDataGridView.Refresh();
                }
            }
        }

        private void findFileButton_Click(object sender, EventArgs e)
        {
            var form = new ImportSystemfile();
            form.ShowDialog();         
            {
                List<string> reference = form.listfile;
                imgPathTextBox.Text = reference[0];
                pictureBox1.ImageLocation = reference[1];
            }
        }
    }
}
