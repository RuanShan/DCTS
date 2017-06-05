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
        EditTripDaysControl editTripControl;
        DiningsControl dinningsControl;
        HotelListControl hotelControl;
        CustomerTripListControl bookControl;
        NationsControl nationsControl;
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
             
            editTripControl = new EditTripDaysControl();
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
            var eventArgs = new CommandRequestEventArgs(CommandRequestEnum.TripList);
            OnCommandRequest(tripsControl, eventArgs);

            //this.mainPanel.Controls.Clear();
            //this.mainPanel.Controls.Add(tripsControl);
        }

        void OnCommandRequest(object sender, EventArgs e)
        {
            var commandEventArgs = e as CommandRequestEventArgs;
            if (commandEventArgs.Command == CommandRequestEnum.EditTripDays)
            {

                this.mainPanel.Controls.Clear();
                this.mainPanel.Controls.Add(editTripControl);
                editTripControl.ModelId = commandEventArgs.ModelId;
                editTripControl.BeginActive();
            }

            if (commandEventArgs.Command == CommandRequestEnum.TripList)
            {
                tripsControl.BeginActive();
                this.mainPanel.Controls.Clear();
                this.mainPanel.Controls.Add(tripsControl);
            }

            Console.WriteLine("Sub1 receives the OnCommandRequest event.");
        } 


        
        private void dinningsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dinningsControl == null)
            {
                dinningsControl = new DiningsControl();
                dinningsControl.Dock = DockStyle.Fill;
            }
            this.dinningsControl.BeginActive();
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(dinningsControl);

        }

        private void hotelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hotelControl == null)
            {
                hotelControl = new HotelListControl();
                hotelControl.Dock = DockStyle.Fill;
            }
            this.hotelControl.BeginActive();
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(hotelControl);


        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void TripsManagementControl_Resize(object sender, EventArgs e)
        {
            //this.tripsControl
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bookControl == null)
            {
                bookControl = new CustomerTripListControl();
                bookControl.Dock = DockStyle.Fill;
            }
            this.bookControl.BeginActive();
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(bookControl);

        }

        
        private void NationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nationsControl == null)
            {
                nationsControl = new NationsControl();
                nationsControl.Dock = DockStyle.Fill;
            }
            this.nationsControl.BeginActive();
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(nationsControl);

        }

    }



}
