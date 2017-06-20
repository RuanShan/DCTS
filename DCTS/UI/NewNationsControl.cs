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
    public partial class NewNationsControl : UserControl
    {

        private Hashtable dataGridChanges = null;
     
        private static string NoOptionSelected = "所有";
        public NewNationsControl()
        {
            InitializeComponent();
            this.dataGridChanges = new Hashtable();
           
            dataGridView.AutoGenerateColumns = false;
            pager2.PageCurrent = 1;
        }
        public void BeginActive()
        {
        
            pager2.Bind();

        }
    

        private int InitializeDataGridView(int pageCurrent = 1)
        {
          
            string title = (this.keywordTextBox.Text != NoOptionSelected ? this.keywordTextBox.Text : string.Empty);

            int count = 0;
            int pageSize = pager2.PageSize;

            using (var ctx = new DctsEntities())
            {
                //分页需要数据总数
                count = Count(  title);

                var list = Paginate(pageCurrent, pageSize, title);

                this.dataGridView.DataSource = list;
            }
            return count;
        }
        private static int Count(  string title)
        {
            int count = 0;
            using (var ctx = new DctsEntities())
            {
                var query = ctx.Nations.AsQueryable();
              

                if (title.Length > 0)
                {
                    query = query.Where(o => o.title.Contains(title));
                }
                count = query.Count();
            }
            return count;
        }
        private static List<Nation> Paginate(int currentPage = 1, int pageSize = 25, string title = "")
        {
            // 如果数据为0，分页控件，设置currentPage = 0; 这回导致下面查询异常
            if (currentPage <= 0)
            {
                currentPage = 1;
            }
            List<Nation> list = new List<Nation>();

            using (var ctx = new DctsEntities())
            {

                var query = ctx.Nations.Where(o =>   o.title != null);


                if (title.Length > 0)
                {
                    query = query.Where(o => o.title.Contains(title));
                }

                if (pageSize > 0)
                {
                    int offset = (currentPage - 1) * pageSize;

                    query = query.OrderBy(o => o.title).Skip(offset).Take(pageSize);
                }
                list = query.ToList();

            }
            return list;
        }

 

        private static int Count(int nation, string title)
        {
            int count = 0;
            using (var ctx = new DctsEntities())
            {
                var query = ctx.Suppliers.AsQueryable();

                if (nation > 0)
                {
                    int ty = Convert.ToInt32(nation);

                    query = query.Where(o => o.stype == ty);

                }
                if (title.Length > 0)
                {
                    query = query.Where(o => o.name.Contains(title));
                }
                count = query.Count();
            }
            return count;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = dataGridView.Columns[e.ColumnIndex];

            if (column == editColumn1)
            {
                var row = dataGridView.Rows[e.RowIndex];

                var model = row.DataBoundItem as Nation;

                var form = new NewNationsForm("Edit", model);
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    BeginActive();
                }
            }
            else if (column == deleteColumn1)
            {
                var row = dataGridView.Rows[e.RowIndex];
                var model = row.DataBoundItem as Nation;
                string msg = string.Format("确定删除国家<{0}>？", model.title);

                if (MessageHelper.DeleteConfirm(msg))
                {
                    ComboLoactionBusiness.nationsDelete(model.id);
                    BeginActive();
                }
            }

        }

     
        private void NationsControl_Resize(object sender, EventArgs e)
        {  //                                                   id


            this.nationColumn1.Width = dataGridView.ClientSize.Width - 60 - 100 * 3 - 280 - 200 - 100 - 60 * 2 - 3;
            //是否包含滚动条
            if (!(this.dataGridView.DisplayedRowCount(false) == this.dataGridView.RowCount))
            {
                nationColumn1.Width -= 18;
            }

        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var form = new NewNationsForm("create", null);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {

            }
        }



        private void btfind_Click(object sender, EventArgs e)
        {
            pager2.PageCurrent = 1;
            pager2.Bind();


        }

        private int pager2_EventPaging(EventPagingArg e)
        {
            int count = InitializeDataGridView(e.PageCurrent);
            return count; return default(int);
        }





    }
}
