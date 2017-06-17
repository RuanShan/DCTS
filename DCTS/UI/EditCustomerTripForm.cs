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
            ctx.Tickets.RemoveRange(deletedTicketList.Where(o=>o.id>0).ToArray());
            
            ctx.SaveChanges();

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


    }
}
