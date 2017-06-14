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

namespace DCTS.UI
{
    public partial class EditCustomerTripDayForm : BaseModalForm
    {
        public int ModelId { get; set; }
        TripDay Model { get; set; }

        public EditCustomerTripDayForm(int id)
        {
            InitializeComponent();
            ModelId = id;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;

            this.FillModelByForm(this.Model);
            ctx.SaveChanges();
        }

        private void EditTripForm_Load(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;

            this.Model = ctx.TripDays.Find(ModelId);
            this.FillFormByModel(this.Model);
        }

        // 初始化DataGridView的数据源, 分页事件调用
        private int InitializeDataGridView(int pageCurrent = 1)
        {
            int count = 0;
            var ctx = this.entityDataSource1.DbContext as DctsEntities;

            var query = ctx.Schedules.Where(o => o.tripday_id == ModelId);

            this.dataGridView.DataSource = this.entityDataSource1.CreateView( query );
            
            return count;
        }

        public void FillModelByForm(TripDay trip)
        {
            trip.title = this.titleTextBox.Text;

            trip.tips = this.tipsTextBox.Text;
            Model = trip;

            //  trip.schedule = this.scheduleTextBox.Text;

        }

        public void FillFormByModel(TripDay trip)
        {
            Model = trip;
            this.titleTextBox.Text = trip.title;
            this.tipsTextBox.Text = trip.tips;
            //this.scheduleTextBox.Text = trip.schedule;
            InitializeDataGridView();


        }
    }
}
