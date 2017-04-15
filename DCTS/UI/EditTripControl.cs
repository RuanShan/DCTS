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
            localtionForm = new ChooseLocaltionForm();
        }

        public void BeginActive()
        {
            InitializeDataSource();
        }

        public void InitializeDataSource()
        {
            var db = this.entityDataSource1.DbContext as DctsEntities;
            this.Model = db.Trips.Find(ModelId);
            this.DayList = db.Days.Where(o => o.tripId == ModelId).OrderBy(o => o.day).ToList();


            InitializeDayListBox();

        }

        public void InitializeDayListBox()
        {
            List<MockEntity> list = new List<MockEntity>();
            for (int i = 1; i <= Model.days; i++)
            {
                list.Add(new MockEntity { Id = i, FullName = String.Format("第 {0} 天", i) });
            }

            this.dayListBox.DisplayMember = "FullName";
            this.dayListBox.ValueMember = "Id";
            this.dayListBox.DataSource = list;
        
        }


        private void backLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var eventArgs = new CommandRequestEventArgs(CommandRequestEnum.TripList);
            this.CommandRequestEvent(this, eventArgs);
        }

        private void dayListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            int day = Convert.ToInt32(this.dayListBox.SelectedValue);

            //this.DayList.Where( o=>o.day == day && o.
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (localtionForm.ShowDialog() == DialogResult.Yes)
            { 
            
            
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
            int day = Convert.ToInt32(this.dayListBox.SelectedValue);

            if (MessageHelper.DeleteConfirm(string.Format("确定删除<第{0}天>的行程吗？", day)))
            {
                var listByDay = this.DayList.Where(o => o.day == day).ToList();

                string sqlFormat = "UPDATE days SET `day`=`day`-1 WHERE `tripId`={0} && `day`>{1}";
                string sql = String.Format(sqlFormat, this.ModelId, day);
                db.Days.RemoveRange(listByDay);
                db.Database.ExecuteSqlCommand(sql);

                Model.days -= 1;
                db.SaveChanges();

                InitializeDataSource();
            }
        }
    }
}
