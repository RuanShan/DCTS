namespace DCTS.UI
{
    partial class TripListControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.addTripButton = new System.Windows.Forms.Button();
            this.tripDataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daysColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tripTitleColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tripMemoColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editTripDaysColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.editTripColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.copyTripColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.deleteTripColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tripDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addTripButton
            // 
            this.addTripButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addTripButton.Location = new System.Drawing.Point(798, 18);
            this.addTripButton.Name = "addTripButton";
            this.addTripButton.Size = new System.Drawing.Size(75, 23);
            this.addTripButton.TabIndex = 4;
            this.addTripButton.Text = "新建";
            this.addTripButton.UseVisualStyleBackColor = true;
            this.addTripButton.Click += new System.EventHandler(this.addTripButton_Click);
            // 
            // tripDataGridView
            // 
            this.tripDataGridView.AllowUserToAddRows = false;
            this.tripDataGridView.AllowUserToDeleteRows = false;
            this.tripDataGridView.AllowUserToResizeRows = false;
            this.tripDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tripDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tripDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.daysColumn1,
            this.tripTitleColumn1,
            this.tripMemoColumn1,
            this.editTripDaysColumn1,
            this.editTripColumn1,
            this.copyTripColumn1,
            this.deleteTripColumn1});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tripDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.tripDataGridView.Location = new System.Drawing.Point(9, 53);
            this.tripDataGridView.Name = "tripDataGridView";
            this.tripDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.tripDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.tripDataGridView.RowTemplate.Height = 34;
            this.tripDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tripDataGridView.Size = new System.Drawing.Size(864, 289);
            this.tripDataGridView.TabIndex = 3;
            this.tripDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tripDataGridView_CellContentClick);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 50);
            this.label2.TabIndex = 6;
            this.label2.Text = "模板列表";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Word文件（*.docx）|*.docx";
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DCTS.DctsEntities);
            // 
            // IdColumn
            // 
            this.IdColumn.DataPropertyName = "id";
            this.IdColumn.HeaderText = "ID";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.Width = 80;
            // 
            // daysColumn1
            // 
            this.daysColumn1.DataPropertyName = "days";
            this.daysColumn1.HeaderText = "天数";
            this.daysColumn1.Name = "daysColumn1";
            this.daysColumn1.Width = 80;
            // 
            // tripTitleColumn1
            // 
            this.tripTitleColumn1.DataPropertyName = "title";
            this.tripTitleColumn1.HeaderText = "名称";
            this.tripTitleColumn1.Name = "tripTitleColumn1";
            this.tripTitleColumn1.Width = 300;
            // 
            // tripMemoColumn1
            // 
            this.tripMemoColumn1.DataPropertyName = "memo";
            this.tripMemoColumn1.HeaderText = "备注";
            this.tripMemoColumn1.Name = "tripMemoColumn1";
            this.tripMemoColumn1.Width = 260;
            // 
            // editTripDaysColumn1
            // 
            this.editTripDaysColumn1.HeaderText = " ";
            this.editTripDaysColumn1.Name = "editTripDaysColumn1";
            this.editTripDaysColumn1.Text = "详细";
            this.editTripDaysColumn1.UseColumnTextForButtonValue = true;
            this.editTripDaysColumn1.Width = 60;
            // 
            // editTripColumn1
            // 
            this.editTripColumn1.HeaderText = "";
            this.editTripColumn1.Name = "editTripColumn1";
            this.editTripColumn1.Text = "编辑";
            this.editTripColumn1.UseColumnTextForButtonValue = true;
            this.editTripColumn1.Width = 60;
            // 
            // copyTripColumn1
            // 
            this.copyTripColumn1.HeaderText = " ";
            this.copyTripColumn1.Name = "copyTripColumn1";
            this.copyTripColumn1.Text = "复制";
            this.copyTripColumn1.UseColumnTextForButtonValue = true;
            this.copyTripColumn1.Width = 60;
            // 
            // deleteTripColumn1
            // 
            this.deleteTripColumn1.HeaderText = " ";
            this.deleteTripColumn1.Name = "deleteTripColumn1";
            this.deleteTripColumn1.Text = "删除";
            this.deleteTripColumn1.UseColumnTextForButtonValue = true;
            this.deleteTripColumn1.Width = 60;
            // 
            // TripListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addTripButton);
            this.Controls.Add(this.tripDataGridView);
            this.Name = "TripListControl";
            this.Size = new System.Drawing.Size(882, 380);
            this.Load += new System.EventHandler(this.TripListControl_Load);
            this.Resize += new System.EventHandler(this.TripListControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tripDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addTripButton;
        private System.Windows.Forms.DataGridView tripDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private CustomComponents.EntityDataSource entityDataSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn daysColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tripTitleColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tripMemoColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn editTripDaysColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn editTripColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn copyTripColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn deleteTripColumn1;
    }
}
