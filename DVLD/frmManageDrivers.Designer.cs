namespace DVLD
{
    partial class frmManageDrivers
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
            this.ctrManageDataView1 = new DVLD.ctrFilterDataView();
            this.ctrCloseBtn1 = new DVLD.ctrCloseBtn();
            this.SuspendLayout();
            // 
            // ctrManageDataView1
            // 
            this.ctrManageDataView1.Location = new System.Drawing.Point(11, 11);
            this.ctrManageDataView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ctrManageDataView1.Name = "ctrManageDataView1";
            this.ctrManageDataView1.Size = new System.Drawing.Size(1048, 657);
            this.ctrManageDataView1.TabIndex = 3;
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(851, 601);
            this.ctrCloseBtn1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(153, 42);
            this.ctrCloseBtn1.TabIndex = 4;
            // 
            // fmMangeDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 676);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.ctrManageDataView1);
            this.Name = "fmMangeDrivers";
            this.Text = "fmMangeDrivers";
            this.Load += new System.EventHandler(this.fmManageDrivers_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrFilterDataView ctrManageDataView1;
        private ctrCloseBtn ctrCloseBtn1;
    }
}