using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCTS.Uti;

namespace DCTS.UI
{
    public partial class TripsManagementControl : UserControl
    {
        ScenicsControl scenicsControl;
        DinningsControl dinningsControl;

        public TripsManagementControl()
        {
            InitializeComponent();
            InitUserControls();
        }

        private void InitUserControls()
        {
            LogHelper.WriteLog("Start initialize main control");
            this.tripsControl.BeginActive();   

        }

        private void scenicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scenicsControl == null)
            {
                scenicsControl = new ScenicsControl();
                scenicsControl.Dock = DockStyle.Fill;
            }
            this.scenicsControl.BeginActive();
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(scenicsControl);

        }

        private void tripsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(tripsControl);
        }

        private void dinningsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dinningsControl == null)
            {
                dinningsControl = new DinningsControl();
                dinningsControl.Dock = DockStyle.Fill;
            }
            this.dinningsControl.BeginActive();
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(dinningsControl);

        }
    }
}
