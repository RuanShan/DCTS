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
    public partial class NewSupplierForm : BaseModalForm
    {
        private long changeid;
        List<MockEntity> locationTypeList;
        public bool istrue;
        public NewSupplierForm(string maintype, Supplier obj)
        {
            InitializeComponent();
            locationTypeList = GlobalCache.Supplier_LocationTypeList;
            InitializeDataSource();

            changeid = 0;
            if (maintype == "Edit")
            {
                label2.Text = "编辑供应商";
                this.Text = "编辑供应商";
                changeid = obj.id;
                this.titleTextBox.Text = obj.name;
                this.cshtextbox.Text = obj.csh;
                this.imgPathTextBox.Text = obj.img;
                var st = this.locationTypeList.Where(s => s.Id.ToString().StartsWith(obj.stype.ToString())).ToList();
                if (st.Count > 0)
                {
                    var store = st.First();
                    this.supplComboBox.SelectedValue = store.Id;
                }

                //supplComboBox.Text = (int)SupplierEnum.stype;

                if (obj.img != null && obj.img != "")
                {
                    string copyToPath = EntityPathConfig.Supplier_LocationImagePath(obj);
                    pictureBox1.ImageLocation = copyToPath;
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

            using (var ctx = new DctsEntities())
            {
                try
                {
                    int ty = Convert.ToInt32(this.supplComboBox.SelectedValue);

                    #region new
                    string imgFilePath = this.imgPathTextBox.Text;
                    string imgFileName = "";
                    bool hasImg = (imgFilePath.Length > 0);
                    bool existSameImage = false;
                    bool nameishave = false;

                    if (hasImg)
                    {
                        imgFileName = Path.GetFileName(imgFilePath);

                        existSameImage = (ctx.Suppliers.Where(o => o.stype == ty && o.img == imgFileName && o.id != changeid).Count() > 0);

                    }
                    bool hastitle = (titleTextBox.Text.Length > 0);
                    if (hastitle)
                    {

                        nameishave = (ctx.Suppliers.Where(o => o.stype == ty && o.name == titleTextBox.Text && o.id != changeid).Count() > 0);
                    }


                    #endregion

                    if (changeid != 0)
                    {
                        if (existSameImage)
                        {
                            istrue = false;
                            MessageBox.Show(string.Format("文件名<{0}>已在, 请使用其他文件名！", imgFileName));
                            return;

                        }
                        Supplier obj = ctx.Suppliers.Find(Convert.ToInt32(changeid));
                        obj.stype = Convert.ToInt32(this.supplComboBox.SelectedValue);
                        obj.name = this.titleTextBox.Text;

                        obj.img = imgFileName;
                        obj.csh = this.cshtextbox.Text;
                        obj.updated_at = DateTime.Now;

                        ctx.SaveChanges();
                        if (hasImg)
                        {
                            string copyToPath = EntityPathConfig.Supplier_LocationImagePath(obj);

                            if (!File.Exists(copyToPath))
                                File.Copy(imgFilePath, copyToPath);
                        }
                    }
                    else
                    {
                        var obj = ctx.Suppliers.Create();
                        obj.stype = Convert.ToInt32(this.supplComboBox.SelectedValue);
                        obj.name = this.titleTextBox.Text;

                        obj.img = imgFileName;
                        obj.csh = this.cshtextbox.Text;
                        obj.created_at = DateTime.Now;

                        ctx.Suppliers.Add(obj);
                        if (nameishave == false && this.titleTextBox.Text.Length <= 100)
                            ctx.SaveChanges();
                        else
                        {
                            MessageBox.Show("错误：请检查名称的长度或是否已存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                        changeid = obj.id;
                        if (hasImg)
                        {
                            string copyToPath = EntityPathConfig.Supplier_LocationImagePath(obj);

                            File.Copy(imgFilePath, copyToPath, true);
                        }
                    }
                    istrue = true;




                }
                catch (Exception EX)
                {

                    throw;
                }


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
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.imgPathTextBox.Text = openFileDialog1.FileName;
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }
    }
}
