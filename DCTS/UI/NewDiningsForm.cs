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
        public bool Saved;
        ComboLocation originalDinings;

        public NewDiningsForm(string maintype, ComboLocation obj)
        {
            InitializeComponent();

            Saved = false;
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
                imgPathTextBox.Text = obj.image_path;
                this.latlngTextBox.Text = obj.latlng;
                this.routeTextBox.Text = obj.local_address;
                this.localAddressTextBox.Text = obj.address;
                this.textBox3.Text = obj.recommended_dishes;
                this.tipsTextBox.Text = obj.tips;
                this.localTitleTextBox.Text = obj.title;
                this.openCloseTextBox.Text = obj.open_close_more;
                this.routeTextBox.Text = obj.route;
                this.originalDinings = new ComboLocation() { img = obj.image_path };
                //处理图片
                //处理图片
                if (obj.image_path != null && obj.image_path.Length > 0)
                {
                    if (obj.id > 0)
                    {
                        this.imgPathTextBox.Text = Path.Combine(obj.image_path);
                        string lcoalPath = EntityPathHelper.LocationImagePathEx(obj);
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
                        obj.image_path = imgFilePath;
                        obj.latlng = this.latlngTextBox.Text;
                        obj.local_address = this.routeTextBox.Text;
                        obj.address = this.localAddressTextBox.Text;
                        obj.recommended_dishes = this.textBox3.Text;
                        obj.tips = this.tipsTextBox.Text;
                        obj.title = this.localTitleTextBox.Text;
                        obj.open_close_more = this.openCloseTextBox.Text;
                        obj.route = this.routeTextBox.Text;
                        ComboLoactionBusiness.Validate(obj);              
                    
                        imgFilePath = obj.image_path;

                        bool newImg = (obj.image_path != originalDinings.img);
                        if (newImg)
                        {
                            //imgFileName = Path.GetFileName(imgFilePath);
                            //obj.image_path = imgFileName;
                            //string copyToPath = EntityPathHelper.LocationImagePath(obj);
                            //File.Copy(imgFilePath, copyToPath, true);
                            string imagePath = obj.image_path;
                            //用户选择了素材目录的其他图片
                            if (imagePath.StartsWith(EntityPathHelper.ImageBasePath))
                            {
                                string relativeImagePath = imagePath.Substring(EntityPathHelper.ImageBasePath.Length);
                                obj.image_path = relativeImagePath;
                            }
                            else
                            { // 用户选择素材目录之外的图片
                                 imgFileName = Path.GetFileName(imagePath);
                                obj.image_path = imgFileName;
                                string copyToPath = EntityPathHelper.LocationImagePathEx(obj);
                                File.Copy(imagePath, copyToPath, true);
                            }

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
                        obj.image_path = imgFilePath;
                        obj.latlng = this.latlngTextBox.Text;
                        obj.local_address = this.routeTextBox.Text;
                        obj.address = this.localAddressTextBox.Text;
                        obj.recommended_dishes = this.textBox3.Text;
                        obj.tips = this.tipsTextBox.Text;
                        obj.title = this.localTitleTextBox.Text;
                        obj.open_close_more = this.openCloseTextBox.Text;
                        obj.route = this.routeTextBox.Text;
                        ComboLoactionBusiness.Validate(obj);
                        ctx.ComboLocations.Add(obj);

                        if (obj.image_path.Length > 0)
                        {
                            string imgPath = obj.image_path;
                            imgFileName = Path.GetFileName(imgPath);
                            obj.img = imgFileName;
                            //string copyToPath = EntityPathHelper.LocationImagePath(obj);
                            //File.Copy(imgPath, copyToPath);
                        }
                      
                        ctx.SaveChanges();

                        ////拷贝图片需要对象ID，所以这样先创建对象，再拷贝图片
                        //if (obj.image_path != null && obj.image_path.Length > 0)
                        //{
                        //    string imgPath = imgFilePath;    
                        //    string copyToPath = EntityPathHelper.LocationImagePath(obj);
                        //    File.Copy(imgPath, copyToPath, true);
                        //}
                        if (obj.img.Length > 0)
                        {
                            string imgPath = imgFilePath;
                            string copyToPath = EntityPathHelper.LocationImagePath(obj);
                            File.Copy(imgPath, copyToPath);
                        }   

                    }
                    Saved = true;
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
            openFileDialog1.InitialDirectory = EntityPathHelper.ImageBasePath;
          
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
            //if (Saved == false)
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
