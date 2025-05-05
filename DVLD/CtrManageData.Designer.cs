namespace DVLD
{
    partial class CtrManageData
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
            this.dgvManageData = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbManageLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbManageLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvManageData
            // 
            this.dgvManageData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageData.Location = new System.Drawing.Point(12, 372);
            this.dgvManageData.Name = "dgvManageData";
            this.dgvManageData.RowHeadersWidth = 82;
            this.dgvManageData.RowTemplate.Height = 33;
            this.dgvManageData.Size = new System.Drawing.Size(2805, 773);
            this.dgvManageData.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(436, 308);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(352, 31);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cmbFilter
            // 
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(172, 305);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(239, 33);
            this.cmbFilter.TabIndex = 2;
            this.cmbFilter.SelectedValueChanged += new System.EventHandler(this.cmbFilter_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Filter By";
            // 
            // pbManageLogo
            // 
            this.pbManageLogo.Location = new System.Drawing.Point(886, 12);
            this.pbManageLogo.Name = "pbManageLogo";
            this.pbManageLogo.Size = new System.Drawing.Size(650, 278);
            this.pbManageLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbManageLogo.TabIndex = 4;
            this.pbManageLogo.TabStop = false;
            // 
            // CtrManageData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbManageLogo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvManageData);
            this.Name = "CtrManageData";
            this.Size = new System.Drawing.Size(2822, 1190);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbManageLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvManageData;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbManageLogo;
    }
}
