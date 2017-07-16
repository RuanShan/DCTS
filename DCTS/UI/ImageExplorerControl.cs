using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCTS.DB;

namespace DCTS.UI
{
    public partial class ImageExplorerControl : UserControl
    {
        public ImageExplorerControl()
        {
            InitializeComponent();
            string basePath = EntityPathConfig.ImageBasePath;
            var uri = new Uri(basePath);
            this.shellComboBox1.RootFolder = new GongSolutions.Shell.ShellItem(uri);
            this.shellTreeView1.RootFolder = new GongSolutions.Shell.ShellItem(uri);
            
        }
    }
}
