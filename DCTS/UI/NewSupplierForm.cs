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
using DCTS.Bus;

namespace DCTS.UI
{
    public partial class NewSupplierForm : BaseModalForm
    {
        private long changeid;
        List<MockEntity> locationTypeList;
        public bool istrue;
        Supplier originalSupplier;

        public NewSupplierForm(string maintype, Supplier obj)
        {
            InitializeComponent();
            locationTypeList = GlobalCache.Supplier_LocationTypeList;
            InitializeDataSource();

            changeid = 0;
            if (maintype == "Edit")
            {
                this.originalSupplier = new Supplier() { image_path = obj.image_path };

                label2.Text = "编辑供应商";
                this.Text = "编辑供应商";
                changeid = obj.id;
                this.titleTextBox.Text = obj.name;
                this.cshtextbox.Text = obj.csh;
                this.imgPathTextBox.Text = obj.image_path;
                var st = this.locationTypeList.Where(s => s.Id.ToString().StartsWith(obj.stype.ToString())).ToList();
                if (st.Count > 0)
                {
                    var store = st.First();
                    this.supplComboBox.SelectedValue = store.Id;
                }

                //supplComboBox.Text = (int)SupplierEnum.stype;

                //处理图片
                if (obj.image_path != null && obj.image_path.Length > 0)
                {
                    if (obj.id > 0)
                    {
                        this.imgPathTextBox.Text = Path.Combine(obj.image_path);

                        string localPath = EntityPathHelper.LocationImagePathEx(obj);
                        pictureBox1.ImageLocation = localPath;
                    }
                }
            }
        }

        public void InitializeDataSource()
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            var nationList = DCTS.DB.GlobalCache.NationList;
            var locationTypeListForComboBox = locationTypeList.Select(o => new MockEntity { Id = o.Id, FullName = o.FullName }).ToList();

            // 活动分类
            this.supplComboBox.DisplayMember = "FullName";
            this.supplComboBox.ValueMember = "Id";
            this.supplComboBox.DataSource = locationTypeListForComboBox;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(this.titleTextBox.Text.Length == 0)
            {
                MessageBox.Show("请输入供应商名称！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var ctx = new DctsEntities())
            {
                try
                {
                    int ty = Convert.ToInt32(this.supplComboBox.SelectedValue);
                    string imgFilePath = this.imgPathTextBox.Text;


                    if (changeid != 0)
                    {
                        
                        Supplier obj = ctx.Suppliers.Find(Convert.ToInt32(changeid));
                        obj.stype = Convert.ToInt32(this.supplComboBox.SelectedValue);
                        obj.name = this.titleTextBox.Text;

                        obj.image_path = imgFilePath;

                        bool newImg = (obj.image_path != originalSupplier.image_path);
                        if (newImg)
                        {
                            SupplierBusiness.ProcessImage(obj);
                        }

                        obj.csh = this.cshtextbox.Text;
                        obj.updated_at = DateTime.Now;

                        ctx.SaveChanges();
                        
                    }
                    else
                    {
                        var obj = ctx.Suppliers.Create();
                        obj.stype = Convert.ToInt32(this.supplComboBox.SelectedValue);
                        obj.name = this.titleTextBox.Text;
                        obj.image_path = imgFilePath;
                        SupplierBusiness.ProcessImage(obj);

                        obj.csh = this.cshtextbox.Text;
                        obj.created_at = DateTime.Now;

                        ctx.Suppliers.Add(obj);
                        ctx.SaveChanges();
                       
                    }
                    istrue = true;

                }
                catch (Exception EX)
                {
                    throw;
                }
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

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
                        nameishave = (ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Country && o.title == titleTextBox.Text).Count() > 0);

                    if (changeid == 0)
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

        private void findFileButton_Click(object sender, EventArgs e)
        {

        }

        private void findFileButton_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = EntityPathHelper.ImageBasePath;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.imgPathTextBox.Text = openFileDialog1.FileName;
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void NewSupplierForm_Load(object sender, EventArgs e)
        {
         
        }
    }
}
