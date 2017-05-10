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

namespace DCTS.UI
{
    public partial class HotelListControl : UserControl
    {
        private Hashtable dataGridChanges = null;
        private static string NoOptionSelected = "所有";
        private List<ComboLocation> hotelList = null;
        private SortableBindingList<ComboLocation> sortabledinningsOrderList;
        int RowRemark = 0;
        string sqlfilter = "";
        public HotelListControl()
        {
            InitializeComponent();
            this.dataGridChanges = new Hashtable();
            // pager1.Bind();
        }

        public void BeginActive()
        {
            InitializeDataGridView();
            pager1.Bind();

        }

        private void InitializeDataGridView()
        {
            this.pager1.PageCurrent = 1;
            this.pager1.PageSize = 24;
            int offset = 0;

            int pageSize = 50;

            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            //using (var ctx = new DctsEntities())
            {
                hotelList = new List<ComboLocation>();
                var query = ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Hotel).OrderBy(o => o.id).Skip(offset).Take(pageSize);
                hotelList = query.ToList();
                //  var query = ctx.ComboLocations.OrderBy(o => o.id).Skip(offset).Take(pageSize);
                var list = this.entityDataSource1.CreateView(query);
                sortabledinningsOrderList = new SortableBindingList<ComboLocation>(query.ToList());
                this.bindingSource1.DataSource = this.sortabledinningsOrderList;
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = this.bindingSource1;

            }
            var nationList = DCTS.DB.GlobalCache.NationList;

