using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class CtrManageData : UserControl
    {
        public DataGridView dgvManageDate1
        {
            get { return dgvManageData; } 
        }
        public CtrManageData()
        {
            InitializeComponent();
        }

        private void _txtFilterVisibilty()
        {
            // hide or show txt
            if (cmbFilter.SelectedIndex == 0)
                txtSearch.Visible = false;
            else
                txtSearch.Visible = true;
        }

        private void _UpdateDgvManageData()
        {
            string filterText = txtSearch.Text;
            string colName = cmbFilter.SelectedItem.ToString();

            DataTable dt = (DataTable)dgvManageData.DataSource; // Referrence


            if (dt.Columns.Contains(colName) && dt.Columns[colName].DataType != typeof(string))
                dt.DefaultView.RowFilter = $"Convert({colName}, 'System.String') Like '%{filterText}%'";
            else
                dt.DefaultView.RowFilter = $"{colName} Like '%{filterText}%'";


        }

        public void LoadDataInDgvManageData(DataTable dt)
        {
            dgvManageData.DataSource = dt;
            lblNumOfRecords.Text = dt.Rows.Count.ToString();
        }

        public void LoadTableHeadersInCmbFilters()
        {
            cmbFilter.Items.Add("None");

            foreach (DataGridViewColumn column in dgvManageData.Columns)
            {
                cmbFilter.Items.Add(column.HeaderText);
            }
        
            cmbFilter.SelectedIndex = 0;
        }

        public void LoadData(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0) 
                return;

            LoadDataInDgvManageData(dt);
            LoadTableHeadersInCmbFilters();
        }

        public void LoadLogoImgAndTitle(string imgUrl, string title)
        {
            pbManageLogo.Image = Image.FromFile(imgUrl);
            lblTitle.Text = title;

        }

        private void cmbFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            _txtFilterVisibilty();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _UpdateDgvManageData();
        }
    
        public void SetContextMenuStrip(ContextMenuStrip cms)
        {
            dgvManageData.ContextMenuStrip = cms;
        }
    }
}
