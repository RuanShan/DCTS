using DCTS.Bus;
using DCTS.CustomComponents;
using DCTS.DB;
using DCTS.Uti;
using Equin.ApplicationFramework;
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
    public partial class EditCustomerTripForm : BaseModalForm
    {
        public long TripId { get; set; }
        Trip trip;
        List<Ticket> ticketList;
        List<Ticket> deletedTicketList;
        List<Customer> customerList;
        List<Nation> nationList;
        private List<ComboLocation> airportList;

        SupplierEnum supplierType;
        private BindingListView<Ticket> ticketView;
        private List<Supplier> supplierList;
        ChooseCustomersForm customerForm;
        ChooseCountries countryForm;

        public EditCustomerTripForm(long tripId)
        {
            InitializeComponent();
            TripId = tripId;
            supplierType = SupplierEnum.Flight;
            deletedTicketList = new List<Ticket>();

            flightDataGridView.AutoGenerateColumns = false;
            hotalDataGridView.AutoGenerateColumns = false;
            InsuranceGridView.AutoGenerateColumns = false;
            RentalGridView.AutoGenerateColumns = false;
            WIFIGridView.AutoGenerateColumns = false;
            activityDataGridView.AutoGenerateColumns = false;
            trainDataGridView.AutoGenerateColumns = false;

            customerForm = new ChooseCustomersForm();
            countryForm = new ChooseCountries();
        }



        private void EditTripForm_Load(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;

            this.trip = ctx.Trips.Find(TripId);
            this.ticketList = trip.Tickets.ToList();
            this.supplierList = ctx.Suppliers.ToList();

            //行程客户
            this.customerList = this.trip.TripCustomers.Select(o => o.Customer).ToList();
            string countryNames = this.trip.countries != null ? this.trip.countries : string.Empty;
            this.nationList = GlobalCache.NationList.Where(o => countryNames.Contains(o.title)).ToList();

            airportList = ComboLoactionBusiness.TypedLocation(ctx, ComboLocationEnum.Airport);

            this.FillFormByModel(trip);

            SetTicketDateGridViewDataSource();
        }

        #region 基本信息

        private void saveButton_Click(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            this.FillModelByForm(this.trip);
            ctx.SaveChanges();
            MessageHelper.InfoBox("成功保存！");

        }

        #region 关联界面和数据

        public void FillModelByForm(Trip trip)
        {
            trip.title = this.titleTextBox.Text;
            trip.days = Convert.ToInt32(this.daysNumericUpDown.Value);
            trip.start_at = this.startAtDateTimePicker.Value;
            trip.memo = this.memoTextBox.Text;
            trip.end_at = trip.start_at.Value.AddDays(trip.days - 1);
            trip.countries = this.nationTextBox.Text;
            using (var ctx = new DctsEntities())
            {
                var location = ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.PageImage).First();

                var query = ctx.LocationImages.Where(o => o.location_id == (int)location.id && o.name == imgPathTextBox.Text);
                List<LocationImage> list = query.ToList();
                if (list.Count > 0)
                {
                    trip.cover_id = list[0].id;
                }
            }

            var tripCustomers = trip.TripCustomers.ToList();
            var oriCustomerIds = tripCustomers.Select(o => o.customer_id).ToList();
            var curCustomerIds = customerList.Select(o=>o.id).ToList();
            var deleteTripCustomer = tripCustomers.Where(o => !curCustomerIds.Contains(o.customer_id)).ToList();
            var newCustomerIds = curCustomerIds.Where(o => !oriCustomerIds.Contains(o)).ToList();
            foreach (var cid in newCustomerIds)
            {
                trip.TripCustomers.Add(new TripCustomer() { customer_id = cid });                
            }
            foreach (var tc in deleteTripCustomer)
            {
                trip.TripCustomers.Remove(tc);
            }
        }

        public void FillFormByModel(Trip trip)
        {

            this.titleTextBox.Text = trip.title;
            this.daysNumericUpDown.Value = trip.days;
            this.memoTextBox.Text = trip.memo;
            this.startAtDateTimePicker.Value = trip.start_at.GetValueOrDefault(DateTime.Now);
            this.nationTextBox.Text = trip.countries;
            this.customersTextBox2.Text = string.Join(",", customerList.Select(o => o.name).ToArray() );
            //读取图片位置
            using (var ctx = new DctsEntities())
            {
                var query = ctx.LocationImages.Where(o => o.id == trip.cover_id);
                if (query.Count() > 0)
                {
                    string ImageLocation = EntityPathConfig.newlocationimagepath(query.ToList()[0]);
                    imgPathTextBox.Text = query.ToList()[0].name;
                    pictureBox1.ImageLocation = ImageLocation;
                }

            }
        }

        #endregion

        #endregion

        #region 处理票务信息

        private void SetTicketViewFilter()
        {
            ticketView.RemoveFilter();
            ticketView.ApplyFilter(delegate(Ticket ticket) { return ticket.ttype == (int)this.supplierType; });            
        }

        
        public void SetTicketDateGridViewDataSource()
        {
            ticketView = new BindingListView<Ticket>(this.ticketList);
            //行程客户
     
            //this.flightCustomerBindingSource.DataSource = this.customerList;
            this.flightCustomerColumn.DisplayMember = "name";
            this.flightCustomerColumn.ValueMember = "id";
            this.flightCustomerColumn.DataSource = this.customerList;


            //火车
            this.trainCustomerColumn.DisplayMember = "name";
            this.trainCustomerColumn.ValueMember = "id";
            this.trainCustomerColumn.DataSource = this.customerList;

            this.trainSupplierColumn1.DisplayMember = "name";
            this.trainSupplierColumn1.ValueMember = "id";
            this.trainSupplierColumn1.DataSource = GetSuppliersByType(SupplierEnum.Train);

            //住宿
            this.hotelCustomerColumn.DisplayMember = "name";
            this.hotelCustomerColumn.ValueMember = "id";
            this.hotelCustomerColumn.DataSource = this.customerList;
           
            //活动
            this.ActivityCustomerColumn1.DisplayMember = "name";
            this.ActivityCustomerColumn1.ValueMember = "id";
            this.ActivityCustomerColumn1.DataSource = this.customerList;


            // 机场       
            var names = nationList.Select(o => o.title).ToArray();
            var airports = airportList.Where(o => names.Contains(o.nation)).ToList();
            airports.Insert(0, new ComboLocation() { id = 0, title = "请选择机场" });
            this.fromAirportColumn.DisplayMember = "title";
            this.fromAirportColumn.ValueMember = "id";
            this.fromAirportColumn.DataSource = airports;
            this.toAirportColumn.DisplayMember = "title";
            this.toAirportColumn.ValueMember = "id";
            this.toAirportColumn.DataSource = airports;


            //飞机
            flightSupplierColumn.DisplayMember = "name";
            flightSupplierColumn.ValueMember = "id";
            flightSupplierColumn.DataSource = GetSuppliersByType(SupplierEnum.Flight);

            //保险
            insuranceSupplierColumn.DisplayMember = "name";
            insuranceSupplierColumn.ValueMember = "id";
            insuranceSupplierColumn.DataSource = GetSuppliersByType(SupplierEnum.Insurance);
            this.insuranceCustomerColumn.DisplayMember = "name";
            this.insuranceCustomerColumn.ValueMember = "id";
            this.insuranceCustomerColumn.DataSource = this.customerList;
            //租车公司
            rentalSupplierColumn4.DisplayMember = "name";
            rentalSupplierColumn4.ValueMember = "id";
            rentalSupplierColumn4.DataSource = GetSuppliersByType(SupplierEnum.Rental);
            
            this.rentalCustomerColumn1.DisplayMember = "name";
            this.rentalCustomerColumn1.ValueMember = "id";
            this.rentalCustomerColumn1.DataSource = this.customerList;
            
            //WIFI
            wifiSupplierColumn.DisplayMember = "name";
            wifiSupplierColumn.ValueMember = "id";
            wifiSupplierColumn.DataSource = GetSuppliersByType(SupplierEnum.WIFI);
 
            this.wifiCustomerColumn.DisplayMember = "name";
            this.wifiCustomerColumn.ValueMember = "id";
            this.wifiCustomerColumn.DataSource = this.customerList;

            //城市
            //string code =.ToString();
            using (var ctx = new DctsEntities())
            {
                var nationNames = nationList.Select(o => o.title).ToArray();

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


            var view = ticketView;
            SetTicketViewFilter();

            this.flightDataGridView.DataSource = view;
            this.hotalDataGridView.DataSource = view;
            this.InsuranceGridView.DataSource = view;
            this.RentalGridView.DataSource = view;
            this.WIFIGridView.DataSource = view;
            this.activityDataGridView.DataSource = view;
            this.trainDataGridView.DataSource = view;

        }

        private List<Supplier> GetSuppliersByType(SupplierEnum supplierEnum)
        {
            return this.supplierList.Where(o => o.stype == (int)supplierEnum).ToList();
        }

        #region 事件处理

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

        private void addFlightButton1_Click(object sender, EventArgs e)
        {

            var suppliers = supplierList.Where(o => (o.stype == (int)supplierType)).ToList();

            if (suppliers.Count == 0)
            {
                MessageHelper.AlertBox(string.Format("请先录入{0}服务商！", supplierType));
                return;
            }

            int cid = trip.customer_id; // customerList.First().id;
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
            ticketView.EndNew(ticketView.Count - 1);
        }

        private void deleteFlightButton_Click(object sender, EventArgs e)
        {
            var view = GetDataGridViewBySupplierType();
            var objectView = view.CurrentRow.DataBoundItem as ObjectView<Ticket>;

            this.deletedTicketList.Add(objectView.Object);
            this.ticketView.DataSource.Remove(objectView.Object);
            this.ticketView.Refresh();

        }
        
        #endregion

        private void saveTicketButton_Click(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            
            //ticketView.RemoveFilter();
            // 使用 DataSource 移除过滤，否则其他TAB页数据无法保存
            
            foreach (var ticket in ticketView.DataSource)
            {
                var model = ticket as Ticket;
                // 设置票务相关的城市，在生成行程概述中使用，
                // 飞机，交通，住宿，保险，租车，WIFI，活动
                TicketBusiness.FillTitle(model, airportList);
                trip.Tickets.Add(model);
                
            }

            // 删除
            ctx.Tickets.RemoveRange(deletedTicketList.Where(o=>o.id>0).ToArray());
            
            ctx.SaveChanges();
            deletedTicketList.Clear();
            MessageHelper.InfoBox("成功保存！");
        }

        private DataGridView GetDataGridViewBySupplierType()
        {
            DataGridView view = null;
            switch ((supplierType))
            {
                case SupplierEnum.Flight:
                    view = this.flightDataGridView;
                    break;
                case SupplierEnum.Train:
                    view = this.trainDataGridView;
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
                case SupplierEnum.WIFI:
                    view = this.WIFIGridView;
                    break;
                case SupplierEnum.Activity:
                    view = this.activityDataGridView;
                    break;
            }
            return view;
        }

        #endregion


        private void findFileButton_Click(object sender, EventArgs e)
        {
            var form = new SelectSystemfile();
            form.ShowDialog();


            //if (form.ShowDialog() == DialogResult.Yes)
            {
                List<string> reference = form.listfile;
                if (reference.Count > 0)
                {
                    imgPathTextBox.Text = reference[0];

                    pictureBox1.ImageLocation = reference[1];
                }


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

        private void customersTextBox2_TextChanged(object sender, EventArgs e)
        {
            var cnames = customersTextBox2.Text.Split(",，".ToArray()).Distinct();

            customerList = customerList.Where(o => cnames.Contains(o.name)).ToList();

            customersTextBox2.Text = string.Join(",", customerList.Select(o => o.name).ToList());
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (this.tabControl1.SelectedTab == this.ticketTabPage)
            {
                SetTicketDateGridViewDataSource();
            }
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
            var cnames = nationTextBox.Text.Split(",，".ToArray()).Distinct();

            nationList = nationList.Where(o => cnames.Contains(o.title)).ToList();

            nationTextBox.Text = string.Join(",", nationList.Select(o => o.title).ToList());           
        }

    }
}
