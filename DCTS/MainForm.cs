using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
        CustomersControl customersControl;
        AboutBox aboutbox;

        public MainForm()
        {
            InitializeComponent();
            aboutbox = new AboutBox();
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new ImportScenicCSV();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutbox.ShowDialog();
        }

        private void importScenicExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ImportLocationExcel();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
            }
        }

        private void 初始化ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                var form = new ImportMysql();
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void 导入图片信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            try
            {
                var form = new ImportImage();
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

     

        private void ImportnationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new ImportNationDoc();
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void CustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customersControl == null)
            {
                customersControl = new CustomersControl();
                customersControl.Dock = DockStyle.Fill;
            }
            this.customersControl.BeginActive();
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(customersControl);
        }




    }
}
