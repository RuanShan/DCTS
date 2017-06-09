using DCTS.DB;
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
    public partial class ChooseLocaltionForm : BaseModalForm
    {
        static string Any = "所有";
        List<MockEntity> locationTypeList;

        List<ComboLocation> comboLocationList;

        public ComboLocation SelectedLocation { get; set; }


        public ChooseLocaltionForm()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            locationTypeList = GlobalCache.LocationTypeList;
        }

        // 初始化过滤条件数据
        public void InitializeDataSource()
        {
            var locationTypeListForComboBox = locationTypeList.Select(o => new MockEntity { Id = o.Id, FullName = o.FullName }).ToList();
            locationTypeListForComboBox.Insert(0,new MockEntity { Id = 0, FullName = Any });

            // 活动分类
            this.locationTypeComboBox.DisplayMember = "FullName";
            this.locationTypeComboBox.ValueMember = "Id";
            this.locationTypeComboBox.DataSource = locationTypeListForComboBox;

            // 国家
            var nationList = DCTS.DB.GlobalCache.NationList;
            var nations = nationList.Select(o => new MockEntity { Id = o.id, ShortName = o.code, FullName = o.title }).ToList();
            nations.Insert(0, new MockEntity { Id = 0, ShortName = "", FullName = Any });
            this.nationComboBox.DisplayMember = "FullName";
            this.nationComboBox.ValueMember = "ShortName";
            this.nationComboBox.DataSource = nations;

                
            // 活动分类列
            var locationTypeListForColumn = locationTypeList.Select(o => new { Id = (int)o.Id, FullName = o.FullName }).ToList();

            this.locationTypeColumn.DisplayMember = "FullName";
            this.locationTypeColumn.ValueMember = "Id";
            this.locationTypeColumn.DataSource = locationTypeListForColumn;

            this.keyworkTextBox.Text = "";

            InitializeLocations();
            
        }

        public void InitializeLocations(int locationType = 0, string nation = "", string city="", string keyword="")
        { 
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            int offset = 0;
            int size = 5000;
            //int offset = (pager1.PageCurrent > 1 ? pager1.OffSet(pager1.PageCurrent - 1) : 0);

            var availableLocationTypes = locationTypeList.Select(o => o.Id).ToList();

            var query = ctx.ComboLocations.Where(o => availableLocationTypes.Contains(o.ltype));

            if (locationType > 0)
            {
                query = query.Where(o => o.ltype == locationType);
            }

            if (nation.Length > 0)
            {
                query = query.Where(o => o.nation == nation);            
            }

            if (city.Length > 0)
            {
                query = query.Where(o => o.city == city);
            }
            if (keyword.Length > 0)
            {
                query = query.Where(o=>o.title.Contains( keyword ));
            }
            query = query.OrderBy(o => o.city).Skip(offset).Take(size);
            this.dataGridView1.DataSource = this.entityDataSource1.CreateView(query);
            //comboLocationList
        }

        private void nationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string code = nationComboBox.SelectedValue.ToString();

            var cityList = DCTS.DB.GlobalCache.CityList;
            cityList = cityList.Where(o => o.nationCode == code).ToList();
            var cities = cityList.Select(o => new MockEntity { Id = o.id, FullName = o.title }).ToList();
            cities.Insert(0, new MockEntity { Id = 0, FullName = Any });

            this.cityComboBox.DisplayMember = "FullName";
            this.cityComboBox.ValueMember = "Id";
            this.cityComboBox.DataSource = cities;
        }

        private void ChooseLocaltionForm_Load(object sender, EventArgs e)
        {
            InitializeDataSource();
            //Console.WriteLine("yes ChooseLocaltionForm_Load called" + DateTime.Now.ToString());
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var row = this.dataGridView1.CurrentRow;
            if (row != null)
            {
                SelectedLocation = row.DataBoundItem as ComboLocation;
            }
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            int locationType = Convert.ToInt32(this.locationTypeComboBox.SelectedValue);

            string nation = this.nationComboBox.Text == Any ? "" : this.nationComboBox.Text;
            string city = this.cityComboBox.Text == Any ? "" : this.cityComboBox.Text;
            string keyword = this.keyworkTextBox.Text.Trim();
            InitializeLocations(locationType, nation, city, keyword);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ;
        }
    }
}
