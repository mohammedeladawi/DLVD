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
            this.ctrTestApplicationInfo1 = new DVLD.ctrManageTestApplicationInfo();
            this.cmsVisionTestAppointment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiTakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewAppointment = new System.Windows.Forms.Button();
            this.cmsVisionTestAppointment.SuspendLayout();
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
            // ctrTestApplicationInfo1
            // 
            this.ctrTestApplicationInfo1.AutoScroll = true;
            this.ctrTestApplicationInfo1.Location = new System.Drawing.Point(18, 19);
            this.ctrTestApplicationInfo1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ctrTestApplicationInfo1.Name = "ctrTestApplicationInfo1";
            this.ctrTestApplicationInfo1.Size = new System.Drawing.Size(1568, 1631);
            this.ctrTestApplicationInfo1.TabIndex = 0;
            // 
            // cmsVisionTestAppointment
            // 
            this.cmsVisionTestAppointment.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsVisionTestAppointment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiTakeTest,
            this.tmsiEdit});
            this.cmsVisionTestAppointment.Name = "cmsVisionTestAppointment";
            this.cmsVisionTestAppointment.Size = new System.Drawing.Size(301, 124);
            this.cmsVisionTestAppointment.Text = "Edit";
            // 
            // cmsiTakeTest
            // 
            this.cmsiTakeTest.Name = "cmsiTakeTest";
            this.cmsiTakeTest.Size = new System.Drawing.Size(300, 38);
            this.cmsiTakeTest.Text = "Take A Test";
            this.cmsiTakeTest.Click += new System.EventHandler(this.cmsiTakeTest_Click);
            // 
            // tmsiEdit
            // 
            this.tmsiEdit.Name = "tmsiEdit";
            this.tmsiEdit.Size = new System.Drawing.Size(300, 38);
            this.tmsiEdit.Text = "Edit";
            this.tmsiEdit.Click += new System.EventHandler(this.tmsiEdit_Click);
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
            // frmManageVisionTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 1648);
            this.Controls.Add(this.btnAddNewAppointment);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.ctrTestApplicationInfo1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmManageVisionTestAppointments";
            this.Text = "frmVisionTestAppointments";
            this.Load += new System.EventHandler(this.frmManageTestAppointments_Load);
            this.cmsVisionTestAppointment.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrManageTestApplicationInfo ctrTestApplicationInfo1;
        private ctrCloseBtn ctrCloseBtn1;
        private System.Windows.Forms.ContextMenuStrip cmsVisionTestAppointment;
        private System.Windows.Forms.ToolStripMenuItem cmsiTakeTest;
        private System.Windows.Forms.ToolStripMenuItem tmsiEdit;
        private System.Windows.Forms.Button btnAddNewAppointment;
    }
}