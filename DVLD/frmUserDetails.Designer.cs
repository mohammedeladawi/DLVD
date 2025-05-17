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
            this.ctrCloseBtn1.Location = new System.Drawing.Point(855, 518);
            this.ctrCloseBtn1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(153, 42);
            this.ctrCloseBtn1.TabIndex = 2;
            // 
            // ctrUserPersonInformation1
            // 
            this.ctrUserPersonInformation1.Location = new System.Drawing.Point(9, 10);
            this.ctrUserPersonInformation1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ctrUserPersonInformation1.Name = "ctrUserPersonInformation1";
            this.ctrUserPersonInformation1.Size = new System.Drawing.Size(1024, 640);
            this.ctrUserPersonInformation1.TabIndex = 3;
            // 
            // ctrCloseBtn2
            // 
            this.ctrCloseBtn2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn2.Location = new System.Drawing.Point(873, 584);
            this.ctrCloseBtn2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ctrCloseBtn2.Name = "ctrCloseBtn2";
            this.ctrCloseBtn2.Size = new System.Drawing.Size(153, 42);
            this.ctrCloseBtn2.TabIndex = 4;
            // 
            // frmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 633);
            this.Controls.Add(this.ctrCloseBtn2);
            this.Controls.Add(this.ctrUserPersonInformation1);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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