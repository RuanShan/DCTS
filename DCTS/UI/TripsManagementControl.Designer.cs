namespace DCTS.UI
{
    partial class TripsManagementControl
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
            this.tripsControl = new DCTS.UI.TripListControl();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tripsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scenicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dinningsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.活动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tripsControl
            // 
            this.tripsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tripsControl.Location = new System.Drawing.Point(0, 0);
            this.tripsControl.Name = "tripsControl";
            this.tripsControl.Size = new System.Drawing.Size(690, 379);
            this.tripsControl.TabIndex = 1;
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.SystemColors.Window;
            this.mainPanel.Controls.Add(this.tripsControl);
            this.mainPanel.Location = new System.Drawing.Point(69, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(690, 379);
            this.mainPanel.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tripsToolStripMenuItem,
            this.scenicsToolStripMenuItem,
            this.dinningsToolStripMenuItem,
            this.hotelsToolStripMenuItem,
            this.活动ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(98, 393);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tripsToolStripMenuItem
            // 
            this.tripsToolStripMenuItem.Name = "tripsToolStripMenuItem";
            this.tripsToolStripMenuItem.Size = new System.Drawing.Size(85, 19);
            this.tripsToolStripMenuItem.Text = "行程";
            this.tripsToolStripMenuItem.Click += new System.EventHandler(this.tripsToolStripMenuItem_Click);
            // 
            // scenicsToolStripMenuItem
            // 
            this.scenicsToolStripMenuItem.Name = "scenicsToolStripMenuItem";
            this.scenicsToolStripMenuItem.Size = new System.Drawing.Size(85, 19);
            this.scenicsToolStripMenuItem.Text = "景点";
            this.scenicsToolStripMenuItem.Click += new System.EventHandler(this.scenicsToolStripMenuItem_Click);
            // 
            // dinningsToolStripMenuItem
            // 
            this.dinningsToolStripMenuItem.Name = "dinningsToolStripMenuItem";
            this.dinningsToolStripMenuItem.Size = new System.Drawing.Size(85, 19);
            this.dinningsToolStripMenuItem.Text = "餐厅";
            this.dinningsToolStripMenuItem.Click += new System.EventHandler(this.dinningsToolStripMenuItem_Click);
            // 
            // hotelsToolStripMenuItem
            // 
            this.hotelsToolStripMenuItem.Name = "hotelsToolStripMenuItem";
            this.hotelsToolStripMenuItem.Size = new System.Drawing.Size(85, 19);
            this.hotelsToolStripMenuItem.Text = "住宿";
            // 
            // 活动ToolStripMenuItem
            // 
            this.活动ToolStripMenuItem.Enabled = false;
            this.活动ToolStripMenuItem.Name = "活动ToolStripMenuItem";
            this.活动ToolStripMenuItem.Size = new System.Drawing.Size(85, 19);
            this.活动ToolStripMenuItem.Text = "活动";
            // 
            // TripsManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.mainPanel);
            this.Name = "TripsManagementControl";
            this.Size = new System.Drawing.Size(762, 393);
            this.mainPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TripListControl tripsControl;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tripsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scenicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dinningsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 活动ToolStripMenuItem;
    }
}
