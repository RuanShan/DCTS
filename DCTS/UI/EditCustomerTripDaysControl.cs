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
using DCTS.Uti;
using DCTS.Bus;

namespace DCTS.UI
{
    public partial class EditCustomerTripDaysControl : UserControl
    {
        public event EventHandler CommandRequestEvent;

        public int ModelId { get; set; }

        public Trip Model { get; set; }
        List<TripDay> dayList;
        List<DayLocation> dayLocationList;
        ChooseLocaltionForm localtionForm;
        ComboLocation blankLocation;

        DateTimePicker dtp = new DateTimePicker();  //这里实例化一个DateTimePicker控件  
        Rectangle _Rectangle;  

        public EditCustomerTripDaysControl()
        {
            InitializeComponent();

            dayDataGridView.AutoGenerateColumns = false;
            dayDetailDataGridView.AutoGenerateColumns = false;
            //dayListView.Columns[0].Width = 0; //id
            //dayListView.Columns[0].Width = dayListView.ClientSize.Width;  // 第几天

            localtionForm = new ChooseLocaltionForm();

            var locationTypeList = GlobalCache.LocationTypeList;

            this.locationTypeColumn.DisplayMember = "FullName";
            this.locationTypeColumn.ValueMember = "Id";
            this.locationTypeColumn.DataSource = locationTypeList;


            dayDetailDataGridView.Controls.Add(dtp);  //把时间控件加入DataGridView  
            dtp.Visible = false;  //先不让它显示  
            dtp.ShowUpDown = true;
            dtp.Format = DateTimePickerFormat.Custom;  //设置日期格式为2010-08-05  
            dtp.CustomFormat = "HH:mm";
            dtp.TextChanged += new EventHandler(dtp_TextChange); //为时间控件加入事件dtp_TextChange  
        }

        public void BeginActive()
        {
            dayTitleColumn.Width = dayDataGridView.ClientSize.Width - 60 - 3;
            //                                                                        StartAt
            localtionTitleColumn.Width = dayDetailDataGridView.ClientSize.Width - 403-100;

            InitializeDataSource();

        }

        public void InitializeDataSource(int selectDay = 0, int selectLocationPosition = 0)
        {
            using (var ctx = new DctsEntities())
            {
                this.blankLocation = ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Blank).First();
                this.Model = ctx.Trips.Find(ModelId);
                this.dayList = ctx.TripDays.Where(o => o.trip_id == ModelId).OrderBy(o => o.day).ToList();
                this.dayLocationList = ctx.DayLocations.Include("ComboLocation").Where(o => o.trip_id == ModelId).OrderBy(o => o.day_id).ThenBy(o=>o.position).ToList();
                // 修正 dl.start_at, datagridview 确保显示时不为空，编辑时为datetimepicker控件。
                

                foreach (var dl in this.dayLocationList)
                {
                    var tripDay = dayList.Find(o => o.id == dl.day_id);
                    var datetime = Model.start_at.GetValueOrDefault().AddDays(tripDay.day - 1).Date;

                    if (dl.start_at == null)
                    {
                        dl.start_at = datetime;
                    }
                    else if (dl.start_at.Value.Date != datetime)
                    {
                        
                        dl.start_at = new DateTime( datetime.Year, datetime.Month, datetime.Day, dl.start_at.Value.Hour, dl.start_at.Value.Minute, 0);
                    }
                    ctx.SaveChanges();                                         
                }

            }

            var locations = this.dayLocationList.Select(o => o.ComboLocation).Distinct().ToList();
            this.localtionTitleColumn.DisplayMember = "title";
            this.localtionTitleColumn.ValueMember = "id";
            this.localtionTitleColumn.DataSource = locations;


            InitializeDayListBox(selectDay, selectLocationPosition);
        }

