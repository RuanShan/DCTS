namespace DCTS.UI
{
    partial class NewCustomerTripForm
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
            this.findTemplateButton = new System.Windows.Forms.Button();
            this.findCustomerButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.daysNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.tripComboBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.memoTextBox = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.daysNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // findTemplateButton
            // 
            this.findTemplateButton.Enabled = false;
            this.findTemplateButton.Location = new System.Drawing.Point(460, 106);
            this.findTemplateButton.Name = "findTemplateButton";
            this.findTemplateButton.Size = new System.Drawing.Size(45, 23);
            this.findTemplateButton.TabIndex = 36;
            this.findTemplateButton.Text = "选择";
            this.findTemplateButton.UseVisualStyleBackColor = true;
            // 
            // findCustomerButton
            // 
            this.findCustomerButton.Enabled = false;
            this.findCustomerButton.Location = new System.Drawing.Point(460, 70);
            this.findCustomerButton.Name = "findCustomerButton";
            this.findCustomerButton.Size = new System.Drawing.Size(45, 23);
            this.findCustomerButton.TabIndex = 35;
            this.findCustomerButton.Text = "选择";
            this.findCustomerButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "天数";
            // 
            // daysNumericUpDown
            // 
            this.daysNumericUpDown.Location = new System.Drawing.Point(65, 175);
            this.daysNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.daysNumericUpDown.Name = "daysNumericUpDown";
            this.daysNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.daysNumericUpDown.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "备注";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(65, 143);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(440, 21);
            this.titleTextBox.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 34;
            this.label4.Text = "模板";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 33;
            this.label6.Text = "客户";
            // 
            // customerComboBox
            // 
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(65, 73);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(389, 20);
            this.customerComboBox.TabIndex = 32;
            // 
            // tripComboBox
            // 
            this.tripComboBox.FormattingEnabled = true;
            this.tripComboBox.Location = new System.Drawing.Point(65, 108);
            this.tripComboBox.Name = "tripComboBox";
            this.tripComboBox.Size = new System.Drawing.Size(389, 20);
            this.tripComboBox.TabIndex = 31;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.cancelButton.Location = new System.Drawing.Point(430, 306);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.saveButton.Location = new System.Drawing.Point(349, 306);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(524, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "新建路书";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // memoTextBox
            // 
            this.memoTextBox.Location = new System.Drawing.Point(65, 208);
            this.memoTextBox.Multiline = true;
            this.memoTextBox.Name = "memoTextBox";
            this.memoTextBox.Size = new System.Drawing.Size(440, 82);
            this.memoTextBox.TabIndex = 28;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DCTS.DctsEntities);
            // 
            // NewCustomerTripForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 358);
            this.Controls.Add(this.findTemplateButton);
            this.Controls.Add(this.findCustomerButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.daysNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.customerComboBox);
            this.Controls.Add(this.tripComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.memoTextBox);
            this.Name = "NewCustomerTripForm";
            this.Text = "新建路书";
            ((System.ComponentModel.ISupportInitialize)(this.daysNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown daysNumericUpDown;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.ComboBox tripComboBox;
        private System.Windows.Forms.TextBox memoTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.Button findCustomerButton;
        private System.Windows.Forms.Button findTemplateButton;
        private CustomComponents.EntityDataSource entityDataSource1;
    }
}