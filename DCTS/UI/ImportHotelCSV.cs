using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComLib;
using ComLib.CsvParse;
using DCTS.DB;

namespace DCTS.CustomComponents
{
    public partial class ImportHotelCSV : Form
    {
        private List<City> CityList = null;

        private List<Nation> NationList = null;
        public ImportHotelCSV()
        {
            InitializeComponent();
            //var nationList = DCTS.DB.GlobalCache.NationList;
            //NationList = new List<Nation>();
            //NationList = nationList.ToList();

            using (var ctx = new DctsEntities())
            {
                NationList = ctx.Nations.ToList();
                CityList = ctx.Cities.ToList();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            //bool success = Execute(pathTextBox.Text, worker, e);
            bool success = NewMethod(worker, e);
        }

        #region csv 路径
        public static DataTable OpenCSV(string filePath)//从csv读取数据返回table
        {
            System.Text.Encoding encoding = GetType(filePath); //Encoding.ASCII;//
            DataTable dt = new DataTable();
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open,
                System.IO.FileAccess.Read);

            System.IO.StreamReader sr = new System.IO.StreamReader(fs, encoding);

            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            string[] tableHead = null;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;
            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                if (IsFirst == true)
                {
                    tableHead = strLine.Split(',');
                    IsFirst = false;
                    columnCount = tableHead.Length;
                    //创建列
                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn dc = new DataColumn(tableHead[i]);
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    aryLine = strLine.Split(',');
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < columnCount; j++)
                    {
                        dr[j] = aryLine[j];
                    }
                    dt.Rows.Add(dr);
                }
            }
            if (aryLine != null && aryLine.Length > 0)
            {
                dt.DefaultView.Sort = tableHead[0] + " " + "asc";
            }

