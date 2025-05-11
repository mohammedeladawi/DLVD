namespace DVLD
{
    partial class frmUserDetails
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
            this.ctrUserInfo1 = new DVLD.ctrUserInfo();
            this.ctrPersonInformation1 = new DVLD.ctrPersonInformation();
            this.SuspendLayout();
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(1283, 810);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(228, 64);
            this.ctrCloseBtn1.TabIndex = 2;
            // 
            // ctrUserInfo1
            // 
            this.ctrUserInfo1.Location = new System.Drawing.Point(94, 667);
            this.ctrUserInfo1.Name = "ctrUserInfo1";
            this.ctrUserInfo1.Size = new System.Drawing.Size(1166, 148);
            this.ctrUserInfo1.TabIndex = 1;
            // 
            // ctrPersonInformation1
            // 
            this.ctrPersonInformation1.Location = new System.Drawing.Point(75, 11);
            this.ctrPersonInformation1.Name = "ctrPersonInformation1";
            this.ctrPersonInformation1.Size = new System.Drawing.Size(1418, 650);
            this.ctrPersonInformation1.TabIndex = 0;
            // 
            // frmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1542, 886);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.ctrUserInfo1);
            this.Controls.Add(this.ctrPersonInformation1);
            this.Name = "frmUserDetails";
            this.Text = "frmUserDetails";
            this.Load += new System.EventHandler(this.frmUserDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrPersonInformation ctrPersonInformation1;
        private ctrUserInfo ctrUserInfo1;
        private ctrCloseBtn ctrCloseBtn1;
    }
}