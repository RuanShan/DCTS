using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
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
        private List<Nation> NationList = null;
        private List<City> CityList = null;
        public ImportMysql()
        {
            InitializeComponent();

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
                string connctionString = "Database=dcts_dev;Data Source=127.0.0.1;User Id=root;Character Set=utf8";//Password=root;
                ExecuteSqlFile(this.pathTextBox.Text, connctionString);

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



        #region mysql 执行脚本文件
        /// <summary>   
        /// 执行Sql文件   
        /// </summary>   
        /// <param name="varFileName">sql文件</param>   
        /// <param name="Conn">连接字符串</param>   
        /// <returns></returns>   
        private bool ExecuteSqlFile(string varFileName, String Conn)
        {
            using (StreamReader reader = new StreamReader(varFileName, System.Text.Encoding.GetEncoding("utf-8")))
            {
                MySqlCommand command;
                MySqlConnection Connection = new MySqlConnection(Conn);
                Connection.Open();
                try
                {
                    string line = "";
                    string l;
                    while (true)
                    {
                        // 如果line被使用，则设为空  
                        if (line.EndsWith(";"))
                            line = "";

                        l = reader.ReadLine();

                        // 如果到了最后一行，则退出循环  
                        if (l == null) break;
                        // 去除空格  
                        l = l.TrimEnd();
                        // 如果是空行，则跳出循环  
                        if (l == "") continue;
                        // 如果是注释，则跳出循环  
                        if (l.StartsWith("--")) continue;

                        // 行数加1   
                        line += l;
                        // 如果不是完整的一条语句，则继续读取  
                        if (!line.EndsWith(";")) continue;
                        if (line.StartsWith("/*!"))
                        {
                            continue;
                        }

                        //执行当前行  
                        command = new MySqlCommand(line, Connection);
                        command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    Connection.Close();
                }
            }

            return true;
        }



        #endregion
    }
}
