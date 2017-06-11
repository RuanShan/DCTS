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
using DCTS.Bus;
using DCTS.DB;
using DCTS.Uti;

namespace DCTS.CustomComponents
{
    public partial class ImportSystemfile : Form
    {
        List<string> listfile = new List<string>();
        string strFileName = String.Empty;
        public ImportSystemfile()
        {
            InitializeComponent();
            pager1.PageCurrent = 1;
            BeginActive();

        }
        public void BeginActive()
        {
            this.listView1.Clear();  //从控件中移除所有项和列（包括列表头）。

            pager1.Bind();

        }
        private void openFileBtton_Click_1(object sender, EventArgs e)
        {
            strFileName = String.Empty;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                strFileName = openFileDialog1.FileName;
                pathTextBox.Text = strFileName;

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

        private void import_Click(object sender, EventArgs e)
        {
            if (strFileName.Length > 0)
            {
                //  imagedockin();
                bool isReplace = this.replaceRadioButton.Checked;

                string[] fs = openFileDialog1.FileNames;
                int copiedCount = 0;

                using (var ctx = new DctsEntities())
                {
                    int imageindex = 0;

                    foreach (string ff in fs)
                    {
                        {
                            string serverimg = new FileInfo(ff).Name;
                            var locations = ctx.LocationImages.Where(o => o.name == serverimg).ToList();
                            //如果存在复制到相应的文件夹中
                            if (locations != null && locations.Count != 0)
                            {
                                string copyToPath = EntityPathConfig.newlocationimagepath(locations[0]);
                                if (File.Exists(copyToPath))
                                {
                                    if (isReplace)
                                    {
                                        File.Copy(fs[imageindex], copyToPath, true);
                                        copiedCount++;
                                    }
                                }
                                else
                                {
                                    File.Copy(fs[imageindex], copyToPath, true);
                                    copiedCount++;
                                }
                            }
                            else
                            {

                                var obj = ctx.LocationImages.Create();
                                obj.name = serverimg;
                                var location = ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.PageImage).First();
                                obj.location_id = location.id;

                                ctx.LocationImages.Add(obj);

                                ctx.SaveChanges();

                                string copyToPath = EntityPathConfig.newlocationimagepath(obj);
                                if (File.Exists(copyToPath))
                                {
                                    if (isReplace)
                                    {
                                        File.Copy(fs[imageindex], copyToPath, true);
                                        copiedCount++;
                                    }
                                }
                                else
                                {
                                    File.Copy(fs[imageindex], copyToPath, true);
                                    copiedCount++;
                                }
                            }
                        }
                        imageindex++;
                    }
                    BeginActive();



                }
            }


        }

        private void imagedockin(List<LocationImage> list)
        {
            ImageList imageListSmall = new ImageList();
            int i = 0;
            //string[] fs = openFileDialog1.FileNames;
            //foreach (string ff in fs)
            foreach (LocationImage item in list)
            {

                if (item.name != null)
                {
                    string ImageLocation = EntityPathConfig.newlocationimagepath(item);

                    imageListSmall.Images.Add(Bitmap.FromFile(ImageLocation));
                }
                // imageListSmall.Images.Add(Bitmap.FromFile(fs[i]));

                //ListViewItem lvi = new ListViewItem();
                //this.listView1.SmallImageList = file.FullName;
                //lvi.Text = new FileInfo(ff).Name;
                //this.listView1.Items.Add(lvi);  
                //listBox1.Items.Add(new FileInfo(ff).Name);
                i++;
            }
            #region 绑定数据图片
            this.listView1.View = View.LargeIcon;

            this.listView1.Columns.Add("文件", 5200, HorizontalAlignment.Left); //一步添加 
            listView1.LargeImageList = imageListSmall;
            //ListFiles(new DirectoryInfo(strFileName));
            this.listView1.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度  
            i = 0;
            //fs = openFileDialog1.FileNames;
            //foreach (string ff in fs)
            foreach (LocationImage item in list)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标  

                lvi.Text = item.name;

                //lvi.SubItems.Add("第2列,第" + j+ "行");


                this.listView1.Items.Add(lvi);
                i++;
            }
            this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。  
            #endregion
        }


        private int InitializeDataGridView(int pageCurrent = 1)
        {
            string title = "";

            int count = 0;
            int pageSize = pager1.PageSize;

            using (var ctx = new DctsEntities())
            {
                //分页需要数据总数
                var location = ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.PageImage).First();

                count = Count(location.id, title);

                var list = Paginate(pageCurrent, pageSize, title);
                imagedockin(list);

            }
            return count;
        }
        private static int Count(int locationType, string title)
        {
            int count = 0;
            using (var ctx = new DctsEntities())
            {
                var query = ctx.LocationImages.AsQueryable();
                if ((int)locationType > 0)
                {
                    query = query.Where(o => o.location_id == (int)locationType);

                }

                if (title.Length > 0)
                {
                    query = query.Where(o => o.name.Contains(title));
                }
                count = query.Count();
            }
            return count;
        }
        private static List<LocationImage> Paginate(int currentPage = 1, int pageSize = 25, string title = "")
        {
            // 如果数据为0，分页控件，设置currentPage = 0; 这回导致下面查询异常
            if (currentPage <= 0)
            {
                currentPage = 1;
            }
            List<LocationImage> list = new List<LocationImage>();

            using (var ctx = new DctsEntities())
            {
                var location = ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.PageImage).First();

                var query = ctx.LocationImages.Where(o => o.location_id == (int)location.id && o.name != null);
                if (title.Length > 0)
                {
                    query = query.Where(o => o.name.Contains(title));
                }

                if (pageSize > 0)
                {
                    int offset = (currentPage - 1) * pageSize;

                    query = query.OrderBy(o => o.name).Skip(offset).Take(pageSize);
                }
                list = query.ToList();

            }
            return list;
        }

        private int pager1_EventPaging(EventPagingArg e)
        {
            int count = InitializeDataGridView(e.PageCurrent);
            return count;


        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ctx = new DctsEntities())
            {
                if (this.listView1.SelectedIndices.Count > 0)
                {

                    string name = this.listView1.SelectedItems[0].Text;

                    var location = ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.PageImage).First();

                    var query = ctx.LocationImages.Where(o => o.location_id == (int)location.id && o.name == name);
                    List<LocationImage> list = query.ToList();

                    string msg = string.Format("确定删除国家<{0}>？", list[0].name);

                    if (MessageHelper.DeleteConfirm(msg))
                    {
                        ComboLoactionBusiness.locaimageDelete(list[0].id);
                        BeginActive();
                    }
                }
            }
        }



    }
}
