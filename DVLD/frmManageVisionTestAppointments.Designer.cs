namespace DVLD
{
    partial class frmManageVisionTestAppointments
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
            this.ctrCloseBtn1.Location = new System.Drawing.Point(845, 1002);
            this.ctrCloseBtn1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(153, 42);
            this.ctrCloseBtn1.TabIndex = 1;
            // 
            // ctrTestApplicationInfo1
            // 
            this.ctrTestApplicationInfo1.AutoScroll = true;
            this.ctrTestApplicationInfo1.Location = new System.Drawing.Point(12, 12);
            this.ctrTestApplicationInfo1.Name = "ctrTestApplicationInfo1";
            this.ctrTestApplicationInfo1.Size = new System.Drawing.Size(1045, 1044);
            this.ctrTestApplicationInfo1.TabIndex = 0;
            // 
            // cmsVisionTestAppointment
            // 
            this.cmsVisionTestAppointment.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsVisionTestAppointment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiTakeTest,
            this.tmsiEdit});
            this.cmsVisionTestAppointment.Name = "cmsVisionTestAppointment";
            this.cmsVisionTestAppointment.Size = new System.Drawing.Size(152, 52);
            this.cmsVisionTestAppointment.Text = "Edit";
            // 
            // cmsiTakeTest
            // 
            this.cmsiTakeTest.Name = "cmsiTakeTest";
            this.cmsiTakeTest.Size = new System.Drawing.Size(151, 24);
            this.cmsiTakeTest.Text = "Take A Test";
            this.cmsiTakeTest.Click += new System.EventHandler(this.cmsiTakeTest_Click);
            // 
            // tmsiEdit
            // 
            this.tmsiEdit.Name = "tmsiEdit";
            this.tmsiEdit.Size = new System.Drawing.Size(151, 24);
            this.tmsiEdit.Text = "Edit";
            this.tmsiEdit.Click += new System.EventHandler(this.tmsiEdit_Click);
            // 
            // btnAddNewAppointment
            // 
            this.btnAddNewAppointment.Location = new System.Drawing.Point(753, 559);
            this.btnAddNewAppointment.Name = "btnAddNewAppointment";
            this.btnAddNewAppointment.Size = new System.Drawing.Size(167, 23);
            this.btnAddNewAppointment.TabIndex = 2;
            this.btnAddNewAppointment.Text = "Add New Appointment";
            this.btnAddNewAppointment.UseVisualStyleBackColor = true;
            this.btnAddNewAppointment.Click += new System.EventHandler(this.btnAddNewAppointment_Click);
            // 
            // frmVisionTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 1055);
            this.Controls.Add(this.btnAddNewAppointment);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.ctrTestApplicationInfo1);
            this.Name = "frmVisionTestAppointments";
            this.Text = "frmVisionTestAppointments";
            this.Load += new System.EventHandler(this.frmVisionTestAppointments_Load);
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