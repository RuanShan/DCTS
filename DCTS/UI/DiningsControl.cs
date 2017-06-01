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
using DCTS.Uti;
using DCTS.Bus;
using NPOI.XWPF.UserModel;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.OpenXmlFormats.Dml.WordProcessing;
using NPOI.OpenXmlFormats.Dml;
using System.Configuration;

namespace DCTS.UI
{
    public partial class DiningsControl : UserControl
    {
        private Hashtable dataGridChanges = null;
        private static string NoOptionSelected = "所有";
        private SortableBindingList<ComboLocation> sortabledinningsOrderList;
        string sqlfilter = "";

        //private List<ComboLocation> dinningsOrderList;
        IBindingList dinningsOrderList = null;
        private List<ComboLocation> DinningList = null;
        private List<DayLocation> DaysList = null;
        public DiningsControl()
        {
            InitializeComponent();
            this.dataGridChanges = new Hashtable();
            dataGridView.AutoGenerateColumns = false;
            pager2.PageCurrent = 1;

        }

        public void BeginActive()
        {
            InitializeDataSource();
            pager2.Bind();

        }
        // 初始化控件的数据源
        private void InitializeDataSource()
        {

            // 初始化查询条件
            var nationList = DCTS.DB.GlobalCache.NationList;
            var nations = nationList.Select(o => new MockEntity { Id = o.id, ShortName = o.code, FullName = o.title }).ToList();
            nations.Insert(0, new MockEntity { Id = 0, ShortName = "", FullName = "所有" });
            this.nationComboBox.DisplayMember = "FullName";
            this.nationComboBox.ValueMember = "ShortName";
            this.nationComboBox.DataSource = nations;

        }


        private void newButton_Click(object sender, EventArgs e)
        {
            var form = new NewDiningsForm("create", null);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                InitializeDataGridView();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(" 确定删除本条餐厅 ?", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
            }
            else
            {
                return;
            }
            var oids = GetOrderIdsBySelectedGridCell();
            using (var ctx = new DctsEntities())
            {
                var filtered = DaysList.FindAll(s => s.location_id == oids[0]);
                if (filtered.Count == 0)
                {
                    var stockrecs = (from s in ctx.ComboLocations
                                     where oids.Contains(s.id)
                                     select s).ToList();
                    ctx.ComboLocations.RemoveRange(stockrecs);
                    ctx.SaveChanges();
                }
                else
                {
                    MessageBox.Show("删除失败，此餐厅在day 表中存在，请重新确认", "删除", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


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

            pager2.PageCurrent = 1;
            //FindDataSources();
            pager2.Bind();

        }

        private int InitializeDataGridView(int pageCurrent = 1)
        {
            string nation = (this.nationComboBox.Text != NoOptionSelected ? this.nationComboBox.Text : string.Empty);
            string city = (this.cityComboBox.Text != NoOptionSelected ? this.cityComboBox.Text : string.Empty);
            string title = (this.keywordTextBox.Text != NoOptionSelected ? this.keywordTextBox.Text : string.Empty);

            int count = 0;
            int pageSize = pager2.PageSize;

            using (var ctx = new DctsEntities())
            {
                //分页需要数据总数
                count = ComboLoactionBusiness.Count(ComboLocationEnum.Dining, nation, city, title);

                var list = ComboLoactionBusiness.Paginate(ComboLocationEnum.Dining, pageCurrent, pageSize, nation, city, title);

                this.dataGridView.DataSource = list;
            }
            return count;
        }

        private int FindDataSources1()
        {

            sqlfilter = "";

            var nation = nationComboBox.Text;
            var city = this.cityComboBox.Text;
            var title = this.keywordTextBox.Text;

            string conditions = "";//s.ltype =(int)ComboLocationEnum.Dining
            List<MySqlParameter> condition_params = new List<MySqlParameter>();

            var ltype = (int)ComboLocationEnum.Dining;


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

                conditions += "(`title`LIKE '%" + @title + "%')";


            }
            #region  new
            condition_params.Add(new MySqlParameter("@ltype", ltype));
            condition_params.Add(new MySqlParameter("@nation", nation));
            condition_params.Add(new MySqlParameter("@city", city));
            condition_params.Add(new MySqlParameter("@title", title));

            int limit = pager2.PageSize;
            int offset = (pager2.PageCurrent > 1 ? pager2.OffSet(pager2.PageCurrent - 1) : 0);
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
                DinningList = ctx.Database.SqlQuery<ComboLocation>(sql, condition_params.ToArray()).ToList();

                sqlfilter = string.Format(" SELECT * FROM combolocations " + conditions.Replace("@ltype", ltype.ToString()).Replace("@nation", "'" + nation.ToString() + "'").Replace("@city", "'" + city.ToString() + "'").Replace("@title", "'" + title.ToString() + "'"));

                sortabledinningsOrderList = new SortableBindingList<ComboLocation>(DinningList.ToList());
                this.bindingSource1.DataSource = this.sortabledinningsOrderList;
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = this.bindingSource1;

            }
            return count;


            #endregion
        }


        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = this.dataGridView.CurrentRow.Index;
            ComboLocation selectedItem = DinningList[i];

            var form = new NewDiningsForm("Edit", selectedItem);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                InitializeDataGridView();
            }
        }


        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView.Rows[e.RowIndex];
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString();
            var new_cell_value = row.Cells[e.ColumnIndex].Value;
            var original_cell_value = dataGridChanges[cell_key];

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
            string cell_key = e.RowIndex.ToString() + "_" + e.ColumnIndex.ToString() + "_changed";

