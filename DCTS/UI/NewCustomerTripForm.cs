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
using DCTS.Uti;

namespace DCTS.UI
{
    public partial class NewCustomerTripForm : BaseModalForm
    {
        private SortableBindingList<Ticket> sortableticketList;
        ChooseCustomersForm customerForm;
        ChooseCountries countryForm;
        List<Customer> customerList;
        List<Nation> nationList;
        SupplierEnum supplierType;
        private List<Supplier> supplierList;
        private List<Supplier> flightCompanies;
        private List<Supplier> trainCompanies;
        private List<ComboLocation> airportList;

        public NewCustomerTripForm()
        {
            InitializeComponent();

            sortableticketList = new SortableBindingList<Ticket>();
            customerList = new List<Customer>();
            nationList = new List<Nation>();

            flightDataGridView.AutoGenerateColumns = false;
            hotalDataGridView.AutoGenerateColumns = false;
            InsuranceGridView.AutoGenerateColumns = false;
            RentalGridView.AutoGenerateColumns = false;
            WIFIGridView.AutoGenerateColumns = false;
            activityDataGridView.AutoGenerateColumns = false;

            customerForm = new ChooseCustomersForm();
            countryForm = new ChooseCountries();

            supplierType = SupplierEnum.Flight;
            InitializeDataSource();
        }

        private void InitializeDataSource()
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            supplierList = ctx.Suppliers.ToList();
            airportList = ComboLoactionBusiness.TypedLocation(ctx, ComboLocationEnum.Airport);

            var trips = ctx.Trips.Where(o => o.customer_id == 0).Take(10).ToList();
            var tripList = trips.Select(o => new MockEntity { Id = o.id, ShortName = o.title }).ToList();
            tripList.Insert(0, new MockEntity { Id = 0, ShortName = "不使用模板" });
            this.tripComboBox.DisplayMember = "ShortName";
            this.tripComboBox.ValueMember = "Id";
            this.tripComboBox.DataSource = tripList;

            SetTicketDateGridViewDataSource();
            InitializeDataSourceByCustomers();
        }

        private void InitializeDataSourceByCustomers()
        {
            //this.flightCustomerBindingSource.DataSource = this.customerList;
            this.flightCustomerColumn.DisplayMember = "name";
            this.flightCustomerColumn.ValueMember = "id";
            this.flightCustomerColumn.DataSource = this.customerList;

            this.hotelCustomerColumn.DisplayMember = "name";
            this.hotelCustomerColumn.ValueMember = "id";
            this.hotelCustomerColumn.DataSource = this.customerList;
        }

