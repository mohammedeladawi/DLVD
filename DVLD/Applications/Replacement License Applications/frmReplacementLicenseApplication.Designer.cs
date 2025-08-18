namespace DVLD
{
    partial class frmReplacementLicenseApplication
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
            this.label1 = new System.Windows.Forms.Label();
            this.ctrFindDLicenseInfo1 = new DVLD.ctrFindDLicenseInfo();
            this.gbReplacement = new System.Windows.Forms.GroupBox();
            this.rbLostLicense = new System.Windows.Forms.RadioButton();
            this.rbDamagedLicense = new System.Windows.Forms.RadioButton();
            this.ctrIssueBtn1 = new DVLD.ctrIssueBtn();
            this.ctrCloseBtn1 = new DVLD.ctrCloseBtn();
            this.llblShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.llblShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.lblReplacedLicenseID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLicenseReplacementAppID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbReplacement.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(417, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(765, 55);
            this.label1.TabIndex = 8;
            this.label1.Text = "Replacement License Application";
            // 
            // ctrFindDLicenseInfo1
            // 
            this.ctrFindDLicenseInfo1.Location = new System.Drawing.Point(28, 125);
            this.ctrFindDLicenseInfo1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ctrFindDLicenseInfo1.Name = "ctrFindDLicenseInfo1";
            this.ctrFindDLicenseInfo1.Size = new System.Drawing.Size(1575, 719);
            this.ctrFindDLicenseInfo1.TabIndex = 7;
            this.ctrFindDLicenseInfo1.txtSearchText = "";
            this.ctrFindDLicenseInfo1.onLocalLicenseInfoLoaded += new System.Action<int>(this.ctrFindDLicenseInfo1_onLocalLicenseInfoLoaded);
            // 
            // gbReplacement
            // 
            this.gbReplacement.Controls.Add(this.rbLostLicense);
            this.gbReplacement.Controls.Add(this.rbDamagedLicense);
            this.gbReplacement.Location = new System.Drawing.Point(1285, 134);
            this.gbReplacement.Name = "gbReplacement";
            this.gbReplacement.Size = new System.Drawing.Size(318, 120);
            this.gbReplacement.TabIndex = 9;
            this.gbReplacement.TabStop = false;
            this.gbReplacement.Text = "Replacement For";
            // 
            // rbLostLicense
            // 
            this.rbLostLicense.AutoSize = true;
            this.rbLostLicense.Location = new System.Drawing.Point(38, 75);
            this.rbLostLicense.Name = "rbLostLicense";
            this.rbLostLicense.Size = new System.Drawing.Size(165, 29);
            this.rbLostLicense.TabIndex = 0;
            this.rbLostLicense.TabStop = true;
            this.rbLostLicense.Text = "Lost License";
            this.rbLostLicense.UseVisualStyleBackColor = true;
            this.rbLostLicense.CheckedChanged += new System.EventHandler(this.rbLostLicense_CheckedChanged);
            // 
            // rbDamagedLicense
            // 
            this.rbDamagedLicense.AutoSize = true;
            this.rbDamagedLicense.Location = new System.Drawing.Point(38, 37);
            this.rbDamagedLicense.Name = "rbDamagedLicense";
            this.rbDamagedLicense.Size = new System.Drawing.Size(216, 29);
            this.rbDamagedLicense.TabIndex = 0;
            this.rbDamagedLicense.TabStop = true;
            this.rbDamagedLicense.Text = "Damaged License";
            this.rbDamagedLicense.UseVisualStyleBackColor = true;
            this.rbDamagedLicense.CheckedChanged += new System.EventHandler(this.rbDamagedLicense_CheckedChanged);
            // 
            // ctrIssueBtn1
            // 
            this.ctrIssueBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrIssueBtn1.btnText = "Issue";
            this.ctrIssueBtn1.Location = new System.Drawing.Point(1350, 1162);
            this.ctrIssueBtn1.Name = "ctrIssueBtn1";
            this.ctrIssueBtn1.Size = new System.Drawing.Size(226, 68);
            this.ctrIssueBtn1.TabIndex = 28;
            this.ctrIssueBtn1.Click += new System.EventHandler(this.ctrIssueBtn1_Click);
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(1082, 1166);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(228, 64);
            this.ctrCloseBtn1.TabIndex = 27;
            // 
            // llblShowLicenseHistory
            // 
            this.llblShowLicenseHistory.AutoSize = true;
            this.llblShowLicenseHistory.Location = new System.Drawing.Point(106, 1175);
            this.llblShowLicenseHistory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblShowLicenseHistory.Name = "llblShowLicenseHistory";
            this.llblShowLicenseHistory.Size = new System.Drawing.Size(219, 25);
            this.llblShowLicenseHistory.TabIndex = 25;
            this.llblShowLicenseHistory.TabStop = true;
            this.llblShowLicenseHistory.Text = "Show License History";
            this.llblShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowLicenseHistory_LinkClicked);
            // 
            // llblShowLicenseInfo
            // 
            this.llblShowLicenseInfo.AutoSize = true;
            this.llblShowLicenseInfo.Location = new System.Drawing.Point(402, 1175);
            this.llblShowLicenseInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblShowLicenseInfo.Name = "llblShowLicenseInfo";
            this.llblShowLicenseInfo.Size = new System.Drawing.Size(187, 25);
            this.llblShowLicenseInfo.TabIndex = 26;
            this.llblShowLicenseInfo.TabStop = true;
            this.llblShowLicenseInfo.Text = "Show License Info";
            this.llblShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowLicenseInfo_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCreatedBy);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lblApplicationFees);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblOldLicenseID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblAppDate);
            this.groupBox2.Controls.Add(this.lblReplacedLicenseID);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblLicenseReplacementAppID);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(39, 854);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1119, 258);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Info";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(938, 200);
            this.lblCreatedBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(60, 25);
            this.lblCreatedBy.TabIndex = 13;
            this.lblCreatedBy.Text = "????";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(658, 71);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(262, 29);
            this.label7.TabIndex = 12;
            this.label7.Text = "Replaced License ID:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(76, 68);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(228, 29);
            this.label12.TabIndex = 12;
            this.label12.Text = "L.R. ApplicaitonID:";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Location = new System.Drawing.Point(325, 200);
            this.lblApplicationFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(60, 25);
            this.lblApplicationFees.TabIndex = 16;
            this.lblApplicationFees.Text = "????";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(658, 196);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(149, 29);
            this.label11.TabIndex = 9;
            this.label11.Text = "Created By:";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Location = new System.Drawing.Point(938, 136);
            this.lblOldLicenseID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(60, 25);
            this.lblOldLicenseID.TabIndex = 17;
            this.lblOldLicenseID.Text = "????";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(658, 132);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "Old License ID:";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Location = new System.Drawing.Point(325, 136);
            this.lblAppDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(60, 25);
            this.lblAppDate.TabIndex = 17;
            this.lblAppDate.Text = "????";
            // 
            // lblReplacedLicenseID
            // 
            this.lblReplacedLicenseID.AutoSize = true;
            this.lblReplacedLicenseID.Location = new System.Drawing.Point(938, 71);
            this.lblReplacedLicenseID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReplacedLicenseID.Name = "lblReplacedLicenseID";
            this.lblReplacedLicenseID.Size = new System.Drawing.Size(60, 25);
            this.lblReplacedLicenseID.TabIndex = 18;
            this.lblReplacedLicenseID.Text = "????";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(76, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 29);
            this.label5.TabIndex = 8;
            this.label5.Text = "Application Date:";
            // 
            // lblLicenseReplacementAppID
            // 
            this.lblLicenseReplacementAppID.AutoSize = true;
            this.lblLicenseReplacementAppID.Location = new System.Drawing.Point(325, 70);
            this.lblLicenseReplacementAppID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLicenseReplacementAppID.Name = "lblLicenseReplacementAppID";
            this.lblLicenseReplacementAppID.Size = new System.Drawing.Size(60, 25);
            this.lblLicenseReplacementAppID.TabIndex = 18;
            this.lblLicenseReplacementAppID.Text = "????";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(76, 198);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 29);
            this.label6.TabIndex = 7;
            this.label6.Text = "Application Fees:";
            // 
            // frmReplacementLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1626, 1248);
            this.Controls.Add(this.ctrIssueBtn1);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.llblShowLicenseHistory);
            this.Controls.Add(this.llblShowLicenseInfo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbReplacement);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrFindDLicenseInfo1);
            this.Name = "frmReplacementLicenseApplication";
            this.Text = "frmReplacementApplication";
            this.Load += new System.EventHandler(this.frmReplacementApplication_Load);
            this.gbReplacement.ResumeLayout(false);
            this.gbReplacement.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ctrFindDLicenseInfo ctrFindDLicenseInfo1;
        private System.Windows.Forms.GroupBox gbReplacement;
        private System.Windows.Forms.RadioButton rbLostLicense;
        private System.Windows.Forms.RadioButton rbDamagedLicense;
        private ctrIssueBtn ctrIssueBtn1;
        private ctrCloseBtn ctrCloseBtn1;
        private System.Windows.Forms.LinkLabel llblShowLicenseHistory;
        private System.Windows.Forms.LinkLabel llblShowLicenseInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label lblReplacedLicenseID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLicenseReplacementAppID;
        private System.Windows.Forms.Label label6;
    }
}