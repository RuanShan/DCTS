namespace DCTS.UI
{
    partial class EditScenicForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.scenicFormControl1 = new DCTS.UI.ScenicFormControl();
            this.label2 = new System.Windows.Forms.Label();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.cancelButton.Location = new System.Drawing.Point(538, 463);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.saveButton.Location = new System.Drawing.Point(457, 463);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 25);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.scenicFormControl1);
            this.panel1.Location = new System.Drawing.Point(27, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 375);
            this.panel1.TabIndex = 5;
            // 
            // scenicFormControl1
            // 
            this.scenicFormControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scenicFormControl1.Location = new System.Drawing.Point(0, 0);
            this.scenicFormControl1.Name = "scenicFormControl1";
            this.scenicFormControl1.Size = new System.Drawing.Size(636, 375);
            this.scenicFormControl1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(671, 44);
            this.label2.TabIndex = 4;
            this.label2.Text = "编辑景点";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DCTS.DctsEntities);
            // 
            // EditScenicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 525);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Name = "EditScenicForm";
            this.Text = "EditScenicForm";
            this.Load += new System.EventHandler(this.EditScenicForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private ScenicFormControl scenicFormControl1;
        private CustomComponents.EntityDataSource entityDataSource1;
    }
}