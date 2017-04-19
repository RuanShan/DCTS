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
        public List<ComboLocation> ReaddinningcsvFile(string aa)
        {

            List<ComboLocation> Result = new List<ComboLocation>();

            string path = AppDomain.CurrentDomain.BaseDirectory + "Resources\\New folder\\Approval Emial.xls";


            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook analyWK = excelApp.Workbooks.Open(path, Type.Missing, true, Type.Missing,
                "htc", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            Microsoft.Office.Interop.Excel.Worksheet WS = (Microsoft.Office.Interop.Excel.Worksheet)analyWK.Worksheets["2016.04"];
            Microsoft.Office.Interop.Excel.Range rng;
            rng = WS.get_Range(WS.Cells[2, 1], WS.Cells[WS.UsedRange.Rows.Count, 30]);
            int rowCount = WS.UsedRange.Rows.Count - 1;
            object[,] o = new object[1, 1];
            o = (object[,])rng.Value2;
            clsCommHelp.CloseExcel(excelApp, analyWK);

            for (int i = 3; i <= rowCount; i++)
            {
                ComboLocation temp = new ComboLocation();

                #region 基础信息

                //temp.zongzhangkemu = "";
                //if (o[i, 1] != null)
                //    temp.zongzhangkemu = o[i, 1].ToString().Trim();
                //if (temp.zongzhangkemu == "" || temp.zongzhangkemu == null)
                //    continue;

                //temp.zhanghao = "";
                //if (o[i, 5] != null)
                //    temp.zhanghao = o[i, 5].ToString().Trim();

                #endregion

                Result.Add(temp);
            }
            return Result;

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           // ReaddinningcsvFile();

        }

    }
}
