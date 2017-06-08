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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.idColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uploadColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.downloadColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.titleColumn1,
            this.word,
            this.uploadColumn1,
            this.downloadColumn1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 50;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(658, 262);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // idColumn1
            // 
            this.idColumn1.DataPropertyName = "id";
            this.idColumn1.HeaderText = "序号";
            this.idColumn1.Name = "idColumn1";
            this.idColumn1.Width = 60;
            // 
            // titleColumn1
            // 
            this.titleColumn1.DataPropertyName = "title";
            this.titleColumn1.HeaderText = "名称";
            this.titleColumn1.Name = "titleColumn1";
            // 
            // word
            // 
            this.word.DataPropertyName = "word";
            this.word.HeaderText = "模板文档";
            this.word.Name = "word";
            this.word.Width = 180;
            // 
            // uploadColumn1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2, 12, 1, 12);
            this.uploadColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.uploadColumn1.HeaderText = "";
            this.uploadColumn1.Name = "uploadColumn1";
            this.uploadColumn1.Text = "上传";
            this.uploadColumn1.UseColumnTextForButtonValue = true;
            this.uploadColumn1.Width = 60;
            // 
            // downloadColumn1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2, 12, 2, 12);
            this.downloadColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.downloadColumn1.HeaderText = "";
            this.downloadColumn1.Name = "downloadColumn1";
            this.downloadColumn1.Text = "下载";
            this.downloadColumn1.UseColumnTextForButtonValue = true;
            this.downloadColumn1.Width = 60;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 50);
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
            this.tabControl1.Location = new System.Drawing.Point(8, 69);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(672, 294);
            this.tabControl1.TabIndex = 15;
            // 
            // airTagPage
            // 
            this.airTagPage.Controls.Add(this.dataGridView);
            this.airTagPage.Location = new System.Drawing.Point(4, 22);
            this.airTagPage.Name = "airTagPage";
            this.airTagPage.Padding = new System.Windows.Forms.Padding(3);
            this.airTagPage.Size = new System.Drawing.Size(664, 268);
            this.airTagPage.TabIndex = 0;
            this.airTagPage.Text = "航空公司";
            this.airTagPage.UseVisualStyleBackColor = true;
            // 
            // insuranceTagPage
            // 
            this.insuranceTagPage.Location = new System.Drawing.Point(4, 22);
            this.insuranceTagPage.Name = "insuranceTagPage";
            this.insuranceTagPage.Padding = new System.Windows.Forms.Padding(3);
            this.insuranceTagPage.Size = new System.Drawing.Size(664, 229);
            this.insuranceTagPage.TabIndex = 1;
            this.insuranceTagPage.Text = "保险公司";
            this.insuranceTagPage.UseVisualStyleBackColor = true;
            // 
            // rantalTabPage
            // 
            this.rantalTabPage.Location = new System.Drawing.Point(4, 22);
            this.rantalTabPage.Name = "rantalTabPage";
            this.rantalTabPage.Size = new System.Drawing.Size(664, 229);
            this.rantalTabPage.TabIndex = 2;
            this.rantalTabPage.Text = "租车公司";
            this.rantalTabPage.UseVisualStyleBackColor = true;
            // 
            // wifiTabPage
            // 
            this.wifiTabPage.Location = new System.Drawing.Point(4, 22);
            this.wifiTabPage.Name = "wifiTabPage";
            this.wifiTabPage.Size = new System.Drawing.Size(664, 229);
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
            // SuppliersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Name = "SuppliersControl";
            this.Size = new System.Drawing.Size(688, 374);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn word;
        private System.Windows.Forms.DataGridViewButtonColumn uploadColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn downloadColumn1;

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage airTagPage;
        private System.Windows.Forms.TabPage insuranceTagPage;
        private System.Windows.Forms.TabPage rantalTabPage;
        private System.Windows.Forms.TabPage wifiTabPage;
    }
}
