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
using Equin.ApplicationFramework;

namespace DCTS.UI
{
    public partial class NewCustomerTripForm : BaseModalForm
    {
        private List<Ticket> ticketList;
        private BindingListView<Ticket> ticketView;
        ChooseCustomersForm customerForm;
        ChooseCountries countryForm;
        List<Customer> customerList;
        List<Nation> nationList;
        SupplierEnum supplierType;
        private List<Supplier> supplierList;

        private List<ComboLocation> airportList;

        public NewCustomerTripForm()
        {
            InitializeComponent();

            ticketList = new List<Ticket>();
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

            ticketView = new BindingListView<Ticket>(new List<Ticket>());
            InitializeDataSource();
        }

        // 取得窗口需要的数据
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
            InitializeDataSourceByNations();
        }

        #region 设置数据源

        //初始化依赖于客户的数据
        private void InitializeDataSourceByCustomers()
        {

            //this.flightCustomerBindingSource.DataSource = this.customerList;
            this.flightCustomerColumn.DisplayMember = "name";
            this.flightCustomerColumn.ValueMember = "id";
            this.flightCustomerColumn.DataSource = this.customerList;

            //保险
            this.insuranceCustomerColumn.DisplayMember = "name";
            this.insuranceCustomerColumn.ValueMember = "id";
            this.insuranceCustomerColumn.DataSource = this.customerList;
            //火车
            this.trainCustomerColumn.DisplayMember = "name";
            this.trainCustomerColumn.ValueMember = "id";
            this.trainCustomerColumn.DataSource = this.customerList;
            //住宿
            this.hotelCustomerColumn.DisplayMember = "name";
            this.hotelCustomerColumn.ValueMember = "id";
            this.hotelCustomerColumn.DataSource = this.customerList;
            //wifi
            this.wifiCustomerColumn.DisplayMember = "name";
            this.wifiCustomerColumn.ValueMember = "id";
            this.wifiCustomerColumn.DataSource = this.customerList;
            //租车
            this.rentalCustomerColumn1.DisplayMember = "name";
            this.rentalCustomerColumn1.ValueMember = "id";
            this.rentalCustomerColumn1.DataSource = this.customerList;
            //活动
            this.ActivityCustomerColumn1.DisplayMember = "name";
            this.ActivityCustomerColumn1.ValueMember = "id";
            this.ActivityCustomerColumn1.DataSource = this.customerList;
        }

        //初始化依赖于国家的数据
        private void InitializeDataSourceByNations()
        {
            var nationNames = nationList.Select(o => o.title).ToArray();
            var airports = airportList.Where(o => nationNames.Contains(o.nation)).ToList();
            airports.Insert(0, new ComboLocation() { id = 0, title = "请选择机场" });
            this.fromAirportColumn.DisplayMember = "title";
            this.fromAirportColumn.ValueMember = "id";
            this.fromAirportColumn.DataSource = airports;
            this.toAirportColumn.DisplayMember = "title";
            this.toAirportColumn.ValueMember = "id";
            this.toAirportColumn.DataSource = airports;

            //城市
            //string code =.ToString();
            using (var ctx = new DctsEntities())
            {
                List<ComboLocation> locations = ctx.ComboLocations.Where(o => nationNames.Contains(o.nation)).ToList();

                var nationList1 = DCTS.DB.GlobalCache.NationList;
                var codelist = nationList1.FindAll(o => o.title == nationTextBox.Text);
                if (codelist != null && codelist.Count > 0)
                {
                    var cityList = DCTS.DB.GlobalCache.CityList;
                    cityList = cityList.Where(o => o.nationCode == codelist.First().code).ToList();
                    var cities = cityList.Select(o => new MockEntity { Id = o.id, FullName = o.title }).ToList();
                    this.cityColumn2.DisplayMember = "FullName";
                    this.cityColumn2.ValueMember = "FullName";
                    this.cityColumn2.DataSource = cities;

                    //酒店

                    var hotellist = locations.Where(o => o.ltype == (int)ComboLocationEnum.Hotel).ToList();
                    hotellist.Insert(0, new ComboLocation() { id = 0, title = "请选择酒店" });
                    this.titlxColumn2.DisplayMember = "title";
                    this.titlxColumn2.ValueMember = "id";
                    this.titlxColumn2.DataSource = hotellist;

                    //活动项目
                    var activelist = locations.Where(o => o.ltype == (int)ComboLocationEnum.Activity).ToList();
                    activelist.Insert(0, new ComboLocation() { id = 0, title = "请选择活动" });
                    this.rulesColumn6.DisplayMember = "title";
                    this.rulesColumn6.ValueMember = "id";
                    this.rulesColumn6.DataSource = activelist;

                }
            }
           

        }

        //设置票务表格的数据源，以及相应列的数据源
        public void SetTicketDateGridViewDataSource()
        {
            var view = ticketView;
            SetTicketViewFilter();

            this.flightDataGridView.DataSource = view;
            this.hotalDataGridView.DataSource = view;
            this.InsuranceGridView.DataSource = view;
            this.RentalGridView.DataSource = view;
            this.WIFIGridView.DataSource = view;
            this.activityDataGridView.DataSource = view;

            //飞机
            flightSupplierColumn.DisplayMember = "name";
            flightSupplierColumn.ValueMember = "id";
            flightSupplierColumn.DataSource = GetSuppliersByType(SupplierEnum.Flight);

            //保险
            insuranceSupplierColumn.DisplayMember = "name";
            insuranceSupplierColumn.ValueMember = "id";
            insuranceSupplierColumn.DataSource = GetSuppliersByType(SupplierEnum.Insurance);

            //租车公司
            rentalSupplierColumn4.DisplayMember = "name";
            rentalSupplierColumn4.ValueMember = "id";
            rentalSupplierColumn4.DataSource = GetSuppliersByType(SupplierEnum.Rental);
            //WIFI
            wifiSupplierColumn.DisplayMember = "name";
            wifiSupplierColumn.ValueMember = "id";
            wifiSupplierColumn.DataSource = GetSuppliersByType(SupplierEnum.WIFI);
        }

