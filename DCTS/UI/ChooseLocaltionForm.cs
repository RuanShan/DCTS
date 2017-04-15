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

        List<MockEntity> locationTypeList;

        List<ComboLocation> comboLocationList;

        public ComboLocation SelectedLocation { get; set; }


        public ChooseLocaltionForm()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            locationTypeList = new List<MockEntity>();
        }

        // 初始化过滤条件数据
        public void InitializeDataSource()
        {
            locationTypeList.Add(new MockEntity { Id = (int)ComboLocationEnum.Scenic, FullName = ComboLocationEnum.Scenic.ToString() });
            locationTypeList.Add(new MockEntity { Id = (int)ComboLocationEnum.Hotel, FullName = ComboLocationEnum.Hotel.ToString() });
            locationTypeList.Add(new MockEntity { Id = (int)ComboLocationEnum.Dining, FullName = ComboLocationEnum.Dining.ToString() });

            // 活动分类
            this.locationTypeComboBox.DisplayMember = "FullName";
            this.locationTypeComboBox.ValueMember = "Id";
            this.locationTypeComboBox.DataSource = locationTypeList;

            // 国家
            var nationList = DCTS.DB.GlobalCache.NationList;
            var nations = nationList.Select(o => new MockEntity { Id = o.id, ShortName = o.code, FullName = o.title }).ToList();
            nations.Insert(0, new MockEntity { Id = 0, ShortName = "", FullName = "所有" });
            this.nationComboBox.DisplayMember = "FullName";
            this.nationComboBox.ValueMember = "ShortName";
            this.nationComboBox.DataSource = nations;

            
        }

        public void InitializeLocations(int locationType = 0, string nation = "", string city="", string keyword="")
        { 
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            int offset = 0;
            int size = 5000;
            //int offset = (pager1.PageCurrent > 1 ? pager1.OffSet(pager1.PageCurrent - 1) : 0);

            var query = ctx.ComboLocations.AsQueryable();
            if (locationType > 0)
            {
                query = query.Where(o => o.ltype == locationType);
            }

            if (nation.Length > 0)
            {
                query = query.Where(o => o.nation == nation);            
            }

            if (nation.Length > 0)
            {
                query = query.Where(o => o.city == city);
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
            cities.Insert(0, new MockEntity { Id = 0, FullName = "所有" });

            this.cityComboBox.DisplayMember = "FullName";
            this.cityComboBox.ValueMember = "Id";
            this.cityComboBox.DataSource = cities;
        }

        private void ChooseLocaltionForm_Load(object sender, EventArgs e)
        {
            InitializeLocations();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var row = this.dataGridView1.CurrentRow;
            if (row != null)
            {
                SelectedLocation = row.DataBoundItem as ComboLocation;
            }
        }
    }
}
