namespace DCTS.UI
{
    partial class TripFormControl
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
            this.memoTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.daysNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.findFileButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.imgPathTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.daysNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // memoTextBox
            // 
            this.memoTextBox.Location = new System.Drawing.Point(43, 218);
            this.memoTextBox.Multiline = true;
            this.memoTextBox.Name = "memoTextBox";
            this.memoTextBox.Size = new System.Drawing.Size(440, 86);
            this.memoTextBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "备注";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(43, 9);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(440, 20);
            this.titleTextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "名称";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "天数";
            // 
            // daysNumericUpDown
            // 
            this.daysNumericUpDown.Location = new System.Drawing.Point(43, 43);
            this.daysNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.daysNumericUpDown.Name = "daysNumericUpDown";
            this.daysNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.daysNumericUpDown.TabIndex = 19;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(45, 106);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(233, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // findFileButton
            // 
            this.findFileButton.Location = new System.Drawing.Point(246, 72);
            this.findFileButton.Name = "findFileButton";
            this.findFileButton.Size = new System.Drawing.Size(32, 25);
            this.findFileButton.TabIndex = 22;
            this.findFileButton.Text = "...";
            this.findFileButton.UseVisualStyleBackColor = true;
            this.findFileButton.Click += new System.EventHandler(this.findFileButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "图片";
            // 
            // imgPathTextBox
            // 
            this.imgPathTextBox.Location = new System.Drawing.Point(45, 73);
            this.imgPathTextBox.Name = "imgPathTextBox";
            this.imgPathTextBox.Size = new System.Drawing.Size(195, 20);
            this.imgPathTextBox.TabIndex = 21;
            // 
            // TripFormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.findFileButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.imgPathTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.daysNumericUpDown);
            this.Controls.Add(this.memoTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label2);
            this.Name = "TripFormControl";
            this.Size = new System.Drawing.Size(528, 307);
            ((System.ComponentModel.ISupportInitialize)(this.daysNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox memoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public System.Windows.Forms.NumericUpDown daysNumericUpDown;
        public System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button findFileButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox imgPathTextBox;
    }
}
