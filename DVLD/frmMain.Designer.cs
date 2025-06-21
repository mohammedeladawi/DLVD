namespace DVLD
{
    partial class frmMain
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
            this.msDVLD = new System.Windows.Forms.MenuStrip();
            this.tsmiApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewLDL = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiIssueInternationLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRenewDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReplaceLostDamagedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReleaseDetainedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRetakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageLDLApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.frmManageIDLApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.DetainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageDetainedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDetainLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReleaseDetainedLicense2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageApplicationTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageTestTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDrivers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAccountSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCurrUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeCurrUserPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSignOut = new System.Windows.Forms.ToolStripMenuItem();
            this.msDVLD.SuspendLayout();
            this.SuspendLayout();
            // 
            // msDVLD
            // 
            this.msDVLD.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.msDVLD.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.msDVLD.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiApplications,
            this.tsmiPeople,
            this.tsmiDrivers,
            this.tsmiUsers,
            this.tsmiAccountSettings});
            this.msDVLD.Location = new System.Drawing.Point(0, 0);
            this.msDVLD.Name = "msDVLD";
            this.msDVLD.Size = new System.Drawing.Size(1870, 42);
            this.msDVLD.TabIndex = 1;
            this.msDVLD.Text = "menuStrip1";
            // 
            // tsmiApplications
            // 
            this.tsmiApplications.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivingLicenseToolStripMenuItem,
            this.manageApplicationsToolStripMenuItem,
            this.DetainLicenseToolStripMenuItem,
            this.tsmiManageApplicationTypes,
            this.tsmiManageTestTypes});
            this.tsmiApplications.Image = global::DVLD.Properties.Resources.form__1_;
            this.tsmiApplications.Name = "tsmiApplications";
            this.tsmiApplications.Size = new System.Drawing.Size(196, 38);
            this.tsmiApplications.Text = "Applications";
            // 
            // drivingLicenseToolStripMenuItem
            // 
            this.drivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicenseToolStripMenuItem,
            this.tsmiRenewDrivingLicense,
            this.tsmiReplaceLostDamagedLicense,
            this.tsmiReleaseDetainedLicense,
            this.tsmiRetakeTest});
            this.drivingLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.id;
            this.drivingLicenseToolStripMenuItem.Name = "drivingLicenseToolStripMenuItem";
            this.drivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(429, 44);
            this.drivingLicenseToolStripMenuItem.Text = "Driving Licenses Services";
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            this.newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewLDL,
            this.tsmiIssueInternationLicense});
            this.newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            this.newDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(596, 44);
            this.newDrivingLicenseToolStripMenuItem.Text = "New Driving License";
            // 
            // tsmiNewLDL
            // 
            this.tsmiNewLDL.Name = "tsmiNewLDL";
            this.tsmiNewLDL.Size = new System.Drawing.Size(367, 44);
            this.tsmiNewLDL.Text = "Local License";
            this.tsmiNewLDL.Click += new System.EventHandler(this.tsmiNewLDL_Click);
            // 
            // tsmiIssueInternationLicense
            // 
            this.tsmiIssueInternationLicense.Name = "tsmiIssueInternationLicense";
            this.tsmiIssueInternationLicense.Size = new System.Drawing.Size(367, 44);
            this.tsmiIssueInternationLicense.Text = "International License";
            this.tsmiIssueInternationLicense.Click += new System.EventHandler(this.tsmiIssueInternationalLicense_Click);
            // 
            // tsmiRenewDrivingLicense
            // 
            this.tsmiRenewDrivingLicense.Name = "tsmiRenewDrivingLicense";
            this.tsmiRenewDrivingLicense.Size = new System.Drawing.Size(596, 44);
            this.tsmiRenewDrivingLicense.Text = "Renew Driving License";
            this.tsmiRenewDrivingLicense.Click += new System.EventHandler(this.tsmiRenewDrivingLicense_Click);
            // 
            // tsmiReplaceLostDamagedLicense
            // 
            this.tsmiReplaceLostDamagedLicense.Name = "tsmiReplaceLostDamagedLicense";
            this.tsmiReplaceLostDamagedLicense.Size = new System.Drawing.Size(596, 44);
            this.tsmiReplaceLostDamagedLicense.Text = "Replacement for Lost or Damaged License";
            this.tsmiReplaceLostDamagedLicense.Click += new System.EventHandler(this.tsmiReplaceLostDamagedLicense_Click);
            // 
            // tsmiReleaseDetainedLicense
            // 
            this.tsmiReleaseDetainedLicense.Name = "tsmiReleaseDetainedLicense";
            this.tsmiReleaseDetainedLicense.Size = new System.Drawing.Size(596, 44);
            this.tsmiReleaseDetainedLicense.Text = "Release Detained Driving License";
            this.tsmiReleaseDetainedLicense.Click += new System.EventHandler(this.tsmiReleaseDetainedLicense_Click);
            // 
            // tsmiRetakeTest
            // 
            this.tsmiRetakeTest.AutoToolTip = true;
            this.tsmiRetakeTest.Name = "tsmiRetakeTest";
            this.tsmiRetakeTest.Size = new System.Drawing.Size(596, 44);
            this.tsmiRetakeTest.Text = "Retake Test";
            this.tsmiRetakeTest.Click += new System.EventHandler(this.tsmiRetakeTest_Click);
            // 
            // manageApplicationsToolStripMenuItem
            // 
            this.manageApplicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiManageLDLApplications,
            this.frmManageIDLApplications});
            this.manageApplicationsToolStripMenuItem.Image = global::DVLD.Properties.Resources.form__2_;
            this.manageApplicationsToolStripMenuItem.Name = "manageApplicationsToolStripMenuItem";
            this.manageApplicationsToolStripMenuItem.Size = new System.Drawing.Size(429, 44);
            this.manageApplicationsToolStripMenuItem.Text = "Manage Applications";
            // 
            // tsmiManageLDLApplications
            // 
            this.tsmiManageLDLApplications.Name = "tsmiManageLDLApplications";
            this.tsmiManageLDLApplications.Size = new System.Drawing.Size(507, 44);
            this.tsmiManageLDLApplications.Text = "Local Driving License Applications";
            this.tsmiManageLDLApplications.Click += new System.EventHandler(this.tsmiManageLDLApplications_Click);
            // 
            // frmManageIDLApplications
            // 
            this.frmManageIDLApplications.Name = "frmManageIDLApplications";
            this.frmManageIDLApplications.Size = new System.Drawing.Size(507, 44);
            this.frmManageIDLApplications.Text = "International License Applications";
            this.frmManageIDLApplications.Click += new System.EventHandler(this.frmManageIDLApplications_Click);
            // 
            // DetainLicenseToolStripMenuItem
            // 
            this.DetainLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiManageDetainedLicense,
            this.tsmiDetainLicense,
            this.tsmiReleaseDetainedLicense2});
            this.DetainLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.id__1_;
            this.DetainLicenseToolStripMenuItem.Name = "DetainLicenseToolStripMenuItem";
            this.DetainLicenseToolStripMenuItem.Size = new System.Drawing.Size(429, 44);
            this.DetainLicenseToolStripMenuItem.Text = "Detain Licenses";
            // 
            // tsmiManageDetainedLicense
            // 
            this.tsmiManageDetainedLicense.Name = "tsmiManageDetainedLicense";
            this.tsmiManageDetainedLicense.Size = new System.Drawing.Size(423, 44);
            this.tsmiManageDetainedLicense.Text = "Manage Detained License";
            this.tsmiManageDetainedLicense.Click += new System.EventHandler(this.tsmiManageDetainedLicense_Click);
            // 
            // tsmiDetainLicense
            // 
            this.tsmiDetainLicense.Name = "tsmiDetainLicense";
            this.tsmiDetainLicense.Size = new System.Drawing.Size(423, 44);
            this.tsmiDetainLicense.Text = "Detain License";
            this.tsmiDetainLicense.Click += new System.EventHandler(this.tsmiDetainLicense_Click_1);
            // 
            // tsmiReleaseDetainedLicense2
            // 
            this.tsmiReleaseDetainedLicense2.Name = "tsmiReleaseDetainedLicense2";
            this.tsmiReleaseDetainedLicense2.Size = new System.Drawing.Size(423, 44);
            this.tsmiReleaseDetainedLicense2.Text = "Release Detained License";
            this.tsmiReleaseDetainedLicense2.Click += new System.EventHandler(this.tsmiReleaseDetainedLicense2_Click);
            // 
            // tsmiManageApplicationTypes
            // 
            this.tsmiManageApplicationTypes.Image = global::DVLD.Properties.Resources.reference;
            this.tsmiManageApplicationTypes.Name = "tsmiManageApplicationTypes";
            this.tsmiManageApplicationTypes.Size = new System.Drawing.Size(429, 44);
            this.tsmiManageApplicationTypes.Text = "Manage Application Types";
            this.tsmiManageApplicationTypes.Click += new System.EventHandler(this.tsmiManageApplicationTypes_Click);
            // 
            // tsmiManageTestTypes
            // 
            this.tsmiManageTestTypes.Image = global::DVLD.Properties.Resources.test;
            this.tsmiManageTestTypes.Name = "tsmiManageTestTypes";
            this.tsmiManageTestTypes.Size = new System.Drawing.Size(429, 44);
            this.tsmiManageTestTypes.Text = "Manage Test Types";
            this.tsmiManageTestTypes.Click += new System.EventHandler(this.tsmiManageTestTypes_Click);
            // 
            // tsmiPeople
            // 
            this.tsmiPeople.Image = global::DVLD.Properties.Resources.group;
            this.tsmiPeople.Name = "tsmiPeople";
            this.tsmiPeople.Size = new System.Drawing.Size(138, 38);
            this.tsmiPeople.Text = "People";
            this.tsmiPeople.Click += new System.EventHandler(this.tsmiPeople_Click);
            // 
            // tsmiDrivers
            // 
            this.tsmiDrivers.Image = global::DVLD.Properties.Resources.car;
            this.tsmiDrivers.Name = "tsmiDrivers";
            this.tsmiDrivers.Size = new System.Drawing.Size(140, 38);
            this.tsmiDrivers.Text = "Drivers";
            this.tsmiDrivers.Click += new System.EventHandler(this.tsmiDrivers_Click);
            // 
            // tsmiUsers
            // 
            this.tsmiUsers.Image = global::DVLD.Properties.Resources.status_available;
            this.tsmiUsers.Name = "tsmiUsers";
            this.tsmiUsers.Size = new System.Drawing.Size(123, 38);
            this.tsmiUsers.Text = "Users";
            this.tsmiUsers.Click += new System.EventHandler(this.tsmiUsers_Click);
            // 
            // tsmiAccountSettings
            // 
            this.tsmiAccountSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCurrUserInfo,
            this.tsmiChangeCurrUserPassword,
            this.tsmiSignOut});
            this.tsmiAccountSettings.Image = global::DVLD.Properties.Resources.account_settings__1_;
            this.tsmiAccountSettings.Name = "tsmiAccountSettings";
            this.tsmiAccountSettings.Size = new System.Drawing.Size(246, 38);
            this.tsmiAccountSettings.Text = "Account Settings";
            // 
            // tsmiCurrUserInfo
            // 
            this.tsmiCurrUserInfo.Image = global::DVLD.Properties.Resources.user;
            this.tsmiCurrUserInfo.Name = "tsmiCurrUserInfo";
            this.tsmiCurrUserInfo.Size = new System.Drawing.Size(333, 44);
            this.tsmiCurrUserInfo.Text = "Current User Info";
            this.tsmiCurrUserInfo.Click += new System.EventHandler(this.tsmiCurrUserInfo_Click);
            // 
            // tsmiChangeCurrUserPassword
            // 
            this.tsmiChangeCurrUserPassword.Image = global::DVLD.Properties.Resources.screw;
            this.tsmiChangeCurrUserPassword.Name = "tsmiChangeCurrUserPassword";
            this.tsmiChangeCurrUserPassword.Size = new System.Drawing.Size(333, 44);
            this.tsmiChangeCurrUserPassword.Text = "Change Password";
            this.tsmiChangeCurrUserPassword.Click += new System.EventHandler(this.tsmiChangeCurrUserPassword_Click);
            // 
            // tsmiSignOut
            // 
            this.tsmiSignOut.Image = global::DVLD.Properties.Resources.cancel;
            this.tsmiSignOut.Name = "tsmiSignOut";
            this.tsmiSignOut.Size = new System.Drawing.Size(333, 44);
            this.tsmiSignOut.Text = "Sign Out";
            this.tsmiSignOut.Click += new System.EventHandler(this.tsmiSignOut_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BackgroundImage = global::DVLD.Properties.Resources.vecteezy_male_character_sitting_in_a_new_car_the_man_took_the_driving_5605324;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1870, 1055);
            this.Controls.Add(this.msDVLD);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msDVLD;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.msDVLD.ResumeLayout(false);
            this.msDVLD.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msDVLD;
        private System.Windows.Forms.ToolStripMenuItem tsmiApplications;
        private System.Windows.Forms.ToolStripMenuItem tsmiPeople;
        private System.Windows.Forms.ToolStripMenuItem tsmiDrivers;
        private System.Windows.Forms.ToolStripMenuItem tsmiUsers;
        private System.Windows.Forms.ToolStripMenuItem tsmiAccountSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiCurrUserInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeCurrUserPassword;
        private System.Windows.Forms.ToolStripMenuItem tsmiSignOut;
        private System.Windows.Forms.ToolStripMenuItem drivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DetainLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageApplicationTypes;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageTestTypes;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewLDL;
        private System.Windows.Forms.ToolStripMenuItem tsmiRenewDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiReplaceLostDamagedLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiReleaseDetainedLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiRetakeTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiIssueInternationLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageLDLApplications;
        private System.Windows.Forms.ToolStripMenuItem frmManageIDLApplications;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageDetainedLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiDetainLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiReleaseDetainedLicense2;
    }
}