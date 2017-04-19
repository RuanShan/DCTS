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

namespace DCTS.UI
{
    public partial class ImportDining : Form
    {
        public ImportDining()
        {
            InitializeComponent();
        }

        private void openFileBtton_Click(object sender, EventArgs e)
        {

            OpenFileDialog tbox = new OpenFileDialog();
            tbox.Multiselect = false;
            tbox.Filter = "Excel Files(*.xls,*.xlsx,*.xlsm,*.xlsb,*.csv)|*.xls;*.xlsx;*.xlsm;*.xlsb;*.csv";
            if (tbox.ShowDialog() == DialogResult.OK)
            {
                pathTextBox.Text = tbox.FileName;

            }
            if (pathTextBox.Text == null || pathTextBox.Text == "")
                pathTextBox.Text = "请选择要导入的文件路径";


        }

        private void importButton_Click(object sender, EventArgs e)
        {

        }
       
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           // ReaddinningcsvFile();

        }

    }
}
