namespace DVLD
{
    partial class frmManageTestTypes
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
            this.cmsManageTestTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEditTestType = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrCloseBtn1 = new DVLD.ctrCloseBtn();
            this.ctrDataView1 = new DVLD.ctrDataView();
            this.cmsManageTestTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(360, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Manage Test Types";
            // 
            // cmsManageTestTypes
            // 
            this.cmsManageTestTypes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsManageTestTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditTestType});
            this.cmsManageTestTypes.Name = "cmsManageTestTypes";
            this.cmsManageTestTypes.Size = new System.Drawing.Size(170, 28);
            // 
            // tsmiEditTestType
            // 
            this.tsmiEditTestType.Name = "tsmiEditTestType";
            this.tsmiEditTestType.Size = new System.Drawing.Size(169, 24);
            this.tsmiEditTestType.Text = "Edit Test Type";
            this.tsmiEditTestType.Click += new System.EventHandler(this.tsmiEditTestType_Click);
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(825, 516);
            this.ctrCloseBtn1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(153, 42);
            this.ctrCloseBtn1.TabIndex = 5;
            // 
            // ctrDataView1
            // 
            this.ctrDataView1.Location = new System.Drawing.Point(10, 72);
            this.ctrDataView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrDataView1.Name = "ctrDataView1";
            this.ctrDataView1.Size = new System.Drawing.Size(985, 429);
            this.ctrDataView1.TabIndex = 4;
            // 
            // frmManageTestTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 568);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.ctrDataView1);
            this.Controls.Add(this.label1);
            this.Name = "frmManageTestTypes";
            this.Text = "frmManageTestTypes";
            this.Load += new System.EventHandler(this.frmManageTestTypes_Load);
            this.cmsManageTestTypes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrCloseBtn ctrCloseBtn1;
        private ctrDataView ctrDataView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsManageTestTypes;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditTestType;
    }
}