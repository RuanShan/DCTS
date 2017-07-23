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
    public partial class OtherControl : UserControl
    {

        private List<ComboLocation> nationlList = null;

        public OtherControl()
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
        }

        public void BeginActive()
        {
            InitializeDataGridView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void btfind_Click(object sender, EventArgs e)
        {

        }


   

        // 初始化DataGridView的数据源, 
        private int InitializeDataGridView(int pageCurrent = 1)
        {

            int[] otherLocationType = { (int)ComboLocationEnum.Letter, (int)ComboLocationEnum.Preparation, (int)ComboLocationEnum.Google, (int)ComboLocationEnum.Flight, (int)ComboLocationEnum.Train, (int)ComboLocationEnum.Rental ,
                                          (int)ComboLocationEnum.FlightList, (int)ComboLocationEnum.HotelList, (int)ComboLocationEnum.RentalList, (int)ComboLocationEnum.OtherList, (int)ComboLocationEnum.InsuranceList
                                      };


            using (var ctx = new DctsEntities())
            {
                List<ComboLocation> list = ctx.ComboLocations.Where(o => otherLocationType.Contains(o.ltype)).ToList();

                // var list = Paginate(pageCurrent, pageSize, title);


                this.dataGridView.DataSource = list;
            }
            return 1;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = dataGridView.Columns[e.ColumnIndex];

            if (column == this.uploadColumn1)
            {

                var row = dataGridView.Rows[e.RowIndex];
                string strFileName = String.Empty;

                var model = row.DataBoundItem as ComboLocation;
                //openFileDialog1.Filter = "DOCX(*.doc,*.docx)|*.doc;*.docx"; //文件类型
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    strFileName = openFileDialog1.FileName;
                }
                if (strFileName.Length > 0)
                {
                    using (var ctx = new DctsEntities())
                    {
                        bool hasDoc = (openFileDialog1.FileName.Length > 0);
                        string docFilePath = this.openFileDialog1.FileName;

                        ComboLocation obj = ctx.ComboLocations.Find(Convert.ToInt32(model.id));
                        obj.title = model.title;
                        obj.ltype = model.ltype;

                        if (hasDoc)
                        {
                            obj.word = openFileDialog1.SafeFileName;
                            string copyToPath = EntityPathHelper.LocationWordPath(obj);


                            if (!File.Exists(copyToPath))
                                File.Copy(docFilePath, copyToPath, true);
                        }
                        ctx.SaveChanges();
                    }
                }
                BeginActive();

            }
            else if (column == this.downloadColumn1)
            {
                string strFileName = String.Empty;

                var row = dataGridView.Rows[e.RowIndex];
                var model = row.DataBoundItem as ComboLocation;


                saveFileDialog1.FileName = model.word;
                if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    strFileName = saveFileDialog1.FileName.ToString();
                }

                if (strFileName.Length > 0)
                {
                    using (var ctx = new DctsEntities())
                    {
                        List<ComboLocation> list = ctx.ComboLocations.Where(o => o.ltype == model.ltype && o.title == model.title).ToList();
                        foreach (ComboLocation item in list)
                        {
                            string copyToPath = EntityPathHelper.LocationWordPath(item);
                            if (File.Exists(copyToPath))
                            {
                                File.Copy(copyToPath, strFileName);
                                MessageBox.Show("下载完成！");
                            }
                            else
                            {
                                MessageBox.Show("无数据可以下载，请重新上传");
                            }
                        }
                    }
                }
            }
        }

        private void NationsControl_Resize(object sender, EventArgs e)
        {  //                                                   id
            titleColumn1.Width = dataGridView.ClientSize.Width - 60 - 100 * 3 - 280 - 200 - 100 - 60 * 2 - 3;
            //是否包含滚动条
            if (!(this.dataGridView.DisplayedRowCount(false) == this.dataGridView.RowCount))
            {
                titleColumn1.Width -= 18;
            }

        }
    }
}
