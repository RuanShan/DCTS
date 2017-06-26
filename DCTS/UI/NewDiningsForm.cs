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
    public partial class NewDiningsForm : BaseModalForm
    {
        private long ModelId { get; set; }
        public bool istrue;
        ComboLocation originalDinings;

        public NewDiningsForm(string maintype, ComboLocation obj)
        {
            InitializeComponent();

       
            istrue = true;
            ModelId = 0;
            if (maintype == "Edit")
            {
            
                label2.Text = "编辑餐厅";
                this.Text = "编辑餐厅";
                ModelId = obj.id;
                this.nationComboBox.Text = obj.nation;
                this.cityComboBox.Text = obj.city;
                this.titleTextBox.Text = obj.area;
                this.textBox1.Text = obj.dishes;
                imgPathTextBox.Text = obj.img;
                this.latlngTextBox.Text = obj.latlng;
                this.textBox2.Text = obj.local_address;
                this.localAddressTextBox.Text = obj.address;
                this.textBox3.Text = obj.recommended_dishes;
                this.textBox6.Text = obj.tips;
                this.localTitleTextBox.Text = obj.title;
                this.originalDinings = new ComboLocation() { img = obj.img };
                //处理图片
                if (obj.img.Length > 0)
                {
                    if (obj.id > 0)
                    {
                        this.imgPathTextBox.Text = obj.img;
                        string lcoalPath = EntityPathConfig.LocationImagePath(obj);
                        pictureBox1.ImageLocation = lcoalPath;
                    }
                }
            }
            InitializeDataSource();
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

                    #region new
                    string imgFilePath = this.imgPathTextBox.Text;
                    string imgFileName = Path.GetFileName(imgFilePath);
                    #endregion
                  
                    if (ModelId != 0)
                    {
                 
                        ComboLocation obj = ctx.ComboLocations.Find(Convert.ToInt32(ModelId));
                        obj.ltype = (int)ComboLocationEnum.Dining;
                        obj.nation = this.nationComboBox.Text;
                        obj.city = this.cityComboBox.Text;
                        obj.area = this.titleTextBox.Text;
                        obj.dishes = this.textBox1.Text;
                        obj.img = imgFilePath;
                        obj.latlng = this.latlngTextBox.Text;
                        obj.local_address = this.textBox2.Text;
                        obj.address = this.localAddressTextBox.Text;
                        obj.recommended_dishes = this.textBox3.Text;
                        obj.tips = this.textBox6.Text;
                        obj.title = this.localTitleTextBox.Text;
                        obj.open_close_more = this.openCloseTextBox.Text;
                        ComboLoactionBusiness.Validate(obj);              
                    
                        imgFilePath = obj.img;

                        bool newImg = (obj.img != originalDinings.img);
                        if (newImg)
                        {
                            imgFileName = Path.GetFileName(imgFilePath);
                            obj.img = imgFileName;
                            string copyToPath = EntityPathConfig.LocationImagePath(obj);
                            File.Copy(imgFilePath, copyToPath, true);
                        }
                        ctx.SaveChanges();
                    }
                    else
                    {
                        var obj = ctx.ComboLocations.Create();
                        obj.ltype = (int)ComboLocationEnum.Dining;
                        obj.nation = this.nationComboBox.Text;
                        obj.city = this.cityComboBox.Text;
                        obj.area = this.titleTextBox.Text;
                        obj.dishes = this.textBox1.Text;
                        obj.img = imgFilePath;
                        obj.latlng = this.latlngTextBox.Text;
                        obj.local_address = this.textBox2.Text;
                        obj.address = this.localAddressTextBox.Text;
                        obj.recommended_dishes = this.textBox3.Text;
                        obj.tips = this.textBox6.Text;
                        obj.title = this.localTitleTextBox.Text;
                        obj.open_close_more = this.openCloseTextBox.Text;
                        ComboLoactionBusiness.Validate(obj);
                        ctx.ComboLocations.Add(obj);

                        if (obj.img.Length > 0)
                        {
                            string imgPath = obj.img;
                            imgFileName = Path.GetFileName(imgPath);
                            obj.img = imgFileName;
                            string copyToPath = EntityPathConfig.LocationImagePath(obj);
                            File.Copy(imgPath, copyToPath);
                        }                       

                        ctx.SaveChanges();
                    }
                    istrue = true;
                }
                catch (DbEntityValidationException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

        }


        private void findFileButton_Click(object sender, EventArgs e)
        {

            // openFileDialog1.Filter = "PNG(*.png)|*.png|JPEG(*.jpg,*.jpeg,*.jpe,*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|GIF(*.gif)|*.gif"; //文件类型
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

        private void NewDiningsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (istrue == false)
            //    e.Cancel = true;
            //else
            //    this.Close();

        }

        private void localTitleTextBox_TextChanged(object sender, EventArgs e)
        {
            using (var ctx = new DctsEntities())
            {
                bool nameishave = false;
                bool hastitle = (localTitleTextBox.Text.Length > 0);
                if (hastitle)
                {
                    ComboLocation lastLocation = ctx.ComboLocations.OrderByDescending(o => o.id).FirstOrDefault();
                    if (lastLocation != null)
                        nameishave = (ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Dining && o.title == localTitleTextBox.Text).Count() > 0);

                    if (ModelId == 0)
                    {
                        if (nameishave == true || this.localTitleTextBox.Text.Length > 100)
                            errorProvider1.SetError(localTitleTextBox, String.Format("错误：请检查名称的长度或是否已存在 {0}", localTitleTextBox.Text));
                    }
                    else
                    {
                        if (this.localTitleTextBox.Text.Length > 100)
                            errorProvider1.SetError(localTitleTextBox, String.Format("错误：请检查名称的长度 {0}", localTitleTextBox.Text));
                    }
                }
            }
        }

        private void NewDiningsForm_Load(object sender, EventArgs e)
        {
   
        }


    }
}
