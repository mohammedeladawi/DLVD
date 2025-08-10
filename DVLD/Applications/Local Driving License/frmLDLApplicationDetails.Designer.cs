namespace DVLD.Applications.Local_Driving_License
{
    partial class frmLDLApplicationDetails
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
            this.ctrLDLApplicationInfo1 = new DVLD.ctrLDLApplicationInfo();
            this.ctrCloseBtn1 = new DVLD.ctrCloseBtn();
            this.SuspendLayout();
            // 
            // ctrLDLApplicationInfo1
            // 
            this.ctrLDLApplicationInfo1.Location = new System.Drawing.Point(30, 23);
            this.ctrLDLApplicationInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrLDLApplicationInfo1.Name = "ctrLDLApplicationInfo1";
            this.ctrLDLApplicationInfo1.Size = new System.Drawing.Size(1179, 728);
            this.ctrLDLApplicationInfo1.TabIndex = 0;
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(971, 750);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(228, 64);
            this.ctrCloseBtn1.TabIndex = 1;
            // 
            // frmLDLApplicationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 846);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.ctrLDLApplicationInfo1);
            this.Name = "frmLDLApplicationDetails";
            this.Text = "frmLDLApplicationDetails";
            this.Load += new System.EventHandler(this.frmLDLApplicationDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrLDLApplicationInfo ctrLDLApplicationInfo1;
        private ctrCloseBtn ctrCloseBtn1;
    }
}