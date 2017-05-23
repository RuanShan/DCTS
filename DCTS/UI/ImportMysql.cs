using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
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
using MySql.Data.MySqlClient;

namespace DCTS.CustomComponents
{
    public partial class ImportMysql : Form
    {

        public ImportMysql()
        {
            InitializeComponent();

        }



        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
        }

        private void importButton_Click(object sender, EventArgs e)
        {

            //得到APP.config字符串
            var myconn = new MySqlConnection(DBConfiguration.GetConnectionString("DctsEntities1"));
            string con = myconn.ConnectionString;

            //用户ID

            string[] temp1 = System.Text.RegularExpressions.Regex.Split(con, "user id=");
            string[] temp2 = System.Text.RegularExpressions.Regex.Split(temp1[1], ";");
            //数据库名称
            string[] temp3 = System.Text.RegularExpressions.Regex.Split(con, "database=");
            string[] temp4 = System.Text.RegularExpressions.Regex.Split(temp3[1], ";");

            String db = ConfigurationManager.AppSettings["DB_Public_Disk_Path"];
            //string cmd = @"mysql -u root -p123456 dcts_dev <d:\a.sql";
            string cmd = @"mysql -u root dcts_dev <C:\\Program Files\\MySQL\\20170510.sql";
            cmd = @"mysql -u " + temp2[0] + " " + temp4[0] + " <" + @db;

            string output = "";
            RunCmd(cmd, out output);
            MessageBox.Show("导入成功");
        }

        private bool NewMethod(BackgroundWorker worker, DoWorkEventArgs e)
        {
            WorkerArgument arg = e.Argument as WorkerArgument;

            bool success = true;
            try
            {
                string connctionString = "Database=dcts_dev;Data Source=127.0.0.1;User Id=root;Character Set=utf8";//Password=root;

                string cmd = @"mysql -u root -p123456 dcts_dev <d:\a.sql";
                cmd = @"mysql -u root dcts_dev <C:\\mysteap\\work_office\\ProjectOut\\RuanShanLvYou\\20170510.sql";
                string output = "";
                RunCmd(cmd, out output);



                backgroundWorker1.ReportProgress(100, arg);
                e.Result = string.Format("{0} 条正常导入成功");
            }
            catch (DbEntityValidationException exception)
            {
                if (!e.Cancel)
                {

                    e.Result = exception.Message + "运行失败";
                }
                success = false;
            }

            return success;
        }

        #region 直接调用命令

        public static void RunCmd(string cmd, out string output)
        {
            try
            {
                string CmdPath = @"C:\Windows\System32\cmd.exe";
                cmd = cmd.Trim().TrimEnd('&') + "&exit";//说明：不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态
                using (Process p = new Process())
                {
                    p.StartInfo.FileName = CmdPath;
                    p.StartInfo.UseShellExecute = false;        //是否使用操作系统shell启动
                    p.StartInfo.RedirectStandardInput = true;   //接受来自调用程序的输入信息
                    p.StartInfo.RedirectStandardOutput = true;  //由调用程序获取输出信息
                    p.StartInfo.RedirectStandardError = true;   //重定向标准错误输出
                    p.StartInfo.CreateNoWindow = true;          //不显示程序窗口
                    p.Start();//启动程序

                    //向cmd窗口写入命令
                    p.StandardInput.WriteLine(cmd);
                    p.StandardInput.AutoFlush = true;

                    //获取cmd窗口的输出信息
                    output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();//等待程序执行完退出进程
                    p.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EX:数据库配置失败 ：" + ex);


                throw;
            }
        }


        #endregion
    }
}
