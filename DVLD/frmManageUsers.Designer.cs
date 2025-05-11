namespace DVLD
{
    partial class frmManageUsers
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
            this.ctrManageData1 = new DVLD.CtrManageData();
            this.SuspendLayout();
            // 
            // ctrManageData1
            // 
            this.ctrManageData1.Location = new System.Drawing.Point(21, 123);
            this.ctrManageData1.Name = "ctrManageData1";
            this.ctrManageData1.Size = new System.Drawing.Size(2314, 1130);
            this.ctrManageData1.TabIndex = 0;
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2354, 1320);
            this.Controls.Add(this.ctrManageData1);
            this.Name = "frmManageUsers";
            this.Text = "frmManageUsers";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmManageUsers_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CtrManageData ctrManageData1;
    }
}