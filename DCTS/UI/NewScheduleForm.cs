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
    public partial class NewScheduleForm : BaseModalForm
    {
        private long changeid;
        TripDay NewTripItem;
        public NewScheduleForm(string maintype, Schedule obj, TripDay TripItem)
        {
            InitializeComponent();
            NewTripItem = TripItem;

            InitializeDataSource();
            changeid = 0;
            if (maintype == "Edit")
            {
                label2.Text = "编辑行程";
                this.Text = "编辑行程";
                changeid = obj.id;
                this.dateTimePicker1.Value = Convert.ToDateTime(obj.start_at);

                this.textBox6.Text = obj.title;

            }
        }

        public void InitializeDataSource()
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            var nationList = DCTS.DB.GlobalCache.NationList;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            using (var ctx = new DctsEntities())
            {
                try
                {

                    if (changeid == 0)
                    {

                        var obj = ctx.Schedules.Create();
                        obj.tripday_id = NewTripItem.id;// 80;// NewTripItem.trip_id;
                        obj.title = textBox6.Text;
                        obj.start_at = this.dateTimePicker1.Value;
                        obj.created_at = DateTime.Now;


                        ctx.Schedules.Add(obj);
                        if (this.textBox6.Text.Length > 0 && this.textBox6.Text.Length <= 1000)
                            ctx.SaveChanges();
                        else
                        {
                            MessageBox.Show("错误：请检查名称的长度！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    else
                    {
                        Schedule obj = ctx.Schedules.Find(Convert.ToInt32(changeid));
                        obj.title = this.textBox6.Text;
                        obj.tripday_id = NewTripItem.id;

                        obj.start_at = this.dateTimePicker1.Value;
                        obj.updated_at = DateTime.Now;

                        ctx.SaveChanges();
                    }
                }
                catch (Exception EX)
                {
                    MessageBox.Show("异常" + EX);

                    return;

                    throw;
                }


            }

        }




        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }


    }
}
