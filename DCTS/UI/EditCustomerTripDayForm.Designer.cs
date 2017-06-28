namespace DCTS.UI
{
    partial class EditCustomerTripDayForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.findFileButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.imgPathTextBox = new System.Windows.Forms.TextBox();
            this.moveDownButton1 = new System.Windows.Forms.Button();
            this.moveUpButton2 = new System.Windows.Forms.Button();
            this.delScheduleButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.scheduleDataGridView = new System.Windows.Forms.DataGridView();
            this.start_atColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.tipsTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.formLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(82, 114);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // findFileButton
            // 
            this.findFileButton.Location = new System.Drawing.Point(283, 87);
            this.findFileButton.Name = "findFileButton";
            this.findFileButton.Size = new System.Drawing.Size(32, 23);
            this.findFileButton.TabIndex = 39;
            this.findFileButton.Text = "...";
            this.findFileButton.UseVisualStyleBackColor = true;
            this.findFileButton.Click += new System.EventHandler(this.findFileButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 40;
            this.label6.Text = "图片";
            // 
            // imgPathTextBox
            // 
            this.imgPathTextBox.Location = new System.Drawing.Point(82, 88);
            this.imgPathTextBox.Name = "imgPathTextBox";
            this.imgPathTextBox.Size = new System.Drawing.Size(195, 21);
            this.imgPathTextBox.TabIndex = 38;
            // 
            // moveDownButton1
            // 
            this.moveDownButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moveDownButton1.Enabled = false;
            this.moveDownButton1.Location = new System.Drawing.Point(205, 460);
            this.moveDownButton1.Name = "moveDownButton1";
            this.moveDownButton1.Size = new System.Drawing.Size(35, 23);
            this.moveDownButton1.TabIndex = 37;
            this.moveDownButton1.Text = "▽";
            this.moveDownButton1.UseVisualStyleBackColor = true;
            this.moveDownButton1.Visible = false;
            this.moveDownButton1.Click += new System.EventHandler(this.moveDownButton1_Click);
            // 
            // moveUpButton2
            // 
            this.moveUpButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moveUpButton2.Enabled = false;
            this.moveUpButton2.Location = new System.Drawing.Point(164, 460);
            this.moveUpButton2.Name = "moveUpButton2";
            this.moveUpButton2.Size = new System.Drawing.Size(35, 23);
            this.moveUpButton2.TabIndex = 36;
            this.moveUpButton2.Text = "△";
            this.moveUpButton2.UseVisualStyleBackColor = true;
            this.moveUpButton2.Visible = false;
            this.moveUpButton2.Click += new System.EventHandler(this.moveUpButton2_Click);
            // 
            // delScheduleButton
            // 
            this.delScheduleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.delScheduleButton.Location = new System.Drawing.Point(123, 460);
            this.delScheduleButton.Name = "delScheduleButton";
            this.delScheduleButton.Size = new System.Drawing.Size(35, 23);
            this.delScheduleButton.TabIndex = 35;
            this.delScheduleButton.Text = "-";
            this.delScheduleButton.UseVisualStyleBackColor = true;
            this.delScheduleButton.Click += new System.EventHandler(this.delScheduleButton_Click);
            // 
            // newButton
            // 
            this.newButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newButton.Location = new System.Drawing.Point(82, 460);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(35, 23);
            this.newButton.TabIndex = 34;
            this.newButton.Text = "+";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // scheduleDataGridView
            // 
            this.scheduleDataGridView.AllowUserToAddRows = false;
            this.scheduleDataGridView.AllowUserToOrderColumns = true;
            this.scheduleDataGridView.AllowUserToResizeColumns = false;
            this.scheduleDataGridView.AllowUserToResizeRows = false;
            this.scheduleDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scheduleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scheduleDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.start_atColumn1,
            this.titleColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.scheduleDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.scheduleDataGridView.Location = new System.Drawing.Point(82, 290);
            this.scheduleDataGridView.Name = "scheduleDataGridView";
            this.scheduleDataGridView.RowHeadersVisible = false;
            this.scheduleDataGridView.RowTemplate.Height = 23;
            this.scheduleDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.scheduleDataGridView.Size = new System.Drawing.Size(739, 164);
            this.scheduleDataGridView.TabIndex = 32;
            this.scheduleDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // start_atColumn1
            // 
            this.start_atColumn1.DataPropertyName = "start_at";
            dataGridViewCellStyle1.Format = "f";
            dataGridViewCellStyle1.NullValue = null;
            this.start_atColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.start_atColumn1.HeaderText = "时间";
            this.start_atColumn1.Name = "start_atColumn1";
            this.start_atColumn1.Width = 140;
            // 
            // titleColumn
            // 
            this.titleColumn.DataPropertyName = "title";
            this.titleColumn.HeaderText = "活动";
            this.titleColumn.Name = "titleColumn";
            this.titleColumn.Width = 590;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 31;
            this.label5.Text = "详细行程";
            // 
            // tipsTextBox
            // 
            this.tipsTextBox.Location = new System.Drawing.Point(82, 200);
            this.tipsTextBox.Multiline = true;
            this.tipsTextBox.Name = "tipsTextBox";
            this.tipsTextBox.Size = new System.Drawing.Size(739, 82);
            this.tipsTextBox.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "深度Tips";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(82, 61);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(739, 21);
            this.titleTextBox.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "名称";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.cancelButton.Location = new System.Drawing.Point(747, 477);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(666, 477);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // formLabel
            // 
            this.formLabel.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.formLabel.Location = new System.Drawing.Point(1, 17);
            this.formLabel.Name = "formLabel";
            this.formLabel.Size = new System.Drawing.Size(888, 41);
            this.formLabel.TabIndex = 7;
            this.formLabel.Text = "编辑某天详细";
            this.formLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DCTS.DctsEntities);
            // 
            // EditCustomerTripDayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 519);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.findFileButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.imgPathTextBox);
            this.Controls.Add(this.moveDownButton1);
            this.Controls.Add(this.moveUpButton2);
            this.Controls.Add(this.delScheduleButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.scheduleDataGridView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tipsTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.formLabel);
            this.Name = "EditCustomerTripDayForm";
            this.Text = "编辑某天详细";
            this.Load += new System.EventHandler(this.EditTripForm_Load);
            this.Resize += new System.EventHandler(this.EditCustomerTripDayForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label formLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private CustomComponents.EntityDataSource entityDataSource1;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.DataGridView scheduleDataGridView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tipsTextBox;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button delScheduleButton;
        private System.Windows.Forms.Button moveDownButton1;
        private System.Windows.Forms.Button moveUpButton2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_atColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleColumn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button findFileButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox imgPathTextBox;
    }
}