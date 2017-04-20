namespace DCTS.UI
{
    partial class NewDiningsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.localAddressTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nationComboBox = new System.Windows.Forms.ComboBox();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.localTitleTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imgPathTextBox = new System.Windows.Forms.TextBox();
            this.findFileButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.latlngTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.openAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.closeAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "国家";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(164, 124);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(518, 20);
            this.titleTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(20, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(673, 44);
            this.label2.TabIndex = 3;
            this.label2.Text = "新建餐厅";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // localAddressTextBox
            // 
            this.localAddressTextBox.Location = new System.Drawing.Point(165, 293);
            this.localAddressTextBox.Name = "localAddressTextBox";
            this.localAddressTextBox.Size = new System.Drawing.Size(518, 20);
            this.localAddressTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "城市";
            // 
            // nationComboBox
            // 
            this.nationComboBox.FormattingEnabled = true;
            this.nationComboBox.Location = new System.Drawing.Point(164, 90);
            this.nationComboBox.Name = "nationComboBox";
            this.nationComboBox.Size = new System.Drawing.Size(233, 21);
            this.nationComboBox.TabIndex = 0;
            this.nationComboBox.SelectedIndexChanged += new System.EventHandler(this.nationComboBox_SelectedIndexChanged);
            // 
            // cityComboBox
            // 
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(449, 90);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(233, 21);
            this.cityComboBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "区域";
            // 
            // localTitleTextBox
            // 
            this.localTitleTextBox.Location = new System.Drawing.Point(164, 153);
            this.localTitleTextBox.Name = "localTitleTextBox";
            this.localTitleTextBox.Size = new System.Drawing.Size(518, 20);
            this.localTitleTextBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "餐厅名称";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(117, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "图片";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "请选择图片文件";
            // 
            // imgPathTextBox
            // 
            this.imgPathTextBox.Location = new System.Drawing.Point(162, 217);
            this.imgPathTextBox.Name = "imgPathTextBox";
            this.imgPathTextBox.Size = new System.Drawing.Size(481, 20);
            this.imgPathTextBox.TabIndex = 5;
            // 
            // findFileButton
            // 
            this.findFileButton.Location = new System.Drawing.Point(649, 215);
            this.findFileButton.Name = "findFileButton";
            this.findFileButton.Size = new System.Drawing.Size(32, 25);
            this.findFileButton.TabIndex = 6;
            this.findFileButton.Text = "...";
            this.findFileButton.UseVisualStyleBackColor = true;
            this.findFileButton.Click += new System.EventHandler(this.findFileButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(105, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "经纬度";
            // 
            // latlngTextBox
            // 
            this.latlngTextBox.Location = new System.Drawing.Point(165, 257);
            this.latlngTextBox.Name = "latlngTextBox";
            this.latlngTextBox.Size = new System.Drawing.Size(518, 20);
            this.latlngTextBox.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(117, 296);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "地址";
            // 
            // openAtDateTimePicker
            // 
            this.openAtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.openAtDateTimePicker.Location = new System.Drawing.Point(162, 352);
            this.openAtDateTimePicker.Name = "openAtDateTimePicker";
            this.openAtDateTimePicker.Size = new System.Drawing.Size(106, 20);
            this.openAtDateTimePicker.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(93, 354);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "营业时间";
            // 
            // closeAtDateTimePicker
            // 
            this.closeAtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.closeAtDateTimePicker.Location = new System.Drawing.Point(291, 352);
            this.closeAtDateTimePicker.Name = "closeAtDateTimePicker";
            this.closeAtDateTimePicker.Size = new System.Drawing.Size(106, 20);
            this.closeAtDateTimePicker.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(274, 362);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "-";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(164, 423);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(518, 56);
            this.textBox6.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(97, 427);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "深度Tips";
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = null;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.cancelButton.Location = new System.Drawing.Point(608, 498);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.saveButton.Location = new System.Drawing.Point(527, 498);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 25);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(117, 182);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "菜系";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(162, 179);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(518, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(40, 322);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "如何抵达(周围特征)";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(165, 319);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(518, 20);
            this.textBox2.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(93, 384);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "推荐菜单";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(162, 382);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(518, 20);
            this.textBox3.TabIndex = 12;
            // 
            // NewDiningsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 547);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.closeAtDateTimePicker);
            this.Controls.Add(this.openAtDateTimePicker);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.latlngTextBox);
            this.Controls.Add(this.findFileButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cityComboBox);
            this.Controls.Add(this.nationComboBox);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.localAddressTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imgPathTextBox);
            this.Controls.Add(this.localTitleTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label1);
            this.Name = "NewDiningsForm";
            this.Text = "新建餐厅";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox localAddressTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox nationComboBox;
        private System.Windows.Forms.ComboBox cityComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox localTitleTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox imgPathTextBox;
        private System.Windows.Forms.Button findFileButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox latlngTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker openAtDateTimePicker;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker closeAtDateTimePicker;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label11;
        private CustomComponents.EntityDataSource entityDataSource1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox3;
    }
}