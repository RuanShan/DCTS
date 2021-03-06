﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCTS.UI
{
    using DCTS.Bus;
    using DCTS.Uti;
    using DCTS.DB;
    using System.IO;

    public partial class CustomerTripListControl : UserControl, CustomControlInterface
    {
        public event EventHandler CommandRequestEvent;
        // 后台执行控件
        private BackgroundWorker bgWorker;
        // 消息显示窗体
        private frmMessageShow frmMessageShow;

        // 后台操作是否正常完成
        private bool blnBackGroundWorkIsOK = false;
        //后加的后台属性显
        private bool backGroundRunResult;

        public CustomerTripListControl()
        {
            InitializeComponent();
            this.tripDataGridView.AutoGenerateColumns = false;

        }

        public void BeginActive()
        {
            InitializeTripDataGridView();
            // ID 80, 天数 80， 备注260 路书生成时间120，  4个按钮
            //tripTitleColumn1.Width = tripDataGridView.ClientSize.Width - 80 * 2 - 260 - 120 - 60 * 4;
        }

        private void InitializeTripDataGridView()
        {
            int offset = 0;
            int pageSize = 5000;
            //var ctx = this.entityDataSource1.DbContext as DctsEntities;
            using (var ctx = new DctsEntities())
            {

                var query = ctx.Trips.Where(o => o.customer_id > 0).OrderBy(o => o.id).Skip(offset).Take(pageSize);
                var list = this.entityDataSource1.CreateView(query);
                tripDataGridView.DataSource = list;
            }

        }


        private void addTripButton_Click(object sender, EventArgs e)
        {
            var form = new NewCustomerTripForm();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                InitializeTripDataGridView();
            }
        }

        private void tripDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = tripDataGridView.Columns[e.ColumnIndex];

            if (column == editTripDaysColumn1)
            {
                var row = tripDataGridView.Rows[e.RowIndex];
                var trip = row.DataBoundItem as Trip;

                var eventArgs = new CommandRequestEventArgs(CommandRequestEnum.EditCustomerTripDays, trip.id);
                this.CommandRequestEvent(this, eventArgs);
            }
            if (column == editTripColumn1)
            {
                var row = tripDataGridView.Rows[e.RowIndex];
                var trip = row.DataBoundItem as Trip;

                int tid = SelectedTripId;
                var form = new EditCustomerTripForm(tid);
                form.ShowDialog();
                if (form.Saved)
                {
                    BeginActive();
                }
            }
            else if (column == copyTripColumn1)
            {
                var row = tripDataGridView.Rows[e.RowIndex];
                var trip = row.DataBoundItem as Trip;
                TripBusiness.Duplicate(trip.id);
                BeginActive();

            }
            else if (column == deleteTripColumn1)
            {
                var row = tripDataGridView.Rows[e.RowIndex];
                var trip = row.DataBoundItem as Trip;
                string msg = string.Format("确定删除<{0}>", trip.title);

                if (MessageHelper.DeleteConfirm(msg))
                {
                    ////删除 schedule 中的信息

                    TripBusiness.Delete(trip.id);

                    BeginActive();
                }
            }

        }
        #region worker
        private void InitialBackGroundWorker()
        {
            bgWorker = new BackgroundWorker();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.ProgressChanged +=
                new ProgressChangedEventHandler(bgWorker_ProgressChanged);
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                blnBackGroundWorkIsOK = false;
            }
            else if (e.Cancelled)
            {
                blnBackGroundWorkIsOK = true;
            }
            else
            {
                blnBackGroundWorkIsOK = true;
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (frmMessageShow != null && frmMessageShow.Visible == true)
            {
                //设置显示的消息
                frmMessageShow.setMessage(e.UserState.ToString());
                //设置显示的按钮文字
                if (e.ProgressPercentage == clsConstant.Thread_Progress_OK)
                {
                    frmMessageShow.setStatus(clsConstant.Dialog_Status_Enable);
                }
            }
        }


        #endregion
        private void exportWordButton_Click(object sender, EventArgs e)
        {

            try
            {
                InitialBackGroundWorker();
                bgWorker.DoWork += new DoWorkEventHandler(exword);

                bgWorker.RunWorkerAsync();
                // 启动消息显示画面
                frmMessageShow = new frmMessageShow(clsShowMessage.MSG_001,
                                                    clsShowMessage.MSG_007,
                                                    clsConstant.Dialog_Status_Disable);
                frmMessageShow.ShowDialog();
                // 数据读取成功后在画面显示
                if (blnBackGroundWorkIsOK)
                {
                    BeginActive();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

 
        }
        private void exword(object sender, DoWorkEventArgs e)
        {

            var exporter = new CustomerTripWordExporterEx(SelectedTripId);
            if (exporter.ExportWord(ref this.bgWorker))
            {
                //MessageBox.Show("导出Word成功！");
                bgWorker.ReportProgress(clsConstant.Thread_Progress_OK, clsShowMessage.MSG_009  );
              
            }
        }


        private int SelectedTripId
        {
            get
            {
                int id = 0;
                var row = tripDataGridView.CurrentRow;
                if (row != null)
                {
                    var trip = row.DataBoundItem as Trip;
                    if (trip != null)
                    {
                        id = trip.id;
                    }
                }

                return id;
            }
        }

        private Trip SelectedTrip
        {
            get
            {
                var row = tripDataGridView.CurrentRow;
                var trip = row.DataBoundItem as Trip;
                return trip;
            }
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            var trip = SelectedTrip;
            if (trip != null)
            {
                if (trip.word_created_at != null)
                {
                    this.saveFileDialog1.FileName = trip.title.Normalize();

                    if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string tripWordFilePath = EntityPathHelper.TripWordFilePath(trip.id);
                        string localFilePath = saveFileDialog1.FileName; //获得文件路径 

                        //给文件名前加上时间 
                        //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt;

                        //在文件名里加字符 
                        //saveFileDialog1.FileName.Insert(1,"dameng");

                        //System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();//输出文件

                        File.Copy(tripWordFilePath, localFilePath, true);

                    }
                }
                else
                {
                    MessageBox.Show("请先生成路书文档，然后再下载！");
                }
            }
        }

        private void TripListControl_Load(object sender, EventArgs e)
        {

        }

        private void TripListControl_Resize(object sender, EventArgs e)
        {  //                                                                  出发日期               复制按钮删除
            tripTitleColumn1.Width = tripDataGridView.ClientSize.Width - 80 * 2 - 120 - 260 - 120 - 60 * 4 - 3;

        }

        private void fullEditButton_Click(object sender, EventArgs e)
        {
            int tid = SelectedTripId;
            var form = new EditCustomerTripForm(tid);
            form.ShowDialog();

        }

    }
}
