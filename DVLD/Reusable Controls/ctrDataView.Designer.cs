namespace DVLD
{
    partial class ctrDataView
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
            this.lblNumOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvManageData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumOfRecords
            // 
            this.lblNumOfRecords.AutoSize = true;
            this.lblNumOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfRecords.Location = new System.Drawing.Point(140, 400);
            this.lblNumOfRecords.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumOfRecords.Name = "lblNumOfRecords";
            this.lblNumOfRecords.Size = new System.Drawing.Size(60, 24);
            this.lblNumOfRecords.TabIndex = 10;
            this.lblNumOfRecords.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 399);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "#Records: ";
            // 
            // dgvManageData
            // 
            this.dgvManageData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvManageData.BackgroundColor = System.Drawing.Color.White;
            this.dgvManageData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageData.Location = new System.Drawing.Point(22, 17);
            this.dgvManageData.Margin = new System.Windows.Forms.Padding(2);
            this.dgvManageData.Name = "dgvManageData";
            this.dgvManageData.RowHeadersWidth = 82;
            this.dgvManageData.RowTemplate.Height = 33;
            this.dgvManageData.Size = new System.Drawing.Size(946, 348);
            this.dgvManageData.TabIndex = 8;
            // 
            // ctrDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNumOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvManageData);
            this.Name = "ctrDataView";
            this.Size = new System.Drawing.Size(985, 429);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumOfRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvManageData;
    }
}
