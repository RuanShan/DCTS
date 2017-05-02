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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tripsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scenicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dinningsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.活动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tripsControl = new DCTS.UI.TripListControl();
            this.mainPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.SystemColors.Window;
            this.mainPanel.Controls.Add(this.tripsControl);
            this.mainPanel.Location = new System.Drawing.Point(50, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(709, 338);
            this.mainPanel.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tripsToolStripMenuItem,
            this.scenicsToolStripMenuItem,
            this.dinningsToolStripMenuItem,
            this.hotelsToolStripMenuItem,
            this.活动ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(50, 363);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tripsToolStripMenuItem
            // 
            this.tripsToolStripMenuItem.Checked = true;
            this.tripsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tripsToolStripMenuItem.Name = "tripsToolStripMenuItem";
            this.tripsToolStripMenuItem.Size = new System.Drawing.Size(37, 21);
            this.tripsToolStripMenuItem.Text = "行程";
            this.tripsToolStripMenuItem.Click += new System.EventHandler(this.tripsToolStripMenuItem_Click);
            // 
            // scenicsToolStripMenuItem
            // 
            this.scenicsToolStripMenuItem.Name = "scenicsToolStripMenuItem";
            this.scenicsToolStripMenuItem.Size = new System.Drawing.Size(37, 21);
            this.scenicsToolStripMenuItem.Text = "景点";
            this.scenicsToolStripMenuItem.Click += new System.EventHandler(this.scenicsToolStripMenuItem_Click);
            // 
            // dinningsToolStripMenuItem
            // 
            this.dinningsToolStripMenuItem.Name = "dinningsToolStripMenuItem";
            this.dinningsToolStripMenuItem.Size = new System.Drawing.Size(37, 21);
            this.dinningsToolStripMenuItem.Text = "餐厅";
            this.dinningsToolStripMenuItem.Click += new System.EventHandler(this.dinningsToolStripMenuItem_Click);
            // 
            // hotelsToolStripMenuItem
            // 
            this.hotelsToolStripMenuItem.Name = "hotelsToolStripMenuItem";
            this.hotelsToolStripMenuItem.Size = new System.Drawing.Size(37, 21);
            this.hotelsToolStripMenuItem.Text = "住宿";
            this.hotelsToolStripMenuItem.Click += new System.EventHandler(this.hotelsToolStripMenuItem_Click);
            // 
            // 活动ToolStripMenuItem
            // 
            this.活动ToolStripMenuItem.Enabled = false;
            this.活动ToolStripMenuItem.Name = "活动ToolStripMenuItem";
            this.活动ToolStripMenuItem.Size = new System.Drawing.Size(37, 21);
            this.活动ToolStripMenuItem.Text = "活动";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(50, 341);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(712, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "状态条";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // tripsControl
            // 
            this.tripsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tripsControl.Location = new System.Drawing.Point(0, 0);
            this.tripsControl.Name = "tripsControl";
            this.tripsControl.Size = new System.Drawing.Size(709, 338);
            this.tripsControl.TabIndex = 1;
            // 
            // TripsManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.mainPanel);
            this.Name = "TripsManagementControl";
            this.Size = new System.Drawing.Size(762, 363);
            this.mainPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}
