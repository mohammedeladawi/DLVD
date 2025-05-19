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
            this.localLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replacementForLostOrDamagedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retakeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTestTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDrivers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAccountSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCurrUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeCurrUserPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSignOut = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingLicenseApplicationsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.detainLicenseToolStripMenuItem,
            this.manageApplicationTypesToolStripMenuItem,
            this.manageTestTypesToolStripMenuItem});
            this.tsmiApplications.Image = global::DVLD.Properties.Resources.form__1_;
            this.tsmiApplications.Name = "tsmiApplications";
            this.tsmiApplications.Size = new System.Drawing.Size(196, 38);
            this.tsmiApplications.Text = "Applications";
            // 
            // drivingLicenseToolStripMenuItem
            // 
            this.drivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicenseToolStripMenuItem,
            this.renewDrivingLicenseToolStripMenuItem,
            this.replacementForLostOrDamagedLicenseToolStripMenuItem,
            this.releaseDetainedDrivingLicenseToolStripMenuItem,
            this.retakeTestToolStripMenuItem});
            this.drivingLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.id;
            this.drivingLicenseToolStripMenuItem.Name = "drivingLicenseToolStripMenuItem";
            this.drivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(429, 44);
            this.drivingLicenseToolStripMenuItem.Text = "Driving Licenses Services";
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            this.newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localLicenseToolStripMenuItem,
            this.internationalLiceToolStripMenuItem});
            this.newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            this.newDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(596, 44);
            this.newDrivingLicenseToolStripMenuItem.Text = "New Driving License";
            // 
            // localLicenseToolStripMenuItem
            // 
            this.localLicenseToolStripMenuItem.Name = "localLicenseToolStripMenuItem";
            this.localLicenseToolStripMenuItem.Size = new System.Drawing.Size(367, 44);
            this.localLicenseToolStripMenuItem.Text = "Local License";
            this.localLicenseToolStripMenuItem.Click += new System.EventHandler(this.localLicenseToolStripMenuItem_Click);
            // 
            // internationalLiceToolStripMenuItem
            // 
            this.internationalLiceToolStripMenuItem.Name = "internationalLiceToolStripMenuItem";
            this.internationalLiceToolStripMenuItem.Size = new System.Drawing.Size(367, 44);
            this.internationalLiceToolStripMenuItem.Text = "International License";
            // 
            // renewDrivingLicenseToolStripMenuItem
            // 
            this.renewDrivingLicenseToolStripMenuItem.Name = "renewDrivingLicenseToolStripMenuItem";
            this.renewDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(596, 44);
            this.renewDrivingLicenseToolStripMenuItem.Text = "Renew Driving License";
            // 
            // replacementForLostOrDamagedLicenseToolStripMenuItem
            // 
            this.replacementForLostOrDamagedLicenseToolStripMenuItem.Name = "replacementForLostOrDamagedLicenseToolStripMenuItem";
            this.replacementForLostOrDamagedLicenseToolStripMenuItem.Size = new System.Drawing.Size(596, 44);
            this.replacementForLostOrDamagedLicenseToolStripMenuItem.Text = "Replacement for Lost or Damaged License";
            // 
            // releaseDetainedDrivingLicenseToolStripMenuItem
            // 
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Name = "releaseDetainedDrivingLicenseToolStripMenuItem";
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(596, 44);
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Text = "Release Detained Driving License";
            // 
            // retakeTestToolStripMenuItem
            // 
            this.retakeTestToolStripMenuItem.Name = "retakeTestToolStripMenuItem";
            this.retakeTestToolStripMenuItem.Size = new System.Drawing.Size(596, 44);
            this.retakeTestToolStripMenuItem.Text = "Retake Test";
            // 
            // manageApplicationsToolStripMenuItem
            // 
            this.manageApplicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingLicenseApplicationsToolStripMenuItem1,
            this.internationalLicenseApplicationsToolStripMenuItem});
            this.manageApplicationsToolStripMenuItem.Image = global::DVLD.Properties.Resources.form__2_;
            this.manageApplicationsToolStripMenuItem.Name = "manageApplicationsToolStripMenuItem";
            this.manageApplicationsToolStripMenuItem.Size = new System.Drawing.Size(429, 44);
            this.manageApplicationsToolStripMenuItem.Text = "Manage Applications";
            // 
            // detainLicenseToolStripMenuItem
            // 
            this.detainLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.id__1_;
            this.detainLicenseToolStripMenuItem.Name = "detainLicenseToolStripMenuItem";
            this.detainLicenseToolStripMenuItem.Size = new System.Drawing.Size(429, 44);
            this.detainLicenseToolStripMenuItem.Text = "Detain Licenses";
            // 
            // manageApplicationTypesToolStripMenuItem
            // 
            this.manageApplicationTypesToolStripMenuItem.Image = global::DVLD.Properties.Resources.reference;
            this.manageApplicationTypesToolStripMenuItem.Name = "manageApplicationTypesToolStripMenuItem";
            this.manageApplicationTypesToolStripMenuItem.Size = new System.Drawing.Size(429, 44);
            this.manageApplicationTypesToolStripMenuItem.Text = "Manage Application Types";
            this.manageApplicationTypesToolStripMenuItem.Click += new System.EventHandler(this.manageApplicationTypesToolStripMenuItem_Click);
            // 
            // manageTestTypesToolStripMenuItem
            // 
            this.manageTestTypesToolStripMenuItem.Image = global::DVLD.Properties.Resources.test;
            this.manageTestTypesToolStripMenuItem.Name = "manageTestTypesToolStripMenuItem";
            this.manageTestTypesToolStripMenuItem.Size = new System.Drawing.Size(429, 44);
            this.manageTestTypesToolStripMenuItem.Text = "Manage Test Types";
            this.manageTestTypesToolStripMenuItem.Click += new System.EventHandler(this.manageTestTypesToolStripMenuItem_Click);
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
            // localDrivingLicenseApplicationsToolStripMenuItem1
            // 
            this.localDrivingLicenseApplicationsToolStripMenuItem1.Name = "localDrivingLicenseApplicationsToolStripMenuItem1";
            this.localDrivingLicenseApplicationsToolStripMenuItem1.Size = new System.Drawing.Size(507, 44);
            this.localDrivingLicenseApplicationsToolStripMenuItem1.Text = "Local Driving License Applications";
            this.localDrivingLicenseApplicationsToolStripMenuItem1.Click += new System.EventHandler(this.localDrivingLicenseApplicationsToolStripMenuItem1_Click);
            // 
            // internationalLicenseApplicationsToolStripMenuItem
            // 
            this.internationalLicenseApplicationsToolStripMenuItem.Name = "internationalLicenseApplicationsToolStripMenuItem";
            this.internationalLicenseApplicationsToolStripMenuItem.Size = new System.Drawing.Size(507, 44);
            this.internationalLicenseApplicationsToolStripMenuItem.Text = "International License Applications";
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
        private System.Windows.Forms.ToolStripMenuItem detainLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTestTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replacementForLostOrDamagedLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retakeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDrivingLicenseApplicationsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseApplicationsToolStripMenuItem;
    }
}