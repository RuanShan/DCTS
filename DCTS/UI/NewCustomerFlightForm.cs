using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCTS.DB;
using DCTS.Bus;

namespace DCTS.UI
{
    public partial class NewCustomerFlightForm : BaseModalForm
    {

        public List<Customer> CustomerList { get; set; }
        public List<Nation> NationList { get; set; }


        private long ModelId { get; set; }

        private List<Supplier> flightCompanies;
        private List<ComboLocation> airportList;
        private List<Ticket> flightTicketList { get; set; }


        public NewCustomerFlightForm(  List<Customer> customers,  List<Nation> nations )
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.CustomerList = customers;
            this.NationList = nations;
            this.flightTicketList = new List<Ticket>();
            InitializeDataSource();
         }

        public void InitializeDataSource()
        {
            this.customerComboBox.DataSource = this.CustomerList;
             
            using (var ctx = new DctsEntities())
            {
                flightCompanies = SupplierBusiness.TypedSuppliers(ctx, SupplierEnum.Flight);

                airportList = ComboLoactionBusiness.TypedLocation(ctx, ComboLocationEnum.Airport);

                this.fromAirportBindingSource.DataSource = airportList;
                this.toAirportBindingSource.DataSource = airportList;

                this.fromAirportColumn.DisplayMember = "title";
                this.fromAirportColumn.ValueMember = "id";
                this.fromAirportColumn.DataSource = this.fromAirportBindingSource;
                this.toAirportColumn.DisplayMember = "title";
                this.toAirportColumn.ValueMember = "id";
                this.toAirportColumn.DataSource = this.toAirportBindingSource;


                this.supplierComboBox.DisplayMember = "name";
                this.supplierComboBox.ValueMember = "id";
                this.supplierComboBox.DataSource = flightCompanies;
            }

            bindingSource1.DataSource = this.flightTicketList;
            this.dataGridView1.DataSource = bindingSource1;
        }



        private void saveButton_Click(object sender, EventArgs e)
        {

            using (var ctx = new DctsEntities())
            {
               
                FillModel();
                ctx.SaveChanges();
            }


        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void EditCustomerFlightForm_Load(object sender, EventArgs e)
        {

        }

        private void FillModel()
        {
 

        }

        private void newButton1_Click(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32( this.customerComboBox.SelectedValue );
            int sid = Convert.ToInt32(this.supplierComboBox.SelectedValue);
            int aid = airportList.FirstOrDefault().id;
            var ticket = new Ticket() { num="", from_location_id=aid, to_location_id=aid, customer_id = cid, supplier_id = sid, start_at = DateTime.Now, end_at = DateTime.Now };
            this.bindingSource1.Add(ticket);


        }

        private void deleteTicketButton_Click(object sender, EventArgs e)
        {
            if (this.bindingSource1.Current != null)
            {
                this.bindingSource1.RemoveCurrent();
            }
        }

    }
}
