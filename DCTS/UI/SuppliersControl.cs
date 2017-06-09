using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using DCTS.CustomComponents;
using System.Collections;
using DCTS.DB;
using MySql.Data.MySqlClient;
using System.IO;
using DCTS.Bus;
using DCTS.Uti;

namespace DCTS.UI
{
    public partial class SuppliersControl : UserControl
    {

        private List<ComboLocation> nationlList = null;
        private Hashtable dataGridChanges = null;

        public SuppliersControl()
        {
            InitializeComponent();
            this.dataGridChanges = new Hashtable();
            dataGridView.AutoGenerateColumns = false;

        }

        public void BeginActive()
        {
            InitializeDataGridView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void btfind_Click(object sender, EventArgs e)
        {

        }




        // 初始化DataGridView的数据源, 
        private int InitializeDataGridView(int pageCurrent = 1)
        {

            int[] otherLocationType = { (int)ComboLocationEnum.AirList, (int)ComboLocationEnum.InsuranceList, (int)ComboLocationEnum.CarList, (int)ComboLocationEnum.Flight, (int)ComboLocationEnum.Train, (int)ComboLocationEnum.Rental };


            using (var ctx = new DctsEntities())
            {

                List<ComboLocation> list = ctx.ComboLocations.Where(o => otherLocationType.Contains(o.ltype)).ToList();

                // var list = Paginate(pageCurrent, pageSize, title);


                this.dataGridView.DataSource = list;
            }
            return 1;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = dataGridView.Columns[e.ColumnIndex];



        }

        private void NationsControl_Resize(object sender, EventArgs e)
        {  //                                                   id
            StypeColumn1.Width = dataGridView.ClientSize.Width - 60 - 100 * 3 - 280 - 200 - 100 - 60 * 2 - 3;
            //是否包含滚动条
            if (!(this.dataGridView.DisplayedRowCount(false) == this.dataGridView.RowCount))
            {
                StypeColumn1.Width -= 18;
            }

        }
    }
}
