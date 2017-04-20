using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCTS.CustomComponents
{
    public partial class NewTripForm : BaseModalForm
    {
 
        public NewTripForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            using (var ctx = new DctsEntities())
            {
                var obj = ctx.Trips.Create();
                obj.title = this.titleTextBox.Text;
                obj.memo = this.memoTextBox.Text;
                obj.days = Convert.ToInt32( this.daysNumericUpDown.Value );

                ctx.Trips.Add(obj);
                ctx.SaveChanges();
            }
        }
    }
}