        public void InitializeDayListBox(int day = 0, int selectLocationPosition = 0)
        {
            this.pageTitleLabel.Text = string.Format("编辑行程<{0}>", Model.title);
            //List<MockEntity> list = new List<MockEntity>();
            //for (int i = 1; i <= Model.days; i++)
            //{
            //    list.Add(new MockEntity { Id = i, FullName = String.Format("第 {0} 天", i) });
            //}           
            //this.dayDataGridView.DataSource = null; //重置一下，添加dayLocation時需要更新 活动列表。
            this.dayDataGridView.DataSource = this.dayList;

            //http://stackoverflow.com/questions/6265228/selecting-a-row-in-datagridview-programmatically
            if (day > 0)
            {

                var cell = dayDataGridView.Rows[day - 1].Cells[0];
                dayDataGridView.CurrentCell = cell;
                dayDataGridView.Rows[day - 1].Selected = true;
            }

            if (selectLocationPosition > 0)
            {
                if (selectLocationPosition <= this.dayDetailDataGridView.RowCount)
                {
                    dayDetailDataGridView.CurrentCell = dayDetailDataGridView.Rows[selectLocationPosition - 1].Cells[0];
                    dayDetailDataGridView.Rows[selectLocationPosition - 1].Selected = true;
                }
            }
            this.selectDayTextBox.Text = day.ToString();
            this.selectedLocationTextBox.Text = selectLocationPosition.ToString();
        }

        public void InitializeDayDetailListBox( int dayId )
        {
            var dayLocations = this.dayLocationList.Where(o => o.day_id == dayId).OrderBy(o => o.position).ToList();
            dayDetailBindingSource.DataSource = dayLocations;
            this.dayDetailDataGridView.DataSource = dayDetailBindingSource;

        }


