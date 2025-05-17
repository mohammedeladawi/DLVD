namespace DVLD
{
    partial class frmAddUpdateUser
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
            this.lblAddUpdateTitle = new System.Windows.Forms.Label();
            this.tcAddEditUser = new System.Windows.Forms.TabControl();
            this.tpPersonInfo = new System.Windows.Forms.TabPage();
            this.ctrNextBtn1 = new DVLD.ctrNextBtn();
            this.ctrFindPerson1 = new DVLD.ctrFindShowPerson();
            this.tpLoginInfo = new System.Windows.Forms.TabPage();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrCloseBtn1 = new DVLD.ctrCloseBtn();
            this.ctrSaveBtn1 = new DVLD.ctrSaveBtn();
            this.tcAddEditUser.SuspendLayout();
            this.tpPersonInfo.SuspendLayout();
            this.tpLoginInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAddUpdateTitle
            // 
            this.lblAddUpdateTitle.AutoSize = true;
            this.lblAddUpdateTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddUpdateTitle.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblAddUpdateTitle.Location = new System.Drawing.Point(543, 18);
            this.lblAddUpdateTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddUpdateTitle.Name = "lblAddUpdateTitle";
            this.lblAddUpdateTitle.Size = new System.Drawing.Size(71, 31);
            this.lblAddUpdateTitle.TabIndex = 0;
            this.lblAddUpdateTitle.Text = "Title";
            // 
            // tcAddEditUser
            // 
            this.tcAddEditUser.Controls.Add(this.tpPersonInfo);
            this.tcAddEditUser.Controls.Add(this.tpLoginInfo);
            this.tcAddEditUser.Location = new System.Drawing.Point(22, 65);
            this.tcAddEditUser.Margin = new System.Windows.Forms.Padding(2);
            this.tcAddEditUser.Name = "tcAddEditUser";
            this.tcAddEditUser.SelectedIndex = 0;
            this.tcAddEditUser.Size = new System.Drawing.Size(1096, 649);
            this.tcAddEditUser.TabIndex = 1;
            this.tcAddEditUser.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tcAddEditUser_Selecting);
            // 
            // tpPersonInfo
            // 
            this.tpPersonInfo.Controls.Add(this.ctrNextBtn1);
            this.tpPersonInfo.Controls.Add(this.ctrFindPerson1);
            this.tpPersonInfo.Location = new System.Drawing.Point(4, 25);
            this.tpPersonInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tpPersonInfo.Name = "tpPersonInfo";
            this.tpPersonInfo.Padding = new System.Windows.Forms.Padding(2);
            this.tpPersonInfo.Size = new System.Drawing.Size(1088, 620);
            this.tpPersonInfo.TabIndex = 0;
            this.tpPersonInfo.Text = "Person Info";
            this.tpPersonInfo.UseVisualStyleBackColor = true;
            // 
            // ctrNextBtn1
            // 
            this.ctrNextBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrNextBtn1.Location = new System.Drawing.Point(928, 556);
            this.ctrNextBtn1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrNextBtn1.Name = "ctrNextBtn1";
            this.ctrNextBtn1.Size = new System.Drawing.Size(143, 42);
            this.ctrNextBtn1.TabIndex = 1;
            this.ctrNextBtn1.Click += new System.EventHandler(this.ctrNextBtn1_Click);
            // 
            // ctrFindPerson1
            // 
            this.ctrFindPerson1.Location = new System.Drawing.Point(37, 29);
            this.ctrFindPerson1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrFindPerson1.Name = "ctrFindPerson1";
            this.ctrFindPerson1.person = null;
            this.ctrFindPerson1.Size = new System.Drawing.Size(1019, 494);
            this.ctrFindPerson1.TabIndex = 0;
            // 
            // tpLoginInfo
            // 
            this.tpLoginInfo.Controls.Add(this.cbIsActive);
            this.tpLoginInfo.Controls.Add(this.txtConfirmPassword);
            this.tpLoginInfo.Controls.Add(this.txtPassword);
            this.tpLoginInfo.Controls.Add(this.txtUserName);
            this.tpLoginInfo.Controls.Add(this.lblUserId);
            this.tpLoginInfo.Controls.Add(this.label4);
            this.tpLoginInfo.Controls.Add(this.label3);
            this.tpLoginInfo.Controls.Add(this.label2);
            this.tpLoginInfo.Controls.Add(this.label1);
            this.tpLoginInfo.Location = new System.Drawing.Point(4, 25);
            this.tpLoginInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tpLoginInfo.Name = "tpLoginInfo";
            this.tpLoginInfo.Padding = new System.Windows.Forms.Padding(2);
            this.tpLoginInfo.Size = new System.Drawing.Size(1088, 620);
            this.tpLoginInfo.TabIndex = 1;
            this.tpLoginInfo.Text = "Login Info";
            this.tpLoginInfo.UseVisualStyleBackColor = true;
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Location = new System.Drawing.Point(208, 243);
            this.cbIsActive.Margin = new System.Windows.Forms.Padding(2);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(79, 20);
            this.cbIsActive.TabIndex = 2;
            this.cbIsActive.Text = "Is Active";
            this.cbIsActive.UseVisualStyleBackColor = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(183, 198);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(185, 22);
            this.txtConfirmPassword.TabIndex = 1;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(183, 148);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(185, 22);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(183, 99);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(185, 22);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(121, 45);
            this.lblUserId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(28, 16);
            this.lblUserId.TabIndex = 0;
            this.lblUserId.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 202);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Confirm Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 148);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "UserName:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserID:";
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(783, 748);
            this.ctrCloseBtn1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(153, 42);
            this.ctrCloseBtn1.TabIndex = 3;
            // 
            // ctrSaveBtn1
            // 
            this.ctrSaveBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrSaveBtn1.Location = new System.Drawing.Point(969, 748);
            this.ctrSaveBtn1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrSaveBtn1.Name = "ctrSaveBtn1";
            this.ctrSaveBtn1.Size = new System.Drawing.Size(149, 42);
            this.ctrSaveBtn1.TabIndex = 2;
            this.ctrSaveBtn1.Click += new System.EventHandler(this.ctrSaveBtn1_Click);
            // 
            // frmAddUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 801);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.ctrSaveBtn1);
            this.Controls.Add(this.tcAddEditUser);
            this.Controls.Add(this.lblAddUpdateTitle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAddUpdateUser";
            this.Text = "frmAddUpdateUser";
            this.Load += new System.EventHandler(this.frmAddUpdateUser_Load);
            this.tcAddEditUser.ResumeLayout(false);
            this.tpPersonInfo.ResumeLayout(false);
            this.tpLoginInfo.ResumeLayout(false);
            this.tpLoginInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddUpdateTitle;
        private System.Windows.Forms.TabControl tcAddEditUser;
        private System.Windows.Forms.TabPage tpPersonInfo;
        private System.Windows.Forms.TabPage tpLoginInfo;
        private ctrFindShowPerson ctrFindPerson1;
        private ctrNextBtn ctrNextBtn1;
        private ctrSaveBtn ctrSaveBtn1;
        private ctrCloseBtn ctrCloseBtn1;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbIsActive;
    }
}