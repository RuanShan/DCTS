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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btfind = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nationComboBox = new System.Windows.Forms.ComboBox();
            this.btsave = new System.Windows.Forms.Button();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pager2 = new DCTS.CustomComponents.Pager();
            this.nationColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dishesColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imgColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.latlngColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reachColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recommendedDishesColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipsColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nationColumn1,
            this.cityColumn1,
            this.areaColumn1,
            this.titleColumn1,
            this.dishesColumn1,
            this.imgColumn1,
            this.latlngColumn1,
            this.addressColumn1,
            this.reachColumn1,
            this.Column6,
            this.recommendedDishesColumn1,
            this.tipsColumn1});
            this.dataGridView.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView.Location = new System.Drawing.Point(8, 152);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(693, 267);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.修改ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.deleteToolStripMenuItem.Text = "删除餐厅";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(597, 14);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 25);
            this.newButton.TabIndex = 1;
            this.newButton.Text = "新建";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btfind);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cityComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nationComboBox);
            this.groupBox1.Location = new System.Drawing.Point(8, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 91);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(314, 20);
            this.textBox1.TabIndex = 10;
            // 
            // btfind
            // 
            this.btfind.Location = new System.Drawing.Point(568, 25);
            this.btfind.Name = "btfind";
            this.btfind.Size = new System.Drawing.Size(75, 25);
            this.btfind.TabIndex = 9;
            this.btfind.Text = "查找";
            this.btfind.UseVisualStyleBackColor = true;
            this.btfind.Click += new System.EventHandler(this.btfind_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "城市";
            // 
            // cityComboBox
            // 
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(288, 23);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(121, 21);
            this.cityComboBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "餐厅名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "国家";
            // 
            // nationComboBox
            // 
            this.nationComboBox.FormattingEnabled = true;
            this.nationComboBox.Location = new System.Drawing.Point(97, 20);
            this.nationComboBox.Name = "nationComboBox";
            this.nationComboBox.Size = new System.Drawing.Size(121, 21);
            this.nationComboBox.TabIndex = 3;
            this.nationComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // btsave
            // 
            this.btsave.Location = new System.Drawing.Point(516, 14);
            this.btsave.Name = "btsave";
            this.btsave.Size = new System.Drawing.Size(75, 25);
            this.btsave.TabIndex = 12;
            this.btsave.Text = "保存";
            this.btsave.UseVisualStyleBackColor = true;
            this.btsave.Click += new System.EventHandler(this.btsave_Click);
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
            // pager2
            // 
            this.pager2.AutoSize = true;
            this.pager2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pager2.Location = new System.Drawing.Point(0, 459);
            this.pager2.Name = "pager2";
            this.pager2.NMax = 0;
            this.pager2.PageCount = 0;
            this.pager2.PageCurrent = 0;
            this.pager2.PageSize = 5000;
            this.pager2.Size = new System.Drawing.Size(709, 0);
            this.pager2.TabIndex = 13;
            this.pager2.EventPaging += new DCTS.CustomComponents.EventPagingHandler(this.pager2_EventPaging_1);
            // 
            // nationColumn1
            // 
            this.nationColumn1.DataPropertyName = "nation";
            this.nationColumn1.HeaderText = "国家";
            this.nationColumn1.Name = "nationColumn1";
            // 
            // cityColumn1
            // 
            this.cityColumn1.DataPropertyName = "city";
            this.cityColumn1.HeaderText = "城市";
            this.cityColumn1.Name = "cityColumn1";
            // 
            // areaColumn1
            // 
            this.areaColumn1.DataPropertyName = "area";
            this.areaColumn1.HeaderText = "区域";
            this.areaColumn1.Name = "areaColumn1";
            // 
            // titleColumn1
            // 
            this.titleColumn1.DataPropertyName = "title";
            this.titleColumn1.HeaderText = "餐厅名称";
            this.titleColumn1.Name = "titleColumn1";
            // 
            // dishesColumn1
            // 
            this.dishesColumn1.DataPropertyName = "dishes";
            this.dishesColumn1.HeaderText = "菜系";
            this.dishesColumn1.Name = "dishesColumn1";
            // 
            // imgColumn1
            // 
            this.imgColumn1.HeaderText = "图片";
            this.imgColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.imgColumn1.Name = "imgColumn1";
            this.imgColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.imgColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // latlngColumn1
            // 
            this.latlngColumn1.DataPropertyName = "latlng";
            this.latlngColumn1.HeaderText = "经纬度";
            this.latlngColumn1.Name = "latlngColumn1";
            // 
            // addressColumn1
            // 
            this.addressColumn1.DataPropertyName = "address";
            this.addressColumn1.HeaderText = "地址";
            this.addressColumn1.Name = "addressColumn1";
            // 
            // reachColumn1
            // 
            this.reachColumn1.DataPropertyName = "reach";
            this.reachColumn1.HeaderText = "如何抵达(周围特征)";
            this.reachColumn1.Name = "reachColumn1";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "营业时间";
            this.Column6.Name = "Column6";
            // 
            // recommendedDishesColumn1
            // 
            this.recommendedDishesColumn1.DataPropertyName = "recommendedDishes ";
            this.recommendedDishesColumn1.HeaderText = "推荐菜单";
            this.recommendedDishesColumn1.Name = "recommendedDishesColumn1";
            // 
            // tipsColumn1
            // 
            this.tipsColumn1.DataPropertyName = "tips";
            this.tipsColumn1.HeaderText = "深度Tlps";
            this.tipsColumn1.Name = "tipsColumn1";
            // 
            // DinningsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pager2);
            this.Controls.Add(this.btsave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.dataGridView);
            this.Name = "DinningsControl";
            this.Size = new System.Drawing.Size(709, 459);
            this.Load += new System.EventHandler(this.DinningsControl_Load);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.Button btsave;
        private CustomComponents.Pager pager1;
        private CustomComponents.Pager pager2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nationColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishesColumn1;
        private System.Windows.Forms.DataGridViewImageColumn imgColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn latlngColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn reachColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn recommendedDishesColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipsColumn1;
    }
}