            sr.Close();
            fs.Close();
            return dt;
        }

        public static System.Text.Encoding GetType(string FILE_NAME)
        {
            System.IO.FileStream fs = new System.IO.FileStream(FILE_NAME, System.IO.FileMode.Open,
                System.IO.FileAccess.Read);
            System.Text.Encoding r = GetType(fs);
            fs.Close();
            return r;
        }
        public static System.Text.Encoding GetType(System.IO.FileStream fs)
        {
            byte[] Unicode = new byte[] { 0xFF, 0xFE, 0x41 };
            byte[] UnicodeBIG = new byte[] { 0xFE, 0xFF, 0x00 };
            byte[] UTF8 = new byte[] { 0xEF, 0xBB, 0xBF }; //带BOM
            System.Text.Encoding reVal = System.Text.Encoding.Default;

            System.IO.BinaryReader r = new System.IO.BinaryReader(fs, System.Text.Encoding.Default);
            int i;
            int.TryParse(fs.Length.ToString(), out i);
            byte[] ss = r.ReadBytes(i);
            if (IsUTF8Bytes(ss) || (ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF))
            {
                reVal = System.Text.Encoding.UTF8;
            }
            else if (ss[0] == 0xFE && ss[1] == 0xFF && ss[2] == 0x00)
            {
                reVal = System.Text.Encoding.BigEndianUnicode;
            }
            else if (ss[0] == 0xFF && ss[1] == 0xFE && ss[2] == 0x41)
            {
                reVal = System.Text.Encoding.Unicode;
            }
            r.Close();
            return reVal;
        }
        /// 判断是否是不带 BOM 的 UTF8 格式
        /// <param name="data"></param>
        /// <returns></returns>
        private static bool IsUTF8Bytes(byte[] data)
        {
            int charByteCounter = 1;　 //计算当前正分析的字符应还有的字节数
            byte curByte; //当前分析的字节.
            for (int i = 0; i < data.Length; i++)
            {
                curByte = data[i];
                if (charByteCounter == 1)
                {
                    if (curByte >= 0x80)
                    {
                        //判断当前
                        while (((curByte <<= 1) & 0x80) != 0)
                        {
                            charByteCounter++;
                        }
                        //标记位首位若为非0 则至少以2个1开始 如:110XXXXX...........1111110X　
                        if (charByteCounter == 1 || charByteCounter > 6)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    //若是UTF-8 此时第一位必须为1
                    if ((curByte & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    charByteCounter--;
                }
            }
            if (charByteCounter > 1)
            {
                throw new Exception("非预期的byte格式");
            }
            return true;
        }

        #endregion
        private void openFileBtton_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pathTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorker1.IsBusy)
            {

                this.backgroundWorker1.CancelAsync();
                // Disable the Cancel button.
                this.cancelButton.Enabled = false;
            }

        }

        private void importButton_Click(object sender, EventArgs e)
        {
            this.importButton.Enabled = false;
            this.cancelButton.Enabled = true;
            this.closeButton.Enabled = false;
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync(new WorkerArgument { OrderCount = 0, CurrentIndex = 0 });

            }
        }

        private bool NewMethod(BackgroundWorker worker, DoWorkEventArgs e)
        {
            WorkerArgument arg = e.Argument as WorkerArgument;

            bool success = true;
            try
            {
                DataTable dt = OpenCSV(this.pathTextBox.Text);
                string a = dt.Rows[1][1].ToString();
                arg.OrderCount = dt.Rows.Count;
                int i = 1;
                int progress = 0;
                using (var ctx = new DctsEntities())
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        arg.CurrentIndex = i + 1;
                        progress = Convert.ToInt16(((i + 1) * 1.0 / dt.Rows.Count) * 100);
                        string texi = "";
                        foreach (DataColumn column in dt.Columns)
                        {
                            var text = row[column];
                            texi = texi + "\t" + row[column];
                        }


                        string[] temp1 = System.Text.RegularExpressions.Regex.Split(texi, "\t");
                        //判断国家是否存在                       
                        Nation order = this.NationList.Find(o => o.title == temp1[2]);
                        if (order == null || order.title == null || order.title == "")
                        {
                            e.Result = "导入[" + temp1[4] + "]国家信息在系统中不存在";
                            throw new Exception("导入[" + temp1[4] + "]国家信息在系统中不存在");
                            //continue;
                        }
                        //判断城市是否存在 不存在创建
                        City CityListorder = this.CityList.Find(o => o.title == temp1[3]);
                        if (CityListorder == null)
                        {
                            var objcity = ctx.Cities.Create();
                            objcity.title = temp1[3];
                            objcity.nationCode = order.code;
                            if (temp1[1] == null || temp1[1] == "")
                            {
                                e.Result = "导入[" + temp1[4] + "]文件中【序号】列不能为空";
                                throw new Exception("导入[" + temp1[4] + "]导入文件中【序号】列不能为空");

                            }
                            objcity.id = Convert.ToInt64(temp1[1]);
                        }
                        else
                        {
                            if (temp1[1] == null || temp1[1] == "")
                            {
                                e.Result = "导入[" + temp1[4] + "]文件中【序号】列不能为空";
                                throw new Exception("导入[" + temp1[4] + "]导入文件中【序号】列不能为空");

                            }
                            City objcity = ctx.Cities.Find(Convert.ToInt32(Convert.ToInt64(temp1[1])));
                            objcity.title = temp1[3];
                            objcity.nationCode = order.code;
                        }



                        var obj = ctx.ComboLocations.Create();
                        obj.ltype = (int)ComboLocationEnum.Hotel;
                        obj.nation = temp1[2];
                        obj.city = temp1[3];
                        obj.title = temp1[4];
                        obj.local_title = temp1[5];
                        obj.img = temp1[6]; ;// this.imgPathTextBox.Text;
                        //obj.open_at = Convert.ToDateTime( temp1[1]);
                        //obj.close_at = Convert.ToDateTime( temp1[1]);
                        obj.room = temp1[7];
                        obj.dinner = temp1[8];
                        obj.latlng = temp1[9];
                        obj.address = temp1[10];
                        obj.local_address = temp1[11];
                        obj.contact = temp1[12];
                        obj.wifi = temp1[13];
                        obj.parking = temp1[14];
                        obj.reception = temp1[15];
                        obj.kitchen = temp1[16];
                        obj.tips = temp1[17];
                        #region 判断名称长度
                        bool nameishave = false;
                        bool hastitle = (temp1[4].Length > 0);
                        if (hastitle)
                        {
                            string demo = temp1[4].ToString();

                            ComboLocation lastLocation = ctx.ComboLocations.OrderByDescending(o => o.id).FirstOrDefault();
                            if (lastLocation != null)
                                nameishave = (ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Hotel && o.title == demo).Count() > 0);
                        }

                        #endregion

                        if (nameishave == false && temp1[4].Length <= 100)
                            ctx.ComboLocations.Add(obj);
                        else
                        {
                            throw new Exception("导入[" + temp1[4] + "]请检查名称的长度或是否已存在");
                            return false;
                        }
                        if (arg.CurrentIndex % 5 == 0)
                        {
                            backgroundWorker1.ReportProgress(progress, arg);
                        }
                    }
                    ctx.SaveChanges();

                }
                backgroundWorker1.ReportProgress(100, arg);
                e.Result = string.Format("{0} 条正常导入成功", dt.Rows.Count);
            }
            catch (Exception exception)
            {
                if (!e.Cancel)
                {
                    //arg.HasError = true;
                    //arg.ErrorMessage = exception.Message;
                    e.Result = exception.Message;
                }
                success = false;
            }

            return success;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            WorkerArgument arg = e.UserState as WorkerArgument;
            if (!arg.HasError)
            {
                this.progressMsgLabel.Text = String.Format("{0}/{1}", arg.CurrentIndex, arg.OrderCount);
                this.ProgressValue = e.ProgressPercentage;
            }
            else
            {
                this.progressMsgLabel.Text = arg.ErrorMessage;
            }
        }
        public int ProgressValue
        {
            get { return this.progressBar1.Value; }
            set { progressBar1.Value = value; }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            this.cancelButton.Enabled = false;
            this.closeButton.Enabled = true;
            this.importButton.Enabled = true;

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show(string.Format("It is cancelled!"));
            }
            else
            {
                MessageBox.Show(string.Format("{0}", e.Result));

            }

        }

    }
}
