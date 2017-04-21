using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCTS.CustomComponents;
using DCTS.UI;

namespace DCTS
{
    public partial class MainForm : Form
    {
        TripsManagementControl tripsManagementControl;
         public MainForm()
        {
            InitializeComponent();
        }
 

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

       

        private void tripsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tripsManagementControl == null)
            {
                tripsManagementControl = new TripsManagementControl();
                tripsManagementControl.Dock = DockStyle.Fill;
            }
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(tripsManagementControl);
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 导入餐厅信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ImportDiningCSV();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
            }
        }

    
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void 导入住宿信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ImportHotelCSV();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
            }

        }


    }
}
