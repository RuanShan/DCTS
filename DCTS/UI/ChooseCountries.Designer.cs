namespace DCTS.UI
{
    partial class ChooseCountries
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yesButton2 = new System.Windows.Forms.Button();
            this.noButton1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn1,
            this.nameColumn1});
            this.dataGridView1.Location = new System.Drawing.Point(12, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(471, 230);
            this.dataGridView1.TabIndex = 4;
            // 
            // idColumn1
            // 
            this.idColumn1.DataPropertyName = "id";
            this.idColumn1.HeaderText = "编号";
            this.idColumn1.Name = "idColumn1";
            // 
            // nameColumn1
            // 
            this.nameColumn1.DataPropertyName = "title";
            this.nameColumn1.HeaderText = "名称";
            this.nameColumn1.Name = "nameColumn1";
            this.nameColumn1.Width = 360;
            // 
            // yesButton2
            // 
            this.yesButton2.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.yesButton2.Location = new System.Drawing.Point(327, 322);
            this.yesButton2.Name = "yesButton2";
            this.yesButton2.Size = new System.Drawing.Size(75, 23);
            this.yesButton2.TabIndex = 7;
            this.yesButton2.Text = "确定";
            this.yesButton2.UseVisualStyleBackColor = true;
            this.yesButton2.Click += new System.EventHandler(this.yesButton2_Click);
            // 
            // noButton1
            // 
            this.noButton1.DialogResult = System.Windows.Forms.DialogResult.No;
            this.noButton1.Location = new System.Drawing.Point(408, 322);
            this.noButton1.Name = "noButton1";
            this.noButton1.Size = new System.Drawing.Size(75, 23);
            this.noButton1.TabIndex = 8;
            this.noButton1.Text = "取消";
            this.noButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "国家信息";
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DCTS.DctsEntities);
            // 
            // ChooseCountries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 364);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.yesButton2);
            this.Controls.Add(this.noButton1);
            this.Controls.Add(this.label1);
            this.Name = "ChooseCountries";
            this.Text = "ChooseCountries";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button yesButton2;
        private System.Windows.Forms.Button noButton1;
        private System.Windows.Forms.Label label1;
        private CustomComponents.EntityDataSource entityDataSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn1;
    }
}