        private void backLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var eventArgs = new CommandRequestEventArgs(CommandRequestEnum.CustomerTripList);
            this.CommandRequestEvent(this, eventArgs);
        }

        private void dayListBox_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void addLocationButton_Click(object sender, EventArgs e)
        {
            if (localtionForm.ShowDialog() == DialogResult.Yes)
            {
                if (localtionForm.SelectedLocation != null)
                {
                    var tripDay = GetSelectedTripDay();
                    int locationId = localtionForm.SelectedLocation.id;
                    TripBusiness.AddLocation(tripDay.id, locationId);
                    InitializeDataSource(tripDay.day);
                }
            
            }
        }

        private void addDayButton_Click(object sender, EventArgs e)
        {
            int day = GetSelectedDay();
            TripBusiness.AddDay(ModelId, day);

            InitializeDataSource(day+1);

        }

        private void delDayButton_Click(object sender, EventArgs e)
        {

            var tripDay = GetSelectedTripDay();
            if (tripDay != null)
            {
                if (MessageHelper.DeleteConfirm(string.Format("确定删除<第{0}天>吗？", tripDay.day)))
                {
                    TripBusiness.DeleteDay(tripDay.id);
                    InitializeDataSource(tripDay.day - 1);
                }
            }
        }

        //https://msdn.microsoft.com/en-us/library/system.windows.forms.datagridview.currentcell.aspx
        //When you change the value of this property, the SelectionChanged event occurs before the CurrentCellChanged event. Any SelectionChanged event handler accessing the CurrentCell property at this time will get its previous value.
        private void dayDataGridView_SelectionChanged(object sender, EventArgs e)
        {

        }




        private void moveUpButton_Click(object sender, EventArgs e)
        {
            var day = GetSelectedDay();
            var dayLocation = GetSelectedDayLocation();
            if (dayLocation.position > 1)
            {
                 
                int newPosition =  dayLocation.position -1;
                TripBusiness.UpdateDayLocationPosition(dayLocation.id, newPosition);
                InitializeDataSource(day,newPosition );
                 
            }
        }



        private void moveDownButton_Click(object sender, EventArgs e)
        {
            var day = GetSelectedDay();
            var dayLocation = GetSelectedDayLocation();
            int maxPosition = dayDetailDataGridView.RowCount;
            if (dayLocation.position < maxPosition)
            {

                int newPosition =  dayLocation.position +1;

                TripBusiness.UpdateDayLocationPosition(dayLocation.id, newPosition);
                InitializeDataSource(day, newPosition);
                
            }
        }


        private DayLocation GetSelectedDayLocation()
        {
            DayLocation dayLocation = null;
            var row = dayDetailDataGridView.CurrentRow;
            if (row != null)
            {
                dayLocation = row.DataBoundItem as DayLocation;
            }
            return dayLocation;
        }

        private int GetSelectedDay()
        {
            int day = 0;
            var row = dayDataGridView.CurrentRow;
            if (row != null)
            {
                var dayTrip = row.DataBoundItem as TripDay;
                day = dayTrip.day;
            }
            return day;
        }

        private void moveDayUpButton_Click(object sender, EventArgs e)
        {
            var day = GetSelectedDay();
            if (day > 1)
            {
                int newDay = day-1;
                TripBusiness.MoveDayPosition(ModelId, day, newDay);
                InitializeDataSource(newDay);
            }
        }

        private void moveDayDownButton_Click(object sender, EventArgs e)
        {
            var day = GetSelectedDay();
            if (day < this.Model.days)
            {
                int newDay = day + 1;
                TripBusiness.MoveDayPosition(ModelId, day, newDay);
                InitializeDataSource(newDay);
            }
        }

        private void removeLocationButton_Click(object sender, EventArgs e)
        {
            var day = GetSelectedDay();
            var dayLocation = GetSelectedDayLocation();
            if (dayLocation != null)
            {
                TripBusiness.DeleteDayLocation(dayLocation.id);
                InitializeDataSource(day);
            }
        }

        private void selectDayTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void addBlankButton_Click(object sender, EventArgs e)
        {          
            var tripDay = GetSelectedTripDay();            
            TripBusiness.AddLocation(tripDay.id, this.blankLocation.id);
            InitializeDataSource(tripDay.day);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var eventArgs = new CommandRequestEventArgs(CommandRequestEnum.CustomerTripList);
            this.CommandRequestEvent(this, eventArgs);
  
        }


        private TripDay GetSelectedTripDay()
        {
            TripDay tripDay = null;

            var row = dayDataGridView.CurrentRow;
            if (row != null)
            {
                tripDay = row.DataBoundItem as TripDay;                
            }
            return tripDay;
        }

        private void dayDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            var tripDay = GetSelectedTripDay();
            if (tripDay != null)
            {
                Console.WriteLine("dayDataGridView_CurrentCellChanged day= " + tripDay.day.ToString());
                InitializeDayDetailListBox(tripDay.id);

            }
        }

        private void dayDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tripDay = GetSelectedTripDay();
            if (tripDay != null)
            {
                var editDayForm = new EditCustomerTripDayForm(tripDay.id);

                if (editDayForm.ShowDialog() == DialogResult.Yes)
                {
                    InitializeDataSource(tripDay.day);
                }
            }
        }

        private void editLocationButton_Click(object sender, EventArgs e)
        {
            
            var dayLocation = GetSelectedDayLocation();
            if (dayLocation != null)
            {

            }
        }

        #region 每天行程详细中的时间空件

        /****************单元格被单击，判断是否是放时间控件的那一列*******************/
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dayDetailDataGridView.Columns[e.ColumnIndex] == dayStartAtColumn)
            {
                _Rectangle = dayDetailDataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //得到所在单元格位置和大小  
                dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height); //把单元格大小赋给时间控件  
                dtp.Location = new Point(_Rectangle.X, _Rectangle.Y); //把单元格位置赋给时间控件  
                dtp.Value = (DateTime)dayDetailDataGridView.CurrentCell.Value;
                dtp.Visible = true;  //可以显示控件了  
            }
            else
                dtp.Visible = false;
        }

        /*************时间控件选择时间时****************/
        private void dtp_TextChange(object sender, EventArgs e)
        {
            dayDetailDataGridView.CurrentCell.Value = dtp.Value;  //时间控件选择时间时，就把时间赋给所在的单元格 
            var dlv = dayDetailDataGridView.CurrentCell.OwningRow.DataBoundItem as  DayLocation;
            var ctx = this.entityDataSource1.DbContext as DctsEntities;

            DayLocation location = ctx.DayLocations.Find(dlv.id);
            location.start_at = dtp.Value;
            ctx.SaveChangesAsync();
            //更新 .dayLocationList 中相应对象的值，以便刷新时， 保证时间是修改后的值。

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
        #endregion

    }
}
