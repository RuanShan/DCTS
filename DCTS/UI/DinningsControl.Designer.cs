namespace DCTS.UI
{
    partial class DinningsControl
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
            this.newButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.nationColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dishesColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imgColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latlngColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reachColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recommendedDishesColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipsColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
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
            this.dataGridView.Location = new System.Drawing.Point(8, 185);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(668, 183);
            this.dataGridView.TabIndex = 0;
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
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox2);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(568, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 9;
            this.button2.Text = "查找";
            this.button2.UseVisualStyleBackColor = true;
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
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(288, 23);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "名称关键词";
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
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(97, 20);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 3;
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
            this.imgColumn1.DataPropertyName = "img";
            this.imgColumn1.HeaderText = "图片";
            this.imgColumn1.Name = "imgColumn1";
            // 
            // latlngColumn1
            // 
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
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DCTS.DctsEntities);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "删除餐厅";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // DinningsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.dataGridView);
            this.Name = "DinningsControl";
            this.Size = new System.Drawing.Size(684, 397);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private CustomComponents.EntityDataSource entityDataSource1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nationColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishesColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn imgColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn latlngColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn reachColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn recommendedDishesColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipsColumn1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}
