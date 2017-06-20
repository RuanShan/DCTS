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
    public partial class NewNationsForm : BaseModalForm
    {
        private long changeid;
        List<MockEntity> locationTypeList;
        public bool istrue;
        public NewNationsForm(string maintype, Nation obj)
        {
            InitializeComponent();
            locationTypeList = GlobalCache.Supplier_LocationTypeList;
            InitializeDataSource();

            changeid = 0;
            if (maintype == "Edit")
            {
                label2.Text = "编辑国家";
                this.Text = "编辑国家";
                changeid = obj.id;
                this.titleTextBox.Text = obj.title;
                this.codetextBox1.Text = obj.code;
            }
        }

        public void InitializeDataSource()
        {
            var ctx = this.entityDataSource1.DbContext as DctsEntities;
            var nationList = DCTS.DB.GlobalCache.NationList;
            var locationTypeListForComboBox = locationTypeList.Select(o => new MockEntity { Id = o.Id, FullName = o.FullName }).ToList();


        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            using (var ctx = new DctsEntities())
            {
                try
                {
                  
                    #region new
                    string title = this.codetextBox1.Text;
                    bool hasImg = (titleTextBox.Text.Length > 0);
                    bool existSame = false;
                    
                    if (hasImg)
                    {

                        existSame = (ctx.Nations.Where(o => o.code == title).Count() > 0);

                    }                 


                    #endregion

                    if (changeid != 0)
                    {
                        //if (existSame)
                        //{
                        //    istrue = false;
                        //    MessageBox.Show(string.Format("文件名<{0}>已在, 请使用其他文件名！", title));
                        //    return;

                        //}
                        Nation obj = ctx.Nations.Find(Convert.ToInt32(changeid));
                        obj.title = this.titleTextBox.Text;
                        obj.code = this.codetextBox1.Text;                      

                        ctx.SaveChanges();
                      
                    }
                    else
                    {
                        var obj = ctx.Nations.Create();
                        obj.title = this.titleTextBox.Text;
                        obj.code = this.codetextBox1.Text;
                        ctx.Nations.Add(obj);
                        if (existSame == false && this.titleTextBox.Text.Length <= 100)
                            ctx.SaveChanges();
                        else
                        {
                            MessageBox.Show("错误：请检查名称的长度或是否已存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        
                    }
                    istrue = true;




                }
                catch (Exception EX)
                {

                    throw;
                }


            }

        }



        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void NewDinningsForm_Load(object sender, EventArgs e)
        {

        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            using (var ctx = new DctsEntities())
            {
                bool nameishave = false;
                bool hastitle = (titleTextBox.Text.Length > 0);
                if (hastitle)
                {
                    ComboLocation lastLocation = ctx.ComboLocations.OrderByDescending(o => o.id).FirstOrDefault();
                    if (lastLocation != null)
                        nameishave = (ctx.ComboLocations.Where(o => o.ltype == (int)ComboLocationEnum.Country && o.title == titleTextBox.Text).Count() > 0);

                    if (changeid == 0)
                    {
                        if (nameishave == true || this.titleTextBox.Text.Length > 100)
                            errorProvider1.SetError(titleTextBox, String.Format("错误：请检查名称的长度或是否已存在 {0}", titleTextBox.Text));
                    }
                    else
                    {
                        if (this.titleTextBox.Text.Length > 100)
                            errorProvider1.SetError(titleTextBox, String.Format("错误：请检查名称的长度 {0}", titleTextBox.Text));
                    }
                }
            }
        }

     
 
    }
}
