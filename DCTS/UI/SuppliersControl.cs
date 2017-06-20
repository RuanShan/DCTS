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

        private Hashtable dataGridChanges = null;
        List<MockEntity> locationTypeList;
        List<Supplier> supplierList;
        SupplierEnum supplierType;

        public SuppliersControl()
        {
            InitializeComponent();
            this.dataGridChanges = new Hashtable();
            InsuranceGridView.AutoGenerateColumns = false;
            RentalGridView.AutoGenerateColumns = false;
            WIFIGridView.AutoGenerateColumns = false;
            flightDataGridView.AutoGenerateColumns = false;
            trainDataGridView.AutoGenerateColumns = false;
            locationTypeList = GlobalCache.Supplier_LocationTypeList;
            supplierType = SupplierEnum.Flight;

            InitializeDataSource();
        }
        public void BeginActive()
        {
            InitializeDataSource();
            InitializeDataGridView();

        }
        public void InitializeDataSource()
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            var nationList = DCTS.DB.GlobalCache.NationList;
             

            // 分类
            this.stypeColumn.DisplayMember = "FullName";
            this.stypeColumn.ValueMember = "Id";
            this.stypeColumn.DataSource = locationTypeList;
            // 分类
            this.stypeColumn2.DisplayMember = "FullName";
            this.stypeColumn2.ValueMember = "Id";
            this.stypeColumn2.DataSource = locationTypeList;
            // 分类
            this.stypeColumn3.DisplayMember = "FullName";
            this.stypeColumn3.ValueMember = "Id";
            this.stypeColumn3.DataSource = locationTypeList;
            // 分类
            this.stypeColumn4.DisplayMember = "FullName";
            this.stypeColumn4.ValueMember = "Id";
            this.stypeColumn4.DataSource = locationTypeList;
            // 分类
            this.stypeColumn5.DisplayMember = "FullName";
            this.stypeColumn5.ValueMember = "Id";
            this.stypeColumn5.DataSource = locationTypeList;
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        // 初始化DataGridView的数据源, 
        private int InitializeDataGridView(int pageCurrent = 1)
        {

            string keyword = (this.keywordTextBox.Text != NoOptionSelected ? this.keywordTextBox.Text : string.Empty);

            

            int[] otherLocationType = { (int)SupplierEnum.Flight, (int)SupplierEnum.Train, (int)SupplierEnum.Insurance, (int)SupplierEnum.Rental, (int)SupplierEnum.WIFI };


            using (var ctx = new DctsEntities())
            {
                //int ty = 0;// Convert.ToInt32(this.nationComboBox.SelectedValue);
                //分页需要数据总数
                //count = Count(ty, title);
                //var list = Paginate( pageCurrent, 100, ty, "", title);
                var query = ctx.Suppliers.AsQueryable();
                if (keyword.Length > 0)
                {
                    query = query.Where(o => o.name.Contains(keyword));
                }

                supplierList = query.ToList();
                
                var Airfiltered = supplierList.FindAll(s => s.stype == (int)SupplierEnum.Flight);
               
                this.flightDataGridView.DataSource = Airfiltered;
                
                var Insurancefiltered = supplierList.FindAll(s => s.stype == (int)SupplierEnum.Insurance);

                this.InsuranceGridView.DataSource = Insurancefiltered;
               
                var Rentalfiltered = supplierList.FindAll(s => s.stype == (int)SupplierEnum.Rental);

                this.RentalGridView.DataSource = Rentalfiltered;
                
                var WIFIfiltered = supplierList.FindAll(s => s.stype == (int)SupplierEnum.WIFI);

                this.WIFIGridView.DataSource = WIFIfiltered;
                this.trainDataGridView.DataSource = supplierList.FindAll(s => s.stype == (int)SupplierEnum.Train); ;

            }
            return 0;
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
                int[] otherLocationType = { (int)SupplierEnum.Flight, (int)SupplierEnum.Insurance, (int)SupplierEnum.Rental, (int)SupplierEnum.WIFI };

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
            var dgv = GetDataGridViewBySupplierType();
            var column = dgv.Columns[e.ColumnIndex];


            if (column == editFlightColumn || column == editWifiColumn || column == editInsuranceColumn || column == editTrainColumn || column == editRentalColumn)
            {
                var row = dgv.Rows[e.RowIndex];

                var model = row.DataBoundItem as Supplier;

                var form = new NewSupplierForm("Edit", model);
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    BeginActive();
                }
            }
            else if (column == deleteFlightColumn || column == deleteWifiColumn || column == deleteInsuranceColumn || column == deleteTrainColumn || column == deleteRentalColumn)
            {
                var row = dgv.Rows[e.RowIndex];
                var model = row.DataBoundItem as Supplier;
                string msg = string.Format("确定删除服务商<{0}>？", model.name);

                if (MessageHelper.DeleteConfirm(msg))
                {
                    ComboLoactionBusiness.Supplier_Delete(model.id);
                    BeginActive();
                }
            }
        }

        private void NationsControl_Resize(object sender, EventArgs e)
        {  //                                                   id

            
            //    StypeColumn1.Width = dataGridView.ClientSize.Width - 60 - 100 * 3 - 280 - 200 - 100 - 60 * 2 - 3;
            //    //是否包含滚动条
            //    if (!(this.dataGridView.DisplayedRowCount(false) == this.dataGridView.RowCount))
            //    {
            //        StypeColumn1.Width -= 18;
            //    }
      
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
            InitializeDataGridView();
          
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (supplierTabControl.SelectedTab == this.flightTabPage)
            {
                this.supplierType = SupplierEnum.Flight;
            }
            else
                if (supplierTabControl.SelectedTab == this.trainTabPage)
                {
                    this.supplierType = SupplierEnum.Train;
                }               
                    else
                        if (supplierTabControl.SelectedTab == this.insuranceTagPage)
                        {
                            this.supplierType = SupplierEnum.Insurance;
                        }
                        else
                            if (supplierTabControl.SelectedTab == this.rentalTabPage)
                            {
                                this.supplierType = SupplierEnum.Rental;
                            }
                            else
                                if (supplierTabControl.SelectedTab == this.wifiTabPage)
                                {
                                    this.supplierType = SupplierEnum.WIFI;
                                }
                                
        }


        private DataGridView GetDataGridViewBySupplierType()
        {
            DataGridView view = null;
            switch ((supplierType))
            {
                case SupplierEnum.Flight:
                    view = this.flightDataGridView;
                    break;
                case SupplierEnum.Train:
                    view = this.trainDataGridView;
                    break;
                case SupplierEnum.Insurance:
                    view = this.InsuranceGridView;
                    break;
                case SupplierEnum.Rental:
                    view = this.RentalGridView;
                    break;
                case SupplierEnum.WIFI:
                    view = this.WIFIGridView;
                    break;

            }
            return view;
        }
    }
}
