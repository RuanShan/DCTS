using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Infrastructure.Interception;

namespace DCTS
{
    using DCTS.Uti;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (IsAlreadyRunning())
            {
                MessageBox.Show("程序已经运行，请使用任务管理器先关闭程序，再重新打开。");
                return;
            }

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            StartMainForm();
        }


        static void StartMainForm()
        {
            //https://msdn.microsoft.com/en-us/library/dd318661(vs.85).aspx
            //https://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.aspx
            //if (Thread.CurrentThread.CurrentCulture.Name != "ja-JP") //zh-CN
            //{
            //    // If current culture is not fr-FR, set culture to fr-FR.
            //    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("ja-JP");
            //    CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture("ja-JP");
            //}   
#if DEBUG
            DbInterception.Add(new EFIntercepterLogging());
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // https://msdn.microsoft.com/en-us/library/system.windows.forms.application.threadexception.aspx
            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            // Set the unhandled exception mode to force all Windows Forms errors to go through
            // our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.Run(new MainForm());

        }

        static void StartDbConfiguration()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new DBConfigurationForm());
            MessageBox.Show(String.Format("{0}",
                "データベースに接続できません。設定ファイルInventoryDemo.exe.config中のGOD DBContext内容を修正してください !"));
        }

        static bool DbConnectable()
        {
            bool success = false;
            string msg = "";
            //连接字符串拼装  
            var myconn = new MySqlConnection(DBConfiguration.GetConnectionString("GODDbContext"));


            //连接 
            try
            {
                myconn.Open();

                if (myconn.State.ToString() == "Open")
                {
                    LogHelper.WriteLog("Connect DB successfully");
                    success = true;
                }

            }
            catch (MySqlException exception)
            {
                LogHelper.WriteLog("DB open error", exception);
                LogHelper.WriteLog(string.Format("DB connection string is {0}", DBConfiguration.GetConnectionString("GODDbContext")));
            }
            finally
            {

                myconn.Close();
            }

            return success;
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs eventArgs)
        {
            //LogHelper.WriteLog("ThreadException", eventArgs.Exception);
            //log4net.ILog objLogger = log4net.LogManager.GetLogger("SystemExceptionLogger");
            string message = string.Format("{0}\r\nThis is serial error， please call system administrator!", eventArgs.Exception.Message);


            DialogResult result = DialogResult.Cancel;
            try
            {
                result = ShowThreadExceptionDialog("Windows Forms Error", eventArgs.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Windows Forms Error",
       "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Exits the program when the user clicks Abort.
            if (result == DialogResult.Abort)
                Application.Exit();
        }




        static bool IsAlreadyRunning()
        {
            Process processCurrent = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (processCurrent.Id != process.Id)
                {
                    if (processCurrent.ProcessName == process.ProcessName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        // Handle the UI exceptions by showing a dialog box, and asking the user whether
        // or not they wish to abort execution.
        // NOTE: This exception cannot be kept from terminating the application - it can only 
        // log the event, and inform the user about it. 
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                string errorMsg = "An application error occurred. Please contact the adminstrator " +
            "with the following information:\n\n";

                // Since we can't prevent the app from terminating, log this to the event log.
                if (!EventLog.SourceExists("ThreadException"))
                {
                    EventLog.CreateEventSource("ThreadException", "Application");
                }

                // Create an EventLog instance and assign its source.
                EventLog myLog = new EventLog();
                myLog.Source = "ThreadException";
                myLog.WriteEntry(errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace);
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("Fatal Non-UI Error",
     "Fatal Non-UI Error. Could not write the error to the event log. Reason: "
     + exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        // Creates the error message and displays it.
        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
            string errorMsg = "An application error occurred. Please contact the adminstrator " +
        "with the following information:\n\n";
            errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Stop);
        }



    }
}
