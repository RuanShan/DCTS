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
    public partial class ImportImage : Form
    {
        private List<City> CityList = null;

        private List<Nation> NationList = null;
        public ImportImage()
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
            bool isReplace = this.replaceRadioButton.Checked;
            bool success = NewMethod(worker, e, isReplace);
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

        private bool NewMethod(BackgroundWorker worker, DoWorkEventArgs e, bool isReplace)
        {
            WorkerArgument arg = e.Argument as WorkerArgument;
            bool success = true;
            try
            {
                string imageName = this.pathTextBox.Text;
                var strs = System.IO.Directory.GetFiles(imageName).Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("gif") || file.ToLower().EndsWith("jpeg") || file.ToLower().EndsWith("png")).ToList();

                    int rowCount = strs.Count;
                    arg.OrderCount = rowCount;
                    decimal i = 0;
                    int progress = 0;
                    int copiedCount = 0;
                    using (var ctx = new DctsEntities())
                    {
                        foreach (string file in strs)
                        {
                            System.IO.FileInfo fi = new System.IO.FileInfo(file);

                            {
                                string serverimg = file.Replace(imageName + "\\", "");

                                var locations = ctx.ComboLocations.Where(o => o.img == serverimg).ToList();
                                //如果存在复制到相应的文件夹中
                                if (locations != null && locations.Count != 0)
                                {
                                    string copyToPath = EntityPathHelper.LocationImagePath(locations[0]);
                                    if (File.Exists(copyToPath))
                                    {
                                        if (isReplace)
                                        {
                                            File.Copy(file, copyToPath, true);
                                            copiedCount++;
                                        }
                                    }
                                    else
                                    {
                                        File.Copy(file, copyToPath, true);
                                        copiedCount++;
                                    }
                                }
                            }
                            progress =Convert.ToInt32( i++ / rowCount * 100);
                            backgroundWorker1.ReportProgress(progress, arg);

                        }
                    }
               
                backgroundWorker1.ReportProgress(100, arg);
                e.Result = string.Format("{0} 条正常导入成功", copiedCount);
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
