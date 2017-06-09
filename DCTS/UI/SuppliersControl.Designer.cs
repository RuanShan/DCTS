namespace DCTS.UI
{
    partial class SuppliersControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.airTagPage = new System.Windows.Forms.TabPage();
            this.insuranceTagPage = new System.Windows.Forms.TabPage();
            this.rantalTabPage = new System.Windows.Forms.TabPage();
            this.wifiTabPage = new System.Windows.Forms.TabPage();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.idColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StypeColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imgColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cshColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.deleteColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.newButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.airTagPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn1,
            this.StypeColumn1,
            this.nameColumn1,
            this.imgColumn1,
            this.cshColumn1,
            this.editColumn1,
            this.deleteColumn1});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 50;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(658, 287);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 54);
            this.label2.TabIndex = 14;
            this.label2.Text = "服务供应商管理";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xslx";
            this.saveFileDialog1.Filter = "Doc(*.doc,*.docx)|*.doc;*.docx";
            this.saveFileDialog1.Title = "导出数据";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Doc(*.doc,*.docx)|*.doc;*.docx";
            this.openFileDialog1.Title = "请选择文件";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.airTagPage);
            this.tabControl1.Controls.Add(this.insuranceTagPage);
            this.tabControl1.Controls.Add(this.rantalTabPage);
            this.tabControl1.Controls.Add(this.wifiTabPage);
            this.tabControl1.Location = new System.Drawing.Point(8, 75);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(672, 319);
            this.tabControl1.TabIndex = 15;
            // 
            // airTagPage
            // 
            this.airTagPage.Controls.Add(this.dataGridView);
            this.airTagPage.Location = new System.Drawing.Point(4, 22);
            this.airTagPage.Name = "airTagPage";
            this.airTagPage.Padding = new System.Windows.Forms.Padding(3);
            this.airTagPage.Size = new System.Drawing.Size(664, 293);
            this.airTagPage.TabIndex = 0;
            this.airTagPage.Text = "航空公司";
            this.airTagPage.UseVisualStyleBackColor = true;
            // 
            // insuranceTagPage
            // 
            this.insuranceTagPage.Location = new System.Drawing.Point(4, 22);
            this.insuranceTagPage.Name = "insuranceTagPage";
            this.insuranceTagPage.Padding = new System.Windows.Forms.Padding(3);
            this.insuranceTagPage.Size = new System.Drawing.Size(664, 293);
            this.insuranceTagPage.TabIndex = 1;
            this.insuranceTagPage.Text = "保险公司";
            this.insuranceTagPage.UseVisualStyleBackColor = true;
            // 
            // rantalTabPage
            // 
            this.rantalTabPage.Location = new System.Drawing.Point(4, 22);
            this.rantalTabPage.Name = "rantalTabPage";
            this.rantalTabPage.Size = new System.Drawing.Size(664, 293);
            this.rantalTabPage.TabIndex = 2;
            this.rantalTabPage.Text = "租车公司";
            this.rantalTabPage.UseVisualStyleBackColor = true;
            // 
            // wifiTabPage
            // 
            this.wifiTabPage.Location = new System.Drawing.Point(4, 22);
            this.wifiTabPage.Name = "wifiTabPage";
            this.wifiTabPage.Size = new System.Drawing.Size(664, 293);
            this.wifiTabPage.TabIndex = 3;
            this.wifiTabPage.Text = "WIFI";
            this.wifiTabPage.UseVisualStyleBackColor = true;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DCTS.DctsEntities);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.entityDataSource1;
            this.bindingSource1.Position = 0;
            // 
            // idColumn1
            // 
            this.idColumn1.DataPropertyName = "id";
            this.idColumn1.HeaderText = "序号";
            this.idColumn1.Name = "idColumn1";
            this.idColumn1.Width = 60;
            // 
            // StypeColumn1
            // 
            this.StypeColumn1.DataPropertyName = "Stype";
            this.StypeColumn1.HeaderText = "类型";
            this.StypeColumn1.Name = "StypeColumn1";
            // 
            // nameColumn1
            // 
            this.nameColumn1.DataPropertyName = "name";
            this.nameColumn1.HeaderText = "名称";
            this.nameColumn1.Name = "nameColumn1";
            // 
            // imgColumn1
            // 
            this.imgColumn1.DataPropertyName = "img";
            this.imgColumn1.HeaderText = "图片";
            this.imgColumn1.Name = "imgColumn1";
            // 
            // cshColumn1
            // 
            this.cshColumn1.DataPropertyName = "csh";
            this.cshColumn1.HeaderText = "电话";
            this.cshColumn1.Name = "cshColumn1";
            // 
            // editColumn1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(2, 12, 1, 12);
            this.editColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.editColumn1.HeaderText = "";
            this.editColumn1.Name = "editColumn1";
            this.editColumn1.Text = "编辑";
            this.editColumn1.UseColumnTextForButtonValue = true;
            this.editColumn1.Width = 60;
            // 
            // deleteColumn1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2, 12, 2, 12);
            this.deleteColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.deleteColumn1.HeaderText = "";
            this.deleteColumn1.Name = "deleteColumn1";
            this.deleteColumn1.Text = "删除";
            this.deleteColumn1.UseColumnTextForButtonValue = true;
            this.deleteColumn1.Width = 60;
            // 
            // newButton
            // 
            this.newButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newButton.Location = new System.Drawing.Point(598, 18);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 25);
            this.newButton.TabIndex = 16;
            this.newButton.Text = "新建";
            this.newButton.UseVisualStyleBackColor = true;
            // 
            // SuppliersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Name = "SuppliersControl";
            this.Size = new System.Drawing.Size(688, 405);
            this.Resize += new System.EventHandler(this.NationsControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.airTagPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private CustomComponents.EntityDataSource entityDataSource1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage airTagPage;
        private System.Windows.Forms.TabPage insuranceTagPage;
        private System.Windows.Forms.TabPage rantalTabPage;
        private System.Windows.Forms.TabPage wifiTabPage;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StypeColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn imgColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cshColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn editColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn deleteColumn1;
        private System.Windows.Forms.Button newButton;
    }
}
