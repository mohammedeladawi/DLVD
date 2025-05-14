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
            this.ctrUserPersonInformation1 = new DVLD.ctrUserPersonInformation();
            this.ctrCloseBtn2 = new DVLD.ctrCloseBtn();
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
            // ctrUserPersonInformation1
            // 
            this.ctrUserPersonInformation1.Location = new System.Drawing.Point(23, 12);
            this.ctrUserPersonInformation1.Name = "ctrUserPersonInformation1";
            this.ctrUserPersonInformation1.Size = new System.Drawing.Size(1536, 1000);
            this.ctrUserPersonInformation1.TabIndex = 3;
            // 
            // ctrCloseBtn2
            // 
            this.ctrCloseBtn2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn2.Location = new System.Drawing.Point(1309, 913);
            this.ctrCloseBtn2.Name = "ctrCloseBtn2";
            this.ctrCloseBtn2.Size = new System.Drawing.Size(228, 64);
            this.ctrCloseBtn2.TabIndex = 4;
            // 
            // frmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1564, 989);
            this.Controls.Add(this.ctrCloseBtn2);
            this.Controls.Add(this.ctrUserPersonInformation1);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Name = "frmUserDetails";
            this.Text = "frmUserDetails";
            this.Load += new System.EventHandler(this.frmUserDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private ctrCloseBtn ctrCloseBtn1;
        private ctrUserPersonInformation ctrUserPersonInformation1;
        private ctrCloseBtn ctrCloseBtn2;
    }
}