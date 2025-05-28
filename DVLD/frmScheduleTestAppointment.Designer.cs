namespace DVLD
{
    partial class frmScheduleTestAppointment
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
            this.gpTest = new System.Windows.Forms.GroupBox();
            this.dtpAppointmentDate = new System.Windows.Forms.DateTimePicker();
            this.gpRetakeTestInfo = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.lblRetakeTestAppFees = new System.Windows.Forms.Label();
            this.lblRetakeTestAppID = new System.Windows.Forms.Label();
            this.lblFees = new System.Windows.Forms.Label();
            this.lblTrials = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLicenseClass = new System.Windows.Forms.Label();
            this.lblDLApplicationID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTestTitle = new System.Windows.Forms.Label();
            this.ctrSaveBtn1 = new DVLD.ctrSaveBtn();
            this.ctrCloseBtn1 = new DVLD.ctrCloseBtn();
            this.gpTest.SuspendLayout();
            this.gpRetakeTestInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpTest
            // 
            this.gpTest.Controls.Add(this.dtpAppointmentDate);
            this.gpTest.Controls.Add(this.gpRetakeTestInfo);
            this.gpTest.Controls.Add(this.lblFees);
            this.gpTest.Controls.Add(this.lblTrials);
            this.gpTest.Controls.Add(this.lblName);
            this.gpTest.Controls.Add(this.lblLicenseClass);
            this.gpTest.Controls.Add(this.lblDLApplicationID);
            this.gpTest.Controls.Add(this.label6);
            this.gpTest.Controls.Add(this.label5);
            this.gpTest.Controls.Add(this.label4);
            this.gpTest.Controls.Add(this.label3);
            this.gpTest.Controls.Add(this.label2);
            this.gpTest.Controls.Add(this.label1);
            this.gpTest.Controls.Add(this.lblTestTitle);
            this.gpTest.Location = new System.Drawing.Point(12, 12);
            this.gpTest.Name = "gpTest";
            this.gpTest.Size = new System.Drawing.Size(580, 537);
            this.gpTest.TabIndex = 1;
            this.gpTest.TabStop = false;
            this.gpTest.Text = "Test";
            // 
            // dtpAppointmentDate
            // 
            this.dtpAppointmentDate.Location = new System.Drawing.Point(163, 283);
            this.dtpAppointmentDate.Name = "dtpAppointmentDate";
            this.dtpAppointmentDate.Size = new System.Drawing.Size(200, 22);
            this.dtpAppointmentDate.TabIndex = 10;
            // 
            // gpRetakeTestInfo
            // 
            this.gpRetakeTestInfo.Controls.Add(this.label8);
            this.gpRetakeTestInfo.Controls.Add(this.label9);
            this.gpRetakeTestInfo.Controls.Add(this.label7);
            this.gpRetakeTestInfo.Controls.Add(this.lblTotalFees);
            this.gpRetakeTestInfo.Controls.Add(this.lblRetakeTestAppFees);
            this.gpRetakeTestInfo.Controls.Add(this.lblRetakeTestAppID);
            this.gpRetakeTestInfo.Location = new System.Drawing.Point(6, 386);
            this.gpRetakeTestInfo.Name = "gpRetakeTestInfo";
            this.gpRetakeTestInfo.Size = new System.Drawing.Size(568, 145);
            this.gpRetakeTestInfo.TabIndex = 9;
            this.gpRetakeTestInfo.TabStop = false;
            this.gpRetakeTestInfo.Text = "Retake Test Info";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "R.App.Test.AppID:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(301, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "Total Fees:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(49, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "R.App.Fees:";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Location = new System.Drawing.Point(407, 40);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(44, 16);
            this.lblTotalFees.TabIndex = 8;
            this.lblTotalFees.Text = "label7";
            // 
            // lblRetakeTestAppFees
            // 
            this.lblRetakeTestAppFees.AutoSize = true;
            this.lblRetakeTestAppFees.Location = new System.Drawing.Point(154, 40);
            this.lblRetakeTestAppFees.Name = "lblRetakeTestAppFees";
            this.lblRetakeTestAppFees.Size = new System.Drawing.Size(44, 16);
            this.lblRetakeTestAppFees.TabIndex = 8;
            this.lblRetakeTestAppFees.Text = "label7";
            // 
            // lblRetakeTestAppID
            // 
            this.lblRetakeTestAppID.AutoSize = true;
            this.lblRetakeTestAppID.Location = new System.Drawing.Point(154, 91);
            this.lblRetakeTestAppID.Name = "lblRetakeTestAppID";
            this.lblRetakeTestAppID.Size = new System.Drawing.Size(44, 16);
            this.lblRetakeTestAppID.TabIndex = 8;
            this.lblRetakeTestAppID.Text = "label7";
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Location = new System.Drawing.Point(160, 338);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(44, 16);
            this.lblFees.TabIndex = 8;
            this.lblFees.Text = "label7";
            // 
            // lblTrials
            // 
            this.lblTrials.AutoSize = true;
            this.lblTrials.Location = new System.Drawing.Point(160, 242);
            this.lblTrials.Name = "lblTrials";
            this.lblTrials.Size = new System.Drawing.Size(44, 16);
            this.lblTrials.TabIndex = 8;
            this.lblTrials.Text = "label7";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(160, 197);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 16);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "label7";
            // 
            // lblLicenseClass
            // 
            this.lblLicenseClass.AutoSize = true;
            this.lblLicenseClass.Location = new System.Drawing.Point(160, 154);
            this.lblLicenseClass.Name = "lblLicenseClass";
            this.lblLicenseClass.Size = new System.Drawing.Size(44, 16);
            this.lblLicenseClass.TabIndex = 8;
            this.lblLicenseClass.Text = "label7";
            // 
            // lblDLApplicationID
            // 
            this.lblDLApplicationID.AutoSize = true;
            this.lblDLApplicationID.Location = new System.Drawing.Point(160, 102);
            this.lblDLApplicationID.Name = "lblDLApplicationID";
            this.lblDLApplicationID.Size = new System.Drawing.Size(44, 16);
            this.lblDLApplicationID.TabIndex = 8;
            this.lblDLApplicationID.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(38, 338);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Fees:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Trial:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "D. Class:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "D.L. AppID:";
            // 
            // lblTestTitle
            // 
            this.lblTestTitle.AutoSize = true;
            this.lblTestTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestTitle.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTestTitle.Location = new System.Drawing.Point(212, 30);
            this.lblTestTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTestTitle.Name = "lblTestTitle";
            this.lblTestTitle.Size = new System.Drawing.Size(92, 31);
            this.lblTestTitle.TabIndex = 6;
            this.lblTestTitle.Text = "label2";
            this.lblTestTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrSaveBtn1
            // 
            this.ctrSaveBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrSaveBtn1.Location = new System.Drawing.Point(307, 579);
            this.ctrSaveBtn1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ctrSaveBtn1.Name = "ctrSaveBtn1";
            this.ctrSaveBtn1.Size = new System.Drawing.Size(141, 42);
            this.ctrSaveBtn1.TabIndex = 9;
            this.ctrSaveBtn1.Click += new System.EventHandler(this.ctrSaveBtn1_Click);
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(106, 579);
            this.ctrCloseBtn1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(153, 42);
            this.ctrCloseBtn1.TabIndex = 2;
            // 
            // frmScheduleTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 637);
            this.Controls.Add(this.ctrSaveBtn1);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.gpTest);
            this.Name = "frmScheduleTestAppointment";
            this.Text = "frmAddEditVisionTestAppointment";
            this.Load += new System.EventHandler(this.frmAddEditVisionTestAppointment_Load);
            this.gpTest.ResumeLayout(false);
            this.gpTest.PerformLayout();
            this.gpRetakeTestInfo.ResumeLayout(false);
            this.gpRetakeTestInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpTest;
        private System.Windows.Forms.DateTimePicker dtpAppointmentDate;
        private System.Windows.Forms.GroupBox gpRetakeTestInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label lblRetakeTestAppFees;
        private System.Windows.Forms.Label lblRetakeTestAppID;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label lblTrials;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLicenseClass;
        private System.Windows.Forms.Label lblDLApplicationID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTestTitle;
        private ctrSaveBtn ctrSaveBtn1;
        private ctrCloseBtn ctrCloseBtn1;
    }
}