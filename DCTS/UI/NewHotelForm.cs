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


            using (var ctx = new DctsEntities())
            {
              //  string copyfilename = Path.GetFileName(this.imgPathTextBox.Text);
                #region new
                string imgFilePath = this.imgPathTextBox.Text;
                string copyfilename = "";
                bool hasImg = (imgFilePath.Length > 0);
                bool existSameImage = false;

                if (hasImg)
                {
                    copyfilename = Path.GetFileName(imgFilePath);

                    ComboLocation lastLocation = ctx.ComboLocations.OrderByDescending(o => o.id).FirstOrDefault();
                    if (lastLocation != null)
                    {
                        long newId = lastLocation.id + 1;

                        long idStart = newId / 1000 * 1000;
                        long idEnd = idStart + 1000;
                        existSameImage = (ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Hotel && o.img == copyfilename && o.id > idStart && o.id < idEnd).Count() > 0);
                    }
                    if (existSameImage)
                    {
                        MessageBox.Show(string.Format("文件名<{0}>已在, 请使用其他文件名！", copyfilename));
                        return;
                    }
                }

                #endregion
                if (changeid == 0)
                {
                    //  createNewMethod(ctx, copyfilename);
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
                    if (hasImg)
                    {
                        string copyToPath = EntityPathConfig.LocationImagePath(obj);
                        File.Copy(imgFilePath, copyToPath);
                    }


                }
                else
                {
                    //  editNewMethod(ctx, copyfilename);

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

                    if (hasImg)
                    {
                        string copyToPath = EntityPathConfig.LocationImagePath(obj);
                        File.Copy(imgFilePath, copyToPath);
                    }
                }
                //if (imgPathTextBox.Text != null && imgPathTextBox.Text != "")
                //{
                //    long folername = changeid / 1000;

                //    string copypathto = imagefolderNewMethod(folername);

                //    if (File.Exists(copypathto + "\\" + copyfilename))
                //    {
                //        if (MessageBox.Show("此文件名已在本文件夹中存在，是否覆盖?", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                //        {

                //            System.IO.File.Copy(this.imgPathTextBox.Text, copypathto + "\\" + copyfilename, true);
                //        }
                //        else
                //            return;
                //    }
                //    else
                //        File.Copy(this.imgPathTextBox.Text, Path.Combine(copypathto, Path.GetFileName(this.imgPathTextBox.Text)));
                //}
            }

        }


        private string imagefolderNewMethod(long filename)
        {
            string lcoalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\data\\images\\locations", "");

            if (Directory.Exists(lcoalPath))
            {
            }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(lcoalPath);
                directoryInfo.Create();
            }


            string copypathto = "";

            //List<string> Alist = GetFileName(lcoalPath);
            string[] dirs = Directory.GetDirectories(lcoalPath + "\\");


            DirectoryInfo dir = new DirectoryInfo(lcoalPath);
            //  FileInfo[] fil = dir.GetFiles();
            DirectoryInfo[] dii = dir.GetDirectories();
            int ishad = 0;
            foreach (DirectoryInfo f in dii)
            {
                if (f.Name == filename.ToString())
                {
                    copypathto = lcoalPath + "\\" + filename.ToString();

                    ishad++;

                }
            }
            if (ishad == 0)
            {
                Directory.CreateDirectory(lcoalPath + "\\" + filename.ToString());
                copypathto = lcoalPath + "\\" + filename.ToString();

            }

            return copypathto;
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
