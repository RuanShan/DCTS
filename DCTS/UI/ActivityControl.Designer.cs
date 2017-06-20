namespace DCTS.UI
{
    partial class ActivityControl
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
            this.newButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.keywordTextBox = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nationComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pager1 = new DCTS.CustomComponents.Pager();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.exportExcelButton = new System.Windows.Forms.Button();
            this.IDColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nationColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imgColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.wordColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localTitleColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceTimeColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ticketColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.deleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
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
            this.IDColumn1,
            this.nationColumn1,
            this.cityColumn1,
            this.imgColumn1,
            this.wordColumn1,
            this.titleColumn1,
            this.localTitleColumn1,
            this.serviceTimeColumn1,
            this.ticketColumn1,
            this.editColumn1,
            this.deleteColumn});
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
            this.dataGridView.Size = new System.Drawing.Size(882, 205);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            // 
            // newButton
            // 
            this.newButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newButton.Location = new System.Drawing.Point(815, 18);
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
            this.groupBox1.Controls.Add(this.findButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cityComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nationComboBox);
            this.groupBox1.Location = new System.Drawing.Point(8, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(882, 84);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // keywordTextBox
            // 
            this.keywordTextBox.Location = new System.Drawing.Point(95, 53);
            this.keywordTextBox.Name = "keywordTextBox";
            this.keywordTextBox.Size = new System.Drawing.Size(435, 21);
            this.keywordTextBox.TabIndex = 10;
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(536, 17);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(75, 23);
            this.findButton.TabIndex = 9;
            this.findButton.Text = "查找";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "城市";
            // 
            // cityComboBox
            // 
            this.cityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(338, 18);
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
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "国家";
            // 
            // nationComboBox
            // 
            this.nationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nationComboBox.FormattingEnabled = true;
            this.nationComboBox.Location = new System.Drawing.Point(97, 19);
            this.nationComboBox.Name = "nationComboBox";
            this.nationComboBox.Size = new System.Drawing.Size(192, 20);
            this.nationComboBox.TabIndex = 3;
            this.nationComboBox.SelectedIndexChanged += new System.EventHandler(this.nationComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 50);
            this.label2.TabIndex = 12;
            this.label2.Text = "活动列表";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xslx";
            this.saveFileDialog1.Filter = "EXCEL文件(*.xls,*.xlsx)|*.xls;*.xlsx";
            this.saveFileDialog1.Title = "导出景点数据";
            // 
            // pager1
            // 
            this.pager1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pager1.AutoSize = true;
            this.pager1.Location = new System.Drawing.Point(8, 351);
            this.pager1.Name = "pager1";
            this.pager1.NMax = 0;
            this.pager1.PageCount = 0;
            this.pager1.PageCurrent = 1;
            this.pager1.PageSize = 25;
            this.pager1.Size = new System.Drawing.Size(877, 29);
            this.pager1.TabIndex = 13;
            this.pager1.EventPaging += new DCTS.CustomComponents.EventPagingHandler(this.pager1_EventPaging);
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DCTS.DctsEntities);
            // 
            // exportExcelButton
            // 
            this.exportExcelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportExcelButton.Location = new System.Drawing.Point(734, 18);
            this.exportExcelButton.Name = "exportExcelButton";
            this.exportExcelButton.Size = new System.Drawing.Size(75, 23);
            this.exportExcelButton.TabIndex = 17;
            this.exportExcelButton.Text = "导出EXCEL";
            this.exportExcelButton.UseVisualStyleBackColor = true;
            this.exportExcelButton.Click += new System.EventHandler(this.exportExcelButton_Click);
            // 
            // IDColumn1
            // 
            this.IDColumn1.DataPropertyName = "id";
            this.IDColumn1.Frozen = true;
            this.IDColumn1.HeaderText = "序号";
            this.IDColumn1.Name = "IDColumn1";
            this.IDColumn1.Width = 60;
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
            // imgColumn1
            // 
            this.imgColumn1.HeaderText = "图片";
            this.imgColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.imgColumn1.Name = "imgColumn1";
            this.imgColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.imgColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // wordColumn1
            // 
            this.wordColumn1.DataPropertyName = "word";
            this.wordColumn1.HeaderText = "Word模板";
            this.wordColumn1.Name = "wordColumn1";
            // 
            // titleColumn1
            // 
            this.titleColumn1.DataPropertyName = "title";
            this.titleColumn1.HeaderText = "中文名称";
            this.titleColumn1.Name = "titleColumn1";
            this.titleColumn1.Width = 280;
            // 
            // localTitleColumn1
            // 
            this.localTitleColumn1.DataPropertyName = "local_title";
            this.localTitleColumn1.HeaderText = "当地语言名称";
            this.localTitleColumn1.Name = "localTitleColumn1";
            this.localTitleColumn1.Width = 280;
            // 
            // serviceTimeColumn1
            // 
            this.serviceTimeColumn1.DataPropertyName = "open_close_more";
            this.serviceTimeColumn1.HeaderText = "开放时间说明";
            this.serviceTimeColumn1.Name = "serviceTimeColumn1";
            this.serviceTimeColumn1.Width = 200;
            // 
            // ticketColumn1
            // 
            this.ticketColumn1.DataPropertyName = "ticket";
            this.ticketColumn1.HeaderText = "门票";
            this.ticketColumn1.Name = "ticketColumn1";
            // 
            // editColumn1
            // 
            this.editColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2, 12, 2, 12);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.editColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.editColumn1.HeaderText = "";
            this.editColumn1.Name = "editColumn1";
            this.editColumn1.Text = "编辑";
            this.editColumn1.UseColumnTextForButtonValue = true;
            this.editColumn1.Width = 60;
            // 
            // deleteColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2, 12, 2, 12);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.deleteColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.deleteColumn.HeaderText = "";
            this.deleteColumn.Name = "deleteColumn";
            this.deleteColumn.Text = "删除";
            this.deleteColumn.UseColumnTextForButtonValue = true;
            this.deleteColumn.Width = 60;
            // 
            // ActivityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exportExcelButton);
            this.Controls.Add(this.pager1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.dataGridView);
            this.Name = "ActivityControl";
            this.Size = new System.Drawing.Size(898, 382);
            this.Resize += new System.EventHandler(this.ScenicsControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
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
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cityComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox nationComboBox;
        private CustomComponents.EntityDataSource entityDataSource1;
        private System.Windows.Forms.TextBox keywordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CustomComponents.Pager pager1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button exportExcelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nationColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityColumn1;
        private System.Windows.Forms.DataGridViewImageColumn imgColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn wordColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn localTitleColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceTimeColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn editColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn deleteColumn;
    }
}
