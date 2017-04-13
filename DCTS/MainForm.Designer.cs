namespace DCTS
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.xingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.景点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.餐厅ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.住宿ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.客户信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.活动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tripsControl = new DCTS.UI.TripsControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.entityDataSource = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.路ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xingToolStripMenuItem,
            this.景点ToolStripMenuItem,
            this.餐厅ToolStripMenuItem,
            this.住宿ToolStripMenuItem,
            this.客户信息ToolStripMenuItem,
            this.活动ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 25);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(74, 354);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // xingToolStripMenuItem
            // 
            this.xingToolStripMenuItem.Name = "xingToolStripMenuItem";
            this.xingToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.xingToolStripMenuItem.Text = "行程";
            this.xingToolStripMenuItem.Click += new System.EventHandler(this.xingToolStripMenuItem_Click);
            // 
            // 景点ToolStripMenuItem
            // 
            this.景点ToolStripMenuItem.Name = "景点ToolStripMenuItem";
            this.景点ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.景点ToolStripMenuItem.Text = "景点";
            // 
            // 餐厅ToolStripMenuItem
            // 
            this.餐厅ToolStripMenuItem.Name = "餐厅ToolStripMenuItem";
            this.餐厅ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.餐厅ToolStripMenuItem.Text = "餐厅";
            // 
            // 住宿ToolStripMenuItem
            // 
            this.住宿ToolStripMenuItem.Name = "住宿ToolStripMenuItem";
            this.住宿ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.住宿ToolStripMenuItem.Text = "住宿";
            // 
            // 客户信息ToolStripMenuItem
            // 
            this.客户信息ToolStripMenuItem.Enabled = false;
            this.客户信息ToolStripMenuItem.Name = "客户信息ToolStripMenuItem";
            this.客户信息ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.客户信息ToolStripMenuItem.Text = "客户信息";
            // 
            // 活动ToolStripMenuItem
            // 
            this.活动ToolStripMenuItem.Enabled = false;
            this.活动ToolStripMenuItem.Name = "活动ToolStripMenuItem";
            this.活动ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.活动ToolStripMenuItem.Text = "活动";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(77, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(862, 351);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tripsControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(854, 325);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tripsControl
            // 
            this.tripsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tripsControl.Location = new System.Drawing.Point(3, 3);
            this.tripsControl.Name = "tripsControl";
            this.tripsControl.Size = new System.Drawing.Size(848, 319);
            this.tripsControl.TabIndex = 0;
            this.tripsControl.Load += new System.EventHandler(this.tripsControl_Load);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(854, 325);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(523, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(591, 292);
            this.dataGridView1.TabIndex = 0;
            // 
            // entityDataSource
            // 
            this.entityDataSource.DbContextType = typeof(DCTS.DctsEntities);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.路ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(942, 25);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 21);
            // 
            // 路ToolStripMenuItem
            // 
            this.路ToolStripMenuItem.Name = "路ToolStripMenuItem";
            this.路ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.路ToolStripMenuItem.Text = "旅遊信息";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 379);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "深度定制行程管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 景点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 餐厅ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 住宿ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 客户信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 活动ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CustomComponents.EntityDataSource entityDataSource;
        private UI.TripsControl tripsControl;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 路ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
    }
}

