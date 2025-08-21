namespace DVLD
{
    partial class frmPersonLicenseHistory
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrPersonInformation1 = new DVLD.ctrPersonInformation();
            this.tcLicenses = new System.Windows.Forms.TabControl();
            this.tpLocal = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrDVLocal = new DVLD.ctrDataView();
            this.tpInternational = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrDVInternational = new DVLD.ctrDataView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctrCloseBtn1 = new DVLD.ctrCloseBtn();
            this.cmsLicence = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsInternationalLicense = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiInternationalLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tcLicenses.SuspendLayout();
            this.tpLocal.SuspendLayout();
            this.tpInternational.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cmsLicence.SuspendLayout();
            this.cmsInternationalLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(438, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "License History";
            // 
            // ctrPersonInformation1
            // 
            this.ctrPersonInformation1.Location = new System.Drawing.Point(105, 57);
            this.ctrPersonInformation1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrPersonInformation1.Name = "ctrPersonInformation1";
            this.ctrPersonInformation1.Size = new System.Drawing.Size(945, 416);
            this.ctrPersonInformation1.TabIndex = 2;
            // 
            // tcLicenses
            // 
            this.tcLicenses.Controls.Add(this.tpLocal);
            this.tcLicenses.Controls.Add(this.tpInternational);
            this.tcLicenses.Location = new System.Drawing.Point(20, 17);
            this.tcLicenses.Name = "tcLicenses";
            this.tcLicenses.SelectedIndex = 0;
            this.tcLicenses.Size = new System.Drawing.Size(1059, 487);
            this.tcLicenses.TabIndex = 3;
            // 
            // tpLocal
            // 
            this.tpLocal.Controls.Add(this.label2);
            this.tpLocal.Controls.Add(this.ctrDVLocal);
            this.tpLocal.Location = new System.Drawing.Point(4, 25);
            this.tpLocal.Name = "tpLocal";
            this.tpLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocal.Size = new System.Drawing.Size(1051, 458);
            this.tpLocal.TabIndex = 0;
            this.tpLocal.Text = "Local";
            this.tpLocal.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Local License History:";
            // 
            // ctrDVLocal
            // 
            this.ctrDVLocal.Location = new System.Drawing.Point(33, 28);
            this.ctrDVLocal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrDVLocal.Name = "ctrDVLocal";
            this.ctrDVLocal.Size = new System.Drawing.Size(985, 429);
            this.ctrDVLocal.TabIndex = 1;
            // 
            // tpInternational
            // 
            this.tpInternational.Controls.Add(this.label3);
            this.tpInternational.Controls.Add(this.ctrDVInternational);
            this.tpInternational.Location = new System.Drawing.Point(4, 25);
            this.tpInternational.Name = "tpInternational";
            this.tpInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternational.Size = new System.Drawing.Size(1051, 458);
            this.tpInternational.TabIndex = 1;
            this.tpInternational.Text = "International";
            this.tpInternational.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "International License History:";
            // 
            // ctrDVInternational
            // 
            this.ctrDVInternational.Location = new System.Drawing.Point(16, 23);
            this.ctrDVInternational.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrDVInternational.Name = "ctrDVInternational";
            this.ctrDVInternational.Size = new System.Drawing.Size(985, 429);
            this.ctrDVInternational.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tcLicenses);
            this.groupBox1.Location = new System.Drawing.Point(10, 478);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1094, 536);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(935, 1000);
            this.ctrCloseBtn1.Margin = new System.Windows.Forms.Padding(1);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(153, 42);
            this.ctrCloseBtn1.TabIndex = 5;
            // 
            // cmsLicence
            // 
            this.cmsLicence.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmsLicence.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.cmsLicence.Name = "cmsLicence";
            this.cmsLicence.Size = new System.Drawing.Size(197, 28);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.tsmiShowLicense_Click);
            // 
            // cmsInternationalLicense
            // 
            this.cmsInternationalLicense.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmsInternationalLicense.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiInternationalLicense});
            this.cmsInternationalLicense.Name = "cmsInternationalLicense";
            this.cmsInternationalLicense.Size = new System.Drawing.Size(255, 28);
            // 
            // tsmiInternationalLicense
            // 
            this.tsmiInternationalLicense.Name = "tsmiInternationalLicense";
            this.tsmiInternationalLicense.Size = new System.Drawing.Size(254, 24);
            this.tsmiInternationalLicense.Text = "Show International License";
            this.tsmiInternationalLicense.Click += new System.EventHandler(this.tsmiShowInternationalLicense_Click);
            // 
            // frmPersonLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 1055);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrPersonInformation1);
            this.Controls.Add(this.label1);
            this.Name = "frmPersonLicenseHistory";
            this.Text = "frmPersonLicenseHistory";
            this.Load += new System.EventHandler(this.frmPersonLicenseHistory_Load);
            this.tcLicenses.ResumeLayout(false);
            this.tpLocal.ResumeLayout(false);
            this.tpLocal.PerformLayout();
            this.tpInternational.ResumeLayout(false);
            this.tpInternational.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.cmsLicence.ResumeLayout(false);
            this.cmsInternationalLicense.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ctrPersonInformation ctrPersonInformation1;
        private System.Windows.Forms.TabControl tcLicenses;
        private System.Windows.Forms.TabPage tpLocal;
        private System.Windows.Forms.TabPage tpInternational;
        private ctrDataView ctrDVLocal;
        private ctrDataView ctrDVInternational;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ctrCloseBtn ctrCloseBtn1;
        private System.Windows.Forms.ContextMenuStrip cmsLicence;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiInternationalLicense;
    }
}