            if (dataGridChanges.ContainsKey(cell_key))
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
            }

            //添加图片
            //int i = this.dataGridView.CurrentRow.Index;
            //if (i < DinningList.Count)

            if (dataGridView.Columns[e.ColumnIndex] == this.imgColumn1)
            {
                if (DinningList != null && e.RowIndex < DinningList.Count)
                {
                    //ComboLocation selectedItem = DinningList[i];
                    ComboLocation selectedItem = dataGridView.Rows[e.RowIndex].DataBoundItem as ComboLocation;
                    long folername = selectedItem.id / 1000;
                    if (selectedItem.img != null && selectedItem.img != "" && selectedItem.img != "\"\"")
                    {
                        string lcoalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\data\\images\\location_" + ComboLocationEnum.Dining.ToString().ToLower() + "\\" + folername + "\\", selectedItem.img);
                        //string lcoalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\data\\images\\locations\\" + folername + "\\", selectedItem.img);
                        e.Value = GetImage1(lcoalPath);
                    }
                }
            }
        }

        public System.Drawing.Image GetImage1(string path)
        {

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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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

        private int pager2_EventPaging_1(EventPagingArg e)
        {
            int count = InitializeDataGridView(e.PageCurrent);
            return count;
        }

        private void btdown_Click(object sender, EventArgs e)
        {



            string strFileName = String.Empty;

            saveFileDialog1.FileName = "餐厅" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                strFileName = saveFileDialog1.FileName.ToString();
            }
            if (strFileName.Length > 0)
            {
                using (var ctx = new DctsEntities())
                {

                    // string sql = "SELECT * FROM combolocations";
                    string sql = BuildSql();

                    DataTable dataTable = ctx.DataTable(sql);
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        if (ComboLocationSchema.LocationCnNameDictionary.ContainsKey(col.ColumnName))
                        {
                            col.ColumnName = ComboLocationSchema.LocationCnNameDictionary[col.ColumnName];
                        }
                    }

                    var stream = ExcelUtility.RenderDataTableToExcel(dataTable);

                    ExcelUtility.WriteSteamToFile(stream, strFileName);
                }

            }

        }

        private string BuildSql()
        {
            var ltype = (int)ComboLocationEnum.Dining;

            string sql = string.Empty;
            var nation = this.nationComboBox.Text;
            var city = this.cityComboBox.Text;
            var title = this.keywordTextBox.Text;
            string conditions = string.Format("(`ltype`= {0})", ltype);


            if (nation.Length > 0 && nation != NoOptionSelected)
            {
                conditions = conditions + " AND " + string.Format("`nation`='{0}'", nation);
            }
            if (city.Length > 0 && city != NoOptionSelected)
            {
                conditions = conditions + " AND " + string.Format("`city`='{0}'", city);
            }
            if (title.Length > 0)
            {
                conditions = conditions + " AND " + string.Format("(`title` like '%{0}%')", title);
            }

            if (conditions.Length > 0)
            {
                conditions = " WHERE " + conditions;
            }
            sql = string.Format(" SELECT * FROM combolocations " + conditions);
            return sql;
        }

        private void DiningsControl_Resize(object sender, EventArgs e)
        {
            //                                                   id
            titleColumn1.Width = dataGridView.ClientSize.Width - 60 - 100 * 3 - 280 - 200 - 100 - 60 * 2 - 3;
            //是否包含滚动条
            if (!(this.dataGridView.DisplayedRowCount(false) == this.dataGridView.RowCount))
            {
                titleColumn1.Width -= 18;
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = dataGridView.Columns[e.ColumnIndex];

            if (column == editColumn1)
            {
                var row = dataGridView.Rows[e.RowIndex];

                var model = row.DataBoundItem as ComboLocation;

                var form = new NewDiningsForm("Edit", model);
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    BeginActive();
                }
            }
            else if (column == deleteColumn1)
            {
                var row = dataGridView.Rows[e.RowIndex];
                var model = row.DataBoundItem as ComboLocation;
                string msg = string.Format("确定删除餐厅<{0}>？", model.title);

                if (MessageHelper.DeleteConfirm(msg))
                {
                    ComboLoactionBusiness.Delete(model.id);
                    BeginActive();
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            // BT1();
            {

                //读取 word
                string file = @"C:\mysteap\work_office\ProjectOut\RuanShanLvYou\data\06正文.docx";

                ReadWordText(file);


                newster();
                return;


                MessageBox.Show("ok");

            }


        }

        private void newster()
        {
            //图片位置
            String m_PicPath = "..\\..\\..\\pic\\";
            m_PicPath = "C:\\pic\\";

            FileStream gfs = null;
            MemoryStream ms = new MemoryStream();
            XWPFDocument m_Docx = new XWPFDocument();
            //页面设置
            //A4:W=11906,h=16838
            //CT_SectPr m_SectPr = m_Docx.Document.body.AddNewSectPr();
            m_Docx.Document.body.sectPr = new CT_SectPr();
            CT_SectPr m_SectPr = m_Docx.Document.body.sectPr;
            //页面设置A4纵向
            m_SectPr.pgSz.h = (ulong)16838;
            m_SectPr.pgSz.w = (ulong)11906;
            XWPFParagraph gp = m_Docx.CreateParagraph();
            // gp.GetCTPPr().AddNewJc().val = ST_Jc.center; //水平居中
            XWPFRun gr = gp.CreateRun();
            gr.GetCTR().AddNewRPr().AddNewRFonts().ascii = "黑体";
            gr.GetCTR().AddNewRPr().AddNewRFonts().eastAsia = "黑体";
            gr.GetCTR().AddNewRPr().AddNewRFonts().hint = ST_Hint.eastAsia;
            gr.GetCTR().AddNewRPr().AddNewSz().val = (ulong)44;//2号字体
            gr.GetCTR().AddNewRPr().AddNewSzCs().val = (ulong)44;
            gr.GetCTR().AddNewRPr().AddNewB().val = true; //加粗
            gr.GetCTR().AddNewRPr().AddNewColor().val = "red";//字体颜色
            gr.SetText("NPOI创建Word2007Docx");
            gp = m_Docx.CreateParagraph();
            ////创建表
            XWPFTable table = m_Docx.CreateTable(1, 4);//创建一行4列表
            CT_Row m_NewRow = new CT_Row();//创建1行
            XWPFTableRow m_Row = new XWPFTableRow(m_NewRow, table);
            table.AddRow(m_Row); //必须要！！！
            XWPFTableCell cell = m_Row.CreateCell();//创建单元格，也创建了一个CT_P

            //表插入图片
            m_NewRow = new CT_Row();
            m_Row = new XWPFTableRow(m_NewRow, table);
            table.AddRow(m_Row);
            gp = cell.GetParagraph(cell.GetCTTc().GetPList()[0]);
            gr = gp.CreateRun();//创建run
            gfs = new FileStream(m_PicPath + "1.jpg", FileMode.Open, FileAccess.Read);//读取图片文件
            gr.AddPicture(gfs, (int)PictureType.PNG, "1.jpg", 500000, 500000);//插入图片
            gfs.Close();
            cell = m_Row.CreateCell();//第2单元格

            m_Docx.Write(ms);
            ms.Flush();
            SaveToFile(ms, Path.GetPathRoot(Directory.GetCurrentDirectory()) + "\\NPOI.docx");



        }

        #region  好用 保存word
        static void SaveToFile(MemoryStream ms, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                byte[] data = ms.ToArray();

                fs.Write(data, 0, data.Length);
                fs.Flush();
                data = null;
            }
        }
        #endregion

        #region 读取 word

        /// <summary>
        /// 读取Word内容
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ReadWordText(string fileName)
        {
            string WordTableCellSeparator = ConfigurationManager.AppSettings["WordTableCellSeparator"];
            string WordTableRowSeparator = ConfigurationManager.AppSettings["WordTableRowSeparator"];
            string WordTableSeparator = ConfigurationManager.AppSettings["WordTableSeparator"];
            //
            string CaptureWordHeader = ConfigurationManager.AppSettings["CaptureWordHeader"];
            string CaptureWordFooter = ConfigurationManager.AppSettings["CaptureWordFooter"];
            string CaptureWordTable = ConfigurationManager.AppSettings["CaptureWordTable"];
            string CaptureWordImage = ConfigurationManager.AppSettings["CaptureWordImage"];
            //
            string CaptureWordImageFileName = ConfigurationManager.AppSettings["CaptureWordImageFileName"];
            //
            string fileText = string.Empty;
            StringBuilder sbFileText = new StringBuilder();

            #region 打开文档
            XWPFDocument document = null;
            try
            {
                using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    document = new XWPFDocument(file);
                }
            }
            catch (Exception e)
            {
               // LogHandler.LogWrite(string.Format("文件{0}打开失败，错误：{1}", new string[] { fileName, e.ToString() }));
            }
            #endregion

            #region 页眉、页脚
            //页眉
            if (CaptureWordHeader == "true")
            {
                sbFileText.AppendLine("Capture Header Begin");
                foreach (XWPFHeader xwpfHeader in document.HeaderList)
                {
                    sbFileText.AppendLine(string.Format("{0}", new string[] { xwpfHeader.Text }));
                }
                sbFileText.AppendLine("Capture Header End");
            }
            //页脚
            if (CaptureWordFooter == "true")
            {
                sbFileText.AppendLine("Capture Footer Begin");
                foreach (XWPFFooter xwpfFooter in document.FooterList)
                {
                    sbFileText.AppendLine(string.Format("{0}", new string[] { xwpfFooter.Text }));
                }
                sbFileText.AppendLine("Capture Footer End");
            }
            #endregion

            #region 表格
            if (CaptureWordTable == "true")
            {
                sbFileText.AppendLine("Capture Table Begin");
                foreach (XWPFTable table in document.Tables)
                {
                    //循环表格行
                    foreach (XWPFTableRow row in table.Rows)
                    {
                        foreach (XWPFTableCell cell in row.GetTableCells())
                        {
                            sbFileText.Append(cell.GetText());
                            //
                            sbFileText.Append(WordTableCellSeparator);
                        }

                        sbFileText.Append(WordTableRowSeparator);
                    }
                    sbFileText.Append(WordTableSeparator);
                }
                sbFileText.AppendLine("Capture Table End");
            }
            #endregion

            #region 图片
             
            if (CaptureWordImage == "true")
            {
                sbFileText.AppendLine("Capture Image Begin");
                foreach (XWPFPictureData pictureData in document.AllPictures)
                {
                  
                    string picExtName = pictureData.SuggestFileExtension();
                    string picFileName = pictureData.FileName;
                    byte[] picFileContent = pictureData.Data;
                    //
                  //  CaptureWordImageFileName = @"C:\mysteap\work_office\ProjectOut\RuanShanLvYou\data\1.doc";

                   string picTempName = string.Format(CaptureWordImageFileName, new string[] { Guid.NewGuid().ToString() + "_" + picFileName + "." + picExtName });
                    //
                    using (FileStream fs = new FileStream(picTempName, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(picFileContent, 0, picFileContent.Length);
                        fs.Close();
                    }
                    //
                    sbFileText.AppendLine(picTempName);
                }
                sbFileText.AppendLine("Capture Image End");
            }
            #endregion

            //正文段落
            sbFileText.AppendLine("Capture Paragraph Begin");
            foreach (XWPFParagraph paragraph in document.Paragraphs)
            {
                sbFileText.AppendLine(paragraph.ParagraphText);

            }
            sbFileText.AppendLine("Capture Paragraph End");
            //

            //
            fileText = sbFileText.ToString();
            return fileText;
        }



        #endregion


    }
}
