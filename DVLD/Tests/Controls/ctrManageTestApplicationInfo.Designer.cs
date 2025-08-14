namespace DVLD
{
    partial class ctrManageTestApplicationInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblTestTitle = new System.Windows.Forms.Label();
            this.ctrDataView1 = new DVLD.ctrDataView();
            this.ctrApplicationInfo1 = new DVLD.ctrLDLApplicationInfo();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 548);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Appointments:";
            // 
            // lblTestTitle
            // 
            this.lblTestTitle.AutoSize = true;
            this.lblTestTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestTitle.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTestTitle.Location = new System.Drawing.Point(345, 20);
            this.lblTestTitle.Name = "lblTestTitle";
            this.lblTestTitle.Size = new System.Drawing.Size(137, 36);
            this.lblTestTitle.TabIndex = 11;
            this.lblTestTitle.Text = "TestTitle";
            // 
            // ctrDataView1
            // 
            this.ctrDataView1.Location = new System.Drawing.Point(14, 567);
            this.ctrDataView1.Name = "ctrDataView1";
            this.ctrDataView1.Size = new System.Drawing.Size(985, 431);
            this.ctrDataView1.TabIndex = 10;
            // 
            // ctrApplicationInfo1
            // 
            this.ctrApplicationInfo1.Location = new System.Drawing.Point(104, 76);
            this.ctrApplicationInfo1.Name = "ctrApplicationInfo1";
            this.ctrApplicationInfo1.Size = new System.Drawing.Size(786, 466);
            this.ctrApplicationInfo1.TabIndex = 0;
            // 
            // ctrTestApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTestTitle);
            this.Controls.Add(this.ctrDataView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrApplicationInfo1);
            this.Name = "ctrTestApplicationInfo";
            this.Size = new System.Drawing.Size(1045, 1044);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrLDLApplicationInfo ctrApplicationInfo1;
        private ctrDataView ctrDataView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTestTitle;
    }
}
