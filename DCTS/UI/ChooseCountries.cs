using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCTS.UI
{
    public partial class ChooseCountries : BaseModalForm
    {
        public ChooseCountries()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            InitializeDataSource();
         }

        // 初始化过滤条件数据
        public int InitializeDataSource()
        {
 
            this.dataGridView1.DataSource = DCTS.DB.GlobalCache.NationList;
            //comboLocationList     
            return 0;
        }

      
        public List<Nation> SelectedNations()
        {
            List<Nation> list = new List<Nation>();

            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                var row = dataGridView1.SelectedRows[i];
                var nation = row.DataBoundItem as Nation;
                list.Add(nation);
            }

            return list;

        }

        private void yesButton2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.yesButton2.PerformClick();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.yesButton2.PerformClick();
        }
    }
}
