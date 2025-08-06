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
            this.ctrUserInformation11 = new DVLD.ctrUserInformation();
            this.SuspendLayout();
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(822, 561);
            this.ctrCloseBtn1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(153, 42);
            this.ctrCloseBtn1.TabIndex = 2;
            // 
            // ctrUserInformation11
            // 
            this.ctrUserInformation11.Location = new System.Drawing.Point(20, 12);
            this.ctrUserInformation11.Name = "ctrUserInformation11";
            this.ctrUserInformation11.Size = new System.Drawing.Size(1011, 527);
            this.ctrUserInformation11.TabIndex = 3;
            // 
            // frmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 633);
            this.Controls.Add(this.ctrUserInformation11);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmUserDetails";
            this.Text = "frmUserDetails";
            this.Load += new System.EventHandler(this.frmUserDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private ctrCloseBtn ctrCloseBtn1;
        private ctrUserInformation ctrUserInformation11;
    }
}