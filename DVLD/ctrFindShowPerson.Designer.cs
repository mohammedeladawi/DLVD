namespace DVLD
{
    partial class ctrFindShowPerson
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
            this.gbFindPerson = new System.Windows.Forms.GroupBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.ctrPersonInformation1 = new DVLD.ctrPersonInformation();
            this.gbFindPerson.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFindPerson
            // 
            this.gbFindPerson.Controls.Add(this.btnAddNewPerson);
            this.gbFindPerson.Controls.Add(this.btnFind);
            this.gbFindPerson.Controls.Add(this.txtSearch);
            this.gbFindPerson.Controls.Add(this.label1);
            this.gbFindPerson.Controls.Add(this.cmbFilter);
            this.gbFindPerson.Location = new System.Drawing.Point(44, 23);
            this.gbFindPerson.Name = "gbFindPerson";
            this.gbFindPerson.Size = new System.Drawing.Size(1064, 100);
            this.gbFindPerson.TabIndex = 0;
            this.gbFindPerson.TabStop = false;
            this.gbFindPerson.Text = "Find Person";
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Location = new System.Drawing.Point(822, 32);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(188, 47);
            this.btnAddNewPerson.TabIndex = 3;
            this.btnAddNewPerson.Text = "Add New Person";
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(684, 32);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(108, 47);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(468, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(178, 31);
            this.txtSearch.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find by:";
            // 
            // cmbFilter
            // 
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "NationalNo",
            "PersonID"});
            this.cmbFilter.Location = new System.Drawing.Point(133, 40);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(309, 33);
            this.cmbFilter.TabIndex = 0;
            // 
            // ctrPersonInformation1
            // 
            this.ctrPersonInformation1.Location = new System.Drawing.Point(20, 132);
            this.ctrPersonInformation1.Name = "ctrPersonInformation1";
            this.ctrPersonInformation1.Size = new System.Drawing.Size(1418, 650);
            this.ctrPersonInformation1.TabIndex = 1;
            // 
            // ctrFindShowPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrPersonInformation1);
            this.Controls.Add(this.gbFindPerson);
            this.Name = "ctrFindShowPerson";
            this.Size = new System.Drawing.Size(1672, 884);
            this.Load += new System.EventHandler(this.ctrFindShowPerson_Load);
            this.gbFindPerson.ResumeLayout(false);
            this.gbFindPerson.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFindPerson;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtSearch;
        private ctrPersonInformation ctrPersonInformation1;
    }
}
