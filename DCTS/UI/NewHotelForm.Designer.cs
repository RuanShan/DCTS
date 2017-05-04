namespace DCTS.UI
{
    partial class NewHotelForm
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
            this.closeAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.openAtDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.kitchen = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.reception = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.parking = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.wifi = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.contact = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.local_address = new System.Windows.Forms.TextBox();
            this.room = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.latlng = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.findFileButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.nationComboBox = new System.Windows.Forms.ComboBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.moringTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imgPathTextBox = new System.Windows.Forms.TextBox();
            this.localTitleTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "请选择图片文件";
            // 
            // closeAtDateTimePicker
            // 
            this.closeAtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.closeAtDateTimePicker.Location = new System.Drawing.Point(449, 200);
            this.closeAtDateTimePicker.Name = "closeAtDateTimePicker";
            this.closeAtDateTimePicker.Size = new System.Drawing.Size(106, 20);
            this.closeAtDateTimePicker.TabIndex = 7;
            // 
            // openAtDateTimePicker
            // 
            this.openAtDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.openAtDateTimePicker.Location = new System.Drawing.Point(165, 200);
            this.openAtDateTimePicker.Name = "openAtDateTimePicker";
            this.openAtDateTimePicker.Size = new System.Drawing.Size(106, 20);
            this.openAtDateTimePicker.TabIndex = 6;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(414, 466);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(31, 13);
            this.label20.TabIndex = 34;
            this.label20.Text = "厨房";
            // 
            // kitchen
            // 
            this.kitchen.Location = new System.Drawing.Point(449, 462);
            this.kitchen.Name = "kitchen";
            this.kitchen.Size = new System.Drawing.Size(237, 20);
            this.kitchen.TabIndex = 17;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(120, 469);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 13);
            this.label19.TabIndex = 32;
            this.label19.Text = "前台";
            // 
            // reception
            // 
            this.reception.Location = new System.Drawing.Point(160, 463);
            this.reception.Name = "reception";
            this.reception.Size = new System.Drawing.Size(237, 20);
            this.reception.TabIndex = 16;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(108, 442);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 13);
            this.label18.TabIndex = 30;
            this.label18.Text = "停车位";
            // 
            // parking
            // 
            this.parking.Location = new System.Drawing.Point(162, 436);
            this.parking.Name = "parking";
            this.parking.Size = new System.Drawing.Size(518, 20);
            this.parking.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(126, 416);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 13);
            this.label17.TabIndex = 28;
            this.label17.Text = "Wifi";
            // 
            // wifi
            // 
            this.wifi.Location = new System.Drawing.Point(162, 410);
            this.wifi.Name = "wifi";
            this.wifi.Size = new System.Drawing.Size(518, 20);
            this.wifi.TabIndex = 14;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(96, 390);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 26;
            this.label16.Text = "联系方式";
            // 
            // contact
            // 
            this.contact.Location = new System.Drawing.Point(162, 384);
            this.contact.Name = "contact";
            this.contact.Size = new System.Drawing.Size(518, 20);
            this.contact.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(96, 361);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "如何抵达";
            // 
            // local_address
            // 
            this.local_address.Location = new System.Drawing.Point(162, 355);
            this.local_address.Name = "local_address";
            this.local_address.Size = new System.Drawing.Size(518, 20);
            this.local_address.TabIndex = 12;
            // 
            // room
            // 
            this.room.FormattingEnabled = true;
            this.room.Location = new System.Drawing.Point(162, 226);
            this.room.Name = "room";
            this.room.Size = new System.Drawing.Size(516, 21);
            this.room.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(414, 202);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "几晚";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(120, 330);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "地址";
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(162, 322);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(518, 20);
            this.address.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(108, 298);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "经纬度";
            // 
            // latlng
            // 
            this.latlng.Location = new System.Drawing.Point(162, 293);
            this.latlng.Name = "latlng";
            this.latlng.Size = new System.Drawing.Size(518, 20);
            this.latlng.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(96, 203);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "入住日期";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.cancelButton.Location = new System.Drawing.Point(608, 567);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 20;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.saveButton.Location = new System.Drawing.Point(527, 567);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 25);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(162, 331);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(100, 499);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "深度Tips";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(120, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "早餐";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(96, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "预定房型";
            // 
            // findFileButton
            // 
            this.findFileButton.Location = new System.Drawing.Point(651, 165);
            this.findFileButton.Name = "findFileButton";
            this.findFileButton.Size = new System.Drawing.Size(32, 20);
            this.findFileButton.TabIndex = 5;
            this.findFileButton.Text = "...";
            this.findFileButton.UseVisualStyleBackColor = true;
            this.findFileButton.Click += new System.EventHandler(this.findFileButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(120, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "图片";
            // 
            // cityComboBox
            // 
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(449, 74);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(233, 21);
            this.cityComboBox.TabIndex = 1;
            // 
            // nationComboBox
            // 
            this.nationComboBox.FormattingEnabled = true;
            this.nationComboBox.Location = new System.Drawing.Point(164, 74);
            this.nationComboBox.Name = "nationComboBox";
            this.nationComboBox.Size = new System.Drawing.Size(233, 21);
            this.nationComboBox.TabIndex = 0;
            this.nationComboBox.SelectedIndexChanged += new System.EventHandler(this.nationComboBox_SelectedIndexChanged);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(164, 492);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(518, 56);
            this.textBox6.TabIndex = 18;
            // 
            // moringTextBox
            // 
            this.moringTextBox.Location = new System.Drawing.Point(162, 262);
            this.moringTextBox.Name = "moringTextBox";
            this.moringTextBox.Size = new System.Drawing.Size(518, 20);
            this.moringTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "英文名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "中文名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "城市";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(20, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(673, 44);
            this.label2.TabIndex = 3;
            this.label2.Text = "新建住宿";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgPathTextBox
            // 
            this.imgPathTextBox.Location = new System.Drawing.Point(164, 167);
            this.imgPathTextBox.Name = "imgPathTextBox";
            this.imgPathTextBox.Size = new System.Drawing.Size(481, 20);
            this.imgPathTextBox.TabIndex = 4;
            // 
            // localTitleTextBox
            // 
            this.localTitleTextBox.Location = new System.Drawing.Point(164, 137);
            this.localTitleTextBox.Name = "localTitleTextBox";
            this.localTitleTextBox.Size = new System.Drawing.Size(518, 20);
            this.localTitleTextBox.TabIndex = 3;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(164, 108);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(518, 20);
            this.titleTextBox.TabIndex = 2;
            this.titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "国家";
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = null;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // NewHotelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 601);
            this.Controls.Add(this.closeAtDateTimePicker);
            this.Controls.Add(this.openAtDateTimePicker);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.kitchen);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.reception);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.parking);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.wifi);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.contact);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.local_address);
            this.Controls.Add(this.room);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.address);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.latlng);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.findFileButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cityComboBox);
            this.Controls.Add(this.nationComboBox);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.moringTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imgPathTextBox);
            this.Controls.Add(this.localTitleTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label1);
            this.Name = "NewHotelForm";
            this.Text = "新建餐厅";
            this.Load += new System.EventHandler(this.NewDinningsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox moringTextBox;
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label11;
        private CustomComponents.EntityDataSource entityDataSource1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox latlng;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox room;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox local_address;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox contact;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox wifi;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox parking;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox reception;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox kitchen;
        private System.Windows.Forms.DateTimePicker openAtDateTimePicker;
        private System.Windows.Forms.DateTimePicker closeAtDateTimePicker;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}