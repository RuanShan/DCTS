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
<<<<<<< HEAD
        EditTripControl editTripControl;
=======
        DinningsControl dinningsControl;
>>>>>>> f6d920bb01e09cbbf316350ad446055692f923b6

        public TripsManagementControl()
        {
            InitializeComponent();

            this.tripsControl.CommandRequestEvent += new EventHandler( OnCommandRequest );

            this.tripsControl.BeginActive();   

            InitUserControls();
            
         }

        private void InitUserControls()
        {
            //LogHelper.WriteLog("Start initialize main control");
             
            editTripControl = new EditTripControl();
            editTripControl.Dock = DockStyle.Fill;

            this.editTripControl.CommandRequestEvent += new EventHandler(OnCommandRequest);

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

<<<<<<< HEAD
        void OnCommandRequest(object sender, EventArgs e)
        {
            var commandEventArgs = e as CommandRequestEventArgs;
            if (commandEventArgs.Command == CommandRequestEnum.EditTrip)
            {
                editTripControl.ModelId = commandEventArgs.ModelId;
                editTripControl.BeginActive();
                this.mainPanel.Controls.Clear();
                this.mainPanel.Controls.Add(editTripControl);
            }

            if (commandEventArgs.Command == CommandRequestEnum.TripList)
            {
                this.mainPanel.Controls.Clear();
                this.mainPanel.Controls.Add(tripsControl);
            }

            Console.WriteLine("Sub1 receives the OnCommandRequest event.");
        } 


        
=======
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
>>>>>>> f6d920bb01e09cbbf316350ad446055692f923b6
    }



}
