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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.路ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tripsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.客户信息ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.服务商信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSuppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importScenicExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入图片信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportnationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入餐厅信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入住宿信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.初始化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.entityDataSource = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.路ToolStripMenuItem,
            this.客户信息ToolStripMenuItem1,
            this.服务商信息ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(942, 24);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // 路ToolStripMenuItem
            // 
            this.路ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tripsToolStripMenuItem});
            this.路ToolStripMenuItem.Name = "路ToolStripMenuItem";
            this.路ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.路ToolStripMenuItem.Text = "旅遊信息";
            // 
            // tripsToolStripMenuItem
            // 
            this.tripsToolStripMenuItem.Name = "tripsToolStripMenuItem";
            this.tripsToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.tripsToolStripMenuItem.Text = "路书";
            this.tripsToolStripMenuItem.Click += new System.EventHandler(this.tripsToolStripMenuItem_Click);
            // 
            // 客户信息ToolStripMenuItem1
            // 
            this.客户信息ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomersToolStripMenuItem});
            this.客户信息ToolStripMenuItem1.Name = "客户信息ToolStripMenuItem1";
            this.客户信息ToolStripMenuItem1.Size = new System.Drawing.Size(67, 20);
            this.客户信息ToolStripMenuItem1.Text = "客户信息";
            // 
            // CustomersToolStripMenuItem
            // 
            this.CustomersToolStripMenuItem.Name = "CustomersToolStripMenuItem";
            this.CustomersToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.CustomersToolStripMenuItem.Text = "客户管理";
            this.CustomersToolStripMenuItem.Click += new System.EventHandler(this.CustomersToolStripMenuItem_Click);
            // 
            // 服务商信息ToolStripMenuItem
            // 
            this.服务商信息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.suppliersToolStripMenuItem,
            this.importSuppliersToolStripMenuItem});
            this.服务商信息ToolStripMenuItem.Name = "服务商信息ToolStripMenuItem";
<<<<<<< HEAD
            this.服务商信息ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
=======
            this.服务商信息ToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
>>>>>>> 3349e77a960015b0392289faeedaa9a500100070
            this.服务商信息ToolStripMenuItem.Text = "服务商信息";
            // 
            // suppliersToolStripMenuItem
            // 
            this.suppliersToolStripMenuItem.Name = "suppliersToolStripMenuItem";
<<<<<<< HEAD
            this.suppliersToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
=======
            this.suppliersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
>>>>>>> 3349e77a960015b0392289faeedaa9a500100070
            this.suppliersToolStripMenuItem.Text = "基本信息维护";
            this.suppliersToolStripMenuItem.Click += new System.EventHandler(this.suppliersToolStripMenuItem_Click);
            // 
            // importSuppliersToolStripMenuItem
            // 
            this.importSuppliersToolStripMenuItem.Name = "importSuppliersToolStripMenuItem";
<<<<<<< HEAD
            this.importSuppliersToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.importSuppliersToolStripMenuItem.Text = "数据导入";
=======
            this.importSuppliersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importSuppliersToolStripMenuItem.Text = "数据导入";
            this.importSuppliersToolStripMenuItem.Click += new System.EventHandler(this.importSuppliersToolStripMenuItem_Click);
>>>>>>> 3349e77a960015b0392289faeedaa9a500100070
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importScenicExcelToolStripMenuItem,
            this.导入图片信息ToolStripMenuItem,
            this.ImportnationToolStripMenuItem,
            this.导入餐厅信息ToolStripMenuItem,
            this.导入住宿信息ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.初始化ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // importScenicExcelToolStripMenuItem
            // 
            this.importScenicExcelToolStripMenuItem.Name = "importScenicExcelToolStripMenuItem";
            this.importScenicExcelToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.importScenicExcelToolStripMenuItem.Text = "导入Excel数据";
            this.importScenicExcelToolStripMenuItem.Click += new System.EventHandler(this.importScenicExcelToolStripMenuItem_Click);
            // 
            // 导入图片信息ToolStripMenuItem
            // 
            this.导入图片信息ToolStripMenuItem.Name = "导入图片信息ToolStripMenuItem";
            this.导入图片信息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.导入图片信息ToolStripMenuItem.Text = "导入图片信息";
            this.导入图片信息ToolStripMenuItem.Click += new System.EventHandler(this.导入图片信息ToolStripMenuItem_Click);
            // 
            // ImportnationToolStripMenuItem
            // 
            this.ImportnationToolStripMenuItem.Name = "ImportnationToolStripMenuItem";
            this.ImportnationToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.ImportnationToolStripMenuItem.Text = "导入国家信息";
            this.ImportnationToolStripMenuItem.Click += new System.EventHandler(this.ImportnationToolStripMenuItem_Click);
            // 
            // 导入餐厅信息ToolStripMenuItem
            // 
            this.导入餐厅信息ToolStripMenuItem.Enabled = false;
            this.导入餐厅信息ToolStripMenuItem.Name = "导入餐厅信息ToolStripMenuItem";
            this.导入餐厅信息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.导入餐厅信息ToolStripMenuItem.Text = "导入餐厅信息";
            this.导入餐厅信息ToolStripMenuItem.Click += new System.EventHandler(this.导入餐厅信息ToolStripMenuItem_Click);
            // 
            // 导入住宿信息ToolStripMenuItem
            // 
            this.导入住宿信息ToolStripMenuItem.Enabled = false;
            this.导入住宿信息ToolStripMenuItem.Name = "导入住宿信息ToolStripMenuItem";
            this.导入住宿信息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.导入住宿信息ToolStripMenuItem.Text = "导入住宿信息";
            this.导入住宿信息ToolStripMenuItem.Click += new System.EventHandler(this.导入住宿信息ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "导入景点信息";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 初始化ToolStripMenuItem
            // 
            this.初始化ToolStripMenuItem.Name = "初始化ToolStripMenuItem";
            this.初始化ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.初始化ToolStripMenuItem.Text = "系统初始化";
            this.初始化ToolStripMenuItem.Click += new System.EventHandler(this.初始化ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.aboutToolStripMenuItem.Text = "关于";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.mainPanel.Location = new System.Drawing.Point(0, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(942, 387);
            this.mainPanel.TabIndex = 3;
            // 
            // entityDataSource
            // 
            this.entityDataSource.DbContextType = typeof(DCTS.DctsEntities);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 411);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip2);
            this.Name = "MainForm";
            this.Text = "深度定制管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomComponents.EntityDataSource entityDataSource;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 路ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 客户信息ToolStripMenuItem1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStripMenuItem tripsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入餐厅信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入住宿信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importScenicExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 初始化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入图片信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportnationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 服务商信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSuppliersToolStripMenuItem;
    }
}

