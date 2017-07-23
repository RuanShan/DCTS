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
    public partial class SelectSystemfile : Form
    {
        public List<string> listfile = new List<string>();
        public string selectedImage = string.Empty;
        public string selectedImageAbsolutePath = string.Empty;
        List<LocationImage> listpage;
        public string strFileName = String.Empty;
        public SelectSystemfile()
        {
            InitializeComponent();
            string basePath = EntityPathHelper.ImageBasePath;
            var uri = new Uri(basePath);
            this.shellTreeView1.RootFolder = new GongSolutions.Shell.ShellItem(uri);
        }
        public void BeginActive()
        {
          

        }
    

        private void saveButton_Click(object sender, EventArgs e)
        {
            GetSelectImagePath();
            this.Close();
        }

        private string GetSelectImagePath()
        {
            string imageRelativePath = string.Empty;

            if (this.shellView1.SelectedItems.Count() > 0)
            {
                var item = this.shellView1.SelectedItems.First();

                string absolutePath = item.FileSystemPath;

                this.selectedImageAbsolutePath = absolutePath;
                this.selectedImage = absolutePath.Substring(EntityPathHelper.ImageBasePath.Length);
            }
            return imageRelativePath;
        
        }

        private void shellView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.shellView1.SelectedItems.Count() == 1)
            {
                GetSelectImagePath();
                this.Close();
            }
        }

    }
}