            // 初始化查询条件
            var nations = nationList.Select(o => new MockEntity { Id = o.id, ShortName = o.code, FullName = o.title }).ToList();
            nations.Insert(0, new MockEntity { Id = 0, ShortName = "", FullName = "所有" });
            this.nationComboBox.DisplayMember = "FullName";
            this.nationComboBox.ValueMember = "ShortName";
            this.nationComboBox.DataSource = nations;
            pager1.Bind();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var form = new NewHotelForm("create", null);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                InitializeDataGridView();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" 确定删除 ?", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
            }
            else
                return;
            var oids = GetOrderIdsBySelectedGridCell();
            using (var ctx = new DctsEntities())
            {
                var stockrecs = (from s in ctx.ComboLocations
                                 where oids.Contains(s.id)
                                 select s).ToList();
                ctx.ComboLocations.RemoveRange(stockrecs);
                ctx.SaveChanges();

            }
            InitializeDataGridView();
        }
        private List<long> GetOrderIdsBySelectedGridCell()
        {

            List<long> order_ids = new List<long>();
            var rows = GetSelectedRowsBySelectedCells(dataGridView);
            foreach (DataGridViewRow row in rows)
            {
                var Diningorder = row.DataBoundItem as ComboLocation;
                order_ids.Add(Diningorder.id);
            }

            return order_ids;
        }
        private IEnumerable<DataGridViewRow> GetSelectedRowsBySelectedCells(DataGridView dgv)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                rows.Add(cell.OwningRow);
            }
            return rows.Distinct();
        }

        private void btfind_Click(object sender, EventArgs e)
        {
            FindDataSources();
            pager1.Bind();
        }
        private int FindDataSources()
        {
            sqlfilter = "";

            var nation = nationComboBox.Text;
            var city = this.cityComboBox.Text;
            var title = this.textBox1.Text;

            string conditions = "";//s.ltype =(int)ComboLocationEnum.Dining
            List<MySqlParameter> condition_params = new List<MySqlParameter>();
            var ltype = (int)ComboLocationEnum.Hotel;


            if (ltype > 0)
            {
                if (conditions.Length > 0)
                {
                    conditions += " AND ";
                }
                conditions += "(`ltype`= @ltype)";
            }
            if (nation != NoOptionSelected)
            {
                if (nation.Length > 0)
                {
                    if (conditions.Length > 0)
                    {
                        conditions += " AND ";
                    }
                    conditions += "(`nation`= @nation)";
                }
            }
            if (city != NoOptionSelected)
            {
                if (city.Length > 0)
                {
                    if (conditions.Length > 0)
                    {
                        conditions += " AND ";
                    }
                    conditions += "(`city`= @city)";
                }
            }
            if (title.Length > 0)
            {
                if (conditions.Length > 0)
                {
                    conditions += " AND ";
                }
                //conditions += "(`title`= @title)";
                conditions += "(`title`LIKE '%" + @title + "%')";
            }



            #region  new
            condition_params.Add(new MySqlParameter("@ltype", ltype));
            condition_params.Add(new MySqlParameter("@nation", nation));
            condition_params.Add(new MySqlParameter("@city", city));
            condition_params.Add(new MySqlParameter("@title", title));

            int limit = pager1.PageSize;
            int offset = (pager1.PageCurrent > 1 ? pager1.OffSet(pager1.PageCurrent - 1) : 0);
            int count = 0;
            using (var ctx = new DctsEntities())
            {
                if (conditions.Length > 0)
                {
                    conditions = " WHERE " + conditions;
                }

                string sqlCount = string.Format(" SELECT count(*) FROM combolocations {0}", conditions);
                count = ctx.Database.SqlQuery<int>(sqlCount, condition_params.ToArray()).First();
                string sql = string.Format(" SELECT * FROM combolocations {0} LIMIT {1} OFFSET {2}", conditions, limit, offset);
                hotelList = ctx.Database.SqlQuery<ComboLocation>(sql, condition_params.ToArray()).ToList();
                count = hotelList.Count;
                sqlfilter = string.Format(" SELECT * FROM combolocations ", conditions);

                //DinningList = (from s in ctx.ComboLocations
                //               where s.title == title
                //               select s).ToList();
                sortabledinningsOrderList = new SortableBindingList<ComboLocation>(hotelList.ToList());
                this.bindingSource1.DataSource = this.sortabledinningsOrderList;
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = this.bindingSource1;

            }


            return count;


            #endregion
        }


        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void btsave_Click(object sender, EventArgs e)
        {
            if (dataGridChanges.Count > 0)
            {
                entityDataSource1.SaveChanges();
            }
            dataGridChanges.Clear();
            //InitializeDataSource(ShipNO);
            InitializeDataGridView();
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView.Rows[e.RowIndex];
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString();
            var new_cell_value = row.Cells[e.ColumnIndex].Value;
            var original_cell_value = dataGridChanges[cell_key];
            // original_cell_value could null
            //Console.WriteLine(" original = {0} {3}, new ={1} {4}, compare = {2}, {5}", original_cell_value, new_cell_value, original_cell_value == new_cell_value, original_cell_value.GetType(), new_cell_value.GetType(), new_cell_value.Equals(original_cell_value));
            if (new_cell_value == null && original_cell_value == null)
            {
                dataGridChanges.Remove(cell_key + "_changed");
            }
            else if ((new_cell_value == null && original_cell_value != null) || (new_cell_value != null && original_cell_value == null) || !new_cell_value.Equals(original_cell_value))
            {
                dataGridChanges[cell_key + "_changed"] = new_cell_value;
            }
            else
            {
                dataGridChanges.Remove(cell_key + "_changed");
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            #region  new
            if (dataGridView.Columns[e.ColumnIndex] == this.imgColumn1)
            {
                if (e.RowIndex < hotelList.Count)
                {

                    ComboLocation selectedItem = dataGridView.Rows[e.RowIndex].DataBoundItem as ComboLocation;
                    long folername = selectedItem.id / 1000;
                    if (selectedItem.img != null && selectedItem.img != "")
                    {
                        //   string path = Path.Combine(ImageBasePath, "location_" + ComboLocationEnum.Scenic.ToString().ToLower());
                        string lcoalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\data\\images\\location_" + ComboLocationEnum.Hotel.ToString().ToLower() + "\\" + folername + "\\", selectedItem.img);
                        e.Value = GetImage1(lcoalPath);
                    }
                }
            }

            #endregion

        }
        public System.Drawing.Image GetImage1(string path)
        {
            //C:\mysteap\work_office\ProjectOut\RuanShanLvYou\DCTS\DCTS\bin\Debug\\data\images\locations\0\QQ截图20170105225656.png
            //C:\mysteap\work_office\ProjectOut\RuanShanLvYou\DCTS\DCTS\bin\Debug\data\images\location_scenic\0
            if (File.Exists(path))
            {

                System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);
                System.Drawing.Image result = System.Drawing.Image.FromStream(fs);

                fs.Close();

                return result;
            }
            else
                return null;

        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow dgrSingle = dataGridView.Rows[e.RowIndex];
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString();

            if (!dataGridChanges.ContainsKey(cell_key))
            {
                dataGridChanges[cell_key] = dgrSingle.Cells[e.ColumnIndex].Value;
            }
        }

        private void nationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string code = nationComboBox.SelectedValue.ToString();

            var cityList = DCTS.DB.GlobalCache.CityList;
            cityList = cityList.Where(o => o.nationCode == code).ToList();
            var cities = cityList.Select(o => new MockEntity { Id = o.id, FullName = o.title }).ToList();
            cities.Insert(0, new MockEntity { Id = 0, FullName = "所有" });

            this.cityComboBox.DisplayMember = "FullName";
            this.cityComboBox.ValueMember = "Id";
            this.cityComboBox.DataSource = cities;
        }

        private int pager1_EventPaging(EventPagingArg e)
        {
            int count = FindDataSources();
            return count;
        }

        private void 修改ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int i = this.dataGridView.CurrentRow.Index;
            ComboLocation selectedItem = hotelList[i];
            var form = new NewHotelForm("Edit", selectedItem);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                InitializeDataGridView();
            }
        }

        private void btdown_Click(object sender, EventArgs e)
        {
            using (var ctx = new DctsEntities())
            {
                var list1 = ctx.Database.SqlQuery<ComboLocation>(sqlfilter).ToList();
                #region MyRegion
                if (list1 == null || list1.Count == 0)
                {
                    MessageBox.Show("Sorry , No Data Output !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = ".csv";
                saveFileDialog.Filter = "csv|*.csv";
                string strFileName = "Hotellist  " + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                saveFileDialog.FileName = strFileName;
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    strFileName = saveFileDialog.FileName.ToString();
                }
                else
                {
                    return;
                }
                FileStream fa = new FileStream(strFileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite );
                StreamWriter sw = new StreamWriter(fa, Encoding.Unicode);
                string delimiter = "\t";
                string strHeader = "";
                //国家	城市		英文名称	图片	预定房型	早餐	经纬度	地址	如何抵达	联系方式	WIFI	停车位	前台	厨房	深度TIPS

                strHeader = "序号\t国家\t城市\t中文名称\t英文名称\t图片\t预定房型\t早餐\t经纬度\t地址\t如何抵达\t联系方式\tWIFI\t停车位\t前台\t厨房\t深度TIPS";

                sw.WriteLine(strHeader);
                //output rows data
                for (int j = 0; j < list1.Count; j++)
                {
                    string strRowValue = "";

                    //strRowValue += delimiter;

                    var model = list1[j];
                    if (model.id != null)
                        strRowValue += model.id.ToString().Replace("\r\n", " ").Replace("\n", "") + delimiter;
                    else
                        strRowValue += delimiter;



                    if (model.nation != null)
                        strRowValue += model.nation.Replace("\r\n", " ").Replace("\n", "") + delimiter;
                    else
                        strRowValue += delimiter;

                    if (model.city != null)
                        strRowValue += model.city.Replace("\r\n", " ").Replace("\n", "") + delimiter;
                    else
                        strRowValue += delimiter;

                    if (model.title != null)
                        strRowValue += model.title.Replace("\r\n", " ").Replace("\n", "") + delimiter;
                    else
                        strRowValue += delimiter;

                    if (model.local_title != null)
                        strRowValue += model.local_title.Replace("\r\n", " ").Replace("\n", "") + delimiter;
                    else
                        strRowValue += delimiter;

                    if (model.img != null)
                        strRowValue += model.img.Replace("\r\n", " ").Replace("\n", "") + delimiter;
                    else
                        strRowValue += delimiter;

                    if (model.room != null)
                        strRowValue += model.room.Replace("\r\n", " ").Replace("\n", "") + delimiter;
                    else
                        strRowValue += delimiter;

                    if (model.dinner != null)
                        strRowValue += model.dinner.Replace("\r\n", " ").Replace("\n", "") + delimiter;
                    else
                        strRowValue += delimiter;

                    if (model.latlng != null)
                        strRowValue += model.latlng.Replace("\r\n", " ").Replace("\n", "") + delimiter;
                    else
                        strRowValue += delimiter;

                    if (model.address != null)
                        strRowValue += model.address.Replace("\r\n", " ").Replace("\n", "") + delimiter;
                    else
                        strRowValue += delimiter;

                    if (model.local_address != null)
                        strRowValue += model.local_address.Replace("\r\n", " ").Replace("\n", "") + delimiter;
                    else
                        strRowValue += delimiter;


                    if (model.contact != null)
                        strRowValue += model.contact.Replace("\r\n", " ").Replace("\n", "") + delimiter;
                    else
                        strRowValue += delimiter;

                    if (model.wifi != null)
                        strRowValue += model.wifi.Replace("\r\n", " ").Replace("\n", "") + delimiter;
                    else
                        strRowValue += delimiter;


                    if (model.parking != null)
                        strRowValue += model.parking.Replace("\r\n", " ").Replace("\n", "") + delimiter;
                    else
                        strRowValue += delimiter;


                    if (model.reception != null)
                        strRowValue += model.reception.Replace("\r\n", " ").Replace("\n", "") + delimiter;
                    else
                        strRowValue += delimiter;



                    if (model.kitchen != null)
                        strRowValue += model.kitchen.Replace("\r\n", " ").Replace("\n", "") + delimiter;
                    else
                        strRowValue += delimiter;


                    if (model.tips != null)
                        strRowValue += model.tips.Replace("\r\n", " ").Replace("\n", "") + delimiter;
                    else
                        strRowValue += delimiter;

                    ;

                    sw.WriteLine(strRowValue);
                }
                sw.Close();
                fa.Close();
                MessageBox.Show("下载成功！", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                #endregion
            }
        }


    }
}
