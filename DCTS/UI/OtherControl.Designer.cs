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
<<<<<<< HEAD
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.idColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nationColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uploadColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.downloadColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
=======
            this.idColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DownColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pager1 = new DCTS.CustomComponents.Pager();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
>>>>>>> ef1825ec87ccb334290495faeeedf1893beb27b9
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
<<<<<<< HEAD
            this.uploadColumn1,
            this.downloadColumn1});
=======
            this.AddColumn1,
            this.DownColumn1});
>>>>>>> ef1825ec87ccb334290495faeeedf1893beb27b9
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.Location = new System.Drawing.Point(8, 149);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 50;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(672, 213);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 48);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.修改ToolStripMenuItem.Text = "编辑";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click_1);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.deleteToolStripMenuItem.Text = "删除此条住宿";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
<<<<<<< HEAD
            this.groupBox1.Controls.Add(this.keywordTextBox);
            this.groupBox1.Controls.Add(this.btfind);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 51);
=======
            this.groupBox1.Location = new System.Drawing.Point(8, 55);
>>>>>>> ef1825ec87ccb334290495faeeedf1893beb27b9
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 84);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
<<<<<<< HEAD
            // keywordTextBox
            // 
            this.keywordTextBox.Location = new System.Drawing.Point(52, 33);
            this.keywordTextBox.Name = "keywordTextBox";
            this.keywordTextBox.Size = new System.Drawing.Size(427, 21);
            this.keywordTextBox.TabIndex = 10;
            // 
            // btfind
            // 
            this.btfind.Location = new System.Drawing.Point(485, 33);
            this.btfind.Name = "btfind";
            this.btfind.Size = new System.Drawing.Size(75, 23);
            this.btfind.TabIndex = 9;
            this.btfind.Text = "查找";
            this.btfind.UseVisualStyleBackColor = true;
            this.btfind.Click += new System.EventHandler(this.btfind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "名称";
            // 
=======
>>>>>>> ef1825ec87ccb334290495faeeedf1893beb27b9
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 50);
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
<<<<<<< HEAD
=======
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
>>>>>>> ef1825ec87ccb334290495faeeedf1893beb27b9
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DCTS.DctsEntities);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.entityDataSource1;
            this.bindingSource1.Position = 0;
            // 
<<<<<<< HEAD
            // idColumn1
            // 
            this.idColumn1.DataPropertyName = "id";
            this.idColumn1.HeaderText = "序号";
            this.idColumn1.Name = "idColumn1";
            this.idColumn1.Width = 60;
            // 
            // nationColumn1
            // 
            this.nationColumn1.DataPropertyName = "title";
            this.nationColumn1.HeaderText = "名称";
            this.nationColumn1.Name = "nationColumn1";
            this.nationColumn1.Width = 200;
            // 
            // word
            // 
            this.word.DataPropertyName = "word";
            this.word.HeaderText = "模板文档";
            this.word.Name = "word";
            this.word.Width = 180;
            // 
            // uploadColumn1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2, 12, 1, 12);
            this.uploadColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.uploadColumn1.HeaderText = "";
            this.uploadColumn1.Name = "uploadColumn1";
            this.uploadColumn1.Text = "上传";
            this.uploadColumn1.UseColumnTextForButtonValue = true;
            this.uploadColumn1.Width = 60;
            // 
            // downloadColumn1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2, 12, 2, 12);
            this.downloadColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.downloadColumn1.HeaderText = "";
            this.downloadColumn1.Name = "downloadColumn1";
            this.downloadColumn1.Text = "下载";
            this.downloadColumn1.UseColumnTextForButtonValue = true;
            this.downloadColumn1.Width = 60;
            // 
=======
>>>>>>> ef1825ec87ccb334290495faeeedf1893beb27b9
            // OtherControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView);
            this.Name = "OtherControl";
            this.Size = new System.Drawing.Size(688, 374);
            this.Resize += new System.EventHandler(this.NationsControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private CustomComponents.EntityDataSource entityDataSource1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn word;
<<<<<<< HEAD
        private System.Windows.Forms.DataGridViewButtonColumn uploadColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn downloadColumn1;
=======
        private System.Windows.Forms.DataGridViewButtonColumn AddColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn DownColumn1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
>>>>>>> ef1825ec87ccb334290495faeeedf1893beb27b9
    }
}
