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
            this.dayNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayDetailDataGridView = new System.Windows.Forms.DataGridView();
            this.positionColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationIdColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayIdColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localtionTitleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.selectedLocationTextBox = new System.Windows.Forms.TextBox();
            this.selectDayTextBox = new System.Windows.Forms.TextBox();
            this.removeLocationButton = new System.Windows.Forms.Button();
            this.moveDayDownButton = new System.Windows.Forms.Button();
            this.moveDayUpButton = new System.Windows.Forms.Button();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.addBlankButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dayDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayDetailDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayDetailBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // addDayButton
            // 
            this.addDayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.addLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addLocationButton.Location = new System.Drawing.Point(315, 320);
            this.addLocationButton.Name = "addLocationButton";
            this.addLocationButton.Size = new System.Drawing.Size(53, 23);
            this.addLocationButton.TabIndex = 3;
            this.addLocationButton.Text = "选活动";
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
            this.delDayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.delDayButton.Location = new System.Drawing.Point(45, 320);
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
            this.dayDataGridView.AllowUserToResizeRows = false;
            this.dayDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dayDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dayDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dayDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dayDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dayNameColumn});
            this.dayDataGridView.Location = new System.Drawing.Point(3, 39);
            this.dayDataGridView.MultiSelect = false;
            this.dayDataGridView.Name = "dayDataGridView";
            this.dayDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dayDataGridView.RowHeadersVisible = false;
            this.dayDataGridView.RowTemplate.Height = 23;
            this.dayDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dayDataGridView.Size = new System.Drawing.Size(192, 275);
            this.dayDataGridView.TabIndex = 8;
            this.dayDataGridView.SelectionChanged += new System.EventHandler(this.dayDataGridView_SelectionChanged);
            // 
            // dayNameColumn
            // 
            this.dayNameColumn.DataPropertyName = "FullName";
            this.dayNameColumn.HeaderText = "行程天数";
            this.dayNameColumn.Name = "dayNameColumn";
            // 
            // dayDetailDataGridView
            // 
            this.dayDetailDataGridView.AllowUserToAddRows = false;
            this.dayDetailDataGridView.AllowUserToDeleteRows = false;
            this.dayDetailDataGridView.AllowUserToResizeRows = false;
            this.dayDetailDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dayDetailDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dayDetailDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dayDetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dayDetailDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.positionColumn1,
            this.locationIdColumn1,
            this.dayIdColumn1,
            this.localtionTitleColumn});
            this.dayDetailDataGridView.Location = new System.Drawing.Point(201, 39);
            this.dayDetailDataGridView.MultiSelect = false;
            this.dayDetailDataGridView.Name = "dayDetailDataGridView";
            this.dayDetailDataGridView.RowHeadersVisible = false;
            this.dayDetailDataGridView.RowTemplate.Height = 23;
            this.dayDetailDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dayDetailDataGridView.Size = new System.Drawing.Size(642, 275);
            this.dayDetailDataGridView.TabIndex = 8;
            // 
            // positionColumn1
            // 
            this.positionColumn1.DataPropertyName = "position";
            this.positionColumn1.HeaderText = "序号";
            this.positionColumn1.Name = "positionColumn1";
            // 
            // locationIdColumn1
            // 
            this.locationIdColumn1.DataPropertyName = "locationId";
            this.locationIdColumn1.HeaderText = "locationId";
            this.locationIdColumn1.Name = "locationIdColumn1";
            // 
            // dayIdColumn1
            // 
            this.dayIdColumn1.DataPropertyName = "dayId";
            this.dayIdColumn1.HeaderText = "dayId";
            this.dayIdColumn1.Name = "dayIdColumn1";
            // 
            // localtionTitleColumn
            // 
            this.localtionTitleColumn.DataPropertyName = "title";
            this.localtionTitleColumn.HeaderText = "名称";
            this.localtionTitleColumn.Name = "localtionTitleColumn";
            // 
            // moveDownButton
            // 
            this.moveDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moveDownButton.Location = new System.Drawing.Point(258, 320);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(53, 23);
            this.moveDownButton.TabIndex = 10;
            this.moveDownButton.Text = "下移";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moveUpButton.Location = new System.Drawing.Point(201, 320);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(53, 23);
            this.moveUpButton.TabIndex = 9;
            this.moveUpButton.Text = "上移";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // selectedLocationTextBox
            // 
            this.selectedLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedLocationTextBox.Location = new System.Drawing.Point(743, 320);
            this.selectedLocationTextBox.Name = "selectedLocationTextBox";
            this.selectedLocationTextBox.Size = new System.Drawing.Size(100, 21);
            this.selectedLocationTextBox.TabIndex = 12;
            this.selectedLocationTextBox.Visible = false;
            // 
            // selectDayTextBox
            // 
            this.selectDayTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectDayTextBox.Location = new System.Drawing.Point(637, 320);
            this.selectDayTextBox.Name = "selectDayTextBox";
            this.selectDayTextBox.Size = new System.Drawing.Size(100, 21);
            this.selectDayTextBox.TabIndex = 12;
            this.selectDayTextBox.Visible = false;
            this.selectDayTextBox.TextChanged += new System.EventHandler(this.selectDayTextBox_TextChanged);
            // 
            // removeLocationButton
            // 
            this.removeLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeLocationButton.Location = new System.Drawing.Point(429, 320);
            this.removeLocationButton.Name = "removeLocationButton";
            this.removeLocationButton.Size = new System.Drawing.Size(53, 23);
            this.removeLocationButton.TabIndex = 3;
            this.removeLocationButton.Text = "删除";
            this.removeLocationButton.UseVisualStyleBackColor = true;
            this.removeLocationButton.Click += new System.EventHandler(this.removeLocationButton_Click);
            // 
            // moveDayDownButton
            // 
            this.moveDayDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moveDayDownButton.Location = new System.Drawing.Point(129, 320);
            this.moveDayDownButton.Name = "moveDayDownButton";
            this.moveDayDownButton.Size = new System.Drawing.Size(36, 23);
            this.moveDayDownButton.TabIndex = 14;
            this.moveDayDownButton.Text = "▽";
            this.moveDayDownButton.UseVisualStyleBackColor = true;
            this.moveDayDownButton.Click += new System.EventHandler(this.moveDayDownButton_Click);
            // 
            // moveDayUpButton
            // 
            this.moveDayUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moveDayUpButton.Location = new System.Drawing.Point(87, 320);
            this.moveDayUpButton.Name = "moveDayUpButton";
            this.moveDayUpButton.Size = new System.Drawing.Size(36, 23);
            this.moveDayUpButton.TabIndex = 13;
            this.moveDayUpButton.Text = "△";
            this.moveDayUpButton.UseVisualStyleBackColor = true;
            this.moveDayUpButton.Click += new System.EventHandler(this.moveDayUpButton_Click);
            // 
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DCTS.DctsEntities);
            // 
            // addBlankButton
            // 
            this.addBlankButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addBlankButton.Location = new System.Drawing.Point(372, 320);
            this.addBlankButton.Name = "addBlankButton";
            this.addBlankButton.Size = new System.Drawing.Size(53, 23);
            this.addBlankButton.TabIndex = 3;
            this.addBlankButton.Text = "空白页";
            this.addBlankButton.UseVisualStyleBackColor = true;
            this.addBlankButton.Click += new System.EventHandler(this.addBlankButton_Click);
            // 
            // EditTripControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.moveDayDownButton);
            this.Controls.Add(this.moveDayUpButton);
            this.Controls.Add(this.selectDayTextBox);
            this.Controls.Add(this.selectedLocationTextBox);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.dayDetailDataGridView);
            this.Controls.Add(this.dayDataGridView);
            this.Controls.Add(this.delDayButton);
            this.Controls.Add(this.backLinkLabel);
            this.Controls.Add(this.removeLocationButton);
            this.Controls.Add(this.addBlankButton);
            this.Controls.Add(this.addLocationButton);
            this.Controls.Add(this.addDayButton);
            this.Name = "EditTripControl";
            this.Size = new System.Drawing.Size(846, 346);
            ((System.ComponentModel.ISupportInitialize)(this.dayDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayDetailDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayDetailBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource dayDetailBindingSource;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.TextBox selectedLocationTextBox;
        private System.Windows.Forms.TextBox selectDayTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationIdColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayIdColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn localtionTitleColumn;
        private System.Windows.Forms.Button removeLocationButton;
        private System.Windows.Forms.Button moveDayDownButton;
        private System.Windows.Forms.Button moveDayUpButton;
        private System.Windows.Forms.Button addBlankButton;
    }
}