        private void InitializeDataSourceByNations()
        {


        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            using (var ctx = new DctsEntities())
            {
                int customer_id = Convert.ToInt32(customerList.First().id);

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
                    
                    trip.Tickets.Concat(this.sortableticketList);

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
                    foreach (var ticket in sortableticketList)
                    {
                        trip.Tickets.Add(ticket);
                    }
                    //trip.Tickets.Concat(sortableticketList);

                    ctx.Trips.Add(trip);
                    ctx.SaveChanges();
                    //创建票务对应的Location
                    
                    ctx.SaveChanges();
                }
                //交通信息


            }
        }

        private void findCustomerButton_Click(object sender, EventArgs e)
        {
            if (customerForm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                var list = customerForm.SelectedCustomers();

                this.customerList.AddRange(list);
                this.customersTextBox2.Text = string.Join( ",", customerList.Select(o => o.name).ToList());
            }
        }

        private void findTemplateButton_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }


        public void SetTicketDateGridViewDataSource()
        {
            SetTicketViewFilter();
            fromAirportBindingSource.DataSource = this.airportList;
            toAirportBindingSource.DataSource = this.airportList;

            this.ticketBindingSource.DataSource = this.sortableticketList;
            //flightDataGridView.AutoGenerateColumns = false;

            this.flightDataGridView.DataSource = this.ticketBindingSource;

            //hotalDataGridView.AutoGenerateColumns = false;
            this.hotalDataGridView.DataSource = this.ticketBindingSource;


            //InsuranceGridView.AutoGenerateColumns = false;
            this.InsuranceGridView.DataSource = this.ticketBindingSource;

            //RentalGridView.AutoGenerateColumns = false;
            this.RentalGridView.DataSource = this.ticketBindingSource;

            //WIFIGridView.AutoGenerateColumns = false;
            this.WIFIGridView.DataSource = this.ticketBindingSource;

            //activityDataGridView.AutoGenerateColumns = false;
            this.activityDataGridView.DataSource = this.ticketBindingSource;


            //飞机
            flightSupplierColumn.DisplayMember = "name";
            flightSupplierColumn.ValueMember = "id";
            flightSupplierColumn.DataSource = GetSuppliersByType(SupplierEnum.Flight);


            this.fromAirportColumn.DisplayMember = "title";
            this.fromAirportColumn.ValueMember = "id";
            this.fromAirportColumn.DataSource = this.fromAirportBindingSource;
            this.toAirportColumn.DisplayMember = "title";
            this.toAirportColumn.ValueMember = "id";
            this.toAirportColumn.DataSource = this.toAirportBindingSource;

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }


        private void addFlightButton1_Click(object sender, EventArgs e)
        {
            if (this.customerList.Count == 0) {
                MessageHelper.AlertBox("请先选择客户！");
                return;
            }

            var suppliers = supplierList.Where(o => (o.stype == (int)supplierType)).ToList();

            if (suppliers.Count == 0)
            {
                MessageHelper.AlertBox( string.Format("请先录入{0}服务商！", supplierType));
                return;
            }

            int cid = customerList.First().id;
            int sid = suppliers.First().id;
            var ticket = new Ticket() { ttype=(int)supplierType, customer_id =cid,  supplier_id = sid, start_at = DateTime.Now, end_at = DateTime.Now };

            if (supplierType == SupplierEnum.Flight)
            {               
                var airport = fromAirportBindingSource.Current as ComboLocation;                    
                //supplier is required for filter
                ticket.from_location_id= airport.id;
                ticket.to_location_id = airport.id;
            }
            if (supplierType == SupplierEnum.Hotal)
            {
                //supplier is required for filter
            }
            this.ticketBindingSource.Add(ticket);
        }

        private void customersTextBox2_TextChanged(object sender, EventArgs e)
        {
            var cnames = customersTextBox2.Text.Split(",，".ToArray());

            customerList = customerList.Where(o => cnames.Contains(o.name)).ToList();

            customersTextBox2.Text = string.Join(",", customerList.Select(o => o.name).ToList());
            //客户更新，更新数据源
            InitializeDataSourceByCustomers();
        }

        private void chooseCountryButton_Click(object sender, EventArgs e)
        {
            if (countryForm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                var list = countryForm.SelectedNations();

                this.nationList.AddRange(list);
                this.nationTextBox.Text = string.Join(",", nationList.Select(o => o.title).ToList());
            }
        }

        private void nationTextBox_TextChanged(object sender, EventArgs e)
        {
            var cnames = nationTextBox.Text.Split(",，".ToArray());

            nationList = nationList.Where(o => cnames.Contains(o.title)).ToList();

            nationTextBox.Text = string.Join(",", nationList.Select(o => o.title).ToList());
            // nation='nation.title'
            string filter = BuildBindingSourceFilter<Nation>(nationList, "nation","title");

            fromAirportBindingSource.Filter = filter;
            toAirportBindingSource.Filter = filter;
        }


        private void SetTicketViewFilter()
        {             
            ticketBindingSource.Filter = string.Format("ttype={0}", (int)supplierType);
        }

        private void ticketTabControl_TabIndexChanged(object sender, EventArgs e)
        {
           
        }

        private List<Supplier> GetSuppliersByType( SupplierEnum supplierEnum)
        {
            return this.supplierList.Where(o => o.stype == (int)supplierEnum).ToList();
        }

        // 'keyName=valName' obj.valName
        private string BuildBindingSourceFilter<T>(List<T> list, string keyName, string valName ){
            var filter = string.Empty;
             var type = typeof(T);
            if (list.Count > 0)
            {
                var first= list.First();

                var val = type.GetProperty(valName).GetValue(first);

                if (val.GetType() == typeof(string))
                {

                    var conditions = list.Select(o => string.Format("{0}='{1}'", keyName, type.GetProperty(valName).GetValue(o))).ToList();
                    filter = string.Join(" OR ", conditions);
                }
                else {
                    var conditions = list.Select(o => string.Format("{0}={1}", keyName, type.GetProperty(valName).GetValue(o))).ToList();
                    filter = string.Join(" OR ", conditions);
                }
            }
            return filter;
        }

 

        private void flightDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ;
            ;
        }

        // 改变选择的tab页，设置相应数据过滤条件
        private void ticketTabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (ticketTabControl.SelectedTab == this.flightTabPage)
            {
                this.supplierType = SupplierEnum.Flight;
            }
            else
                if (ticketTabControl.SelectedTab == this.trainTabPage)
                {
                    this.supplierType = SupplierEnum.Train;
                }
                else
                    if (ticketTabControl.SelectedTab == this.hotalTabPage)
                    {
                        this.supplierType = SupplierEnum.Hotal;
                    }
                    else
                        if (ticketTabControl.SelectedTab == this.insuranceTagPage)
                        {
                            this.supplierType = SupplierEnum.Insurance;
                        }
                        else
                            if (ticketTabControl.SelectedTab == this.rantalTabPage)
                            {
                                this.supplierType = SupplierEnum.Rental;
                            }
                            else
                                if (ticketTabControl.SelectedTab == this.wifiTabPage)
                                {
                                    this.supplierType = SupplierEnum.WIFI;
                                }
                                else
                                    if (ticketTabControl.SelectedTab == this.activityTabPage)
                                    {
                                        this.supplierType = SupplierEnum.Activity;
                                    }
            Console.WriteLine("selected tab {0}, current supplierType={1}", ticketTabControl.SelectedTab.Text, this.supplierType);
            SetTicketViewFilter();

        }

        private void deleteFlightButton_Click(object sender, EventArgs e)
        {

        }
    }
}
