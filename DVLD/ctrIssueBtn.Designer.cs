namespace DVLD
{
    partial class ctrIssueBtn
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBtnTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBtnTitle
            // 
            this.lblBtnTitle.AutoSize = true;
            this.lblBtnTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBtnTitle.Location = new System.Drawing.Point(66, 15);
            this.lblBtnTitle.Name = "lblBtnTitle";
            this.lblBtnTitle.Size = new System.Drawing.Size(92, 37);
            this.lblBtnTitle.TabIndex = 2;
            this.lblBtnTitle.Text = "Issue";
            // 
            // ctrIssueBtn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblBtnTitle);
            this.Name = "ctrIssueBtn";
            this.Size = new System.Drawing.Size(226, 68);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBtnTitle;
    }
}
