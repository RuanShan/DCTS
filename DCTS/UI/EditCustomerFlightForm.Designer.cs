namespace DCTS.UI
{
    partial class EditCustomerFlightForm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.flightCompanyComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ticketNumColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromPlaceColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toPlaceColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startAtColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endAtColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromAddressColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toAddressColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newButton1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "PNG(*.png)JPEG(*.jpg,*.jpeg,*.jpe,*.jfif)GIF(*.gif)BMP(*.bmp)|*.png;*.jpg;*.jpeg;" +
    "*.jpe;*.jfif;*.gif;*.bmp";
            this.openFileDialog1.Title = "请选择住宿图片文件";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.cancelButton.Location = new System.Drawing.Point(708, 412);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.saveButton.Location = new System.Drawing.Point(627, 412);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "航空公司";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(821, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "客户机票信息";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "客户";
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = null;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // flightCompanyComboBox
            // 
            this.flightCompanyComboBox.FormattingEnabled = true;
            this.flightCompanyComboBox.Items.AddRange(new object[] {
            "男",
            "女"});
            this.flightCompanyComboBox.Location = new System.Drawing.Point(83, 114);
            this.flightCompanyComboBox.Name = "flightCompanyComboBox";
            this.flightCompanyComboBox.Size = new System.Drawing.Size(233, 20);
            this.flightCompanyComboBox.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ticketNumColumn1,
            this.fromPlaceColumn1,
            this.toPlaceColumn1,
            this.startAtColumn1,
            this.endAtColumn1,
            this.fromAddressColumn1,
            this.toAddressColumn1});
            this.dataGridView1.Location = new System.Drawing.Point(83, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(700, 218);
            this.dataGridView1.TabIndex = 17;
            // 
            // ticketNumColumn1
            // 
            this.ticketNumColumn1.HeaderText = "航班号";
            this.ticketNumColumn1.Name = "ticketNumColumn1";
            // 
            // fromPlaceColumn1
            // 
            this.fromPlaceColumn1.HeaderText = "始发地";
            this.fromPlaceColumn1.Name = "fromPlaceColumn1";
            // 
            // toPlaceColumn1
            // 
            this.toPlaceColumn1.HeaderText = "目的地";
            this.toPlaceColumn1.Name = "toPlaceColumn1";
            // 
            // startAtColumn1
            // 
            this.startAtColumn1.HeaderText = "起飞时间";
            this.startAtColumn1.Name = "startAtColumn1";
            // 
            // endAtColumn1
            // 
            this.endAtColumn1.HeaderText = "到达时间";
            this.endAtColumn1.Name = "endAtColumn1";
            // 
            // fromAddressColumn1
            // 
            this.fromAddressColumn1.HeaderText = "始发地机场";
            this.fromAddressColumn1.Name = "fromAddressColumn1";
            // 
            // toAddressColumn1
            // 
            this.toAddressColumn1.HeaderText = "目的地机场";
            this.toAddressColumn1.Name = "toAddressColumn1";
            // 
            // newButton1
            // 
            this.newButton1.Location = new System.Drawing.Point(80, 375);
            this.newButton1.Name = "newButton1";
            this.newButton1.Size = new System.Drawing.Size(30, 23);
            this.newButton1.TabIndex = 18;
            this.newButton1.Text = "+";
            this.newButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "航班信息";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "男",
            "女"});
            this.comboBox1.Location = new System.Drawing.Point(83, 85);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(233, 20);
            this.comboBox1.TabIndex = 3;
            // 
            // EditCustomerFlightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 470);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.newButton1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.flightCompanyComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditCustomerFlightForm";
            this.Text = "编辑机票信息";
            this.Load += new System.EventHandler(this.EditCustomerFlightForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private CustomComponents.EntityDataSource entityDataSource1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox flightCompanyComboBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketNumColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromPlaceColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn toPlaceColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn startAtColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn endAtColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromAddressColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn toAddressColumn1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button newButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}