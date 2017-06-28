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
        //http://blog.csdn.net/jasonleesjtu/article/details/7584857   C# 为DataGridView的一个列加入DateTimePicker控件
        DateTimePicker dtp = new DateTimePicker();  //这里实例化一个DateTimePicker控件  
        Rectangle _Rectangle;  

        public EditCustomerTripDayForm(int id)
        {
            InitializeComponent();
            this.scheduleDataGridView.AutoGenerateColumns = false;
            ModelId = id;
            deletedScheduleList = new List<Schedule>();

            scheduleDataGridView.Controls.Add(dtp);  //把时间控件加入DataGridView  
            dtp.Visible = false;  //先不让它显示  
            dtp.ShowUpDown = true;
            dtp.Format = DateTimePickerFormat.Custom;  //设置日期格式为2010-08-05  
            dtp.CustomFormat = "HH:mm";
            dtp.TextChanged += new EventHandler(dtp_TextChange); //为时间控件加入事件dtp_TextChange  
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;

            this.FillModelByForm(this.Model);
            ctx.Schedules.RemoveRange(deletedScheduleList);
            ctx.Schedules.AddRange( scheduleList.Where(o=>o.id == 0).ToArray() );
            ctx.SaveChanges();
            this.Close();
        }

        private void EditTripForm_Load(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;

            this.Model = ctx.TripDays.Find(ModelId);
            this.FillFormByModel(this.Model);
            this.Text = string.Format("编辑<{0}>", Model.title);
            this.formLabel.Text = this.Text;
        }

        // 初始化DataGridView的数据源, 分页事件调用
        private int InitializeDataGridView(int pageCurrent = 1)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;

            scheduleList = ctx.Schedules.Where(o => o.tripday_id == ModelId).ToList();

            bindingSource1.DataSource = new SortableBindingList<Schedule>(this.scheduleList);
            bindingSource1.Sort = "start_at";
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
                if (list.Count > 0)
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

            //读取图片位置
            using (var ctx = new DctsEntities())
            {
                var query = ctx.LocationImages.Where(o => o.id == Model.cover_id);
                if (query != null && query.ToList().Count > 0)
                {
                    string ImageLocation = EntityPathConfig.newlocationimagepath(query.ToList()[0]);
                    imgPathTextBox.Text = query.ToList()[0].name;
                    pictureBox1.ImageLocation = ImageLocation;
                }

            }

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
            var startAt = trip.start_at.Value.AddDays(this.Model.day - 1);
            Schedule newSchedule = new Schedule() { tripday_id = Model.id, start_at = startAt, created_at = DateTime.Now };
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
                if (idx < bindingSource1.Count - 1)
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
            var form = new SelectSystemfile();
            form.ShowDialog();
            {
                List<string> reference = form.listfile;
                if (reference.Count > 0)
                {
                    imgPathTextBox.Text = reference[0];
                    pictureBox1.ImageLocation = reference[1];
                }
            }
        }


        /*************时间控件选择时间时****************/
        private void dtp_TextChange(object sender, EventArgs e)
        {
            scheduleDataGridView.CurrentCell.Value = dtp.Value;  //时间控件选择时间时，就把时间赋给所在的单元格  
        }

        /****************单元格被单击，判断是否是放时间控件的那一列*******************/
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                _Rectangle = scheduleDataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //得到所在单元格位置和大小  
                dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height); //把单元格大小赋给时间控件  
                dtp.Location = new Point(_Rectangle.X, _Rectangle.Y); //把单元格位置赋给时间控件  
                dtp.Value = (DateTime)scheduleDataGridView.CurrentCell.Value;
                dtp.Visible = true;  //可以显示控件了  
            }
            else
                dtp.Visible = false;
        }

        /***********当列的宽度变化时，时间控件先隐藏起来，不然单元格变大时间控件无法跟着变大哦***********/
        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;

        }

        /***********滚动条滚动时，单元格位置发生变化，也得隐藏时间控件，不然时间控件位置不动就乱了********/
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }  
  
    }
}
