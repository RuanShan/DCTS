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

namespace DCTS.UI
{
    public partial class NewCustomerForm : BaseModalForm
    {
        private long changeid;
        public NewCustomerForm(string maintype, Customer obj)
        {
            InitializeComponent();
            InitializeDataSource();
            changeid = 0;
            if (maintype == "Edit")
            {
                label2.Text = "编辑客户";
                this.Text = "编辑客户";
                changeid = obj.id;

                this.nameTextBox.Text = obj.name;
                this.genderComboBox.Text = obj.gender;
                this.ennameTextBox.Text = obj.enname;
                this.passporttexbox.Text = obj.passport;

            }
        }

        public void InitializeDataSource()
        {


        }



        private void saveButton_Click(object sender, EventArgs e)
        {

            using (var ctx = new DctsEntities())
            {
                bool nameishave = (ctx.Customers.Where(o => o.passport == passporttexbox.Text).Count() > 0);
                if (nameishave == true && changeid == 0)
                {
                    MessageBox.Show("同护照ID已存在");
                    return;

                }
                if (changeid == 0)
                {
               
                    Customer obj = new Customer();

                    obj.name = nameTextBox.Text;
                    obj.enname = ennameTextBox.Text;
                    obj.gender = genderComboBox.Text;
                    obj.passport = passporttexbox.Text;
                    obj.birthday = Convert.ToDateTime(birthdayTextBox.Text);

                    if (nameishave == false)
                    {    
                        ctx.Customers.Add(obj);
                        ctx.SaveChanges();
                    }
                }
                else
                {
                    Customer obj = ctx.Customers.Find(Convert.ToInt32(changeid));
                    obj.name = nameTextBox.Text;
                    obj.enname = ennameTextBox.Text;
                    obj.gender = genderComboBox.Text;
                    obj.passport = passporttexbox.Text;
                    obj.birthday = Convert.ToDateTime(birthdayTextBox.Text);

                    ctx.SaveChanges();

                }


            }


        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

    }
}
