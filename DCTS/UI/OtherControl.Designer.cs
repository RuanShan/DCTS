﻿namespace DCTS.UI
{
    partial class OtherControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.idColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DownColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pager1 = new DCTS.CustomComponents.Pager();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn1,
            this.titleColumn1,
            this.word,
            this.AddColumn1,
            this.DownColumn1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.Location = new System.Drawing.Point(8, 161);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 50;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(672, 204);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改ToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 48);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.修改ToolStripMenuItem.Text = "编辑";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click_1);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.deleteToolStripMenuItem.Text = "删除此条住宿";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(8, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 91);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 54);
            this.label2.TabIndex = 14;
            this.label2.Text = "其他列表";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xslx";
            this.saveFileDialog1.Filter = "EXCEL文件(*.xls,*.xlsx)|*.xls;*.xlsx";
            this.saveFileDialog1.Title = "导出景点数据";
            // 
            // idColumn1
            // 
            this.idColumn1.DataPropertyName = "id";
            this.idColumn1.HeaderText = "序号";
            this.idColumn1.Name = "idColumn1";
            this.idColumn1.Width = 60;
            // 
            // titleColumn1
            // 
            this.titleColumn1.DataPropertyName = "title";
            this.titleColumn1.HeaderText = "名称";
            this.titleColumn1.Name = "titleColumn1";
            // 
            // word
            // 
            this.word.DataPropertyName = "word";
            this.word.HeaderText = "word";
            this.word.Name = "word";
            // 
            // AddColumn1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2, 12, 1, 12);
            this.AddColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.AddColumn1.HeaderText = "";
            this.AddColumn1.Name = "AddColumn1";
            this.AddColumn1.Text = "上传";
            this.AddColumn1.UseColumnTextForButtonValue = true;
            this.AddColumn1.Width = 60;
            // 
            // DownColumn1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2, 12, 2, 12);
            this.DownColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.DownColumn1.HeaderText = "";
            this.DownColumn1.Name = "DownColumn1";
            this.DownColumn1.Text = "下载";
            this.DownColumn1.UseColumnTextForButtonValue = true;
            this.DownColumn1.Width = 60;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Doc(*.doc,*.docx)|*.doc;*.docx";
            this.openFileDialog1.Title = "请选择文件";
            // 
            // pager1
            // 
            this.pager1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pager1.AutoSize = true;
            this.pager1.Location = new System.Drawing.Point(8, 371);
            this.pager1.Name = "pager1";
            this.pager1.NMax = 0;
            this.pager1.PageCount = 0;
            this.pager1.PageCurrent = 1;
            this.pager1.PageSize = 10;
            this.pager1.Size = new System.Drawing.Size(672, 34);
            this.pager1.TabIndex = 13;
            this.pager1.EventPaging += new DCTS.CustomComponents.EventPagingHandler(this.pager1_EventPaging);
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DCTS.DctsEntities);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.entityDataSource1;
            this.bindingSource1.Position = 0;
            // 
            // OtherControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pager1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView);
            this.Name = "OtherControl";
            this.Size = new System.Drawing.Size(688, 405);
            this.Resize += new System.EventHandler(this.NationsControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private CustomComponents.EntityDataSource entityDataSource1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource1;
        private CustomComponents.Pager pager1;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn word;
        private System.Windows.Forms.DataGridViewButtonColumn AddColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn DownColumn1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
