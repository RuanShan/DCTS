using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCTS.UI;

namespace DCTS
{
    public partial class MainForm : Form
    {
        TripsManagementControl tripsManagementControl;
         public MainForm()
        {
            InitializeComponent();
            MessageBox.Show("测试");

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




    }
}
