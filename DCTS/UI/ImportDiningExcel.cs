﻿using System;
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
    public partial class ImportDiningCSV : Form
    {
        private List<City> CityList = null;

        private List<Nation> NationList = null;
        public ImportDiningCSV()
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

        /// <summary>
        /// Run the application.
        /// </summary>
        public bool Execute(string path, BackgroundWorker worker, DoWorkEventArgs e)
        {
            bool isrun = false;

            try
            {
                //<doc:example>
                // See CommonLibrary.UnitTests Source code for actual csv files.
                string text = GetSampleCsv();
                CsvDoc csv = Csv.LoadText(text, true);

                // 1. Get cell at row 0, column 1
                string cell0 = csv.Get<string>(0, 1);

                // 2. Get cell at row 0, column called "FilePath"
                string cell2 = csv.Get<string>(0, "FilePath");

                // 3. Number of columns
                var colCount = csv.Columns.Count;

                // 4. Number of rows
                var rowCount = csv.Data.Count;

                // 5. Column name at index 2
                var col2 = csv.Columns[1];

                // 6. Get int id at row 2
                var id = csv.Get<int>(2, 0);

                // 7. Iterate over all the cells in column named "Date" starting at row 0.
                csv.ForEach<DateTime>("Date", 0, (row, col, val) =>
                {
                    Console.WriteLine(string.Format("Row[{0}]Col[{1}] : {2}", row, col, val.ToString()));
                });

                // 8. Get the csv data as a datatable.
                DataTable table = csv.ToDataTable("My_Sample_Data");

                // 9. Iterate over rows / columns
                for (int row = 0; row < csv.Data.Count; row++)
                {
                    for (int col = 0; col < csv.Columns.Count; col++)
                    {
                        string cellVal = csv.Data[row][col] as string;
                    }
                }
                //</doc:example>
                isrun = true;

            }
            catch (Exception ex)
            {
                isrun = false;

                return isrun;
                throw;
            }
            return isrun;
        }
        private string GetSampleCsv()
        {
            var csv = @"Id,NonAlphaNumeric,FilePath,Date" + Environment.NewLine
                    + @"1,(`~!@#$%^&*()_+-=[]\{}|<>?./;:),C:\pictures\100_01.JPG,4/10/2009 11:27 AM" + Environment.NewLine
                    + @"2,(`~!@#$%^&*()_+-=[]\{}|<>?./;:),C:\pictures\100_01.JPG,4/11/2009 11:37 AM" + Environment.NewLine
                    + @"3,(`~!@#$%^&*()_+-=[]\{}|<>?./;:),C:\pictures\100_01.JPG,4/12/2009 11:47 AM";
            return csv;
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

        private bool NewMethod1(BackgroundWorker worker, DoWorkEventArgs e)
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
                            e.Result = "导入[" + temp1[5] + "]国家信息在系统中不存在";
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
                                e.Result = "导入[" + temp1[5] + "]文件中【序号】列不能为空";
                                throw new Exception("导入[" + temp1[5] + "]导入文件中【序号】列不能为空");
                            }
                            objcity.code = "";
                            var objcity1 = ctx.Cities.Add(objcity);
                            ctx.SaveChanges();
                        }
                        else
                        {
                            if (temp1[1] == null || temp1[1] == "")
                            {
                                e.Result = "导入[" + temp1[5] + "]文件中【序号】列不能为空";
                                throw new Exception("导入[" + temp1[5] + "]导入文件中【序号】列不能为空");

                            }
                            City objcity = ctx.Cities.Find(Convert.ToInt32(Convert.ToInt64(temp1[1])));
                            objcity.title = temp1[3];
                            objcity.nationCode = order.code;
                        }


                        var obj = ctx.ComboLocations.Create();
                        obj.ltype = (int)ComboLocationEnum.Dining;
                        obj.nation = temp1[2];
                        obj.city = temp1[3];
                        obj.area = temp1[4];
                        obj.title = temp1[5];
                        obj.dishes = temp1[6];
                        obj.img = temp1[7];
                        obj.latlng = temp1[8];
                        obj.address = temp1[9];
                        obj.local_address = temp1[10];
                        if (temp1[11] != null && temp1[11] != "" && temp1[11].Contains("-"))
                        {
                            string[] temp2 = System.Text.RegularExpressions.Regex.Split(temp1[11], "-");

                            try
                            {
                                obj.open_at = Convert.ToDateTime(temp2[0].Trim());
                                obj.close_at = Convert.ToDateTime(temp2[1].Trim());
                            }
                            catch (Exception)
                            {
                                success = false;
                            }
                        }
                        obj.recommended_dishes = temp1[12];
                        obj.tips = temp1[12];
                        #region 判断名称长度
                        bool nameishave = false;
                        bool hastitle = (temp1[5].Length > 0);
                        if (hastitle)
                        {
                            string demo = temp1[5].ToString();

                            ComboLocation lastLocation = ctx.ComboLocations.OrderByDescending(o => o.id).FirstOrDefault();
                            if (lastLocation != null)
                                nameishave = (ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Dining && o.title == demo).Count() > 0);
                        }

                        #endregion
                        if (nameishave == false && temp1[5].Length <= 100)
                            ctx.ComboLocations.Add(obj);
                        else
                        {
                            throw new Exception("导入[" + temp1[5] + "]请检查名称的长度或是否已存在");
                            //MessageBox.Show("错误：请检查名称的长度或是否已存在！" + temp1[4], "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        ctx.SaveChanges();
                        if (arg.CurrentIndex % 5 == 0)
                        {
                            backgroundWorker1.ReportProgress(progress, arg);
                        }
                    }
                }
                arg.CurrentIndex = dt.Rows.Count;
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

        private bool NewMethod(BackgroundWorker worker, DoWorkEventArgs e)
        {
            WorkerArgument arg = e.Argument as WorkerArgument;

            bool success = true;
            try
            {
                string sheetName = this.pathTextBox.Text;
                using (var excelHelper = new ExcelHelper(sheetName))
                {

                    DataTable dt = excelHelper.ExcelToDataTable(string.Empty, true);

                    var newLocations = ConverDataTableToComboLocationList(dt);

                    int rowCount = dt.Rows.Count;
                    arg.OrderCount = rowCount;
                    int i = 0;
                    int progress = 0;
                    using (var ctx = new DctsEntities())
                    {
                        var locations = ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Dining).ToList();

                        foreach (var location in newLocations)
                        {
                            ComboLocation existsLocation = null;

                            i += 1;
                            progress = Convert.ToInt16(((i) * 1.0 / rowCount) * 100);
                            arg.CurrentIndex = i;

                            //判断国家是否存在                       
                            Nation nation = this.NationList.Find(o => o.title == location.nation);
                            if (nation == null)
                            {
                                e.Result = "导入[" + location.nation + "]国家信息在系统中不存在";
                                e.Cancel = true;
                                //continue;
                            }
                            //判断城市是否存在 不存在创建
                            City city = this.CityList.Find(o => o.title == location.city);
                            if (city == null)
                            {
                                city = ctx.Cities.Create();
                                city.title = location.city;
                                city.nationCode = nation.code;
                                city.code = "";
                                ctx.Cities.Add(city);

                            }

                            if (location.id > 0)
                            {
                                existsLocation = ctx.ComboLocations.Where(o => o.id == location.id).FirstOrDefault();
                            }
                            if (existsLocation != null)
                            {
                                existsLocation.nation = location.nation;
                                existsLocation.city = location.city;
                                existsLocation.title = location.title;
                                existsLocation.dishes = location.dishes;
                                existsLocation.latlng = location.latlng;
                                existsLocation.address = location.address;
                                existsLocation.route = location.route;
                                // 格式定义11:00-22:00
                                //obj.open_at = Convert.ToDateTime(temp1[1]);
                                //obj.close_at = Convert.ToDateTime(temp1[1]);
                                existsLocation.open_close_more = location.open_close_more;

                                existsLocation.recommended_dishes = location.recommended_dishes;
                                existsLocation.tips = location.tips;
                                //ctx.ComboLocations.Add(existsLocation);
                            }
                            else
                            {
                                ctx.ComboLocations.Add(location);
                            }


                            backgroundWorker1.ReportProgress(progress, arg);

                        }
                        ctx.SaveChanges();
                    }
                    backgroundWorker1.ReportProgress(100, arg);
                    e.Result = string.Format("{0} 条正常导入成功", dt.Rows.Count);
                }
            }
            catch (DbEntityValidationException exception)
            {
                if (!e.Cancel)
                {
                    //arg.HasError = true;
                    //arg.ErrorMessage = exception.Message;
                    e.Result = exception.Message + "或所导入信息超出要求长度";
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

        private List<ComboLocation> ConverDataTableToComboLocationList(DataTable table)
        {

            //ltype	nation	city	area	title      dishes   img     latlng  address  route         open_close_more  recommended_dishes  tips
            // 序号	国家	城市	区域	餐厅名称	菜系	图片	经纬度	地址	如何抵达(周围特征)	营业时间	推荐菜单	      深度Tlps

            var columnNameMap = ComboLocationSchema.diningColumnNameDictionary;

            List<ComboLocation> list = new List<ComboLocation>();

            Type locationType = typeof(ComboLocation);

            List<MethodInfo> methods = new List<MethodInfo>();
            foreach (DataColumn column in table.Columns)
            {
                string innerColumnName = columnNameMap[column.Caption];
                var m = locationType.GetMethod(innerColumnName);
                methods.Add(m);

                column.ColumnName = innerColumnName;
            }

            foreach (DataRow row in table.Rows)
            {

                var location = new ComboLocation();
                location.ltype = (int)ComboLocationEnum.Dining;
                location.id = Convert.ToInt32(row["id"]);
                location.nation = row["nation"].ToString();
                location.city = row["city"].ToString();
                location.title = row["title"].ToString();
                location.dishes = row["dishes"].ToString();
                location.img = "";
                location.latlng = row["latlng"].ToString();
                location.route = row["route"].ToString();
                location.address = row["address"].ToString();
                // 格式定义11:00-22:00
                //obj.open_at = Convert.ToDateTime(temp1[1]);
                //obj.close_at = Convert.ToDateTime(temp1[1]);
                location.open_close_more = row["open_close_more"].ToString().Trim();

                location.recommended_dishes = row["recommended_dishes"].ToString().Trim();
                location.tips = row["tips"].ToString();
                list.Add(location);
            }

            return list;
        }


    }
}
