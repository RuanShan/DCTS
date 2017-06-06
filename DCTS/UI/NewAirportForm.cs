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
    public partial class NewAirportForm : BaseModalForm
    {
        private long changeid;
        public NewAirportForm(string maintype, ComboLocation obj)
        {
            InitializeComponent();
            InitializeDataSource();
            changeid = 0;
            if (maintype == "Edit")
            {
                label2.Text = "编辑机场";
                this.Text = "编辑机场";
                changeid = obj.id;
                this.titleTextBox.Text = obj.title;

                this.textBox6.Text = obj.tips;
                long folername = obj.id / 1000;
                string lcoalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\data\\export\\words" + "\\" + folername + "\\", obj.word);
                if (obj.word != null && obj.word != "")
                    this.docPathTextBox.Text = lcoalPath;
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
                    #region new
                    string docFilePath = this.docPathTextBox.Text;
                    string copyfilename = "";
                    bool hasDoc = (docFilePath.Length > 0);
                    bool existSamedoc = false;
                    bool nameishave = false;
                    if (hasDoc)
                    {
                        copyfilename = Path.GetFileName(docFilePath);

                        ComboLocation lastLocation = ctx.ComboLocations.OrderByDescending(o => o.id).FirstOrDefault();
                        if (lastLocation != null)
                        {
                            long newId = lastLocation.id + 1;

                            long idStart = newId / 1000 * 1000;
                            long idEnd = idStart + 1000;
                            existSamedoc = (ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Flight && o.word == copyfilename && o.id > idStart && o.id < idEnd).Count() > 0);
                        }

                    }
                    bool hastitle = (titleTextBox.Text.Length > 0);
                    if (hastitle)
                    {
                        ComboLocation lastLocation = ctx.ComboLocations.OrderByDescending(o => o.id).FirstOrDefault();
                        if (lastLocation != null)
                            nameishave = (ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Flight && o.word == openFileDialog1.SafeFileName && o.title == titleTextBox.Text).Count() > 0);
                    }
                    #endregion
                    if (changeid == 0)
                    {
                        if (existSamedoc)
                        {
                            MessageBox.Show(string.Format("文件名<{0}>已在, 请使用其他文件名！", copyfilename));
                            return;
                        }
                        var obj = ctx.ComboLocations.Create();
                        obj.ltype = (int)ComboLocationEnum.Flight;
                        obj.title = this.titleTextBox.Text;

                        obj.word = copyfilename; ;

                        obj.tips = this.textBox6.Text;
                        ctx.ComboLocations.Add(obj);
                        if (nameishave == false && this.titleTextBox.Text.Length <= 100)
                            ctx.SaveChanges();
                        else
                        {
                            MessageBox.Show("错误：请检查名称的长度或是否已存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (hasDoc)
                        {
                            string copyToPath = EntityPathConfig.LocationWordPath(obj);
                            if (!File.Exists(copyToPath))
                                File.Copy(docFilePath, copyToPath);
                        }
                    }
                    else
                    {
                        ComboLocation obj = ctx.ComboLocations.Find(Convert.ToInt32(changeid));
                        obj.title = this.titleTextBox.Text;
                        obj.ltype = (int)ComboLocationEnum.Flight;
                        obj.word = "";
                        obj.tips = this.textBox6.Text;

                        if (hasDoc)
                        {
                            obj.word = copyfilename;
                            string copyToPath = EntityPathConfig.LocationWordPath(obj);

                            if (!File.Exists(copyToPath))
                                File.Copy(docFilePath, copyToPath);
                        }
                        ctx.SaveChanges();
                    }
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
        private void findFileButton_Click(object sender, EventArgs e)
        {

            //openFileDialog1.Filter = "DOC(*.doc)|*.docx"; //文件类型
            //if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    this.docPathTextBox.Text = openFileDialog1.FileName;

            //}

            openFileDialog1.Filter = "DOCX(*.doc,*.docx)|*.doc;*.docx"; //文件类型
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.docPathTextBox.Text = openFileDialog1.FileName;

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
                        nameishave = (ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Flight && o.title == titleTextBox.Text).Count() > 0);

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
    }
}
