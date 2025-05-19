namespace DVLD
{
    partial class frmUpdateApplicationType
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
            this.ctrSaveBtn1 = new DVLD.ctrSaveBtn();
            this.ctrCloseBtn1 = new DVLD.ctrCloseBtn();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblApplicationTypeID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrSaveBtn1
            // 
            this.ctrSaveBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrSaveBtn1.Location = new System.Drawing.Point(531, 455);
            this.ctrSaveBtn1.Name = "ctrSaveBtn1";
            this.ctrSaveBtn1.Size = new System.Drawing.Size(210, 64);
            this.ctrSaveBtn1.TabIndex = 20;
            this.ctrSaveBtn1.Click += new System.EventHandler(this.ctrSaveBtn1_Click);
            // 
            // ctrCloseBtn1
            // 
            this.ctrCloseBtn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrCloseBtn1.Location = new System.Drawing.Point(265, 455);
            this.ctrCloseBtn1.Name = "ctrCloseBtn1";
            this.ctrCloseBtn1.Size = new System.Drawing.Size(228, 64);
            this.ctrCloseBtn1.TabIndex = 19;
            // 
            // txtFees
            // 
            this.txtFees.Location = new System.Drawing.Point(189, 346);
            this.txtFees.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(552, 31);
            this.txtFees.TabIndex = 17;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(189, 251);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(552, 31);
            this.txtTitle.TabIndex = 18;
            // 
            // lblApplicationTypeID
            // 
            this.lblApplicationTypeID.AutoSize = true;
            this.lblApplicationTypeID.Location = new System.Drawing.Point(210, 151);
            this.lblApplicationTypeID.Name = "lblApplicationTypeID";
            this.lblApplicationTypeID.Size = new System.Drawing.Size(48, 25);
            this.lblApplicationTypeID.TabIndex = 15;
            this.lblApplicationTypeID.Text = "???";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(83, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Fees:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(88, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(94, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(105, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(570, 55);
            this.label1.TabIndex = 10;
            this.label1.Text = "Update Application Type";
            // 
            // frmUpdateApplicationType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 550);
            this.Controls.Add(this.ctrSaveBtn1);
            this.Controls.Add(this.ctrCloseBtn1);
            this.Controls.Add(this.txtFees);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblApplicationTypeID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmUpdateApplicationType";
            this.Text = "frmUpdateApplicationType";
            this.Load += new System.EventHandler(this.frmUpdateApplicationTypes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrSaveBtn ctrSaveBtn1;
        private ctrCloseBtn ctrCloseBtn1;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblApplicationTypeID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}