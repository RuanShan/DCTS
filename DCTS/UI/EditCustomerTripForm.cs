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
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            this.tripFormControl1.FillModelByForm(this.trip);
            ctx.SaveChanges();
        }

        private void EditTripForm_Load(object sender, EventArgs e)
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;

            this.trip = ctx.Trips.Find(TripId);
            this.ticketList = trip.Tickets.ToList();
            this.supplierList = ctx.Suppliers.ToList();

            this.tripFormControl1.FillFormByModel(trip);
            this.tripFormControl1.daysNumericUpDown.ReadOnly = true;

            //行程客户
            this.customerList = this.trip.TripCustomers.Select(o => o.Customer).ToList();
            string countryNames = this.trip.countries != null ? this.trip.countries : string.Empty;
            this.nationList = GlobalCache.NationList.Where(o => countryNames.Contains(o.title)).ToList();

            airportList = ComboLoactionBusiness.TypedLocation(ctx, ComboLocationEnum.Airport);

            SetTicketDateGridViewDataSource();
        }

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
            //保险
            this.insuranceCustomerColumn.DisplayMember = "name";
            this.insuranceCustomerColumn.ValueMember = "id";
            this.insuranceCustomerColumn.DataSource = this.customerList;
            //
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


            this.hotelCustomerColumn.DisplayMember = "name";
            this.hotelCustomerColumn.ValueMember = "id";
            this.hotelCustomerColumn.DataSource = this.customerList;

            var names = nationList.Select(o => o.title).ToArray();
            var airports = airportList.Where(o => names.Contains(o.nation)).ToList();
            airports.Insert(0, new ComboLocation() { id = 0, title = "请选择机场" });
            this.fromAirportColumn.DisplayMember = "title";
            this.fromAirportColumn.ValueMember = "id";
            this.fromAirportColumn.DataSource = airports;
            this.toAirportColumn.DisplayMember = "title";
            this.toAirportColumn.ValueMember = "id";
            this.toAirportColumn.DataSource = airports;

            //活动项目
            //string code =.ToString();
            using (var ctx = new DctsEntities())
            {
                List<ComboLocation> List = ctx.ComboLocations.ToList();

                var nationList1 = DCTS.DB.GlobalCache.NationList;
                var codelist = nationList1.FindAll(o => o.title == trip.countries);
                if (codelist != null && codelist.Count > 0)
                {
                    var cityList = DCTS.DB.GlobalCache.CityList;
                    cityList = cityList.Where(o => o.nationCode == codelist.First().code).ToList();
                    var cities = cityList.Select(o => new MockEntity { Id = o.id, FullName = o.title }).ToList();
                    this.cityColumn2.DisplayMember = "FullName";
                    this.cityColumn2.ValueMember = "FullName";
                    this.cityColumn2.DataSource = cities;

                    //酒店


                    var names1 = cityList.Select(o => o.title).ToArray();
                    var hotellist = List.Where(o => names1.Contains(o.city) && o.ltype == (int)ComboLocationEnum.Hotel).ToList();

                    var hotel = hotellist.Select(o => new MockEntity { Id = o.id, FullName = o.title }).ToList();
                    this.titlxColumn2.DisplayMember = "FullName";
                    this.titlxColumn2.ValueMember = "FullName";
                    this.titlxColumn2.DataSource = hotel;

                    //活动项目
                    var activelist = List.Where(o => names1.Contains(o.city) && o.ltype == (int)ComboLocationEnum.Activity).ToList();
                    var active = activelist.Select(o => new MockEntity { Id = o.id, FullName = o.title }).ToList();
                    this.rulesColumn6.DisplayMember = "FullName";
                    this.rulesColumn6.ValueMember = "FullName";
                    this.rulesColumn6.DataSource = active;

                }
            }


            //飞机
            flightSupplierColumn.DisplayMember = "name";
            flightSupplierColumn.ValueMember = "id";
            flightSupplierColumn.DataSource = GetSuppliersByType(SupplierEnum.Flight);

            //
            //保险
            titleTextBoxColumn3.DisplayMember = "name";
            titleTextBoxColumn3.ValueMember = "name";
            titleTextBoxColumn3.DataSource = GetSuppliersByType(SupplierEnum.Insurance);

            //租车公司
            titleColumn4.DisplayMember = "name";
            titleColumn4.ValueMember = "name";
            titleColumn4.DataSource = GetSuppliersByType(SupplierEnum.Rental);



            var view = ticketView;
            SetTicketViewFilter();

            this.flightDataGridView.DataSource = view;
            this.hotalDataGridView.DataSource = view;
            this.InsuranceGridView.DataSource = view;
            this.RentalGridView.DataSource = view;
            this.WIFIGridView.DataSource = view;
            this.activityDataGridView.DataSource = view;

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

            // 保存及添加
            foreach (var ticket in ticketView)
            {
                trip.Tickets.Add(ticket);
            }

            // 删除
            ctx.Tickets.RemoveRange(deletedTicketList.Where(o => o.id > 0).ToArray());

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

        #endregion

        private void RentalGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            bool handle;
            if (RentalGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals(DBNull.Value))
            {
                handle = true;
            }
            else
                handle = false;
            e.Cancel = handle;
        }

        private void activityDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        //    bool handle;
           
        //    {
        //        if (activityDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals(DBNull.Value))
        //        {
        //            handle = true;
        //        }
        //        else
        //            handle = false;
        //        e.Cancel = handle;
        //    }
         }


    }
}
