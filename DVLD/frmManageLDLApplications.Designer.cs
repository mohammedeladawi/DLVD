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
            this.ctrCloseBtn1 = new DVLD.ctrCloseBtn();
            this.ctrManageData1 = new DVLD.ctrManageDataView();
            this.SuspendLayout();
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(1347, 1000);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(228, 64);
            this.ctrCloseBtn1.TabIndex = 3;
            // 
            // ctrManageData1
            // 
            this.ctrManageData1.Location = new System.Drawing.Point(25, 46);
            this.ctrManageData1.Margin = new System.Windows.Forms.Padding(2);
            this.ctrManageData1.Name = "ctrManageData1";
            this.ctrManageData1.Size = new System.Drawing.Size(1550, 919);
            this.ctrManageData1.TabIndex = 2;
            // 
            // frmManageLDLApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1612, 1086);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.ctrManageData1);
            this.Name = "frmManageLDLApplications";
            this.Text = "frmManageLDLApplications";
            this.Load += new System.EventHandler(this.frmManageLDLApplications_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrCloseBtn ctrCloseBtn1;
        private ctrManageDataView ctrManageData1;
    }
}