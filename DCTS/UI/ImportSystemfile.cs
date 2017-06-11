using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComLib;
using ComLib.CsvParse;
using DCTS.DB;
using DCTS.Uti;

namespace DCTS.CustomComponents
{
    public partial class ImportSystemfile : Form
    {
        List<string> listfile = new List<string>();

        public ImportSystemfile()
        {
            InitializeComponent();

        }


        private void openFileBtton_Click_1(object sender, EventArgs e)
        {
            string strFileName = String.Empty;
            ImageList imageListSmall = new ImageList();

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                strFileName = openFileDialog1.FileName;
            }
            if (strFileName.Length > 0)
            {
                int i = 0;

                string[] fs = openFileDialog1.FileNames;
                foreach (string ff in fs)
                {
                    imageListSmall.Images.Add(Bitmap.FromFile(fs[i]));
                    //ListViewItem lvi = new ListViewItem();
                    //this.listView1.SmallImageList = file.FullName;
                    //lvi.Text = new FileInfo(ff).Name;
                    //this.listView1.Items.Add(lvi);  
                    //listBox1.Items.Add(new FileInfo(ff).Name);
                    i++;
                }
                #region 绑定数据图片
                this.listView1.View = View.LargeIcon;
 
                this.listView1.Columns.Add("列标题1", 5200, HorizontalAlignment.Left); //一步添加 
                this.listView1.Columns.Add("列标题1", 5200, HorizontalAlignment.Left); //一步添加 
                listView1.LargeImageList = imageListSmall;
                //ListFiles(new DirectoryInfo(strFileName));
                this.listView1.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度  
                i = 0;
                fs = openFileDialog1.FileNames;
                foreach (string ff in fs)
                {
                    ListViewItem lvi = new ListViewItem();

                    lvi.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标  

                    lvi.Text = new FileInfo(ff).Name;

                    //lvi.SubItems.Add("第2列,第" + j+ "行");


                    this.listView1.Items.Add(lvi);
                    i++;
                }
                this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。  
                #endregion
            }
        }
        public void ListFiles(FileSystemInfo info)
        {
            ColumnHeader ch = new ColumnHeader();

            ch.Text = "列标题1";   //设置列标题  

            ch.Width = 120;    //设置列宽度  

            ch.TextAlign = HorizontalAlignment.Left;   //设置列的对齐方式  

            this.listView1.Columns.Add(ch);    //将列头添加到ListView控件
            
            if (!info.Exists) return;
            DirectoryInfo dir = info as DirectoryInfo;
            //不是目录 
            if (dir == null) return;
            FileSystemInfo[] files = dir.GetFileSystemInfos();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = files[i] as FileInfo;
                //是文件 
                if (file != null)
                {
                    //Console.WriteLine(file.FullName + "/t " + file.Length);
                    if (file.FullName.Substring(file.FullName.LastIndexOf(".")) == ".jpg")
                    //此处为显示JPG格式，不加IF可遍历所有格式的文件
                    {
                        ListViewItem lvi = new ListViewItem();
                        //   this.listView1.SmallImageList = file.FullName; 
                        lvi.Text = file.FullName;
                        this.listView1.Items.Add(lvi);

                        //MessageBox.Show(file.FullName.Substring(file.FullName.LastIndexOf(".")));
                    }
                }
                //对于子目录，进行递归调用 
                else
                {
                    ListFiles(files[i]);
                }
            }
        }

    }
}
