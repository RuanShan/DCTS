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
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
           

            var query = ctx.Nations.AsQueryable();

            int count = query.Count();
            this.dataGridView1.DataSource = this.entityDataSource1.CreateView(query);
            //comboLocationList     
            return count;
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
    }
}
