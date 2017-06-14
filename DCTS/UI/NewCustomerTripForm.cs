using DCTS.Bus;
using DCTS.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCTS.CustomComponents;

namespace DCTS.UI
{
    public partial class NewCustomerTripForm : BaseModalForm
    {
        private List<Ticket> TicketList = null;
        private SortableBindingList<Ticket> sortableticketList;

        public NewCustomerTripForm()
        {
            InitializeComponent();
            InitializeDataSource();
            TicketList = new List<Ticket>();
            dataGridView.AutoGenerateColumns = false;
            hotalDataGridView.AutoGenerateColumns = false;
            InsuranceGridView.AutoGenerateColumns = false;
            RentalGridView.AutoGenerateColumns = false;
            WIFIGridView.AutoGenerateColumns = false;
            activityDataGridView.AutoGenerateColumns = false;

        }

        private void InitializeDataSource()
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            var trips = ctx.Trips.Where(o => o.customer_id == 0).Take(10).ToList();
            var customerList = ctx.Customers.Take(10).ToList();

            this.customerComboBox.DisplayMember = "name";
            this.customerComboBox.ValueMember = "id";
            this.customerComboBox.DataSource = customerList;


            var tripList = trips.Select(o => new MockEntity { Id = o.id, ShortName = o.title }).ToList();
            tripList.Insert(0, new MockEntity { Id = 0, ShortName = "不使用模板" });
            this.tripComboBox.DisplayMember = "ShortName";
            this.tripComboBox.ValueMember = "Id";
            this.tripComboBox.DataSource = tripList;

        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            using (var ctx = new DctsEntities())
            {
                int customer_id = Convert.ToInt32(customerComboBox.SelectedValue);

                int template_id = Convert.ToInt32(tripComboBox.SelectedValue);
                if (template_id > 0)
                {
                    int days = Convert.ToInt32(this.daysNumericUpDown.Value);
                    var trip = TripBusiness.Duplicate(template_id, customer_id);
                    trip = ctx.Trips.Find(trip.id);
                    trip.start_at = this.startAtDateTimePicker.Value;
                    trip.title = this.titleTextBox.Text;
                    trip.memo = this.memoTextBox.Text;
                    if (trip.days < days)
                    {
                        for (int i = days; i < trip.days; i++)
                        {
                            var tripDay = new TripDay();
                            tripDay.day = i + 1;
                            tripDay.title = String.Format("第{0}天", i + 1);
                            trip.TripDays.Add(tripDay);
                        }
                    }
                    ctx.Tickets.AddRange(TicketList);

                    ctx.SaveChanges();
                }
                else
                {
                    var trip = new Trip();
                    trip.customer_id = customer_id;
                    trip.title = this.titleTextBox.Text;
                    trip.start_at = this.startAtDateTimePicker.Value;
                    trip.memo = this.memoTextBox.Text;
                    trip.days = Convert.ToInt32(this.daysNumericUpDown.Value);

                    for (int i = 0; i < trip.days; i++)
                    {
                        var tripDay = new TripDay();
                        tripDay.day = i + 1;
                        tripDay.title = String.Format("第{0}天", i + 1);
                        trip.TripDays.Add(tripDay);
                    }
                    ctx.Trips.Add(trip);

                    ctx.Tickets.AddRange(TicketList);


                    ctx.SaveChanges();
                }
                //交通信息


            }
        }

        private void findCustomerButton_Click(object sender, EventArgs e)
        {

        }

        private void findTemplateButton_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dataGridView.Rows[e.RowIndex];
            var model = row.DataBoundItem as Ticket;
            using (var ctx = new DctsEntities())
            {
                var location = ctx.Suppliers.Where(o => o.name == model.title).First();
                model.supplier_id = location.id;
                model.customer_id = Convert.ToInt32(customerComboBox.SelectedValue);

                //住宿
                int s = this.tabControl1.SelectedIndex;
                if (s == 1)
                {
                    location = ctx.Suppliers.Where(o => o.name == "缺省住宿服务商").First();
                    model.supplier_id = location.id;
                    model.customer_id = Convert.ToInt32(customerComboBox.SelectedValue);
                }
                //活动
                else if (s == 5)
                {
                    location = ctx.Suppliers.Where(o => o.name == "缺省活动服务商").First();
                    model.supplier_id = location.id;
                    model.customer_id = Convert.ToInt32(customerComboBox.SelectedValue);
                }
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }


        public void BeginActive()
        {
            sortableticketList = new SortableBindingList<Ticket>(TicketList.ToList());
            this.bindingSource1.DataSource = this.sortableticketList;
            dataGridView.AutoGenerateColumns = false;
            string filter = "";
            //var location = ctx.Suppliers.Where(o => o.name == model.title).First();
            //model.supplier_id = location.id;

            //  filter += " (supplier_id>='" + shipper + "')";

            bindingSource1.Filter = filter;

            this.dataGridView.DataSource = this.bindingSource1;



            hotalDataGridView.AutoGenerateColumns = false;
            this.hotalDataGridView.DataSource = this.bindingSource1;


            InsuranceGridView.AutoGenerateColumns = false;
            this.InsuranceGridView.DataSource = this.bindingSource1;

            RentalGridView.AutoGenerateColumns = false;
            this.RentalGridView.DataSource = this.bindingSource1;

            WIFIGridView.AutoGenerateColumns = false;
            this.WIFIGridView.DataSource = this.bindingSource1;

            activityDataGridView.AutoGenerateColumns = false;
            this.activityDataGridView.DataSource = this.bindingSource1;

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        private void newadd_Click(object sender, EventArgs e)
        {
            using (var ctx = new DctsEntities())
            {
                int s = this.tabControl1.SelectedIndex;
                //if (s == 0)
                {
                    Ticket item = new Ticket();
                    //  item.supplier_id = (int)ComboLocationEnum.TrainList;

                    TicketList.Add(item);
                    BeginActive();

                }

            }

        }



    }
}
