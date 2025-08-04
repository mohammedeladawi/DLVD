namespace DVLD
{
    partial class frmManageLDLApplications
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
            this.cmsManageLDLApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowApplicationDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddNewLDLApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiScheduleTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiScheduleVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiScheduleWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiScheduleStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiIssueDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrCloseBtn1 = new DVLD.ctrCloseBtn();
            this.ctrManageData1 = new DVLD.ctrFilterDataView();
            this.cmsManageLDLApplications.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsManageLDLApplications
            // 
            this.cmsManageLDLApplications.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmsManageLDLApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowApplicationDetails,
            this.tsmiAddNewLDLApplication,
            this.tsmiEditApplication,
            this.tsmiDeleteApplication,
            this.tsmiCancelApplication,
            this.tsmiScheduleTest,
            this.tsmiIssueDrivingLicense,
            this.tsmiShowLicense,
            this.tsmiShowPersonLicenseHistory});
            this.cmsManageLDLApplications.Name = "cmsManageLDLApplications";
            this.cmsManageLDLApplications.Size = new System.Drawing.Size(293, 248);
            this.cmsManageLDLApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsManageLDLApplications_Opening);
            // 
            // tsmiShowApplicationDetails
            // 
            this.tsmiShowApplicationDetails.Name = "tsmiShowApplicationDetails";
            this.tsmiShowApplicationDetails.Size = new System.Drawing.Size(292, 24);
            this.tsmiShowApplicationDetails.Text = "Show Application Details";
            // 
            // tsmiAddNewLDLApplication
            // 
            this.tsmiAddNewLDLApplication.Name = "tsmiAddNewLDLApplication";
            this.tsmiAddNewLDLApplication.Size = new System.Drawing.Size(292, 24);
            this.tsmiAddNewLDLApplication.Text = "Add New Application";
            this.tsmiAddNewLDLApplication.Click += new System.EventHandler(this.tsmiAddNewLDLApplication_Click);
            // 
            // tsmiEditApplication
            // 
            this.tsmiEditApplication.Name = "tsmiEditApplication";
            this.tsmiEditApplication.Size = new System.Drawing.Size(292, 24);
            this.tsmiEditApplication.Text = "Edit Application";
            this.tsmiEditApplication.Click += new System.EventHandler(this.tsmiEditApplication_Click);
            // 
            // tsmiDeleteApplication
            // 
            this.tsmiDeleteApplication.Name = "tsmiDeleteApplication";
            this.tsmiDeleteApplication.Size = new System.Drawing.Size(292, 24);
            this.tsmiDeleteApplication.Text = "Delete Application";
            this.tsmiDeleteApplication.Click += new System.EventHandler(this.tsmiDeleteApplication_Click);
            // 
            // tsmiCancelApplication
            // 
            this.tsmiCancelApplication.Name = "tsmiCancelApplication";
            this.tsmiCancelApplication.Size = new System.Drawing.Size(292, 24);
            this.tsmiCancelApplication.Text = "Cancel Application";
            this.tsmiCancelApplication.Click += new System.EventHandler(this.tsmiCancelApplication_Click);
            // 
            // tsmiScheduleTest
            // 
            this.tsmiScheduleTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiScheduleVisionTest,
            this.tsmiScheduleWrittenTest,
            this.tsmiScheduleStreetTest});
            this.tsmiScheduleTest.Name = "tsmiScheduleTest";
            this.tsmiScheduleTest.Size = new System.Drawing.Size(292, 24);
            this.tsmiScheduleTest.Text = "Schedule Tests";
            // 
            // tsmiScheduleVisionTest
            // 
            this.tsmiScheduleVisionTest.Name = "tsmiScheduleVisionTest";
            this.tsmiScheduleVisionTest.Size = new System.Drawing.Size(235, 26);
            this.tsmiScheduleVisionTest.Text = "Schedule Vision Test";
            this.tsmiScheduleVisionTest.Click += new System.EventHandler(this.tsmiScheduleVisionTest_Click);
            // 
            // tsmiScheduleWrittenTest
            // 
            this.tsmiScheduleWrittenTest.Name = "tsmiScheduleWrittenTest";
            this.tsmiScheduleWrittenTest.Size = new System.Drawing.Size(235, 26);
            this.tsmiScheduleWrittenTest.Text = "Schedule Written Test";
            this.tsmiScheduleWrittenTest.Click += new System.EventHandler(this.tsmiScheduleWrittenTest_Click);
            // 
            // tsmiScheduleStreetTest
            // 
            this.tsmiScheduleStreetTest.Name = "tsmiScheduleStreetTest";
            this.tsmiScheduleStreetTest.Size = new System.Drawing.Size(235, 26);
            this.tsmiScheduleStreetTest.Text = "Schedule Street Test";
            this.tsmiScheduleStreetTest.Click += new System.EventHandler(this.tsmiScheduleStreetTest_Click);
            // 
            // tsmiIssueDrivingLicense
            // 
            this.tsmiIssueDrivingLicense.Name = "tsmiIssueDrivingLicense";
            this.tsmiIssueDrivingLicense.Size = new System.Drawing.Size(292, 24);
            this.tsmiIssueDrivingLicense.Text = "Issue Driving License (First Time)";
            this.tsmiIssueDrivingLicense.Click += new System.EventHandler(this.tsmiIssueDrivingLicense_Click);
            // 
            // tsmiShowLicense
            // 
            this.tsmiShowLicense.Name = "tsmiShowLicense";
            this.tsmiShowLicense.Size = new System.Drawing.Size(292, 24);
            this.tsmiShowLicense.Text = "Show License";
            this.tsmiShowLicense.Click += new System.EventHandler(this.tsmiShowLicense_Click);
            // 
            // tsmiShowPersonLicenseHistory
            // 
            this.tsmiShowPersonLicenseHistory.Name = "tsmiShowPersonLicenseHistory";
            this.tsmiShowPersonLicenseHistory.Size = new System.Drawing.Size(292, 24);
            this.tsmiShowPersonLicenseHistory.Text = "Show Person License History";
            this.tsmiShowPersonLicenseHistory.Click += new System.EventHandler(this.tsmiShowPersonLicenseHistory_Click);
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(890, 607);
            this.ctrCloseBtn1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(153, 42);
            this.ctrCloseBtn1.TabIndex = 3;
            // 
            // ctrManageData1
            // 
            this.ctrManageData1.Location = new System.Drawing.Point(10, 10);
            this.ctrManageData1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrManageData1.Name = "ctrManageData1";
            this.ctrManageData1.Size = new System.Drawing.Size(1033, 581);
            this.ctrManageData1.TabIndex = 2;
            // 
            // frmManageLDLApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 659);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.ctrManageData1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmManageLDLApplications";
            this.Text = "frmManageLDLApplications";
            this.Load += new System.EventHandler(this.frmManageLDLApplications_Load);
            this.cmsManageLDLApplications.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrCloseBtn ctrCloseBtn1;
        private ctrFilterDataView ctrManageData1;
        private System.Windows.Forms.ContextMenuStrip cmsManageLDLApplications;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNewLDLApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancelApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmiScheduleTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowApplicationDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmiIssueDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem tsmiScheduleVisionTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiScheduleWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiScheduleStreetTest;
    }
}