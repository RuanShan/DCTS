﻿namespace DCTS.UI
{
    partial class NewNationForm
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
            this.label11 = new System.Windows.Forms.Label();
            this.findFileButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.docPathTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "PNG(*.png)JPEG(*.jpg,*.jpeg,*.jpe,*.jfif)GIF(*.gif)BMP(*.bmp)|*.png;*.jpg;*.jpeg;" +
    "*.jpe;*.jfif;*.gif;*.bmp";
            this.openFileDialog1.Title = "请选择国家文件";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.cancelButton.Location = new System.Drawing.Point(561, 226);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 18;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.saveButton.Location = new System.Drawing.Point(480, 226);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 25);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(60, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "深度Tips";
            // 
            // findFileButton
            // 
            this.findFileButton.Location = new System.Drawing.Point(597, 70);
            this.findFileButton.Name = "findFileButton";
            this.findFileButton.Size = new System.Drawing.Size(32, 25);
            this.findFileButton.TabIndex = 6;
            this.findFileButton.Text = "...";
            this.findFileButton.UseVisualStyleBackColor = true;
            this.findFileButton.Click += new System.EventHandler(this.findFileButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Word";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(118, 118);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(520, 56);
            this.textBox6.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(681, 44);
            this.label2.TabIndex = 3;
            this.label2.Text = "新建国家";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // docPathTextBox
            // 
            this.docPathTextBox.Location = new System.Drawing.Point(395, 71);
            this.docPathTextBox.Name = "docPathTextBox";
            this.docPathTextBox.Size = new System.Drawing.Size(200, 20);
            this.docPathTextBox.TabIndex = 5;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(118, 74);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(233, 20);
            this.titleTextBox.TabIndex = 2;
            this.titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 78);
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
            // NewNationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 274);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.findFileButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.docPathTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label1);
            this.Name = "NewNationForm";
            this.Text = "新建国家";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox docPathTextBox;
        private System.Windows.Forms.Button findFileButton;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label11;
        private CustomComponents.EntityDataSource entityDataSource1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}