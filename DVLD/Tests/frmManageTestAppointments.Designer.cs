namespace DVLD
{
    partial class frmManageTestAppointments
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
            this.ctrCloseBtn1 = new DVLD.ctrCloseBtn();
            this.cmsManageTestAppointment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiTakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewAppointment = new System.Windows.Forms.Button();
            this.ctrTestApplicationInfo1 = new DVLD.ctrManageTestApplicationInfo();
            this.cmsManageTestAppointment.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(1268, 1566);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(228, 64);
            this.ctrCloseBtn1.TabIndex = 1;
            // 
            // cmsManageTestAppointment
            // 
            this.cmsManageTestAppointment.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageTestAppointment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTakeTest,
            this.tsmiEdit});
            this.cmsManageTestAppointment.Name = "cmsVisionTestAppointment";
            this.cmsManageTestAppointment.Size = new System.Drawing.Size(207, 80);
            this.cmsManageTestAppointment.Text = "Edit";
            this.cmsManageTestAppointment.Opening += new System.ComponentModel.CancelEventHandler(this.cmsManageTestAppointment_Opening);
            // 
            // tsmiTakeTest
            // 
            this.tsmiTakeTest.Name = "tsmiTakeTest";
            this.tsmiTakeTest.Size = new System.Drawing.Size(206, 38);
            this.tsmiTakeTest.Text = "Take A Test";
            this.tsmiTakeTest.Click += new System.EventHandler(this.tsmiTakeTest_Click);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(206, 38);
            this.tsmiEdit.Text = "Edit";
            this.tsmiEdit.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // btnAddNewAppointment
            // 
            this.btnAddNewAppointment.Location = new System.Drawing.Point(1130, 873);
            this.btnAddNewAppointment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddNewAppointment.Name = "btnAddNewAppointment";
            this.btnAddNewAppointment.Size = new System.Drawing.Size(250, 36);
            this.btnAddNewAppointment.TabIndex = 2;
            this.btnAddNewAppointment.Text = "Add New Appointment";
            this.btnAddNewAppointment.UseVisualStyleBackColor = true;
            this.btnAddNewAppointment.Click += new System.EventHandler(this.btnAddNewAppointment_Click);
            // 
            // ctrTestApplicationInfo1
            // 
            this.ctrTestApplicationInfo1.AutoScroll = true;
            this.ctrTestApplicationInfo1.Location = new System.Drawing.Point(18, 19);
            this.ctrTestApplicationInfo1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ctrTestApplicationInfo1.Name = "ctrTestApplicationInfo1";
            this.ctrTestApplicationInfo1.Size = new System.Drawing.Size(1568, 1631);
            this.ctrTestApplicationInfo1.TabIndex = 0;
            // 
            // frmManageTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 1648);
            this.Controls.Add(this.btnAddNewAppointment);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.ctrTestApplicationInfo1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmManageTestAppointments";
            this.Text = "frmVisionTestAppointments";
            this.Load += new System.EventHandler(this.frmManageTestAppointments_Load);
            this.cmsManageTestAppointment.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrManageTestApplicationInfo ctrTestApplicationInfo1;
        private ctrCloseBtn ctrCloseBtn1;
        private System.Windows.Forms.ContextMenuStrip cmsManageTestAppointment;
        private System.Windows.Forms.ToolStripMenuItem tsmiTakeTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.Button btnAddNewAppointment;
    }
}