using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.IO;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.POIFS;
using NPOI.Util;
using NPOI.HSSF.Util;
using NPOI.HSSF.Extractor;

namespace DCTS.Uti
{
    public static class ExcelUtility
    {
        public static HSSFWorkbook workbook;
        //https://dotblogs.com.tw/killysss/archive/2010/01/27/13344.aspx

        public static void InitializeWorkbook()
        {
            ////create a entry of DocumentSummaryInformation
            if (workbook == null)
                workbook = new HSSFWorkbook();
            //HSSFFont font1 = workbook.CreateFont();
            //HSSFCellStyle Style = workbook.CreateCellStyle();
            //font1.FontHeightInPoints = 10;
            //font1.FontName = "新細明體";
            //Style.SetFont(font1);
            //for (int i = 0; i < workbook.NumberOfSheets; i++)
            //{
            //    HSSFSheet Sheets = workbook.GetSheetAt(0);
            //    for (int k = Sheets.FirstRowNum; k <= Sheets.LastRowNum; k++)
            //    {
            //        HSSFRow row = Sheets.GetRow(k);
            //        for (int l = row.FirstCellNum; l < row.LastCellNum; l++)
            //        {
            //            HSSFCell Cell = row.GetCell(l);
            //            Cell.CellStyle = Style;
            //        }
            //    }
            //}
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "測試公司";
            workbook.DocumentSummaryInformation = dsi;
            ////create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "測試公司Excel檔案";
            si.Title = "測試公司Excel檔案";
            si.Author = "killysss";
            si.Comments = "謝謝您的使用！";
            workbook.SummaryInformation = si;

        }

        #region 資料形態轉換

        public static void WriteSteamToFile(MemoryStream ms, string FileName)
        {
            FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            byte[] data = ms.ToArray();

            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();

            data = null;
            ms = null;
            fs = null;
        }
        public static void WriteSteamToFile(byte[] data, string FileName)
        {
            FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
            data = null;
            fs = null;
        }
        public static Stream WorkBookToStream(HSSFWorkbook InputWorkBook)
        {
            MemoryStream ms = new MemoryStream();
            InputWorkBook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            return ms;
        }
        public static HSSFWorkbook StreamToWorkBook(Stream InputStream)
        {
            HSSFWorkbook WorkBook = new HSSFWorkbook(InputStream);
            return WorkBook;
        }
        public static HSSFWorkbook MemoryStreamToWorkBook(MemoryStream InputStream)
        {
            HSSFWorkbook WorkBook = new HSSFWorkbook(InputStream as Stream);
            return WorkBook;
        }
        public static MemoryStream WorkBookToMemoryStream(HSSFWorkbook InputStream)
        {
            //Write the stream data of workbook to the root directory
            MemoryStream file = new MemoryStream();
            InputStream.Write(file);
            return file;
        }
        public static Stream FileToStream(string FileName)
        {
            FileInfo fi = new FileInfo(FileName);
            if (fi.Exists == true)
            {
                FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                return fs;
            }
            else return null;
        }
        public static Stream MemoryStreamToStream(MemoryStream ms)
        {
            return ms as Stream;
        }
        #endregion

        #region DataTable與Excel資料格式轉換
        /// <summary>
        /// 將DataTable轉成Stream輸出.
        /// </summary>
        /// <param name="SourceTable">The source table.</param>
        /// <returns></returns>
        public static MemoryStream RenderDataTableToExcel(DataTable SourceTable)
        {
            workbook = new HSSFWorkbook();
            InitializeWorkbook();
            MemoryStream ms = new MemoryStream();
            var  sheet = workbook.CreateSheet();
            var headerRow = sheet.CreateRow(0);

            // handling header.
            foreach (DataColumn column in SourceTable.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

            // handling value.
            int rowIndex = 1;

            foreach (DataRow row in SourceTable.Rows)
            {
                var dataRow = sheet.CreateRow(rowIndex);

                foreach (DataColumn column in SourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }

                rowIndex++;
            }

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            sheet = null;
            headerRow = null;
            workbook = null;

            return ms;
        }
        /// <summary>
        /// 將DataTable轉成Workbook(自定資料型態)輸出.
        /// </summary>
        /// <param name="SourceTable">The source table.</param>
        /// <returns></returns>
        public static HSSFWorkbook RenderDataTableToWorkBook(DataTable SourceTable)
        {
            workbook = new HSSFWorkbook();
            InitializeWorkbook();
            MemoryStream ms = new MemoryStream();
            var sheet = workbook.CreateSheet();
            var headerRow = sheet.CreateRow(0);

            // handling header.
            foreach (DataColumn column in SourceTable.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

            // handling value.
            int rowIndex = 1;

            foreach (DataRow row in SourceTable.Rows)
            {
                var dataRow = sheet.CreateRow(rowIndex);

                foreach (DataColumn column in SourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }

                rowIndex++;
            }
            return workbook;
        }

        /// <summary>
        /// 將DataTable資料輸出成檔案.
        /// </summary>
        /// <param name="SourceTable">The source table.</param>
        /// <param name="FileName">Name of the file.</param>
        public static void RenderDataTableToExcel(DataTable SourceTable, string FileName)
        {
            MemoryStream ms = RenderDataTableToExcel(SourceTable) as MemoryStream;
            WriteSteamToFile(ms, FileName);
        }

        /// <summary>
        /// 從位元流讀取資料到DataTable.
        /// </summary>
        /// <param name="ExcelFileStream">The excel file stream.</param>
        /// <param name="SheetName">Name of the sheet.</param>
        /// <param name="HeaderRowIndex">Index of the header row.</param>
        /// <param name="HaveHeader">if set to <c>true</c> [have header].</param>
        /// <returns></returns>
        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, string SheetName, int HeaderRowIndex, bool HaveHeader)
        {
            workbook = new HSSFWorkbook(ExcelFileStream);
            InitializeWorkbook();
            var sheet = workbook.GetSheet(SheetName);

            DataTable table = new DataTable();

            var headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                string ColumnName = (HaveHeader == true) ? headerRow.GetCell(i).StringCellValue : "f" + i.ToString();
                DataColumn column = new DataColumn(ColumnName);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;
            int RowStart = (HaveHeader == true) ? sheet.FirstRowNum + 1 : sheet.FirstRowNum;
            for (int i = RowStart; i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                    dataRow[j] = row.GetCell(j).ToString();
            }

            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }

        /// <summary>
        /// 從位元流讀取資料到DataTable.
        /// </summary>
        /// <param name="ExcelFileStream">The excel file stream.</param>
        /// <param name="SheetIndex">Index of the sheet.</param>
        /// <param name="HeaderRowIndex">Index of the header row.</param>
        /// <param name="HaveHeader">if set to <c>true</c> [have header].</param>
        /// <returns></returns>
        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, int SheetIndex, int HeaderRowIndex, bool HaveHeader)
        {
            workbook = new HSSFWorkbook(ExcelFileStream);
            InitializeWorkbook();
            var sheet = workbook.GetSheetAt(SheetIndex);

            DataTable table = new DataTable();

            var headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                string ColumnName = (HaveHeader == true) ? headerRow.GetCell(i).StringCellValue : "f" + i.ToString();
                DataColumn column = new DataColumn(ColumnName);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;
            int RowStart = (HaveHeader == true) ? sheet.FirstRowNum + 1 : sheet.FirstRowNum;
            for (int i = RowStart; i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                table.Rows.Add(dataRow);
            }

            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }
        #endregion
    }
}
