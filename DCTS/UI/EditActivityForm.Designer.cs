namespace DCTS.UI
{
    partial class EditActivityForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.activityFormControl1 = new DCTS.UI.ActivityFormControl();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.cancelButton.Location = new System.Drawing.Point(544, 483);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.saveButton.Location = new System.Drawing.Point(463, 483);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(671, 41);
            this.label2.TabIndex = 4;
            this.label2.Text = "编辑活动";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DCTS.DctsEntities);
            // 
            // activityFormControl1
            // 
            this.activityFormControl1.Location = new System.Drawing.Point(17, 46);
            this.activityFormControl1.Name = "activityFormControl1";
            this.activityFormControl1.Size = new System.Drawing.Size(643, 431);
            this.activityFormControl1.TabIndex = 16;
            // 
            // EditActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 527);
            this.Controls.Add(this.activityFormControl1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Name = "EditActivityForm";
            this.Text = "编辑活动";
            this.Load += new System.EventHandler(this.EditScenicForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private CustomComponents.EntityDataSource entityDataSource1;
        private ActivityFormControl activityFormControl1;
    }
}