namespace DCTS.UI
{
    partial class EditTripControl
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
            this.addDayButton = new System.Windows.Forms.Button();
            this.addLocationButton = new System.Windows.Forms.Button();
            this.backLinkLabel = new System.Windows.Forms.LinkLabel();
            this.delDayButton = new System.Windows.Forms.Button();
            this.dayDataGridView = new System.Windows.Forms.DataGridView();
            this.dayDetailDataGridView = new System.Windows.Forms.DataGridView();
            this.dayNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.localtionTitleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dayDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayDetailDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addDayButton
            // 
            this.addDayButton.Location = new System.Drawing.Point(3, 320);
            this.addDayButton.Name = "addDayButton";
            this.addDayButton.Size = new System.Drawing.Size(36, 23);
            this.addDayButton.TabIndex = 1;
            this.addDayButton.Text = "+";
            this.addDayButton.UseVisualStyleBackColor = true;
            this.addDayButton.Click += new System.EventHandler(this.addDayButton_Click);
            // 
            // addLocationButton
            // 
            this.addLocationButton.Location = new System.Drawing.Point(518, 10);
            this.addLocationButton.Name = "addLocationButton";
            this.addLocationButton.Size = new System.Drawing.Size(75, 23);
            this.addLocationButton.TabIndex = 3;
            this.addLocationButton.Text = "添加";
            this.addLocationButton.UseVisualStyleBackColor = true;
            this.addLocationButton.Click += new System.EventHandler(this.addLocationButton_Click);
            // 
            // backLinkLabel
            // 
            this.backLinkLabel.AutoSize = true;
            this.backLinkLabel.Location = new System.Drawing.Point(3, 15);
            this.backLinkLabel.Name = "backLinkLabel";
            this.backLinkLabel.Size = new System.Drawing.Size(77, 12);
            this.backLinkLabel.TabIndex = 4;
            this.backLinkLabel.TabStop = true;
            this.backLinkLabel.Text = "返回行程列表";
            this.backLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.backLinkLabel_LinkClicked);
            // 
            // delDayButton
            // 
            this.delDayButton.Location = new System.Drawing.Point(87, 320);
            this.delDayButton.Name = "delDayButton";
            this.delDayButton.Size = new System.Drawing.Size(36, 23);
            this.delDayButton.TabIndex = 5;
            this.delDayButton.Text = "-";
            this.delDayButton.UseVisualStyleBackColor = true;
            this.delDayButton.Click += new System.EventHandler(this.delDayButton_Click);
            // 
            // dayDataGridView
            // 
            this.dayDataGridView.AllowUserToAddRows = false;
            this.dayDataGridView.AllowUserToDeleteRows = false;
            this.dayDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dayDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dayDataGridView.ColumnHeadersVisible = false;
            this.dayDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dayNameColumn});
            this.dayDataGridView.Location = new System.Drawing.Point(3, 39);
            this.dayDataGridView.Name = "dayDataGridView";
            this.dayDataGridView.RowHeadersVisible = false;
            this.dayDataGridView.RowTemplate.Height = 23;
            this.dayDataGridView.Size = new System.Drawing.Size(120, 275);
            this.dayDataGridView.TabIndex = 8;
            this.dayDataGridView.SelectionChanged += new System.EventHandler(this.dayDataGridView_SelectionChanged);
            // 
            // dayDetailDataGridView
            // 
            this.dayDetailDataGridView.AllowUserToAddRows = false;
            this.dayDetailDataGridView.AllowUserToDeleteRows = false;
            this.dayDetailDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dayDetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dayDetailDataGridView.ColumnHeadersVisible = false;
            this.dayDetailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.localtionTitleColumn});
            this.dayDetailDataGridView.Location = new System.Drawing.Point(129, 39);
            this.dayDetailDataGridView.Name = "dayDetailDataGridView";
            this.dayDetailDataGridView.RowHeadersVisible = false;
            this.dayDetailDataGridView.RowTemplate.Height = 23;
            this.dayDetailDataGridView.Size = new System.Drawing.Size(464, 275);
            this.dayDetailDataGridView.TabIndex = 8;
            // 
            // dayNameColumn
            // 
            this.dayNameColumn.DataPropertyName = "FullName";
            this.dayNameColumn.HeaderText = "FullName";
            this.dayNameColumn.Name = "dayNameColumn";
            this.dayNameColumn.Visible = false;
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DCTS.DctsEntities);
            // 
            // localtionTitleColumn
            // 
            this.localtionTitleColumn.DataPropertyName = "locationId";
            this.localtionTitleColumn.HeaderText = "localtionTitle";
            this.localtionTitleColumn.Name = "localtionTitleColumn";
            this.localtionTitleColumn.Visible = false;
            // 
            // EditTripControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dayDetailDataGridView);
            this.Controls.Add(this.dayDataGridView);
            this.Controls.Add(this.delDayButton);
            this.Controls.Add(this.backLinkLabel);
            this.Controls.Add(this.addLocationButton);
            this.Controls.Add(this.addDayButton);
            this.Name = "EditTripControl";
            this.Size = new System.Drawing.Size(596, 346);
            ((System.ComponentModel.ISupportInitialize)(this.dayDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayDetailDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addDayButton;
        private System.Windows.Forms.Button addLocationButton;
        private System.Windows.Forms.LinkLabel backLinkLabel;
        private CustomComponents.EntityDataSource entityDataSource1;
        private System.Windows.Forms.Button delDayButton;
        private System.Windows.Forms.DataGridView dayDataGridView;
        private System.Windows.Forms.DataGridView dayDetailDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localtionTitleColumn;
    }
}
