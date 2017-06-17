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
    public partial class EditCustomerFlightForm : BaseModalForm
    {
        private long ModelId { get; set; }

        private List<Supplier> flightCompanies;

        public EditCustomerFlightForm( )
        {
            InitializeComponent();
            InitializeDataSource();
         }

        public void InitializeDataSource()
        {
            using (var ctx = new DctsEntities())
            {
                flightCompanies = SupplierBusiness.TypedSuppliers(ctx, SupplierEnum.Flight);
                this.flightCompanyComboBox.DisplayMember = "id";
                this.flightCompanyComboBox.ValueMember = "name";
                this.flightCompanyComboBox.DataSource = flightCompanies;
            }
        }



        private void saveButton_Click(object sender, EventArgs e)
        {

            using (var ctx = new DctsEntities())
            {
                var model = ctx.DayLocations.Find(ModelId);

                FillModel(model);

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

        private void FillModel(DayLocation model)
        {
            model.flight_company = Convert.ToInt32( this.flightCompanyComboBox.SelectedValue );
            //model.flight_no = this.flightNoTextBox.Text;
            //model.flight_from = this.flightFromTextBox.Text;
            //model.flight_to = this.flightToTextBox.Text;
            //model.flight_start_at = this.flightStartDateTimePicker.Value;
            //model.flight_end_at = this.flightEndDateTimePicker.Value;
            //model.airport_from = this.airportFromTextBox.Text;
            //model.airport_to = this.airportToTextBox.Text;

            //model.flight_layover = this.flightLayoverCheckBox.Checked;
            if (model.flight_layover)
            {
                //model.flight2_no = this.flight2NoTextBox.Text;
                //model.flight2_start_at = this.flight2StartDateTimePicker.Value;
                //model.flight2_end_at = this.flight2EndDateTimePicker.Value;
                //model.airport2_from = this.airport2FromTextBox5.Text;
                //model.airport2_to = this.airport2ToTextBox.Text;
            }

        }

    }
}
