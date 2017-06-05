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
    public partial class ImportNationDoc : Form
    {
        private List<City> CityList = null;

        private List<Nation> NationList = null;
        public ImportNationDoc()
        {
            InitializeComponent();
         
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
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件夹路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.pathTextBox.Text = dialog.SelectedPath;
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
                string imageName = this.pathTextBox.Text;
                string[] strs = System.IO.Directory.GetFiles(imageName);
                {
                    int rowCount = strs.Length;
                    arg.OrderCount = rowCount;
                    int i = 0;
                    int progress = 0;
                    using (var ctx = new DctsEntities())
                    {
                        foreach (string file in strs)
                        {
                            System.IO.FileInfo fi = new System.IO.FileInfo(file);

                            if (fi.Extension == ".doc" || fi.Extension == ".docx")
                            {
                                string serverimg = file.Replace(imageName + "\\", "");

                                var locations = ctx.ComboLocations.Where(o => o.word == serverimg).ToList();
                                //如果存在复制到相应的文件夹中
                                if (locations != null && locations.Count != 0)
                                {
                                    string copyToPath = EntityPathConfig.TripWordFilePath(locations[0].id);
                                    if (File.Exists(copyToPath))
                                    {
                                        e.Result = "导入[" + file + "]在系统中已存在";
                                        throw new Exception("导入[" + file + "]在系统中已存在");
                                        //  e.Cancel = true;
                                    }
                                    else
                                        File.Copy(file, copyToPath, true);
                                }
                            }
                        }
                        backgroundWorker1.ReportProgress(progress, arg);
                    }
                }
                backgroundWorker1.ReportProgress(100, arg);
                e.Result = string.Format("{0} 条正常导入成功", strs.Length);
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


    }
}
