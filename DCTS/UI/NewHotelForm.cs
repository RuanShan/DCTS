using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCTS.Bus;
using DCTS.DB;

namespace DCTS.UI
{
    public partial class NewHotelForm : BaseModalForm
    {
        private long ModelId { get; set; }
        ComboLocation originalHotel;
        public bool Saved { get; set; }

        public NewHotelForm(string maintype, ComboLocation obj)
        {
            InitializeComponent();
            InitializeDataSource();
            ModelId = 0;
            Saved = false;

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
                routeTextBox.Text = obj.route;
                contact.Text = obj.contact;
                wifi.Text = obj.wifi;
                parking.Text = obj.parking;
                reception.Text = obj.reception;
                kitchen.Text = obj.kitchen;
                tipsTextBox.Text = obj.tips;
                this.originalHotel = new ComboLocation() { img = obj.img };
                //处理图片
                if (obj.img!=null && obj.img.Length > 0)
                {
                    if (obj.id > 0)
                    {
                        this.imgPathTextBox.Text = obj.img;
                        string lcoalPath = EntityPathHelper.LocationImagePath(obj);
                        pictureBox1.ImageLocation = lcoalPath;
                    }
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
                    #region 检查图片是否存在
                    string imgFilePath = this.imgPathTextBox.Text;
                    string imgFileName = Path.GetFileName(imgFilePath);

                    #endregion
                    if (ModelId == 0)
                    {

                        var obj = ctx.ComboLocations.Create();
                        obj.ltype = (int)ComboLocationEnum.Hotel;
                        obj.nation = this.nationComboBox.Text;
                        obj.city = this.cityComboBox.Text;
                        obj.title = this.titleTextBox.Text;
                        obj.local_title = this.localTitleTextBox.Text;
                        obj.img = imgFilePath;// this.imgPathTextBox.Text;

                        obj.room = room.Text;
                        obj.dinner = moringTextBox.Text;
                        obj.latlng = latlng.Text;
                        obj.address = address.Text;
                        obj.route = routeTextBox.Text;
                        obj.contact = contact.Text;
                        obj.wifi = wifi.Text;
                        obj.parking = parking.Text;
                        obj.reception = reception.Text;
                        obj.kitchen = kitchen.Text;
                        obj.tips = this.tipsTextBox.Text;
                        ComboLoactionBusiness.Validate(obj);
                        ctx.ComboLocations.Add(obj);
                        if (obj.img.Length > 0)
                        {
                            string imgPath = obj.img;
                            imgFileName = Path.GetFileName(imgPath);
                            obj.img = imgFileName;
                        }
                        ctx.SaveChanges();
                        if (obj.img.Length > 0)
                        {
                            string imgPath = imgFilePath;
                            string copyToPath = EntityPathHelper.LocationImagePath(obj);
                            File.Copy(imgPath, copyToPath, true);
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
                        obj.img = imgFilePath;

                        obj.room = room.Text;
                        obj.dinner = moringTextBox.Text;
                        obj.latlng = latlng.Text;
                        obj.address = address.Text;
                        obj.route = routeTextBox.Text;
                        obj.contact = contact.Text;
                        obj.wifi = wifi.Text;
                        obj.parking = parking.Text;
                        obj.reception = reception.Text;
                        obj.kitchen = kitchen.Text;
                        obj.tips = this.tipsTextBox.Text;

                        ComboLoactionBusiness.Validate(obj);

                        imgFilePath = obj.img;

                        bool newImg = (obj.img != originalHotel.img);
                        if (newImg)
                        {
                            imgFileName = Path.GetFileName(imgFilePath);
                            obj.img = imgFileName;
                            string copyToPath = EntityPathHelper.LocationImagePath(obj);
                            File.Copy(imgFilePath, copyToPath, true);
                        }
                        ctx.SaveChanges();
                    }
                    this.Saved = true;
                    this.Close();
                }
                catch (DbEntityValidationException exception)
                {
                    MessageBox.Show(exception.Message);
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
