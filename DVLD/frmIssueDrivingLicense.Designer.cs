namespace DVLD
{
    partial class frmIssueDrivingLicense
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
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrCloseBtn1 = new DVLD.ctrCloseBtn();
            this.ctrIssueBtn1 = new DVLD.ctrIssueBtn();
            this.SuspendLayout();
            // 
            // ctrLDLApplicationInfo1
            // 
            this.ctrLDLApplicationInfo1.Location = new System.Drawing.Point(13, 19);
            this.ctrLDLApplicationInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrLDLApplicationInfo1.Name = "ctrLDLApplicationInfo1";
            this.ctrLDLApplicationInfo1.Size = new System.Drawing.Size(1179, 728);
            this.ctrLDLApplicationInfo1.TabIndex = 0;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(173, 716);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(990, 287);
            this.txtNotes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 729);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Notes:";
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(685, 1048);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(228, 64);
            this.ctrCloseBtn1.TabIndex = 3;
            // 
            // ctrIssueBtn1
            // 
            this.ctrIssueBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrIssueBtn1.Location = new System.Drawing.Point(937, 1048);
            this.ctrIssueBtn1.Name = "ctrIssueBtn1";
            this.ctrIssueBtn1.Size = new System.Drawing.Size(226, 64);
            this.ctrIssueBtn1.TabIndex = 4;
            this.ctrIssueBtn1.Click += new System.EventHandler(this.ctrIssueBtn1_Click);
            // 
            // frmIssueDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 1134);
            this.Controls.Add(this.ctrIssueBtn1);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.ctrLDLApplicationInfo1);
            this.Name = "frmIssueDrivingLicense";
            this.Text = "frmIssueDrivingLicense";
            this.Load += new System.EventHandler(this.frmIssueDrivingLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrLDLApplicationInfo ctrLDLApplicationInfo1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label1;
        private ctrCloseBtn ctrCloseBtn1;
        private ctrIssueBtn ctrIssueBtn1;
    }
}