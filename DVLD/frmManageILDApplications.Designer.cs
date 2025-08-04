namespace DVLD
{
    partial class frmManageILDApplications
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
            this.cmsIDLApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrCloseBtn1 = new DVLD.ctrCloseBtn();
            this.ctrManageData1 = new DVLD.ctrFilterDataView();
            this.cmsIDLApplications.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsIDLApplications
            // 
            this.cmsIDLApplications.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmsIDLApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseInfoToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmsIDLApplications.Name = "cmsIDLApplications";
            this.cmsIDLApplications.Size = new System.Drawing.Size(392, 162);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(391, 38);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(391, 38);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Details";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(391, 38);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(1271, 873);
            this.ctrCloseBtn1.Margin = new System.Windows.Forms.Padding(2);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(228, 64);
            this.ctrCloseBtn1.TabIndex = 4;
            // 
            // ctrManageData1
            // 
            this.ctrManageData1.Location = new System.Drawing.Point(11, 29);
            this.ctrManageData1.Margin = new System.Windows.Forms.Padding(2);
            this.ctrManageData1.Name = "ctrManageData1";
            this.ctrManageData1.Size = new System.Drawing.Size(1550, 908);
            this.ctrManageData1.TabIndex = 3;
            // 
            // frmManageILDApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 974);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.ctrManageData1);
            this.Name = "frmManageILDApplications";
            this.Text = "frmManageInternationalLicenseApplications";
            this.Load += new System.EventHandler(this.frmManageILDApplications_Load);
            this.cmsIDLApplications.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrFilterDataView ctrManageData1;
        private ctrCloseBtn ctrCloseBtn1;
        private System.Windows.Forms.ContextMenuStrip cmsIDLApplications;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}