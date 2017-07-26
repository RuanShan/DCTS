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
            this.components = new System.ComponentModel.Container();
            this.shellView1 = new GongSolutions.Shell.ShellView();
            this.shellTreeView1 = new GongSolutions.Shell.ShellTreeView();
            this.shellNotificationListener1 = new GongSolutions.Shell.ShellNotificationListener(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // shellView1
            // 
            this.shellView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shellView1.Location = new System.Drawing.Point(0, 0);
            this.shellView1.Name = "shellView1";
            this.shellView1.Size = new System.Drawing.Size(512, 427);
            this.shellView1.StatusBar = null;
            this.shellView1.TabIndex = 2;
            this.shellView1.Text = "shellView1";
            // 
            // shellTreeView1
            // 
            this.shellTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.shellTreeView1.Location = new System.Drawing.Point(3, 53);
            this.shellTreeView1.Name = "shellTreeView1";
            this.shellTreeView1.ShellView = this.shellView1;
            this.shellTreeView1.Size = new System.Drawing.Size(215, 429);
            this.shellTreeView1.TabIndex = 1;
            // 
            // shellNotificationListener1
            // 
            this.shellNotificationListener1.FolderCreated += new GongSolutions.Shell.ShellItemEventHandler(this.shellNotificationListener1_FolderCreated);
            this.shellNotificationListener1.FolderDeleted += new GongSolutions.Shell.ShellItemEventHandler(this.shellNotificationListener1_FolderDeleted);
            this.shellNotificationListener1.FolderRenamed += new GongSolutions.Shell.ShellItemChangeEventHandler(this.shellNotificationListener1_FolderRenamed);
            this.shellNotificationListener1.ItemCreated += new GongSolutions.Shell.ShellItemEventHandler(this.shellNotificationListener1_ItemCreated);
            this.shellNotificationListener1.ItemDeleted += new GongSolutions.Shell.ShellItemEventHandler(this.shellNotificationListener1_ItemDeleted);
            this.shellNotificationListener1.ItemRenamed += new GongSolutions.Shell.ShellItemChangeEventHandler(this.shellNotificationListener1_ItemRenamed);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.shellView1);
            this.panel1.Location = new System.Drawing.Point(224, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 429);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 50);
            this.label2.TabIndex = 15;
            this.label2.Text = "系统素材";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ImageExplorerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shellTreeView1);
            this.Controls.Add(this.panel1);
            this.Name = "ImageExplorerControl";
            this.Size = new System.Drawing.Size(741, 485);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GongSolutions.Shell.ShellTreeView shellTreeView1;
        private GongSolutions.Shell.ShellView shellView1;
        private GongSolutions.Shell.ShellNotificationListener shellNotificationListener1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}
