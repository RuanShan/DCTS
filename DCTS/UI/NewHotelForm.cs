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
    public partial class NewHotelForm : BaseModalForm
    {
        private long changeid;
        public NewHotelForm(string maintype, ComboLocation obj)
        {
            InitializeComponent();
            InitializeDataSource();
            changeid = 0;
            if (maintype == "Edit")
            {
                //obj.ltype = (int)ComboLocationEnum.Hotel;
                this.nationComboBox.Text = obj.nation;
                this.cityComboBox.Text = obj.city;
                this.titleTextBox.Text = obj.title;
                this.localTitleTextBox.Text = obj.local_title;
                this.imgPathTextBox.Text = obj.img;
                this.openAtDateTimePicker.Text = obj.open_at.ToString();
                this.closeAtDateTimePicker.Text = obj.close_at.ToString();
                room.Text = obj.room;
                moringTextBox.Text = obj.dinner;
                latlng.Text = obj.latlng;
                address.Text = obj.address;
                local_address.Text = obj.local_address;
                contact.Text = obj.contact;
                wifi.Text = obj.wifi;
                parking.Text = obj.parking;
                reception.Text = obj.reception;
                kitchen.Text = obj.kitchen;
                changeid = obj.id;
            }
        }

        public void InitializeDataSource()
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            var nationList = DCTS.DB.GlobalCache.NationList;

            this.nationComboBox.DisplayMember = "title";
            this.nationComboBox.ValueMember = "code";
            this.nationComboBox.DataSource = nationList;

        }

        private void nationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string code = nationComboBox.SelectedValue.ToString();

            var cityList = DCTS.DB.GlobalCache.CityList;
            cityList = cityList.Where(o => o.nationCode == code).ToList();
            this.cityComboBox.DisplayMember = "title";
            this.cityComboBox.ValueMember = "id";
            this.cityComboBox.DataSource = cityList;

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string lcoalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\data\\images\\locations\\", "");
            string copypathto = "";

            List<string> Alist = GetFileName(lcoalPath);
            string[] dirs = Directory.GetDirectories(lcoalPath);
            for (int i = 0; i < dirs.Length; i++)
            {
                string[] files = Directory.GetFiles(dirs[i]);
                if (files.Length >= 1000)
                {
                    copypathto = lcoalPath + DateTime.Now.ToString("yyyyMMdd");

                    Directory.CreateDirectory(copypathto);
                    break;

                }
                else if (files.Length < 1000)
                {
                    copypathto = dirs[i] + "\\";
                    break;
                }
            }

            using (var ctx = new DctsEntities())
            {
                string copyfilename = Path.GetFileName(this.imgPathTextBox.Text);
                if (changeid == 0)
                {
                    createNewMethod(ctx, copyfilename);
                }
                else
                    editNewMethod(ctx, copyfilename);
                if (File.Exists(copypathto + copyfilename))
                {
                    if (MessageBox.Show("此文件名已在本文件夹中存在，是否覆盖?", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {

                        System.IO.File.Copy(this.imgPathTextBox.Text, copypathto + copyfilename, true);
                    }
                    else
                        return;
                }
                else
                    File.Copy(this.imgPathTextBox.Text, Path.Combine(copypathto, Path.GetFileName(this.imgPathTextBox.Text)));

            }

        }

        private void createNewMethod(DctsEntities ctx, string copyfilename)
        {
            var obj = ctx.ComboLocations.Create();
            obj.ltype = (int)ComboLocationEnum.Hotel;
            obj.nation = this.nationComboBox.Text;
            obj.city = this.cityComboBox.Text;
            obj.title = this.titleTextBox.Text;
            obj.local_title = this.localTitleTextBox.Text;
            obj.img = copyfilename;// this.imgPathTextBox.Text;
            //  obj.ticket = this.tickettime.Text;
            obj.open_at = Convert.ToDateTime(this.openAtDateTimePicker.Text);
            obj.close_at = Convert.ToDateTime(this.closeAtDateTimePicker.Text);
            obj.room = room.Text;
            obj.dinner = moringTextBox.Text;
            obj.latlng = latlng.Text;
            obj.address = address.Text;
            obj.local_address = local_address.Text;
            obj.contact = contact.Text;
            obj.wifi = wifi.Text;
            obj.parking = parking.Text;
            obj.reception = reception.Text;
            obj.kitchen = kitchen.Text;

            ctx.ComboLocations.Add(obj);
            ctx.SaveChanges();
        }
        private void editNewMethod(DctsEntities ctx, string copyfilename)
        {
            ComboLocation obj = ctx.ComboLocations.Find(Convert.ToInt32(changeid));

            obj.ltype = (int)ComboLocationEnum.Hotel;
            obj.nation = this.nationComboBox.Text;
            obj.city = this.cityComboBox.Text;
            obj.title = this.titleTextBox.Text;
            obj.local_title = this.localTitleTextBox.Text;
            obj.img = copyfilename;// this.imgPathTextBox.Text;
            //  obj.ticket = this.tickettime.Text;
            obj.open_at = Convert.ToDateTime(this.openAtDateTimePicker.Text);
            obj.close_at = Convert.ToDateTime(this.closeAtDateTimePicker.Text);
            obj.room = room.Text;
            obj.dinner = moringTextBox.Text;
            obj.latlng = latlng.Text;
            obj.address = address.Text;
            obj.local_address = local_address.Text;
            obj.contact = contact.Text;
            obj.wifi = wifi.Text;
            obj.parking = parking.Text;
            obj.reception = reception.Text;
            obj.kitchen = kitchen.Text;

            //ctx.ComboLocations.Add(obj);
            ctx.SaveChanges();
        }
        private List<string> GetFileName(string dirPath)
        {
            List<string> FileNameList = new List<string>();
            ArrayList list = new ArrayList();

            if (Directory.Exists(dirPath))
            {
                list.AddRange(Directory.GetFiles(dirPath));
            }
            if (list.Count > 0)
            {
                foreach (object item in list)
                {
                    FileNameList.Add(item.ToString().Replace(dirPath + "\\", ""));
                }
            }

            return FileNameList;
        }
        private void findFileButton_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "PNG(*.png)|*.png|JPEG(*.jpg,*.jpeg,*.jpe,*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|GIF(*.gif)|*.gif"; //文件类型
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.imgPathTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void NewDinningsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
