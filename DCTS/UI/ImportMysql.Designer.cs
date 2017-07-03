namespace DCTS.CustomComponents
{
    partial class ImportMysql
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cancelButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.openFileBtton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.upgradeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text Files (*)|**|All Files (*.*)|*.*";
            this.openFileDialog1.Title = "请选择数据库目录";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(314, 140);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(233, 140);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 12;
            this.importButton.Text = "确定";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(458, 23);
            this.label2.TabIndex = 16;
            this.label2.Text = "系统初始化";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "数据库安装目录";
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(125, 89);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(264, 21);
            this.pathTextBox.TabIndex = 19;
            // 
            // openFileBtton
            // 
            this.openFileBtton.Location = new System.Drawing.Point(395, 87);
            this.openFileBtton.Name = "openFileBtton";
            this.openFileBtton.Size = new System.Drawing.Size(44, 23);
            this.openFileBtton.TabIndex = 18;
            this.openFileBtton.Text = "选择";
            this.openFileBtton.UseVisualStyleBackColor = true;
            this.openFileBtton.Click += new System.EventHandler(this.openFileBtton_Click);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(1, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(463, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "所有客户数据将被删除，慎用";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // upgradeButton
            // 
            this.upgradeButton.Location = new System.Drawing.Point(152, 140);
            this.upgradeButton.Name = "upgradeButton";
            this.upgradeButton.Size = new System.Drawing.Size(75, 23);
            this.upgradeButton.TabIndex = 22;
            this.upgradeButton.Text = "升级";
            this.upgradeButton.UseVisualStyleBackColor = true;
            this.upgradeButton.Click += new System.EventHandler(this.upgradeButton_Click);
            // 
            // ImportMysql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 190);
            this.Controls.Add(this.upgradeButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.openFileBtton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportMysql";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统初始化";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button openFileBtton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button upgradeButton;
    }
}