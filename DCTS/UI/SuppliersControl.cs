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
        private static string NoOptionSelected = "所有";
        private List<ComboLocation> nationlList = null;
        private Hashtable dataGridChanges = null;
        List<MockEntity> locationTypeList;
        public SuppliersControl()
        {
            InitializeComponent();
            this.dataGridChanges = new Hashtable();
            InsuranceGridView.AutoGenerateColumns = false;
            RentalGridView.AutoGenerateColumns = false;
            WIFIGridView.AutoGenerateColumns = false;
            dataGridView.AutoGenerateColumns = false;
            locationTypeList = GlobalCache.Supplier_LocationTypeList;
            InitializeDataSource();
            pager2.PageCurrent = 1;
        }
        public void BeginActive()
        {
            InitializeDataSource();
            InitializeDataGridView();
            pager2.Bind();

        }
        public void InitializeDataSource()
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            var nationList = DCTS.DB.GlobalCache.NationList;
            var locationTypeListForComboBox = locationTypeList.Select(o => new MockEntity { Id = o.Id, FullName = o.FullName }).ToList();

            // 活动分类
            //this.nationComboBox.DisplayMember = "FullName";
            //this.nationComboBox.ValueMember = "Id";
            //this.nationComboBox.DataSource = locationTypeListForComboBox;
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        // 初始化DataGridView的数据源, 
        private int InitializeDataGridView(int pageCurrent = 1)
        {
            string Suppliername =""; //(this.nationComboBox.Text != NoOptionSelected ? this.nationComboBox.Text : string.Empty);

            string title = (this.keywordTextBox.Text != NoOptionSelected ? this.keywordTextBox.Text : string.Empty);

            int count = 0;
            int pageSize = pager2.PageSize;


            int[] otherLocationType = { (int)SupplierEnum.Air, (int)SupplierEnum.Insurance, (int)SupplierEnum.Rental, (int)SupplierEnum.WIFI };


            using (var ctx = new DctsEntities())
            {
                int ty = 0;// Convert.ToInt32(this.nationComboBox.SelectedValue);

                //分页需要数据总数
                count = Count(ty, title);

                var list = Paginate( pageCurrent, pageSize, ty, "", title);



                //List<Supplier> list = ctx.Suppliers.Where(o => otherLocationType.Contains(o.stype)).ToList();
                int page = this.tabControl1.SelectedIndex;

                if (page == 0)
                {
                    var Airfiltered = list.FindAll(s => s.stype == (int)SupplierEnum.Air);
               
                this.dataGridView.DataSource = Airfiltered;
                }
                if (page == 1)
                {
                    var Insurancefiltered = list.FindAll(s => s.stype == (int)SupplierEnum.Insurance);

                    this.InsuranceGridView.DataSource = Insurancefiltered;
                }
                if (page == 2)
                {
                    var Rentalfiltered = list.FindAll(s => s.stype == (int)SupplierEnum.Rental);

                    this.RentalGridView.DataSource = Rentalfiltered;
                }
                if (page == 3)
                {
                    var WIFIfiltered = list.FindAll(s => s.stype == (int)SupplierEnum.WIFI);

                    this.WIFIGridView.DataSource = WIFIfiltered;
                }
            }
            return 1;
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
        private static List<Supplier> Paginate( int currentPage = 1, int pageSize = 25, int nation = 0, string city = "", string title = "")
        {
            // 如果数据为0，分页控件，设置currentPage = 0; 这回导致下面查询异常
            if (currentPage <= 0)
            {
                currentPage = 1;
            }
            List<Supplier> list = new List<Supplier>();

            using (var ctx = new DctsEntities())
            {
                int[] otherLocationType = { (int)SupplierEnum.Air, (int)SupplierEnum.Insurance, (int)SupplierEnum.Rental, (int)SupplierEnum.WIFI };

                var query = ctx.Suppliers.Where(o => otherLocationType.Contains(o.stype));

                //var query = ctx.Suppliers.Where(o => o.stype == (int)locationType);

                if (nation > 0)
                {
                    query = query.Where(o => o.stype == nation);
                }

                if (title.Length > 0)
                {
                    query = query.Where(o => o.name.Contains(title));
                }

                if (pageSize > 0)
                {
                    int offset = (currentPage - 1) * pageSize;
                    // order is required before skip
                    query = query.OrderBy(o => o.id).Skip(offset).Take(pageSize);
                }
                list = query.ToList();

            }
            return list;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Edit(e);

        }

        private void Edit(DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = dataGridView.Columns[e.ColumnIndex];
            int s = this.tabControl1.SelectedIndex;

            if (s == 1)
                column = InsuranceGridView.Columns[e.ColumnIndex];
            else if (s == 2)
                column = RentalGridView.Columns[e.ColumnIndex];
            else if (s == 3)
                column = WIFIGridView.Columns[e.ColumnIndex];

            if (column == editColumn1 || column == EditWifi || column == dav3Edit || column == dav2Edit)
            {
                var row = dataGridView.Rows[e.RowIndex];

                if (s == 1)
                    row = InsuranceGridView.Rows[e.RowIndex];
                else if (s == 2)
                    row = RentalGridView.Rows[e.RowIndex];
                else if (s == 3)
                    row = WIFIGridView.Rows[e.RowIndex];

                var model = row.DataBoundItem as Supplier;

                var form = new NewSupplierForm("Edit", model);
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    BeginActive();
                }
            }
            else if (column == deleteColumn1 || column == DeleteWifli || column == dav3Delete || column == dav2Delete)
            {
                var row = dataGridView.Rows[e.RowIndex];
                if (s == 1)
                    row = InsuranceGridView.Rows[e.RowIndex];
                else if (s == 2)
                    row = RentalGridView.Rows[e.RowIndex];
                else if (s == 3)
                    row = WIFIGridView.Rows[e.RowIndex];

                var model = row.DataBoundItem as Supplier;
                string msg = string.Format("确定删除餐厅<{0}>？", model.name);

                if (MessageHelper.DeleteConfirm(msg))
                {
                    ComboLoactionBusiness.Supplier_Delete(model.id);
                    BeginActive();
                }
            }
        }

        private void NationsControl_Resize(object sender, EventArgs e)
        {  //                                                   id
            //int s = this.tabControl1.SelectedIndex;

            //if (s == 0)
            //{
            //    StypeColumn1.Width = dataGridView.ClientSize.Width - 60 - 100 * 3 - 280 - 200 - 100 - 60 * 2 - 3;
            //    //是否包含滚动条
            //    if (!(this.dataGridView.DisplayedRowCount(false) == this.dataGridView.RowCount))
            //    {
            //        StypeColumn1.Width -= 18;
            //    }
            //}
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var form = new NewSupplierForm("create", null);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                InitializeDataGridView();
            }
        }

        private void InsuranceGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Edit(e);
        }

        private void RentalGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Edit(e);
        }

        private void WIFIGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Edit(e);
        }

        private void btfind_Click(object sender, EventArgs e)
        {

            pager2.PageCurrent = 1;

            pager2.Bind();
        }

        private int pager2_EventPaging(EventPagingArg e)
        {


            int count = InitializeDataGridView(e.PageCurrent);
            return count;

        }
    }
}
