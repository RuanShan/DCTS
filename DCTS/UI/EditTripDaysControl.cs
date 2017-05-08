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
    public partial class EditTripDaysControl : UserControl
    {
        public event EventHandler CommandRequestEvent;

        public int ModelId { get; set; }

        public Trip Model { get; set; }
        List<TripDay> dayList;
        List<DayLocation> dayLocationList;
        ChooseLocaltionForm localtionForm;
        
        public EditTripDaysControl()
        {
            InitializeComponent();

            dayDataGridView.AutoGenerateColumns = false;
            dayDetailDataGridView.AutoGenerateColumns = false;
            //dayListView.Columns[0].Width = 0; //id
            //dayListView.Columns[0].Width = dayListView.ClientSize.Width;  // 第几天

            localtionForm = new ChooseLocaltionForm();

            var locationTypeList = new []{ 
                new { Id = (int)ComboLocationEnum.Blank, FullName = "空白页" },
                new { Id = (int)ComboLocationEnum.Scenic, FullName = "景点" },
                new { Id = (int)ComboLocationEnum.Hotel, FullName = "住宿" },
                new { Id = (int)ComboLocationEnum.Dining, FullName = "餐厅" }}.ToList();

            this.locationTypeColumn.DisplayMember = "FullName";
            this.locationTypeColumn.ValueMember = "Id";
            this.locationTypeColumn.DataSource = locationTypeList;
        }

        public void BeginActive()
        {
            dayTitleColumn.Width = dayDataGridView.ClientSize.Width - 60 - 3;
            localtionTitleColumn.Width = dayDetailDataGridView.ClientSize.Width - 403;

            InitializeDataSource();

        }

        public void InitializeDataSource(int selectDay = 0, int selectLocationPosition = 0)
        {
            using (var ctx = new DctsEntities())
            {
                this.Model = ctx.Trips.Find(ModelId);
                this.dayList = ctx.TripDays.Where(o => o.trip_id == ModelId).OrderBy(o => o.day).ToList();
                this.dayLocationList = ctx.DayLocations.Include("ComboLocation").Where(o => o.trip_id == ModelId).OrderBy(o => o.day_id).ThenBy(o=>o.position).ToList();                
            }
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
            var dayLocations = this.dayLocationList.Where(o => o.day_id == dayId).Select(o => new DayLocationView()
            {
                ltype = o.ComboLocation.ltype,
                id = o.id, location_id = o.ComboLocation.id, title = o.ComboLocation.title, position = o.position }).OrderBy(o=>o.position).ToList();
            dayDetailBindingSource.DataSource = dayLocations;
            this.dayDetailDataGridView.DataSource = dayDetailBindingSource;

        }


        private void backLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var eventArgs = new CommandRequestEventArgs(CommandRequestEnum.TripList);
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
                if (MessageHelper.DeleteConfirm(string.Format("确定删除<第{0}天>的行程吗？", tripDay.day)))
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


        private DayLocationView GetSelectedDayLocation()
        {
            DayLocationView dayLocation = null;
            var row = dayDetailDataGridView.CurrentRow;
            if (row != null)
            {
                dayLocation = row.DataBoundItem as DayLocationView;
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
            int locationId = 0;
            TripBusiness.AddLocation(tripDay.id, locationId);
            InitializeDataSource(tripDay.day);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var eventArgs = new CommandRequestEventArgs(CommandRequestEnum.TripList);
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
    }
}
