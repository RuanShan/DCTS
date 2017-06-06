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
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flightFromTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.customerTextBox = new System.Windows.Forms.TextBox();
            this.flightCompanyComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.flightToTextBox = new System.Windows.Forms.TextBox();
            this.flightStartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.flightEndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.flightNoTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.airportFromTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.airportToTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flightLayoverCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flight2StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.flight2EndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.airport2FromTextBox5 = new System.Windows.Forms.TextBox();
            this.airport2ToTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.flight2NoTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.cancelButton.Location = new System.Drawing.Point(595, 435);
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
            this.saveButton.Location = new System.Drawing.Point(514, 435);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "始发地";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 115);
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
            this.label2.Size = new System.Drawing.Size(713, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "客户机票信息";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flightFromTextBox
            // 
            this.flightFromTextBox.Location = new System.Drawing.Point(81, 50);
            this.flightFromTextBox.Name = "flightFromTextBox";
            this.flightFromTextBox.Size = new System.Drawing.Size(233, 21);
            this.flightFromTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 85);
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
            // customerTextBox
            // 
            this.customerTextBox.Location = new System.Drawing.Point(116, 81);
            this.customerTextBox.Name = "customerTextBox";
            this.customerTextBox.Size = new System.Drawing.Size(233, 21);
            this.customerTextBox.TabIndex = 0;
            // 
            // flightCompanyComboBox
            // 
            this.flightCompanyComboBox.FormattingEnabled = true;
            this.flightCompanyComboBox.Items.AddRange(new object[] {
            "男",
            "女"});
            this.flightCompanyComboBox.Location = new System.Drawing.Point(116, 111);
            this.flightCompanyComboBox.Name = "flightCompanyComboBox";
            this.flightCompanyComboBox.Size = new System.Drawing.Size(233, 20);
            this.flightCompanyComboBox.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(355, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "目的地";
            // 
            // flightToTextBox
            // 
            this.flightToTextBox.Location = new System.Drawing.Point(402, 50);
            this.flightToTextBox.Name = "flightToTextBox";
            this.flightToTextBox.Size = new System.Drawing.Size(233, 21);
            this.flightToTextBox.TabIndex = 11;
            // 
            // flightStartDateTimePicker
            // 
            this.flightStartDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.flightStartDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.flightStartDateTimePicker.Location = new System.Drawing.Point(81, 79);
            this.flightStartDateTimePicker.Name = "flightStartDateTimePicker";
            this.flightStartDateTimePicker.Size = new System.Drawing.Size(233, 21);
            this.flightStartDateTimePicker.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "起飞时间";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(343, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "到达时间";
            // 
            // flightEndDateTimePicker
            // 
            this.flightEndDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.flightEndDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.flightEndDateTimePicker.Location = new System.Drawing.Point(402, 79);
            this.flightEndDateTimePicker.Name = "flightEndDateTimePicker";
            this.flightEndDateTimePicker.Size = new System.Drawing.Size(233, 21);
            this.flightEndDateTimePicker.TabIndex = 13;
            // 
            // flightNoTextBox
            // 
            this.flightNoTextBox.Location = new System.Drawing.Point(81, 20);
            this.flightNoTextBox.Name = "flightNoTextBox";
            this.flightNoTextBox.Size = new System.Drawing.Size(233, 21);
            this.flightNoTextBox.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(34, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "航班号";
            // 
            // airportFromTextBox
            // 
            this.airportFromTextBox.Location = new System.Drawing.Point(81, 109);
            this.airportFromTextBox.Name = "airportFromTextBox";
            this.airportFromTextBox.Size = new System.Drawing.Size(233, 21);
            this.airportFromTextBox.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "始发地机场";
            // 
            // airportToTextBox
            // 
            this.airportToTextBox.Location = new System.Drawing.Point(402, 109);
            this.airportToTextBox.Name = "airportToTextBox";
            this.airportToTextBox.Size = new System.Drawing.Size(233, 21);
            this.airportToTextBox.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(331, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 12;
            this.label12.Text = "目的地机场";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flightStartDateTimePicker);
            this.groupBox1.Controls.Add(this.flightEndDateTimePicker);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.flightToTextBox);
            this.groupBox1.Controls.Add(this.airportToTextBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.flightNoTextBox);
            this.groupBox1.Controls.Add(this.flightFromTextBox);
            this.groupBox1.Controls.Add(this.airportFromTextBox);
            this.groupBox1.Location = new System.Drawing.Point(35, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 146);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "航班信息";
            // 
            // flightLayoverCheckBox
            // 
            this.flightLayoverCheckBox.AutoSize = true;
            this.flightLayoverCheckBox.Location = new System.Drawing.Point(368, 114);
            this.flightLayoverCheckBox.Name = "flightLayoverCheckBox";
            this.flightLayoverCheckBox.Size = new System.Drawing.Size(72, 16);
            this.flightLayoverCheckBox.TabIndex = 16;
            this.flightLayoverCheckBox.Text = "是否转机";
            this.flightLayoverCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flight2StartDateTimePicker);
            this.groupBox2.Controls.Add(this.flight2EndDateTimePicker);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.airport2FromTextBox5);
            this.groupBox2.Controls.Add(this.airport2ToTextBox);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.flight2NoTextBox);
            this.groupBox2.Location = new System.Drawing.Point(35, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(663, 121);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "转机信息";
            // 
            // flight2StartDateTimePicker
            // 
            this.flight2StartDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.flight2StartDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.flight2StartDateTimePicker.Location = new System.Drawing.Point(80, 51);
            this.flight2StartDateTimePicker.Name = "flight2StartDateTimePicker";
            this.flight2StartDateTimePicker.Size = new System.Drawing.Size(233, 21);
            this.flight2StartDateTimePicker.TabIndex = 13;
            // 
            // flight2EndDateTimePicker
            // 
            this.flight2EndDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.flight2EndDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.flight2EndDateTimePicker.Location = new System.Drawing.Point(402, 51);
            this.flight2EndDateTimePicker.Name = "flight2EndDateTimePicker";
            this.flight2EndDateTimePicker.Size = new System.Drawing.Size(233, 21);
            this.flight2EndDateTimePicker.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "起飞时间";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(343, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 14;
            this.label13.Text = "到达时间";
            // 
            // airport2FromTextBox5
            // 
            this.airport2FromTextBox5.Location = new System.Drawing.Point(80, 82);
            this.airport2FromTextBox5.Name = "airport2FromTextBox5";
            this.airport2FromTextBox5.Size = new System.Drawing.Size(233, 21);
            this.airport2FromTextBox5.TabIndex = 11;
            // 
            // airport2ToTextBox
            // 
            this.airport2ToTextBox.Location = new System.Drawing.Point(402, 82);
            this.airport2ToTextBox.Name = "airport2ToTextBox";
            this.airport2ToTextBox.Size = new System.Drawing.Size(233, 21);
            this.airport2ToTextBox.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(331, 86);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 12;
            this.label15.Text = "目的地机场";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(34, 86);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 12;
            this.label16.Text = "目的地";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(34, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 4;
            this.label17.Text = "航班号";
            // 
            // flight2NoTextBox
            // 
            this.flight2NoTextBox.Location = new System.Drawing.Point(81, 24);
            this.flight2NoTextBox.Name = "flight2NoTextBox";
            this.flight2NoTextBox.Size = new System.Drawing.Size(233, 21);
            this.flight2NoTextBox.TabIndex = 1;
            // 
            // EditCustomerFlightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 470);
            this.Controls.Add(this.flightLayoverCheckBox);
            this.Controls.Add(this.customerTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.flightCompanyComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "EditCustomerFlightForm";
            this.Text = "编辑机票信息";
            this.Load += new System.EventHandler(this.EditCustomerFlightForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox flightFromTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private CustomComponents.EntityDataSource entityDataSource1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox customerTextBox;
        private System.Windows.Forms.ComboBox flightCompanyComboBox;
        private System.Windows.Forms.DateTimePicker flightEndDateTimePicker;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker flightStartDateTimePicker;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox airportToTextBox;
        private System.Windows.Forms.TextBox flightToTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox airportFromTextBox;
        private System.Windows.Forms.TextBox flightNoTextBox;
        private System.Windows.Forms.CheckBox flightLayoverCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker flight2StartDateTimePicker;
        private System.Windows.Forms.DateTimePicker flight2EndDateTimePicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox airport2FromTextBox5;
        private System.Windows.Forms.TextBox airport2ToTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox flight2NoTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}