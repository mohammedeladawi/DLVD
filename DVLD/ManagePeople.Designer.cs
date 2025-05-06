namespace DVLD
{
    partial class frmManagePeople
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
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.ctrManageData1 = new DVLD.CtrManageData();
            this.SuspendLayout();
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewPerson.BackgroundImage = global::DVLD.Properties.Resources.incorporation;
            this.btnAddNewPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewPerson.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddNewPerson.Image = global::DVLD.Properties.Resources.incorporation;
            this.btnAddNewPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewPerson.Location = new System.Drawing.Point(2257, 282);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(133, 99);
            this.btnAddNewPerson.TabIndex = 1;
            this.btnAddNewPerson.UseVisualStyleBackColor = false;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // ctrManageData1
            // 
            this.ctrManageData1.Location = new System.Drawing.Point(11, 24);
            this.ctrManageData1.Name = "ctrManageData1";
            this.ctrManageData1.Size = new System.Drawing.Size(2654, 1284);
            this.ctrManageData1.TabIndex = 0;
            // 
            // frmManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(2724, 1261);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.ctrManageData1);
            this.Name = "frmManagePeople";
            this.Text = "Manage People";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ManagePeople_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CtrManageData ctrManageData1;
        private System.Windows.Forms.Button btnAddNewPerson;
    }
}

