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
            this.dayListBox = new System.Windows.Forms.ListBox();
            this.addDayButton = new System.Windows.Forms.Button();
            this.dayDetailListBox = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.backLinkLabel = new System.Windows.Forms.LinkLabel();
            this.delDayButton = new System.Windows.Forms.Button();
            this.entityDataSource1 = new DCTS.CustomComponents.EntityDataSource(this.components);
            this.SuspendLayout();
            // 
            // dayListBox
            // 
            this.dayListBox.FormattingEnabled = true;
            this.dayListBox.ItemHeight = 12;
            this.dayListBox.Items.AddRange(new object[] {
            "第一天",
            "第二天"});
            this.dayListBox.Location = new System.Drawing.Point(3, 39);
            this.dayListBox.Name = "dayListBox";
            this.dayListBox.Size = new System.Drawing.Size(120, 280);
            this.dayListBox.TabIndex = 0;
            this.dayListBox.SelectedIndexChanged += new System.EventHandler(this.dayListBox_SelectedIndexChanged);
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
            // dayDetailListBox
            // 
            this.dayDetailListBox.FormattingEnabled = true;
            this.dayDetailListBox.ItemHeight = 12;
            this.dayDetailListBox.Location = new System.Drawing.Point(129, 39);
            this.dayDetailListBox.Name = "dayDetailListBox";
            this.dayDetailListBox.Size = new System.Drawing.Size(464, 280);
            this.dayDetailListBox.TabIndex = 2;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(518, 10);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "添加";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
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
            // entityDataSource1
            // 
            this.entityDataSource1.DbContextType = typeof(DCTS.DctsEntities);
            // 
            // EditTripControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.delDayButton);
            this.Controls.Add(this.backLinkLabel);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.dayDetailListBox);
            this.Controls.Add(this.addDayButton);
            this.Controls.Add(this.dayListBox);
            this.Name = "EditTripControl";
            this.Size = new System.Drawing.Size(596, 346);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox dayListBox;
        private System.Windows.Forms.Button addDayButton;
        private System.Windows.Forms.ListBox dayDetailListBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.LinkLabel backLinkLabel;
        private CustomComponents.EntityDataSource entityDataSource1;
        private System.Windows.Forms.Button delDayButton;
    }
}
