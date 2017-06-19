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
        private long ModelId { get; set; }

        public NewHotelForm(string maintype, ComboLocation obj)
        {
            InitializeComponent();
            InitializeDataSource();
            ModelId = 0;
            if (maintype == "Edit")
            {
                label2.Text = "编辑住宿";
                this.Text = "编辑住宿";
                ModelId = obj.id;
                //obj.ltype = (int)ComboLocationEnum.Hotel;
                this.nationComboBox.Text = obj.nation;
                this.cityComboBox.Text = obj.city;
                this.titleTextBox.Text = obj.title;
                this.localTitleTextBox.Text = obj.local_title;
                this.imgPathTextBox.Text = obj.img;
                //this.openAtDateTimePicker.Text = obj.open_at.ToString();
                //this.closeAtDateTimePicker.Text = obj.close_at.ToString();
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
                if (obj.img != null)
                {
                    pictureBox1.ImageLocation = EntityPathConfig.LocationImagePath(obj);
                }
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


            using (var ctx = new DctsEntities())
            {
                try
                {
                    //  string copyfilename = Path.GetFileName(this.imgPathTextBox.Text);
                    #region new
                    string imgFilePath = this.imgPathTextBox.Text;
                    string copyfilename = "";
                    bool hasImg = (imgFilePath.Length > 0);
                    bool existSameImage = false;
                    bool nameishave = false;
                    if (hasImg)
                    {
                        copyfilename = Path.GetFileName(imgFilePath);

                        existSameImage = (ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Hotel && o.img == copyfilename && o.id!=ModelId).Count() > 0);

                    }
                    bool hastitle = (titleTextBox.Text.Length > 0);
                    if (hastitle)
                    {

                        nameishave = (ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Hotel && o.title == titleTextBox.Text && o.id != ModelId).Count() > 0);
                    }
                    #endregion
                    if (ModelId == 0)
                    {
                        if (existSameImage)
                        {
                            MessageBox.Show(string.Format("文件名<{0}>已在, 请使用其他文件名！", copyfilename));
                            return;
                        }
                        var obj = ctx.ComboLocations.Create();
                        obj.ltype = (int)ComboLocationEnum.Hotel;
                        obj.nation = this.nationComboBox.Text;
                        obj.city = this.cityComboBox.Text;
                        obj.title = this.titleTextBox.Text;
                        obj.local_title = this.localTitleTextBox.Text;
                        obj.img = copyfilename;// this.imgPathTextBox.Text;
                        //  obj.ticket = this.tickettime.Text;
                        //obj.open_at = Convert.ToDateTime(this.openAtDateTimePicker.Text);
                        //obj.close_at = Convert.ToDateTime(this.closeAtDateTimePicker.Text);
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
                        obj.tips = this.textBox6.Text;
                        ctx.ComboLocations.Add(obj);
                        if (nameishave == false && this.titleTextBox.Text.Length <= 100)
                            ctx.SaveChanges();
                        else
                        {
                            MessageBox.Show("错误：请检查名称的长度或是否已存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (hasImg)
                        {
                            string copyToPath = EntityPathConfig.LocationImagePath(obj);
                           if (!File.Exists(copyToPath))
                            File.Copy(imgFilePath, copyToPath);
                        }
                    }
                    else
                    {


                        ComboLocation obj = ctx.ComboLocations.Find(Convert.ToInt32(ModelId));

                        obj.ltype = (int)ComboLocationEnum.Hotel;
                        obj.nation = this.nationComboBox.Text;
                        obj.city = this.cityComboBox.Text;
                        obj.title = this.titleTextBox.Text;
                        obj.local_title = this.localTitleTextBox.Text;
                        obj.img = copyfilename;// this.imgPathTextBox.Text;
                        //  obj.ticket = this.tickettime.Text;
                        //obj.open_at = Convert.ToDateTime(this.openAtDateTimePicker.Text);
                        //obj.close_at = Convert.ToDateTime(this.closeAtDateTimePicker.Text);
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
                        obj.tips = this.textBox6.Text;
                        //ctx.ComboLocations.Add(obj);
                        if (hasImg)
                        {

                            string imgFileName = Path.GetFileName(imgFilePath);

                            obj.img = imgFileName;
                        }

                        ctx.SaveChanges();

                        if (hasImg)
                        {
                            imgFilePath = pictureBox1.ImageLocation;
                            string copyToPath = EntityPathConfig.LocationImagePath(obj);                            
                            File.Copy(imgFilePath, copyToPath, true);
                        }
                    }
                }
                catch (Exception EX)
                {

                    throw;
                }


            }

        }


        private void findFileButton_Click(object sender, EventArgs e)
        {

            //  openFileDialog1.Filter = "PNG(*.png)|*.png|JPEG(*.jpg,*.jpeg,*.jpe,*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|GIF(*.gif)|*.gif"; //文件类型
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.imgPathTextBox.Text = openFileDialog1.FileName;
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void NewDinningsForm_Load(object sender, EventArgs e)
        {

        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            using (var ctx = new DctsEntities())
            {
                bool nameishave = false;
                bool hastitle = (titleTextBox.Text.Length > 0);
                if (hastitle)
                {
                    ComboLocation lastLocation = ctx.ComboLocations.OrderByDescending(o => o.id).FirstOrDefault();
                    if (lastLocation != null)
                        nameishave = (ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Hotel && o.title == titleTextBox.Text).Count() > 0);

                    if (ModelId == 0)
                    {
                        if (nameishave == true || this.titleTextBox.Text.Length > 100)
                            errorProvider1.SetError(titleTextBox, String.Format("错误：请检查名称的长度或是否已存在 {0}", titleTextBox.Text));
                    }
                    else
                    {
                        if (this.titleTextBox.Text.Length > 100)
                            errorProvider1.SetError(titleTextBox, String.Format("错误：请检查名称的长度 {0}", titleTextBox.Text));
                    }
                }
            }
        }
    }
}
