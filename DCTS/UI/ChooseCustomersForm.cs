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
    public partial class ChooseCustomersForm : BaseModalForm
    {
        public ChooseCustomersForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            this.pager1.Bind();
        }

        // 初始化过滤条件数据
        public int InitializeDataSource()
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            int size = pager1.PageSize;
            int offset = (pager1.PageCurrent > 1 ? pager1.OffSet(pager1.PageCurrent - 1) : 0);

            var query = ctx.Customers.AsQueryable();

            query = query.OrderBy(o => o.created_at).Skip(offset).Take(size);
            int count = query.Count();
            this.dataGridView1.DataSource = this.entityDataSource1.CreateView(query);
            //comboLocationList     
            return count;
        }

        private int pager1_EventPaging(CustomComponents.EventPagingArg e)
        {
            return InitializeDataSource();
        }

        public List<Customer> SelectedCustomers()
        {
            List<Customer> list = new List<Customer>();
            
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    var row = dataGridView1.SelectedRows[i];
                    var customer = row.DataBoundItem as Customer;
                    list.Add(customer);
                }
                        
            return list;
        
        }
    }
}
