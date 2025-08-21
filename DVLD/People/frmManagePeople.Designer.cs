namespace DVLD
{
    partial class frmManagePeople
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
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.cmsPeople = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditPersonInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeletePerson = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrCloseBtn1 = new DVLD.ctrCloseBtn();
            this.ctrManageData1 = new DVLD.ctrFilterDataView();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.cmsPeople.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewPerson.BackgroundImage = global::DVLD.Properties.Resources.incorporation;
            this.btnAddNewPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewPerson.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddNewPerson.Image = global::DVLD.Properties.Resources.incorporation;
            this.btnAddNewPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewPerson.Location = new System.Drawing.Point(1523, 195);
            this.btnAddNewPerson.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(63, 43);
            this.btnAddNewPerson.TabIndex = 1;
            this.btnAddNewPerson.UseVisualStyleBackColor = false;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // cmsPeople
            // 
            this.cmsPeople.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmsPeople.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowPersonDetails,
            this.tsmiAddNewPerson,
            this.tsmiEditPersonInfo,
            this.tsmiDeletePerson});
            this.cmsPeople.Name = "contextMenuStrip1";
            this.cmsPeople.Size = new System.Drawing.Size(188, 100);
            // 
            // tsmiShowPersonDetails
            // 
            this.tsmiShowPersonDetails.Name = "tsmiShowPersonDetails";
            this.tsmiShowPersonDetails.Size = new System.Drawing.Size(187, 24);
            this.tsmiShowPersonDetails.Text = "Show Details";
            this.tsmiShowPersonDetails.Click += new System.EventHandler(this.tsmiShowPersonDetails_Click);
            // 
            // tsmiAddNewPerson
            // 
            this.tsmiAddNewPerson.Name = "tsmiAddNewPerson";
            this.tsmiAddNewPerson.Size = new System.Drawing.Size(187, 24);
            this.tsmiAddNewPerson.Text = "Add New Person";
            this.tsmiAddNewPerson.Click += new System.EventHandler(this.tsmiAddNewPerson_Click);
            // 
            // tsmiEditPersonInfo
            // 
            this.tsmiEditPersonInfo.Name = "tsmiEditPersonInfo";
            this.tsmiEditPersonInfo.Size = new System.Drawing.Size(187, 24);
            this.tsmiEditPersonInfo.Text = "Edit";
            this.tsmiEditPersonInfo.Click += new System.EventHandler(this.tsmiEditPersonInfo_Click);
            // 
            // tsmiDeletePerson
            // 
            this.tsmiDeletePerson.Name = "tsmiDeletePerson";
            this.tsmiDeletePerson.Size = new System.Drawing.Size(187, 24);
            this.tsmiDeletePerson.Text = "Delete";
            this.tsmiDeletePerson.Click += new System.EventHandler(this.tsmiDeletePerson_Click);
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(851, 585);
            this.ctrCloseBtn1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(153, 42);
            this.ctrCloseBtn1.TabIndex = 2;
            // 
            // ctrManageData1
            // 
            this.ctrManageData1.Location = new System.Drawing.Point(8, 10);
            this.ctrManageData1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrManageData1.Name = "ctrManageData1";
            this.ctrManageData1.Size = new System.Drawing.Size(1028, 573);
            this.ctrManageData1.TabIndex = 0;
            this.ctrManageData1.Load += new System.EventHandler(this.ctrManageData1_Load);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(841, 127);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(140, 23);
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // frmManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1032, 655);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.ctrManageData1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmManagePeople";
            this.Text = "Manage People";
            this.cmsPeople.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrFilterDataView ctrManageData1;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.ContextMenuStrip cmsPeople;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPersonDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNewPerson;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditPersonInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeletePerson;
        private ctrCloseBtn ctrCloseBtn1;
        private System.Windows.Forms.Button btnAddNew;
    }
}

