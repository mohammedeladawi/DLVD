namespace DVLD
{
    partial class frmManageUsers
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
            this.cmsUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowUserDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddNewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeUserPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrManageData1 = new DVLD.ctrFilterDataView();
            this.ctrCloseBtn1 = new DVLD.ctrCloseBtn();
            this.cmsUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsUsers
            // 
            this.cmsUsers.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmsUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowUserDetails,
            this.tsmiAddNewUser,
            this.tsmiEditUser,
            this.tsmiDeleteUser,
            this.tsmiChangeUserPassword});
            this.cmsUsers.Name = "contextMenuStrip1";
            this.cmsUsers.Size = new System.Drawing.Size(194, 124);
            // 
            // tsmiShowUserDetails
            // 
            this.tsmiShowUserDetails.Name = "tsmiShowUserDetails";
            this.tsmiShowUserDetails.Size = new System.Drawing.Size(193, 24);
            this.tsmiShowUserDetails.Text = "Show Details";
            this.tsmiShowUserDetails.Click += new System.EventHandler(this.tsmiShowUserDetails_Click);
            // 
            // tsmiAddNewUser
            // 
            this.tsmiAddNewUser.Name = "tsmiAddNewUser";
            this.tsmiAddNewUser.Size = new System.Drawing.Size(193, 24);
            this.tsmiAddNewUser.Text = "Add New User";
            this.tsmiAddNewUser.Click += new System.EventHandler(this.tsmiAddNewUser_Click);
            // 
            // tsmiEditUser
            // 
            this.tsmiEditUser.Name = "tsmiEditUser";
            this.tsmiEditUser.Size = new System.Drawing.Size(193, 24);
            this.tsmiEditUser.Text = "Edit";
            this.tsmiEditUser.Click += new System.EventHandler(this.tsmiEditUser_Click);
            // 
            // tsmiDeleteUser
            // 
            this.tsmiDeleteUser.Name = "tsmiDeleteUser";
            this.tsmiDeleteUser.Size = new System.Drawing.Size(193, 24);
            this.tsmiDeleteUser.Text = "Delete";
            this.tsmiDeleteUser.Click += new System.EventHandler(this.tsmiDeleteUser_Click);
            // 
            // tsmiChangeUserPassword
            // 
            this.tsmiChangeUserPassword.Name = "tsmiChangeUserPassword";
            this.tsmiChangeUserPassword.Size = new System.Drawing.Size(193, 24);
            this.tsmiChangeUserPassword.Text = "Change Password";
            this.tsmiChangeUserPassword.Click += new System.EventHandler(this.tsmiChangeUserPassword_Click);
            // 
            // ctrManageData1
            // 
            this.ctrManageData1.Location = new System.Drawing.Point(21, 10);
            this.ctrManageData1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ctrManageData1.Name = "ctrManageData1";
            this.ctrManageData1.Size = new System.Drawing.Size(1033, 588);
            this.ctrManageData1.TabIndex = 0;
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(946, 621);
            this.ctrCloseBtn1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(153, 42);
            this.ctrCloseBtn1.TabIndex = 1;
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 674);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.ctrManageData1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmManageUsers";
            this.Text = "frmManageUsers";
            this.Load += new System.EventHandler(this.frmManageUsers_Load);
            this.cmsUsers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrFilterDataView ctrManageData1;
        private System.Windows.Forms.ContextMenuStrip cmsUsers;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowUserDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNewUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeUserPassword;
        private ctrCloseBtn ctrCloseBtn1;
    }
}