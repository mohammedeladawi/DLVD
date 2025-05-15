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
            this.tsmiApplications.Name = "tsmiApplications";
            this.tsmiApplications.Size = new System.Drawing.Size(164, 38);
            this.tsmiApplications.Text = "Applications";
            // 
            // tsmiPeople
            // 
            this.tsmiPeople.Name = "tsmiPeople";
            this.tsmiPeople.Size = new System.Drawing.Size(106, 38);
            this.tsmiPeople.Text = "People";
            this.tsmiPeople.Click += new System.EventHandler(this.tsmiPeople_Click);
            // 
            // tsmiDrivers
            // 
            this.tsmiDrivers.Name = "tsmiDrivers";
            this.tsmiDrivers.Size = new System.Drawing.Size(108, 38);
            this.tsmiDrivers.Text = "Drivers";
            // 
            // tsmiUsers
            // 
            this.tsmiUsers.Name = "tsmiUsers";
            this.tsmiUsers.Size = new System.Drawing.Size(91, 38);
            this.tsmiUsers.Text = "Users";
            this.tsmiUsers.Click += new System.EventHandler(this.tsmiUsers_Click);
            // 
            // tsmiAccountSettings
            // 
            this.tsmiAccountSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCurrUserInfo,
            this.tsmiChangeCurrUserPassword,
            this.tsmiSignOut});
            this.tsmiAccountSettings.Name = "tsmiAccountSettings";
            this.tsmiAccountSettings.Size = new System.Drawing.Size(214, 38);
            this.tsmiAccountSettings.Text = "Account Settings";
            // 
            // tsmiCurrUserInfo
            // 
            this.tsmiCurrUserInfo.Name = "tsmiCurrUserInfo";
            this.tsmiCurrUserInfo.Size = new System.Drawing.Size(359, 44);
            this.tsmiCurrUserInfo.Text = "Current User Info";
            this.tsmiCurrUserInfo.Click += new System.EventHandler(this.tsmiCurrUserInfo_Click);
            // 
            // tsmiChangeCurrUserPassword
            // 
            this.tsmiChangeCurrUserPassword.Name = "tsmiChangeCurrUserPassword";
            this.tsmiChangeCurrUserPassword.Size = new System.Drawing.Size(359, 44);
            this.tsmiChangeCurrUserPassword.Text = "Change Password";
            this.tsmiChangeCurrUserPassword.Click += new System.EventHandler(this.tsmiChangeCurrUserPassword_Click);
            // 
            // tsmiSignOut
            // 
            this.tsmiSignOut.Name = "tsmiSignOut";
            this.tsmiSignOut.Size = new System.Drawing.Size(359, 44);
            this.tsmiSignOut.Text = "Sign Out";
            this.tsmiSignOut.Click += new System.EventHandler(this.tsmiSignOut_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1870, 1088);
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
    }
}