using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCTS.DB;

namespace DCTS.UI
{
    public partial class NewDinningsForm : BaseModalForm
    {
        private long changeid;

        public NewDinningsForm(string maintype, ComboLocation obj)
        {
            InitializeComponent();
            InitializeDataSource();
            changeid = 0;
            if (maintype == "Edit")
            {


                //obj.ltype = (int)ComboLocationEnum.Dining;
                this.nationComboBox.Text = obj.nation;
                this.cityComboBox.Text = obj.city;
                this.titleTextBox.Text = obj.area;
                this.textBox1.Text = obj.dishes;
                //obj.img = this.imgPathTextBox.Text;
                imgPathTextBox.Text = obj.img;
                this.latlngTextBox.Text = obj.latlng;
                this.textBox2.Text = obj.local_address;
                this.localAddressTextBox.Text = obj.address;
                this.textBox3.Text = obj.recommended_dishes;
                this.textBox6.Text = obj.tips;
                this.localTitleTextBox.Text = obj.title;
                this.openAtDateTimePicker.Text = obj.open_at.ToString();
                this.closeAtDateTimePicker.Text = obj.close_at.ToString();
                changeid = obj.id;




            }
        }

        public void InitializeDataSource()
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            var nationList = DCTS.DB.GlobalCache.NationList;



            this.nationComboBox.DisplayMember = "title";
            this.nationComboBox.ValueMember = "code";
            this.nationComboBox.DataSource = nationList;


        }

        private void nationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string code = nationComboBox.SelectedValue.ToString();

            var cityList = DCTS.DB.GlobalCache.CityList;
            cityList = cityList.Where(o => o.nationCode == code).ToList();
            this.cityComboBox.DisplayMember = "title";
            this.cityComboBox.ValueMember = "id";
            this.cityComboBox.DataSource = cityList;

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string lcoalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\data\\images\\locations\\", "");
            string copypathto = "";

            List<string> Alist = GetFileName(lcoalPath);
            string[] dirs = Directory.GetDirectories(lcoalPath);
            for (int i = 0; i < dirs.Length; i++)
            {
                string[] files = Directory.GetFiles(dirs[i]);
                if (files.Length >= 1000)
                {
                    copypathto = lcoalPath + DateTime.Now.ToString("yyyyMMdd");

                    Directory.CreateDirectory(copypathto);
                    break;

                }
                else if (files.Length < 1000)
                {
                    copypathto = dirs[i] + "\\";
                    break;
                }


            }

            using (var ctx = new DctsEntities())
            {
                string copyfilename = Path.GetFileName(this.imgPathTextBox.Text);


                if (changeid != 0)
                {

                    updateNewMethod(ctx, copyfilename);

                }
                else
                    createNewMethod(ctx, copyfilename);

                if (File.Exists(copypathto + copyfilename))
                {
                    if (MessageBox.Show("此文件名已在本文件夹中存在，是否覆盖?", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {

                        System.IO.File.Copy(this.imgPathTextBox.Text, copypathto + copyfilename, true);


                    }
                    else
                        return;
                }
                else
                    File.Copy(this.imgPathTextBox.Text, Path.Combine(copypathto, Path.GetFileName(this.imgPathTextBox.Text)));
                //File.Copy(this.imgPathTextBox.Text, lcoalPath);
            }

        }

        private void updateNewMethod(DctsEntities ctx, string copyfilename)
        {
            ComboLocation obj = ctx.ComboLocations.Find(Convert.ToInt32(changeid));

            //var obj = ctx.ComboLocations.Create();
            obj.ltype = (int)ComboLocationEnum.Dining;
            obj.nation = this.nationComboBox.Text;
            obj.city = this.cityComboBox.Text;
            obj.area = this.titleTextBox.Text;
            obj.dishes = this.textBox1.Text;
            //obj.img = this.imgPathTextBox.Text;
            obj.img = copyfilename;
            obj.latlng = this.latlngTextBox.Text;
            obj.local_address = this.textBox2.Text;
            obj.address = this.localAddressTextBox.Text;
            obj.recommended_dishes = this.textBox3.Text;
            obj.tips = this.textBox6.Text;
            obj.title = this.localTitleTextBox.Text;
            obj.open_at = Convert.ToDateTime(this.openAtDateTimePicker.Text);
            obj.close_at = Convert.ToDateTime(this.closeAtDateTimePicker.Text);


            //obj.memo = this.memoTextBox.Text;
            //  ctx.ComboLocations.Add(obj);
            ctx.SaveChanges();
        }
        private void createNewMethod(DctsEntities ctx, string copyfilename)
        {

            var obj = ctx.ComboLocations.Create();
            obj.ltype = (int)ComboLocationEnum.Dining;
            obj.nation = this.nationComboBox.Text;
            obj.city = this.cityComboBox.Text;
            obj.area = this.titleTextBox.Text;
            obj.dishes = this.textBox1.Text;
            //obj.img = this.imgPathTextBox.Text;
            obj.img = copyfilename;
            obj.latlng = this.latlngTextBox.Text;
            obj.local_address = this.textBox2.Text;
            obj.address = this.localAddressTextBox.Text;
            obj.recommended_dishes = this.textBox3.Text;
            obj.tips = this.textBox6.Text;
            obj.title = this.localTitleTextBox.Text;
            obj.open_at = Convert.ToDateTime(this.openAtDateTimePicker.Text);
            obj.close_at = Convert.ToDateTime(this.closeAtDateTimePicker.Text);


            //obj.memo = this.memoTextBox.Text;
            ctx.ComboLocations.Add(obj);
            ctx.SaveChanges();
        }

        private List<string> GetFileName(string dirPath)
        {
            List<string> FileNameList = new List<string>();
            ArrayList list = new ArrayList();

            if (Directory.Exists(dirPath))
            {
                list.AddRange(Directory.GetFiles(dirPath));
            }
            if (list.Count > 0)
            {
                foreach (object item in list)
                {
                    FileNameList.Add(item.ToString().Replace(dirPath + "\\", ""));
                }
            }

            return FileNameList;
        }
        private void findFileButton_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "PNG(*.png)|*.png|JPEG(*.jpg,*.jpeg,*.jpe,*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|GIF(*.gif)|*.gif"; //文件类型
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.imgPathTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
