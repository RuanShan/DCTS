namespace DCTS.UI
{
    partial class ChooseCustomersForm
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
            this.pager1 = new DCTS.CustomComponents.Pager();
            this.label1 = new System.Windows.Forms.Label();
            this.noButton1 = new System.Windows.Forms.Button();
            this.yesButton2 = new System.Windows.Forms.Button();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.idColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genderColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAtColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.nameColumn1,
            this.genderColumn1,
            this.createdAtColumn1});
            this.dataGridView1.Location = new System.Drawing.Point(12, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(471, 230);
            this.dataGridView1.TabIndex = 0;
            // 
            // pager1
            // 
            this.pager1.AutoSize = true;
            this.pager1.Location = new System.Drawing.Point(12, 317);
            this.pager1.Name = "pager1";
            this.pager1.NMax = 0;
            this.pager1.PageCount = 0;
            this.pager1.PageCurrent = 1;
            this.pager1.PageSize = 25;
            this.pager1.Size = new System.Drawing.Size(471, 28);
            this.pager1.TabIndex = 1;
            this.pager1.EventPaging += new DCTS.CustomComponents.EventPagingHandler(this.pager1_EventPaging);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "客户信息";
            // 
            // noButton1
            // 
            this.noButton1.DialogResult = System.Windows.Forms.DialogResult.No;
            this.noButton1.Location = new System.Drawing.Point(408, 368);
            this.noButton1.Name = "noButton1";
            this.noButton1.Size = new System.Drawing.Size(75, 23);
            this.noButton1.TabIndex = 3;
            this.noButton1.Text = "取消";
            this.noButton1.UseVisualStyleBackColor = true;
            // 
            // yesButton2
            // 
            this.yesButton2.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.yesButton2.Location = new System.Drawing.Point(327, 368);
            this.yesButton2.Name = "yesButton2";
            this.yesButton2.Size = new System.Drawing.Size(75, 23);
            this.yesButton2.TabIndex = 3;
            this.yesButton2.Text = "确定";
            this.yesButton2.UseVisualStyleBackColor = true;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DCTS.DctsEntities);
            // 
            // idColumn1
            // 
            this.idColumn1.DataPropertyName = "id";
            this.idColumn1.HeaderText = "编号";
            this.idColumn1.Name = "idColumn1";
            // 
            // nameColumn1
            // 
            this.nameColumn1.DataPropertyName = "name";
            this.nameColumn1.HeaderText = "姓名";
            this.nameColumn1.Name = "nameColumn1";
            // 
            // genderColumn1
            // 
            this.genderColumn1.DataPropertyName = "gender";
            this.genderColumn1.HeaderText = "性别";
            this.genderColumn1.Name = "genderColumn1";
            // 
            // createdAtColumn1
            // 
            this.createdAtColumn1.DataPropertyName = "created_at";
            this.createdAtColumn1.HeaderText = "创建时间";
            this.createdAtColumn1.Name = "createdAtColumn1";
            // 
            // ChooseCustomersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 415);
            this.Controls.Add(this.yesButton2);
            this.Controls.Add(this.noButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pager1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ChooseCustomersForm";
            this.Text = "ChooseCustomersForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private CustomComponents.Pager pager1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button noButton1;
        private System.Windows.Forms.Button yesButton2;
        private CustomComponents.EntityDataSource entityDataSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn genderColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdAtColumn1;
    }
}