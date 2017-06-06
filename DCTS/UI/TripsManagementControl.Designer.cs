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
            this.bookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tripsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scenicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dinningsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.其他ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.airportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mainPanel.Location = new System.Drawing.Point(68, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(691, 338);
            this.mainPanel.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookToolStripMenuItem,
            this.tripsToolStripMenuItem,
            this.scenicsToolStripMenuItem,
            this.dinningsToolStripMenuItem,
            this.hotelsToolStripMenuItem,
            this.NationToolStripMenuItem,
            this.airportToolStripMenuItem,
            this.其他ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 12, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(98, 363);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bookToolStripMenuItem
            // 
            this.bookToolStripMenuItem.Name = "bookToolStripMenuItem";
            this.bookToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.bookToolStripMenuItem.Text = "路书";
            this.bookToolStripMenuItem.Click += new System.EventHandler(this.bookToolStripMenuItem_Click);
            // 
            // tripsToolStripMenuItem
            // 
            this.tripsToolStripMenuItem.Checked = true;
            this.tripsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tripsToolStripMenuItem.Name = "tripsToolStripMenuItem";
            this.tripsToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.tripsToolStripMenuItem.Text = "模板";
            this.tripsToolStripMenuItem.Click += new System.EventHandler(this.tripsToolStripMenuItem_Click);
            // 
            // scenicsToolStripMenuItem
            // 
            this.scenicsToolStripMenuItem.Name = "scenicsToolStripMenuItem";
            this.scenicsToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.scenicsToolStripMenuItem.Text = "景点";
            this.scenicsToolStripMenuItem.Click += new System.EventHandler(this.scenicsToolStripMenuItem_Click);
            // 
            // dinningsToolStripMenuItem
            // 
            this.dinningsToolStripMenuItem.Name = "dinningsToolStripMenuItem";
            this.dinningsToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.dinningsToolStripMenuItem.Text = "餐厅";
            this.dinningsToolStripMenuItem.Click += new System.EventHandler(this.dinningsToolStripMenuItem_Click);
            // 
            // hotelsToolStripMenuItem
            // 
            this.hotelsToolStripMenuItem.Name = "hotelsToolStripMenuItem";
            this.hotelsToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.hotelsToolStripMenuItem.Text = "住宿";
            this.hotelsToolStripMenuItem.Click += new System.EventHandler(this.hotelsToolStripMenuItem_Click);
            // 
            // NationToolStripMenuItem
            // 
            this.NationToolStripMenuItem.Name = "NationToolStripMenuItem";
            this.NationToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.NationToolStripMenuItem.Text = "国家";
            this.NationToolStripMenuItem.Click += new System.EventHandler(this.NationToolStripMenuItem_Click);
            // 
            // 其他ToolStripMenuItem
            // 
            this.其他ToolStripMenuItem.Name = "其他ToolStripMenuItem";
            this.其他ToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.其他ToolStripMenuItem.Text = "其他";
            this.其他ToolStripMenuItem.Click += new System.EventHandler(this.otherToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(98, 341);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(664, 22);
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
            // airportToolStripMenuItem
            // 
            this.airportToolStripMenuItem.Name = "airportToolStripMenuItem";
            this.airportToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.airportToolStripMenuItem.Text = "机场";
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tripsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scenicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dinningsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NationToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 其他ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem airportToolStripMenuItem;
    }
}
