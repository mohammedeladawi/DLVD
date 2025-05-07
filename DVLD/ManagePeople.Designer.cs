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
            this.ctrManageData1 = new DVLD.CtrManageData();
            this.cmsPeople = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditPersonInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeletePerson = new System.Windows.Forms.ToolStripMenuItem();
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
            this.btnAddNewPerson.Location = new System.Drawing.Point(2285, 304);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(95, 67);
            this.btnAddNewPerson.TabIndex = 1;
            this.btnAddNewPerson.UseVisualStyleBackColor = false;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // ctrManageData1
            // 
            this.ctrManageData1.Location = new System.Drawing.Point(7, 38);
            this.ctrManageData1.Name = "ctrManageData1";
            this.ctrManageData1.Size = new System.Drawing.Size(2392, 936);
            this.ctrManageData1.TabIndex = 0;
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
            this.cmsPeople.Size = new System.Drawing.Size(301, 200);
            // 
            // tsmiShowPersonDetails
            // 
            this.tsmiShowPersonDetails.Name = "tsmiShowPersonDetails";
            this.tsmiShowPersonDetails.Size = new System.Drawing.Size(300, 38);
            this.tsmiShowPersonDetails.Text = "Show Details";
            // 
            // tsmiAddNewPerson
            // 
            this.tsmiAddNewPerson.Name = "tsmiAddNewPerson";
            this.tsmiAddNewPerson.Size = new System.Drawing.Size(300, 38);
            this.tsmiAddNewPerson.Text = "Add New Person";
            this.tsmiAddNewPerson.Click += new System.EventHandler(this.tsmiAddNewPerson_Click);
            // 
            // tsmiEditPersonInfo
            // 
            this.tsmiEditPersonInfo.Name = "tsmiEditPersonInfo";
            this.tsmiEditPersonInfo.Size = new System.Drawing.Size(300, 38);
            this.tsmiEditPersonInfo.Text = "Edit";
            this.tsmiEditPersonInfo.Click += new System.EventHandler(this.tsmiEditPersonInfo_Click);
            // 
            // tsmiDeletePerson
            // 
            this.tsmiDeletePerson.Name = "tsmiDeletePerson";
            this.tsmiDeletePerson.Size = new System.Drawing.Size(300, 38);
            this.tsmiDeletePerson.Text = "Delete";
            // 
            // frmManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(2408, 1105);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.ctrManageData1);
            this.Name = "frmManagePeople";
            this.Text = "Manage People";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.cmsPeople.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CtrManageData ctrManageData1;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.ContextMenuStrip cmsPeople;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPersonDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNewPerson;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditPersonInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeletePerson;
    }
}

