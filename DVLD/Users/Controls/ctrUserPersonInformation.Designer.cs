namespace DVLD
{
    partial class ctrUserPersonInformation
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
            this.ctrPersonInformation1 = new DVLD.ctrPersonInformation();
            this.ctrUserInformation1 = new DVLD.ctrUserInformation();
            this.SuspendLayout();
            // 
            // ctrPersonInformation1
            // 
            this.ctrPersonInformation1.Location = new System.Drawing.Point(76, 71);
            this.ctrPersonInformation1.Name = "ctrPersonInformation1";
            this.ctrPersonInformation1.Size = new System.Drawing.Size(1418, 650);
            this.ctrPersonInformation1.TabIndex = 0;
            // 
            // ctrUserInformation1
            // 
            this.ctrUserInformation1.Location = new System.Drawing.Point(98, 752);
            this.ctrUserInformation1.Name = "ctrUserInformation1";
            this.ctrUserInformation1.Size = new System.Drawing.Size(1342, 148);
            this.ctrUserInformation1.TabIndex = 1;
            // 
            // ctrUserPersonInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrUserInformation1);
            this.Controls.Add(this.ctrPersonInformation1);
            this.Name = "ctrUserPersonInformation";
            this.Size = new System.Drawing.Size(1536, 1000);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrPersonInformation ctrPersonInformation1;
        private ctrUserInformation ctrUserInformation1;
    }
}
