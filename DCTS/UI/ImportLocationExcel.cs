using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComLib;
using ComLib.CsvParse;
using DCTS.DB;
using DCTS.Uti;
using System.Reflection;

namespace DCTS.CustomComponents
{
    public partial class ImportLocationExcel : Form
    {
        private List<Nation> NationList = null;
        private List<City> CityList = null;
        public ImportLocationExcel()
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
            bool success = NewMethod(worker, e);
        }


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
                        var locations = ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Scenic).ToList();

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
                            City city = this.CityList.Find(o => o.title == location.city );
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
                                existsLocation.local_title = location.local_title;
                                existsLocation.latlng = location.latlng;
                                existsLocation.local_address = location.local_address;
                                existsLocation.route = location.route;
                                existsLocation.img = location.img;
                                // 格式定义11:00-22:00
                                //obj.open_at = Convert.ToDateTime(temp1[1]);
                                //obj.close_at = Convert.ToDateTime(temp1[1]);
                                existsLocation.open_close_more = location.open_close_more;

                                existsLocation.ticket = location.ticket;
                                existsLocation.tips = location.tips;
                                //ctx.ComboLocations.Add(existsLocation);
                            }
                            else {
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

            // id	ltype	nation	city	area	title	local_title	img	address	local_address	latlng	route	contact	
            // open_at	close_at	open_close_more	ticket	room	dinner	wifi	parking	reception	kitchen	dishes	recommended_dishes	tips	guidance

            // 序号  类型    国家    城市    区域     中文名称 当地语言名称    图片  地址   当地语言地址 经纬度  如何抵达    联系方式 
            // 开始时间  结束时间  营业时间说明  门票  房型  早餐   WIFI 停车场  前台 厨房 菜系 推荐菜单 小贴士


            var columnNameMap = ComboLocationSchema.ColumnNameDictionary;


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

                //对象不能从 DBNull 转换为其他类型。
                int id = 0;
                Int32.TryParse(row["id"].ToString(), out id);

                location.id = id;
                location.ltype = Convert.ToInt32(row["ltype"]);

                location.nation = row["nation"].ToString();
                location.city = row["city"].ToString();
                location.title = row["title"].ToString();
                location.local_title = row["local_title"].ToString();
                location.img = row["img"].ToString();
                location.latlng = row["latlng"].ToString();
                location.local_address = row["local_address"].ToString();
                location.route = row["route"].ToString();
                // 格式定义11:00-22:00
                //obj.open_at = Convert.ToDateTime(temp1[1]);
                //obj.close_at = Convert.ToDateTime(temp1[1]);
                location.open_close_more = row["open_close_more"].ToString().Trim();

                location.ticket = row["ticket"].ToString().Trim();
                location.tips = row["tips"].ToString();
                list.Add(location);
            }

            return list;
        }

    }
}
