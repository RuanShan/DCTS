namespace DCTS.UI
{
    partial class ImageExplorerControl
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
            this.shellComboBox1 = new GongSolutions.Shell.ShellComboBox();
            this.shellTreeView1 = new GongSolutions.Shell.ShellTreeView();
            this.shellView1 = new GongSolutions.Shell.ShellView();
            this.SuspendLayout();
            // 
            // shellComboBox1
            // 
            this.shellComboBox1.Location = new System.Drawing.Point(3, 57);
            this.shellComboBox1.Name = "shellComboBox1";
            this.shellComboBox1.ShellView = this.shellView1;
            this.shellComboBox1.Size = new System.Drawing.Size(735, 23);
            this.shellComboBox1.TabIndex = 0;
            this.shellComboBox1.Text = "shellComboBox1";
            // 
            // shellTreeView1
            // 
            this.shellTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.shellTreeView1.Location = new System.Drawing.Point(3, 86);
            this.shellTreeView1.Name = "shellTreeView1";
            this.shellTreeView1.ShellView = this.shellView1;
            this.shellTreeView1.Size = new System.Drawing.Size(215, 396);
            this.shellTreeView1.TabIndex = 1;
            // 
            // shellView1
            // 
            this.shellView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shellView1.Location = new System.Drawing.Point(224, 86);
            this.shellView1.Name = "shellView1";
            this.shellView1.Size = new System.Drawing.Size(514, 396);
            this.shellView1.StatusBar = null;
            this.shellView1.TabIndex = 2;
            this.shellView1.Text = "shellView1";
            // 
            // ImageExplorerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.shellView1);
            this.Controls.Add(this.shellTreeView1);
            this.Controls.Add(this.shellComboBox1);
            this.Name = "ImageExplorerControl";
            this.Size = new System.Drawing.Size(741, 485);
            this.ResumeLayout(false);

        }

        #endregion

        private GongSolutions.Shell.ShellComboBox shellComboBox1;
        private GongSolutions.Shell.ShellTreeView shellTreeView1;
        private GongSolutions.Shell.ShellView shellView1;
    }
}
