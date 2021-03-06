﻿namespace DCTS.UI
{
    partial class DiningsControl
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
            this.idColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nationColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imgColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.titleColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dishesColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recommendedDishesColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.deleteColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.keywordTextBox = new System.Windows.Forms.TextBox();
            this.btfind = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nationComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btdown = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pager2 = new DCTS.CustomComponents.Pager();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn1,
            this.nationColumn1,
            this.cityColumn1,
            this.areaColumn1,
            this.imgColumn1,
            this.titleColumn1,
            this.dishesColumn1,
            this.addressColumn1,
            this.Column6,
            this.recommendedDishesColumn1,
            this.editColumn1,
            this.deleteColumn1});
            this.dataGridView.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.Location = new System.Drawing.Point(8, 140);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 50;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(693, 246);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            // 
            // idColumn1
            // 
            this.idColumn1.DataPropertyName = "id";
            this.idColumn1.HeaderText = "序号";
            this.idColumn1.Name = "idColumn1";
            this.idColumn1.Width = 60;
            // 
            // nationColumn1
            // 
            this.nationColumn1.DataPropertyName = "nation";
            this.nationColumn1.HeaderText = "国家";
            this.nationColumn1.Name = "nationColumn1";
            this.nationColumn1.Width = 60;
            // 
            // cityColumn1
            // 
            this.cityColumn1.DataPropertyName = "city";
            this.cityColumn1.HeaderText = "城市";
            this.cityColumn1.Name = "cityColumn1";
            this.cityColumn1.Width = 60;
            // 
            // areaColumn1
            // 
            this.areaColumn1.DataPropertyName = "area";
            this.areaColumn1.HeaderText = "区域";
            this.areaColumn1.Name = "areaColumn1";
            this.areaColumn1.Width = 60;
            // 
            // imgColumn1
            // 
            this.imgColumn1.HeaderText = "图片";
            this.imgColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.imgColumn1.Name = "imgColumn1";
            this.imgColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.imgColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // titleColumn1
            // 
            this.titleColumn1.DataPropertyName = "title";
            this.titleColumn1.HeaderText = "餐厅名称";
            this.titleColumn1.Name = "titleColumn1";
            this.titleColumn1.Width = 280;
            // 
            // dishesColumn1
            // 
            this.dishesColumn1.DataPropertyName = "dishes";
            this.dishesColumn1.HeaderText = "菜系";
            this.dishesColumn1.Name = "dishesColumn1";
            // 
            // addressColumn1
            // 
            this.addressColumn1.DataPropertyName = "address";
            this.addressColumn1.HeaderText = "地址";
            this.addressColumn1.Name = "addressColumn1";
            this.addressColumn1.Width = 200;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "open_close_more";
            this.Column6.HeaderText = "营业时间说明";
            this.Column6.Name = "Column6";
            this.Column6.Width = 200;
            // 
            // recommendedDishesColumn1
            // 
            this.recommendedDishesColumn1.DataPropertyName = "recommended_dishes";
            this.recommendedDishesColumn1.HeaderText = "推荐菜单";
            this.recommendedDishesColumn1.Name = "recommendedDishesColumn1";
            // 
            // editColumn1
            // 
            this.editColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2, 12, 2, 12);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            this.editColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.editColumn1.HeaderText = "";
            this.editColumn1.Name = "editColumn1";
            this.editColumn1.Text = "编辑";
            this.editColumn1.UseColumnTextForButtonValue = true;
            this.editColumn1.Width = 60;
            // 
            // deleteColumn1
            // 
            this.deleteColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2, 12, 2, 12);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            this.deleteColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.deleteColumn1.HeaderText = "";
            this.deleteColumn1.Name = "deleteColumn1";
            this.deleteColumn1.Text = "删除";
            this.deleteColumn1.ToolTipText = "删除";
            this.deleteColumn1.UseColumnTextForButtonValue = true;
            this.deleteColumn1.Width = 60;
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
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.deleteToolStripMenuItem.Text = "删除此条餐厅";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // newButton
            // 
            this.newButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newButton.Location = new System.Drawing.Point(626, 19);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 1;
            this.newButton.Text = "新建";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.keywordTextBox);
            this.groupBox1.Controls.Add(this.btfind);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cityComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nationComboBox);
            this.groupBox1.Location = new System.Drawing.Point(8, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(693, 84);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // keywordTextBox
            // 
            this.keywordTextBox.Location = new System.Drawing.Point(95, 53);
            this.keywordTextBox.Name = "keywordTextBox";
            this.keywordTextBox.Size = new System.Drawing.Size(441, 21);
            this.keywordTextBox.TabIndex = 10;
            this.keywordTextBox.TextChanged += new System.EventHandler(this.keywordTextBox_TextChanged);
            // 
            // btfind
            // 
            this.btfind.Location = new System.Drawing.Point(542, 23);
            this.btfind.Name = "btfind";
            this.btfind.Size = new System.Drawing.Size(75, 23);
            this.btfind.TabIndex = 9;
            this.btfind.Text = "查找";
            this.btfind.UseVisualStyleBackColor = true;
            this.btfind.Click += new System.EventHandler(this.btfind_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "城市";
            // 
            // cityComboBox
            // 
            this.cityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(344, 23);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(192, 20);
            this.cityComboBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "名称关键词";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "国家";
            // 
            // nationComboBox
            // 
            this.nationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nationComboBox.FormattingEnabled = true;
            this.nationComboBox.Location = new System.Drawing.Point(97, 23);
            this.nationComboBox.Name = "nationComboBox";
            this.nationComboBox.Size = new System.Drawing.Size(192, 20);
            this.nationComboBox.TabIndex = 3;
            this.nationComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 50);
            this.label2.TabIndex = 14;
            this.label2.Text = "餐厅列表";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btdown
            // 
            this.btdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btdown.Location = new System.Drawing.Point(545, 19);
            this.btdown.Name = "btdown";
            this.btdown.Size = new System.Drawing.Size(75, 23);
            this.btdown.TabIndex = 15;
            this.btdown.Text = "下载Excel";
            this.btdown.UseVisualStyleBackColor = true;
            this.btdown.Click += new System.EventHandler(this.btdown_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xslx";
            this.saveFileDialog1.Filter = "EXCEL文件(*.xls,*.xlsx)|*.xls;*.xlsx";
            this.saveFileDialog1.Title = "导出餐厅数据";
            // 
            // pager2
            // 
            this.pager2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pager2.AutoSize = true;
            this.pager2.Location = new System.Drawing.Point(8, 390);
            this.pager2.Name = "pager2";
            this.pager2.NMax = 0;
            this.pager2.PageCount = 0;
            this.pager2.PageCurrent = 0;
            this.pager2.PageSize = 25;
            this.pager2.Size = new System.Drawing.Size(693, 31);
            this.pager2.TabIndex = 13;
            this.pager2.EventPaging += new DCTS.CustomComponents.EventPagingHandler(this.pager2_EventPaging_1);
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
            // DiningsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btdown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pager2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.dataGridView);
            this.Name = "DiningsControl";
            this.Size = new System.Drawing.Size(709, 424);
            this.Resize += new System.EventHandler(this.DiningsControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btfind;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cityComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox nationComboBox;
        private CustomComponents.EntityDataSource entityDataSource1;
        private System.Windows.Forms.TextBox keywordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        //private CustomComponents.Pager pager1;
        private CustomComponents.Pager pager2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btdown;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nationColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaColumn1;
        private System.Windows.Forms.DataGridViewImageColumn imgColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishesColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn recommendedDishesColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn editColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn deleteColumn1;
    }
}