        #endregion

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
                    trip.countries = this.nationTextBox.Text;

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

                    foreach (var ticket in ticketView)
                    {

                        trip.Tickets.Add(ticket);
                    }
                    //trip.Tickets.Concat(this.ticketView);

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
                    trip.end_at = trip.start_at.Value.AddDays(trip.days - 1);

                    trip.countries = this.nationTextBox.Text;

                    for (int i = 0; i < trip.days; i++)
                    {
                        var tripDay = new TripDay();
                        tripDay.day = i + 1;
                        tripDay.title = String.Format("第{0}天", i + 1);
                        trip.TripDays.Add(tripDay);
                    }
                    foreach (var ticket in ticketView)
                    {
                        trip.Tickets.Add(ticket);
                    }
                    //trip.Tickets.Concat(ticketList);
                    foreach (var customer in customerList)
                    {
                        trip.TripCustomers.Add(new TripCustomer() { customer_id = customer.id });
                    }

                    ctx.Trips.Add(trip);
                    ctx.SaveChanges();
                    //创建票务对应的Location
                    if (supplierType == SupplierEnum.Insurance)
                    {
                        // trip.DayLocations = (int)SupplierEnum.Insurance;

                    }
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
                this.customersTextBox2.Text = string.Join(",", customerList.Select(o => o.name).ToList());
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

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }


        private void addFlightButton1_Click(object sender, EventArgs e)
        {
            if (this.customerList.Count == 0)
            {
                MessageHelper.AlertBox("请先选择客户！");
                return;
            }

            var suppliers = supplierList.Where(o => (o.stype == (int)supplierType)).ToList();

            if (suppliers.Count == 0)
            {
                MessageHelper.AlertBox(string.Format("请先录入{0}服务商！", supplierType));
                return;
            }

            int cid = customerList.First().id;
            int sid = suppliers.First().id;
            var objectView = ticketView.AddNew();

            var ticket = objectView.Object;
            ticket.ttype = (int)supplierType;
            ticket.customer_id = cid;
            //supplier is required for filter
            ticket.supplier_id = sid;
            ticket.start_at = DateTime.Now;
            ticket.end_at = DateTime.Now;

            if (supplierType == SupplierEnum.Flight)
            {
                //var airport = fromAirportBindingSource.Current as ComboLocation;                    
                //ticket.from_location_id= airport.id;
                //ticket.to_location_id = airport.id;
            }
            if (supplierType == SupplierEnum.Hotal)
            {
                //supplier is required for filter
            }
            if (supplierType == SupplierEnum.Insurance)
            {


            }




            ticketView.EndNew(ticketView.Count - 1);

        }
        
        private void deleteFlightButton_Click(object sender, EventArgs e)
        {
            var view = GetDataGridViewBySupplierType();
            var objectView = view.CurrentRow.DataBoundItem as ObjectView<Ticket>;

            this.ticketView.DataSource.Remove(objectView.Object);
            this.ticketView.Refresh();
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
            string filter = BuildBindingSourceFilter<Nation>(nationList, "nation", "title");

            InitializeDataSourceByNations();

        }


        private void SetTicketViewFilter()
        {
            //ticketBindingSource.DataSource = this.ticketList.Where(o => o.ttype == (int)this.supplierType).ToList();
            ticketView.RemoveFilter();
            ticketView.ApplyFilter(delegate(Ticket ticket) { return ticket.ttype == (int)this.supplierType; });
            //ticketView.Refresh();
            //ticketDataView.RowFilter = string.Format("ttype={0}", (int)this.supplierType);
        }

        private List<Supplier> GetSuppliersByType(SupplierEnum supplierEnum)
        {
            return this.supplierList.Where(o => o.stype == (int)supplierEnum).ToList();
        }

        // 'keyName=valName' obj.valName
        private string BuildBindingSourceFilter<T>(List<T> list, string keyName, string valName)
        {
            var filter = string.Empty;
            var type = typeof(T);
            if (list.Count > 0)
            {
                var first = list.First();

                var val = type.GetProperty(valName).GetValue(first);

                if (val.GetType() == typeof(string))
                {

                    var conditions = list.Select(o => string.Format("{0}='{1}'", keyName, type.GetProperty(valName).GetValue(o))).ToList();
                    filter = string.Join(" OR ", conditions);
                }
                else
                {
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
                            if (ticketTabControl.SelectedTab == this.rentalTabPage)
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

        private DataGridView GetDataGridViewBySupplierType()
        {
            DataGridView view = null;
            switch ((supplierType))
            {
                case SupplierEnum.Flight:
                    view = this.flightDataGridView;
                    break;
                case SupplierEnum.Hotal:
                    view = this.hotalDataGridView;
                    break;
                case SupplierEnum.Insurance:
                    view = this.InsuranceGridView;
                    break;
                case SupplierEnum.Rental:
                    view = this.RentalGridView;
                    break;

            }
            return view;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new SelectSystemfile();
            form.ShowDialog();



            {
                List<string> reference = form.listfile;
                if (reference.Count > 0)
                {

                    pictureBox1.ImageLocation = reference[1];
                }


            }
        }

        private void activityDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            bool handle;
            if (activityDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals(DBNull.Value))
            {
                handle = true;
            }
            else
                handle = false;
            e.Cancel = handle;
        }

        private void NewCustomerTripForm_Load(object sender, EventArgs e)
        {

        }

    }
}
