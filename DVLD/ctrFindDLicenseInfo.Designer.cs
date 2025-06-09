namespace DVLD
{
    partial class ctrFindDLicenseInfo
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
            this.ctrDriverLicenseInfo1 = new DVLD.ctrDriverLicenseInfo();
            this.gbFindPerson = new System.Windows.Forms.GroupBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbFindPerson.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrDriverLicenseInfo1
            // 
            this.ctrDriverLicenseInfo1.Location = new System.Drawing.Point(3, 91);
            this.ctrDriverLicenseInfo1.Name = "ctrDriverLicenseInfo1";
            this.ctrDriverLicenseInfo1.Size = new System.Drawing.Size(1044, 367);
            this.ctrDriverLicenseInfo1.TabIndex = 0;
            // 
            // gbFindPerson
            // 
            this.gbFindPerson.Controls.Add(this.btnFind);
            this.gbFindPerson.Controls.Add(this.txtSearch);
            this.gbFindPerson.Controls.Add(this.label1);
            this.gbFindPerson.Location = new System.Drawing.Point(152, 18);
            this.gbFindPerson.Margin = new System.Windows.Forms.Padding(2);
            this.gbFindPerson.Name = "gbFindPerson";
            this.gbFindPerson.Padding = new System.Windows.Forms.Padding(2);
            this.gbFindPerson.Size = new System.Drawing.Size(669, 64);
            this.gbFindPerson.TabIndex = 1;
            this.gbFindPerson.TabStop = false;
            this.gbFindPerson.Text = "Filter";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(456, 20);
            this.btnFind.Margin = new System.Windows.Forms.Padding(2);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(72, 30);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(169, 26);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(263, 22);
            this.txtSearch.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "License ID:";
            // 
            // ctrFindDLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFindPerson);
            this.Controls.Add(this.ctrDriverLicenseInfo1);
            this.Name = "ctrFindDLicenseInfo";
            this.Size = new System.Drawing.Size(1050, 460);
            this.gbFindPerson.ResumeLayout(false);
            this.gbFindPerson.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrDriverLicenseInfo ctrDriverLicenseInfo1;
        private System.Windows.Forms.GroupBox gbFindPerson;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
    }
}
