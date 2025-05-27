namespace DVLD
{
    partial class frmAddEditLDLApplication
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
            this.lblLDLApplicationTitle = new System.Windows.Forms.Label();
            this.tcLDLApplication = new System.Windows.Forms.TabControl();
            this.tpPersonInfo = new System.Windows.Forms.TabPage();
            this.ctrNextBtn1 = new DVLD.ctrNextBtn();
            this.ctrFindShowPerson1 = new DVLD.ctrFindShowPerson();
            this.tpApplicationInfo = new System.Windows.Forms.TabPage();
            this.cbLicenseClasses = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblDLApplicationID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrCloseBtn1 = new DVLD.ctrCloseBtn();
            this.ctrSaveBtn1 = new DVLD.ctrSaveBtn();
            this.tcLDLApplication.SuspendLayout();
            this.tpPersonInfo.SuspendLayout();
            this.tpApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLDLApplicationTitle
            // 
            this.lblLDLApplicationTitle.AutoSize = true;
            this.lblLDLApplicationTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLDLApplicationTitle.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblLDLApplicationTitle.Location = new System.Drawing.Point(239, 27);
            this.lblLDLApplicationTitle.Name = "lblLDLApplicationTitle";
            this.lblLDLApplicationTitle.Size = new System.Drawing.Size(562, 36);
            this.lblLDLApplicationTitle.TabIndex = 4;
            this.lblLDLApplicationTitle.Text = "New Local Driving License Application";
            // 
            // tcLDLApplication
            // 
            this.tcLDLApplication.Controls.Add(this.tpPersonInfo);
            this.tcLDLApplication.Controls.Add(this.tpApplicationInfo);
            this.tcLDLApplication.Location = new System.Drawing.Point(71, 86);
            this.tcLDLApplication.Margin = new System.Windows.Forms.Padding(2);
            this.tcLDLApplication.Name = "tcLDLApplication";
            this.tcLDLApplication.SelectedIndex = 0;
            this.tcLDLApplication.Size = new System.Drawing.Size(985, 600);
            this.tcLDLApplication.TabIndex = 5;
            this.tcLDLApplication.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tcLDLApplication_Selecting);
            // 
            // tpPersonInfo
            // 
            this.tpPersonInfo.Controls.Add(this.ctrNextBtn1);
            this.tpPersonInfo.Controls.Add(this.ctrFindShowPerson1);
            this.tpPersonInfo.Location = new System.Drawing.Point(4, 25);
            this.tpPersonInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tpPersonInfo.Name = "tpPersonInfo";
            this.tpPersonInfo.Padding = new System.Windows.Forms.Padding(2);
            this.tpPersonInfo.Size = new System.Drawing.Size(977, 571);
            this.tpPersonInfo.TabIndex = 0;
            this.tpPersonInfo.Text = "Personal Info";
            this.tpPersonInfo.UseVisualStyleBackColor = true;
            // 
            // ctrNextBtn1
            // 
            this.ctrNextBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrNextBtn1.Location = new System.Drawing.Point(813, 522);
            this.ctrNextBtn1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrNextBtn1.Name = "ctrNextBtn1";
            this.ctrNextBtn1.Size = new System.Drawing.Size(142, 40);
            this.ctrNextBtn1.TabIndex = 1;
            this.ctrNextBtn1.Click += new System.EventHandler(this.ctrNextBtn1_Click);
            // 
            // ctrFindShowPerson1
            // 
            this.ctrFindShowPerson1.Location = new System.Drawing.Point(4, 15);
            this.ctrFindShowPerson1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrFindShowPerson1.Name = "ctrFindShowPerson1";
            this.ctrFindShowPerson1.person = null;
            this.ctrFindShowPerson1.Size = new System.Drawing.Size(950, 495);
            this.ctrFindShowPerson1.TabIndex = 0;
            // 
            // tpApplicationInfo
            // 
            this.tpApplicationInfo.Controls.Add(this.cbLicenseClasses);
            this.tpApplicationInfo.Controls.Add(this.label6);
            this.tpApplicationInfo.Controls.Add(this.label5);
            this.tpApplicationInfo.Controls.Add(this.label4);
            this.tpApplicationInfo.Controls.Add(this.label3);
            this.tpApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.tpApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.tpApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.tpApplicationInfo.Controls.Add(this.lblDLApplicationID);
            this.tpApplicationInfo.Controls.Add(this.label2);
            this.tpApplicationInfo.Location = new System.Drawing.Point(4, 25);
            this.tpApplicationInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tpApplicationInfo.Name = "tpApplicationInfo";
            this.tpApplicationInfo.Padding = new System.Windows.Forms.Padding(2);
            this.tpApplicationInfo.Size = new System.Drawing.Size(977, 571);
            this.tpApplicationInfo.TabIndex = 1;
            this.tpApplicationInfo.Text = "ApplicationInfo";
            this.tpApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // cbLicenseClasses
            // 
            this.cbLicenseClasses.FormattingEnabled = true;
            this.cbLicenseClasses.Location = new System.Drawing.Point(247, 165);
            this.cbLicenseClasses.Margin = new System.Windows.Forms.Padding(2);
            this.cbLicenseClasses.Name = "cbLicenseClasses";
            this.cbLicenseClasses.Size = new System.Drawing.Size(235, 24);
            this.cbLicenseClasses.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(77, 292);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Created By:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(77, 231);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Application Fees:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(77, 170);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "License Class:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Application Date:";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(244, 292);
            this.lblCreatedBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(35, 17);
            this.lblCreatedBy.TabIndex = 0;
            this.lblCreatedBy.Text = "???";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(244, 231);
            this.lblApplicationFees.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(35, 17);
            this.lblApplicationFees.TabIndex = 0;
            this.lblApplicationFees.Text = "???";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(244, 109);
            this.lblApplicationDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(35, 17);
            this.lblApplicationDate.TabIndex = 0;
            this.lblApplicationDate.Text = "???";
            // 
            // lblDLApplicationID
            // 
            this.lblDLApplicationID.AutoSize = true;
            this.lblDLApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDLApplicationID.Location = new System.Drawing.Point(244, 49);
            this.lblDLApplicationID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDLApplicationID.Name = "lblDLApplicationID";
            this.lblDLApplicationID.Size = new System.Drawing.Size(35, 17);
            this.lblDLApplicationID.TabIndex = 0;
            this.lblDLApplicationID.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "D.L. Application ID:";
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(739, 712);
            this.ctrCloseBtn1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(153, 42);
            this.ctrCloseBtn1.TabIndex = 7;
            // 
            // ctrSaveBtn1
            // 
            this.ctrSaveBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrSaveBtn1.Location = new System.Drawing.Point(911, 712);
            this.ctrSaveBtn1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrSaveBtn1.Name = "ctrSaveBtn1";
            this.ctrSaveBtn1.Size = new System.Drawing.Size(141, 42);
            this.ctrSaveBtn1.TabIndex = 6;
            this.ctrSaveBtn1.Click += new System.EventHandler(this.ctrSaveBtn1_Click);
            // 
            // frmAddEditLDLApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 784);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.ctrSaveBtn1);
            this.Controls.Add(this.tcLDLApplication);
            this.Controls.Add(this.lblLDLApplicationTitle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAddEditLDLApplication";
            this.Text = "frmNewLocalDrivingLicenseApplication";
            this.Load += new System.EventHandler(this.frmAddEditLDLApplication_Load);
            this.tcLDLApplication.ResumeLayout(false);
            this.tpPersonInfo.ResumeLayout(false);
            this.tpApplicationInfo.ResumeLayout(false);
            this.tpApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLDLApplicationTitle;
        private System.Windows.Forms.TabControl tcLDLApplication;
        private System.Windows.Forms.TabPage tpPersonInfo;
        private System.Windows.Forms.TabPage tpApplicationInfo;
        private ctrFindShowPerson ctrFindShowPerson1;
        private ctrNextBtn ctrNextBtn1;
        private System.Windows.Forms.Label label2;
        private ctrSaveBtn ctrSaveBtn1;
        private ctrCloseBtn ctrCloseBtn1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblDLApplicationID;
        private System.Windows.Forms.ComboBox cbLicenseClasses;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblApplicationFees;
    }
}