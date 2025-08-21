namespace DVLD
{
    partial class frmManageApplicationTypes
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
            this.ctrCloseBtn1 = new DVLD.ctrCloseBtn();
            this.ctrDataView1 = new DVLD.ctrDataView();
            this.cmsManageApplicationTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editApplicationTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsManageApplicationTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(298, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Application Types";
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(812, 506);
            this.ctrCloseBtn1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(153, 42);
            this.ctrCloseBtn1.TabIndex = 2;
            // 
            // ctrDataView1
            // 
            this.ctrDataView1.Location = new System.Drawing.Point(-6, 60);
            this.ctrDataView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrDataView1.Name = "ctrDataView1";
            this.ctrDataView1.Size = new System.Drawing.Size(985, 429);
            this.ctrDataView1.TabIndex = 1;
            // 
            // cmsManageApplicationTypes
            // 
            this.cmsManageApplicationTypes.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmsManageApplicationTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editApplicationTypeToolStripMenuItem});
            this.cmsManageApplicationTypes.Name = "cmsManageApplicationTypes";
            this.cmsManageApplicationTypes.Size = new System.Drawing.Size(221, 28);
            // 
            // editApplicationTypeToolStripMenuItem
            // 
            this.editApplicationTypeToolStripMenuItem.Name = "editApplicationTypeToolStripMenuItem";
            this.editApplicationTypeToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.editApplicationTypeToolStripMenuItem.Text = "Edit Application Type";
            this.editApplicationTypeToolStripMenuItem.Click += new System.EventHandler(this.editApplicationTypeToolStripMenuItem_Click);
            // 
            // frmManageApplicationTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 563);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.ctrDataView1);
            this.Controls.Add(this.label1);
            this.Name = "frmManageApplicationTypes";
            this.Text = "frmManageApplicationTypes";
            this.Load += new System.EventHandler(this.frmManageApplicationTypes_Load);
            this.cmsManageApplicationTypes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ctrDataView ctrDataView1;
        private ctrCloseBtn ctrCloseBtn1;
        private System.Windows.Forms.ContextMenuStrip cmsManageApplicationTypes;
        private System.Windows.Forms.ToolStripMenuItem editApplicationTypeToolStripMenuItem;
    }
}