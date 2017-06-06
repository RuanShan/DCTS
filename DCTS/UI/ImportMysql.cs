using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            this.pathTextBox.Text = Properties.Settings.Default.DBServerPath;
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

            try
            {
                Dictionary<string, string> setting = DBConfiguration.ConnectionSettings();

                string setupSql = SqlPath.SetupSql;
                string seedSql = SqlPath.SeedSql;
                //string mysql = Path.Combine( pathTextBox.Text, "bin", "mysql");
                //string cmd = mysql + " -u " + setting["user id"] + " -p " + setting["password"] + setting["database"] + " <" + setupSql;

                

                using(MySqlConnection conn = new MySqlConnection( DBConfiguration.GetConnectionString() ))
                {
                    MySqlScript script = new MySqlScript(conn);
                    //加载表结构
                    script.Query = File.ReadAllText(setupSql);
                    script.Execute();
                    //加载基本数据
                    script.Query = File.ReadAllText(seedSql);
                    script.Execute();
                }
                

                //string output = "";
                //RunCmd(cmd, out output);

            }
            catch (Exception ex)
            {
                MessageBox.Show("异常" + ex);
                return;

                throw ex;
            } MessageBox.Show("导入成功");
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

        private void openFileBtton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择数据库服务器安装路径";


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.pathTextBox.Text = dialog.SelectedPath;
            }


        }
    }
}
