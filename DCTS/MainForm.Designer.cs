﻿namespace DCTS
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
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入餐厅信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入住宿信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.entityDataSource = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.路ToolStripMenuItem,
            this.客户信息ToolStripMenuItem1,
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
            this.客户信息ToolStripMenuItem1.Name = "客户信息ToolStripMenuItem1";
            this.客户信息ToolStripMenuItem1.Size = new System.Drawing.Size(67, 20);
            this.客户信息ToolStripMenuItem1.Text = "客户信息";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nationsToolStripMenuItem,
            this.导入餐厅信息ToolStripMenuItem,
            this.导入住宿信息ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // nationsToolStripMenuItem
            // 
            this.nationsToolStripMenuItem.Name = "nationsToolStripMenuItem";
            this.nationsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nationsToolStripMenuItem.Text = "国家信息";
            // 
            // 导入餐厅信息ToolStripMenuItem
            // 
            this.导入餐厅信息ToolStripMenuItem.Name = "导入餐厅信息ToolStripMenuItem";
            this.导入餐厅信息ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.导入餐厅信息ToolStripMenuItem.Text = "导入餐厅信息";
            this.导入餐厅信息ToolStripMenuItem.Click += new System.EventHandler(this.导入餐厅信息ToolStripMenuItem_Click);
            // 
            // 导入住宿信息ToolStripMenuItem
            // 
            this.导入住宿信息ToolStripMenuItem.Name = "导入住宿信息ToolStripMenuItem";
            this.导入住宿信息ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.导入住宿信息ToolStripMenuItem.Text = "导入住宿信息";
            this.导入住宿信息ToolStripMenuItem.Click += new System.EventHandler(this.导入住宿信息ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
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
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "导入景点信息";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 411);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip2);
            this.Name = "MainForm";
            this.Text = "深度定制行程管理系统";
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
        private System.Windows.Forms.ToolStripMenuItem nationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入餐厅信息ToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem 导入住宿信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

