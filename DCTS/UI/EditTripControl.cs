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
    public partial class EditTripControl : UserControl
    {
        public event EventHandler CommandRequestEvent;

        public long ModelId { get; set; }

        public Trip Model { get; set; }
        public List<Day> DayList { get; set; }
        ChooseLocaltionForm localtionForm;
        
        public EditTripControl()
        {
            InitializeComponent();

            dayDataGridView.AutoGenerateColumns = false;
            dayDetailDataGridView.AutoGenerateColumns = false;
            //dayListView.Columns[0].Width = 0; //id
            //dayListView.Columns[0].Width = dayListView.ClientSize.Width;  // 第几天

            localtionForm = new ChooseLocaltionForm();
        }

        public void BeginActive()
        {
            dayNameColumn.Width = dayDataGridView.ClientSize.Width - 3;
            localtionTitleColumn.Width = dayDetailDataGridView.ClientSize.Width - 303;

            InitializeDataSource();

        }

        public void InitializeDataSource(int selectDay = 0, int selectLocationPosition = 0)
        {
             using (var ctx = new DctsEntities())
            {
                this.Model = ctx.Trips.Find(ModelId);
                this.DayList = ctx.Days.Include("ComboLocation").Where(o => o.tripId == ModelId).OrderBy(o => o.day).ToList();
            }
             InitializeDayListBox(selectDay, selectLocationPosition);
        }

        public void InitializeDayListBox(int day = 0, int selectLocationPosition = 0)
        {
            List<MockEntity> list = new List<MockEntity>();
            for (int i = 1; i <= Model.days; i++)
            {
                list.Add(new MockEntity { Id = i, FullName = String.Format("第 {0} 天", i) });
            }
            this.dayDataGridView.DataSource = list;

            //http://stackoverflow.com/questions/6265228/selecting-a-row-in-datagridview-programmatically
            if (day > 0)
            {
                Console.WriteLine("InitializeDayListBox day= " + day.ToString());

                dayDataGridView.CurrentCell = dayDataGridView.Rows[day - 1].Cells[0]; 
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

        public void InitializeDayDetailListBox( int day )
        {
            var dayLocations = this.DayList.Where(o => o.day == day).Select(o => new DayLocation() { 
                dayId = o.id, locationId = o.ComboLocation.id, title = o.ComboLocation.title, position = o.position }).OrderBy(o=>o.position).ToList();
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
                    var day = GetSelectedDay();
                    long locationId = localtionForm.SelectedLocation.id;
                    TripBusiness.AddLocation(this.ModelId, day, locationId);
                    InitializeDataSource(day);
                    //InitializeDayDetailListBox(day);
                }
            
            }
        }

        private void addDayButton_Click(object sender, EventArgs e)
        {
            TripBusiness.AddDay(ModelId);
            int selectDay = Model.days + 1;
            InitializeDataSource(selectDay);

        }

        private void delDayButton_Click(object sender, EventArgs e)
        {
            
            var day =  GetSelectedDay();
            if( day >0 )
            {
                if (MessageHelper.DeleteConfirm(string.Format("确定删除<第{0}天>的行程吗？", day)))
                {
                    TripBusiness.DeleteDay(ModelId, (int) day);                     
                    InitializeDataSource(day-1);
                }
            }
        }

        private void dayDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var day = GetSelectedDay();
            Console.WriteLine("dayDataGridView_SelectionChanged day= " + day.ToString());
            if (day > 0)
            {
                InitializeDayDetailListBox(day);
            
            }
        }




        private void moveUpButton_Click(object sender, EventArgs e)
        {
            var day = GetSelectedDay();
            var dayLocation = GetSelectedDayLocation();
            if (dayLocation.position > 1)
            {
                 
                int newPosition =  dayLocation.position -1;
                TripBusiness.UpdateDayLocationPosition(dayLocation.dayId,newPosition);
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

                TripBusiness.UpdateDayLocationPosition(dayLocation.dayId, newPosition);
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
                var mockEntity = row.DataBoundItem as MockEntity;
                day = (int)mockEntity.Id;
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
                TripBusiness.DeleteDayLocation(dayLocation.dayId);
                InitializeDataSource(day);
            }
        }

        private void selectDayTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void addBlankButton_Click(object sender, EventArgs e)
        {          
            var day = GetSelectedDay();
            long locationId = 0;
            TripBusiness.AddLocation(this.ModelId, day, locationId);
            InitializeDataSource(day);
        }
    }
}
