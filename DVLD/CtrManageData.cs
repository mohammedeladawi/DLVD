using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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

        private void SearchIconVisibility()
        {
            // hide or show txt box
            if (cmbFilter.SelectedItem.ToString() == "None")
            {
                cmbSearch.Visible = false;
                txtSearch.Visible = false;

            }
            else if (cmbFilter.SelectedItem.ToString() == "IsActive")
            {
                txtSearch.Visible = false;
                cmbSearch.Visible = true;

                InitializeCmbSearchItems();
            }
            else
            {
                cmbSearch.Visible = false;
                txtSearch.Visible = true;
            }
        }

        private void InitializeCmbSearchItems()
        {
            cmbSearch.DisplayMember = "Key";
            cmbSearch.ValueMember = "Value";

            cmbSearch.Items.Add(new KeyValuePair<string, bool>("Yes", true));
            cmbSearch.Items.Add(new KeyValuePair<string, bool>("No", false));
            cmbSearch.SelectedIndex = 0;
        }

        private void LoadDataInDgvManageData(DataTable dt)
        {
            dgvManageData.DataSource = dt;
            lblNumOfRecords.Text = dt.Rows.Count.ToString();
        }

        private void LoadTableHeadersInCmbFilters()
        {
            if (cmbFilter.Items.Count > 0)
                return;

            cmbFilter.Items.Add("None");

            foreach (DataGridViewColumn column in dgvManageData.Columns)
            {
                cmbFilter.Items.Add(column.HeaderText);
            }
        
            cmbFilter.SelectedIndex = 0;
        }

        private void cmbFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            SearchIconVisibility();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearch.Text;
            string colName = cmbFilter.SelectedItem.ToString();

            DataTable dt = (DataTable)dgvManageData.DataSource; // Referrence


            if (dt.Columns.Contains(colName) && dt.Columns[colName].DataType != typeof(string))
                dt.DefaultView.RowFilter = $"Convert({colName}, 'System.String') Like '%{filterText}%'";
            else
                dt.DefaultView.RowFilter = $"{colName} Like '%{filterText}%'";
        }
       
        private void cmbSearch_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbSearch.SelectedItem is KeyValuePair<string, bool> selectedItem)
            {
                string colName = cmbFilter.SelectedItem.ToString();
                bool filterValue = selectedItem.Value;

                DataTable dt = (DataTable)dgvManageData.DataSource; // Referrence

                dt.DefaultView.RowFilter = $"{colName} = {filterValue}";
            }
        
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
            if (File.Exists(imgUrl))
                pbManageLogo.Image = Image.FromFile(imgUrl);

            lblTitle.Text = title;

        }

        public void SetContextMenuStrip(ContextMenuStrip cms)
        {
            dgvManageData.ContextMenuStrip = cms;
        }


    }
}
