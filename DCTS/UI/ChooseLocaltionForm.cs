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

        public ChooseLocaltionForm()
        {
            InitializeComponent();
            locationTypeList = new List<MockEntity>();
        }

        public void InitializeDataSource()
        {
            locationTypeList.Add(new MockEntity { FullName = ComboLocationEnum.Scenic.ToString() });
            locationTypeList.Add(new MockEntity { FullName = ComboLocationEnum.Hotel.ToString() });
            locationTypeList.Add(new MockEntity { FullName = ComboLocationEnum.Dining.ToString() });

            // 活动分类
            this.locationTypeComboBox.DisplayMember = "FullName";
            this.locationTypeComboBox.ValueMember = "FullName";
            this.locationTypeComboBox.DataSource = locationTypeList;

            // 国家
            var nationList = DCTS.DB.GlobalCache.NationList;
            var nations = nationList.Select(o => new MockEntity { Id = o.id, ShortName = o.code, FullName = o.title }).ToList();
            nations.Insert(0, new MockEntity { Id = 0, ShortName = "", FullName = "所有" });
            this.nationComboBox.DisplayMember = "FullName";
            this.nationComboBox.ValueMember = "ShortName";
            this.nationComboBox.DataSource = nations;
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
    }
}
