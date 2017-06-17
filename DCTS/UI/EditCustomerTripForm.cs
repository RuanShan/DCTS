using DCTS.CustomComponents;
using DCTS.DB;
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
        SupplierEnum supplierType;
        private BindingListView<Ticket> ticketView;
        private List<Supplier> supplierList;

        public EditCustomerTripForm(long tripId)
        {
            InitializeComponent();
            TripId = tripId;
            supplierType = SupplierEnum.Flight;
            ticketView = new BindingListView<Ticket>(new List<Ticket>());
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
        }

        #region 处理票务信息

        private void SetTicketViewFilter()
        {
            ticketView.RemoveFilter();
            ticketView.ApplyFilter(delegate(Ticket ticket) { return ticket.ttype == (int)this.supplierType; });            
        }

        
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


        #endregion

        #endregion
    }
}
