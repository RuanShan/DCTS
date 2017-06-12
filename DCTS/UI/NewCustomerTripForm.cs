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

namespace DCTS.UI
{
    public partial class NewCustomerTripForm : BaseModalForm
    {

        public NewCustomerTripForm()
        {
            InitializeComponent();
            InitializeDataSource();
        }

        private void InitializeDataSource()
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            var trips = ctx.Trips.Where(o=>o.customer_id == 0 ).Take(10).ToList();
            var customerList = ctx.Customers.Take(10).ToList();

            this.customerComboBox.DisplayMember = "name";
            this.customerComboBox.ValueMember = "id";
            this.customerComboBox.DataSource = customerList;


            var tripList = trips.Select(o => new MockEntity { Id = o.id, ShortName = o.title }).ToList();
            tripList.Insert(0, new MockEntity{ Id = 0, ShortName="不使用模板"});
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
                    var trip = TripBusiness.Duplicate(template_id,customer_id);
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
                    ctx.SaveChanges();
                }

            }
        }

        private void findCustomerButton_Click(object sender, EventArgs e)
        {

        }

        private void findTemplateButton_Click(object sender, EventArgs e)
        {

        }
    }
}
