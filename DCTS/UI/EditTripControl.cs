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
            dayNameColumn.Width = dayDataGridView.ClientSize.Width;
            dayDataGridView.AutoGenerateColumns = false;
            dayDetailDataGridView.AutoGenerateColumns = false;
            //dayListView.Columns[0].Width = 0; //id
            //dayListView.Columns[0].Width = dayListView.ClientSize.Width;  // 第几天

            localtionForm = new ChooseLocaltionForm();
        }

        public void BeginActive()
        {
            InitializeDataSource();
        }

        public void InitializeDataSource(int day = 0)
        {
            var db = this.entityDataSource1.DbContext as DctsEntities;
            this.Model = db.Trips.Find(ModelId);
            this.DayList = db.Days.Where(o => o.tripId == ModelId).OrderBy(o => o.day).ToList();

            InitializeDayListBox( day );
        }

        public void InitializeDayListBox( int day = 0)
        {
            List<MockEntity> list = new List<MockEntity>();
            for (int i = 1; i <= Model.days; i++)
            {
                list.Add(new MockEntity { Id = i, FullName = String.Format("第 {0} 天", i) });
            }
            this.dayDataGridView.DataSource = list;

            if (day > 0)
            {
                this.dayDataGridView.Rows[day - 1].Selected = true;
            }
        }

        public void InitializeDayDetailListBox( int day )
        {
            var dayModelByDay = this.DayList.Where(o => o.day == day).ToList();
            this.dayDetailDataGridView.DataSource = dayModelByDay;

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
            var db = this.entityDataSource1.DbContext as DctsEntities;
            this.Model.days += 1;
            db.SaveChanges();
            InitializeDayListBox();
        }

        private void delDayButton_Click(object sender, EventArgs e)
        {
            var db = this.entityDataSource1.DbContext as DctsEntities;
            
            var day =  GetSelectedDay();
            if( day >0 )
            {
                if (MessageHelper.DeleteConfirm(string.Format("确定删除<第{0}天>的行程吗？", day)))
                {
                    TripBusiness.DeleteDay(ModelId, (int) day);

                    InitializeDataSource();
                }
            }
        }

        private void dayDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var day = GetSelectedDay();

            if (day > 0)
            {
                InitializeDayDetailListBox(day);
            
            }
        }


        private int GetSelectedDay()
        {
            int day = 0;
            var row = dayDataGridView.CurrentRow;
            if(  row != null )
            {
                var mockEntity = row.DataBoundItem as MockEntity;
                day = (int)mockEntity.Id;
            }
            return day;
        }
    }
}
