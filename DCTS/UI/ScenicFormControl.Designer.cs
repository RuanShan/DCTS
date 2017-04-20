namespace DCTS.CustomComponents
{
    partial class ScenicFormControl
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
            this.label13 = new System.Windows.Forms.Label();
            this.routeTextBox = new System.Windows.Forms.TextBox();
            this.ticketTextBox = new System.Windows.Forms.TextBox();
            this.closeAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.openAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.latlngTextBox = new System.Windows.Forms.TextBox();
            this.findFileButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.nationComboBox = new System.Windows.Forms.ComboBox();
            this.tipsTextBox = new System.Windows.Forms.TextBox();
            this.localAddressTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.imgPathTextBox = new System.Windows.Forms.TextBox();
            this.localTitleTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 231);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 41;
            this.label13.Text = "如何抵达";
            // 
            // routeTextBox
            // 
            this.routeTextBox.Location = new System.Drawing.Point(85, 228);
            this.routeTextBox.Multiline = true;
            this.routeTextBox.Name = "routeTextBox";
            this.routeTextBox.Size = new System.Drawing.Size(518, 52);
            this.routeTextBox.TabIndex = 40;
            // 
            // ticketTextBox
            // 
            this.ticketTextBox.Location = new System.Drawing.Point(372, 163);
            this.ticketTextBox.Name = "ticketTextBox";
            this.ticketTextBox.Size = new System.Drawing.Size(231, 21);
            this.ticketTextBox.TabIndex = 39;
            // 
            // closeAtDateTimePicker
            // 
            this.closeAtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.closeAtDateTimePicker.Location = new System.Drawing.Point(212, 163);
            this.closeAtDateTimePicker.Name = "closeAtDateTimePicker";
            this.closeAtDateTimePicker.ShowUpDown = true;
            this.closeAtDateTimePicker.Size = new System.Drawing.Size(106, 21);
            this.closeAtDateTimePicker.TabIndex = 38;
            // 
            // openAtDateTimePicker
            // 
            this.openAtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.openAtDateTimePicker.Location = new System.Drawing.Point(85, 163);
            this.openAtDateTimePicker.Name = "openAtDateTimePicker";
            this.openAtDateTimePicker.ShowUpDown = true;
            this.openAtDateTimePicker.Size = new System.Drawing.Size(106, 21);
            this.openAtDateTimePicker.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(197, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 36;
            this.label10.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(337, 167);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 35;
            this.label12.Text = "门票";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 167);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 34;
            this.label9.Text = "开放时间";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 295);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 33;
            this.label11.Text = "深度Tips";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 32;
            this.label8.Text = "当地语言地址";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 31;
            this.label7.Text = "经纬度";
            // 
            // latlngTextBox
            // 
            this.latlngTextBox.Location = new System.Drawing.Point(85, 98);
            this.latlngTextBox.Name = "latlngTextBox";
            this.latlngTextBox.Size = new System.Drawing.Size(518, 21);
            this.latlngTextBox.TabIndex = 30;
            // 
            // findFileButton
            // 
            this.findFileButton.Location = new System.Drawing.Point(571, 129);
            this.findFileButton.Name = "findFileButton";
            this.findFileButton.Size = new System.Drawing.Size(32, 23);
            this.findFileButton.TabIndex = 29;
            this.findFileButton.Text = "...";
            this.findFileButton.UseVisualStyleBackColor = true;
            this.findFileButton.Click += new System.EventHandler(this.findFileButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "图片";
            // 
            // cityComboBox
            // 
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(370, 3);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(233, 20);
            this.cityComboBox.TabIndex = 27;
            // 
            // nationComboBox
            // 
            this.nationComboBox.FormattingEnabled = true;
            this.nationComboBox.Location = new System.Drawing.Point(85, 3);
            this.nationComboBox.Name = "nationComboBox";
            this.nationComboBox.Size = new System.Drawing.Size(233, 20);
            this.nationComboBox.TabIndex = 26;
            // 
            // tipsTextBox
            // 
            this.tipsTextBox.Location = new System.Drawing.Point(85, 292);
            this.tipsTextBox.Multiline = true;
            this.tipsTextBox.Name = "tipsTextBox";
            this.tipsTextBox.Size = new System.Drawing.Size(518, 52);
            this.tipsTextBox.TabIndex = 25;
            // 
            // localAddressTextBox
            // 
            this.localAddressTextBox.Location = new System.Drawing.Point(85, 195);
            this.localAddressTextBox.Name = "localAddressTextBox";
            this.localAddressTextBox.Size = new System.Drawing.Size(518, 21);
            this.localAddressTextBox.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "当地语言名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "中文名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "城市";
            // 
            // imgPathTextBox
            // 
            this.imgPathTextBox.Location = new System.Drawing.Point(85, 131);
            this.imgPathTextBox.Name = "imgPathTextBox";
            this.imgPathTextBox.ReadOnly = true;
            this.imgPathTextBox.Size = new System.Drawing.Size(481, 21);
            this.imgPathTextBox.TabIndex = 19;
            this.imgPathTextBox.TextChanged += new System.EventHandler(this.imgPathTextBox_TextChanged);
            // 
            // localTitleTextBox
            // 
            this.localTitleTextBox.Location = new System.Drawing.Point(85, 67);
            this.localTitleTextBox.Name = "localTitleTextBox";
            this.localTitleTextBox.Size = new System.Drawing.Size(518, 21);
            this.localTitleTextBox.TabIndex = 18;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(85, 35);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(518, 21);
            this.titleTextBox.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "国家";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ScenicFormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label13);
            this.Controls.Add(this.routeTextBox);
            this.Controls.Add(this.ticketTextBox);
            this.Controls.Add(this.closeAtDateTimePicker);
            this.Controls.Add(this.openAtDateTimePicker);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.latlngTextBox);
            this.Controls.Add(this.findFileButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cityComboBox);
            this.Controls.Add(this.nationComboBox);
            this.Controls.Add(this.tipsTextBox);
            this.Controls.Add(this.localAddressTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imgPathTextBox);
            this.Controls.Add(this.localTitleTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label1);
            this.Name = "ScenicFormControl";
            this.Size = new System.Drawing.Size(634, 351);
            this.Load += new System.EventHandler(this.ScenicFormControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox routeTextBox;
        private System.Windows.Forms.TextBox ticketTextBox;
        private System.Windows.Forms.DateTimePicker closeAtDateTimePicker;
        private System.Windows.Forms.DateTimePicker openAtDateTimePicker;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox latlngTextBox;
        private System.Windows.Forms.Button findFileButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cityComboBox;
        private System.Windows.Forms.ComboBox nationComboBox;
        private System.Windows.Forms.TextBox tipsTextBox;
        private System.Windows.Forms.TextBox localAddressTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox imgPathTextBox;
        private System.Windows.Forms.TextBox localTitleTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
