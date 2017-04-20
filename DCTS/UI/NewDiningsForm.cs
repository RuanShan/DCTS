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

namespace DCTS.CustomComponents
{
    public partial class NewDiningsForm : BaseModalForm
    {
        private long changeid;

        public NewDiningsForm(string maintype, ComboLocation obj)
        {
            InitializeComponent();
            InitializeDataSource();
            changeid = 0;
            if (maintype == "Edit")
            {
                //obj.ltype = (int)ComboLocationEnum.Dining;
                this.nationComboBox.Text = obj.nation;
                this.cityComboBox.Text = obj.city;
                this.titleTextBox.Text = obj.area;
                this.textBox1.Text = obj.dishes;
                //obj.img = this.imgPathTextBox.Text;
                imgPathTextBox.Text = obj.img;
                this.latlngTextBox.Text = obj.latlng;
                this.textBox2.Text = obj.local_address;
                this.localAddressTextBox.Text = obj.address;
                this.textBox3.Text = obj.recommended_dishes;
                this.textBox6.Text = obj.tips;
                this.localTitleTextBox.Text = obj.title;
                this.openAtDateTimePicker.Text = obj.open_at.ToString();
                this.closeAtDateTimePicker.Text = obj.close_at.ToString();
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
                //string copyfilename = Path.GetFileName(this.imgPathTextBox.Text);
                #region new
                string imgFilePath = this.imgPathTextBox.Text;
                string imgFileName = "";
                bool hasImg = (imgFilePath.Length > 0);
                bool existSameImage = false;

                if (hasImg)
                {
                    imgFileName = Path.GetFileName(imgFilePath);
                    ComboLocation lastLocation = ctx.ComboLocations.OrderByDescending(o => o.id).FirstOrDefault();
                    if (lastLocation != null)
                    {
                        long newId = lastLocation.id + 1;

                        long idStart = newId / 1000 * 1000;
                        long idEnd = idStart + 1000;
                        existSameImage = (ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Dining && o.img == imgFileName && o.id > idStart && o.id < idEnd).Count() > 0);
                    }
                    if (existSameImage)
                    {
                        MessageBox.Show(string.Format("文件名<{0}>已在, 请使用其他文件名！", imgFileName));
                        //// this.saveButton.DialogResult = DialogResult.Cancel;
                        // this.DialogResult = System.Windows.Forms.DialogResult.No;
                        return;
                    }
                }
                #endregion
                // ComboLocation obj = new ComboLocation();
                if (changeid != 0)
                {

                    ComboLocation obj = ctx.ComboLocations.Find(Convert.ToInt32(changeid));
                    obj.ltype = (int)ComboLocationEnum.Dining;
                    obj.nation = this.nationComboBox.Text;
                    obj.city = this.cityComboBox.Text;
                    obj.area = this.titleTextBox.Text;
                    obj.dishes = this.textBox1.Text;
                    //obj.img = this.imgPathTextBox.Text;
                    obj.img = imgFileName;
                    obj.latlng = this.latlngTextBox.Text;
                    obj.local_address = this.textBox2.Text;
                    obj.address = this.localAddressTextBox.Text;
                    obj.recommended_dishes = this.textBox3.Text;
                    obj.tips = this.textBox6.Text;
                    obj.title = this.localTitleTextBox.Text;
                    obj.open_at = Convert.ToDateTime(this.openAtDateTimePicker.Text);
                    obj.close_at = Convert.ToDateTime(this.closeAtDateTimePicker.Text);
                    ctx.SaveChanges();
                    if (hasImg)
                    {
                        string copyToPath = EntityPathConfig.LocationImagePath(obj);
                        File.Copy(imgFilePath, copyToPath);
                    }
                }
                else
                {
                    var obj = ctx.ComboLocations.Create();
                    obj.ltype = (int)ComboLocationEnum.Dining;
                    obj.nation = this.nationComboBox.Text;
                    obj.city = this.cityComboBox.Text;
                    obj.area = this.titleTextBox.Text;
                    obj.dishes = this.textBox1.Text;
                    //obj.img = this.imgPathTextBox.Text;
                    obj.img = imgFileName;
                    obj.latlng = this.latlngTextBox.Text;
                    obj.local_address = this.textBox2.Text;
                    obj.address = this.localAddressTextBox.Text;
                    obj.recommended_dishes = this.textBox3.Text;
                    obj.tips = this.textBox6.Text;
                    obj.title = this.localTitleTextBox.Text;
                    obj.open_at = Convert.ToDateTime(this.openAtDateTimePicker.Text);
                    obj.close_at = Convert.ToDateTime(this.closeAtDateTimePicker.Text);
                    ctx.ComboLocations.Add(obj);
                    ctx.SaveChanges();
                    changeid = obj.id;
                    if (hasImg)
                    {
                        string copyToPath = EntityPathConfig.LocationImagePath(obj);
                        File.Copy(imgFilePath, copyToPath);
                    }
                }
                this.Close();

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
    }
}
