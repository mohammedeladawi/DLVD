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
    public partial class ctrFilterDataView : UserControl
    {
        public DataGridView dgvManageDate1
        {
            get {return ctrDataView1.dgvManageDate1;}
        }

        private DataTable _dt; 
        public ctrFilterDataView()
        {
            InitializeComponent();
        }

        private bool isTxtSearchSubscribed = false;

        // --------------- Search Combo Box ------------------
        private bool isCmbSearchSubscribed = false;
        
        private void StopCmbSearch()
        {
            if (isCmbSearchSubscribed)
            {
                cmbSearch.SelectedValueChanged -= cmbSearch_SelectedValueChanged;
                isCmbSearchSubscribed = false;
            }

            cmbSearch.SelectedValue = null;
            cmbSearch.Visible = false;
        }

        private void PlayCmbSearch()
        {
            cmbSearch.Visible = true;

            if (!isCmbSearchSubscribed)
            {
                cmbSearch.SelectedValueChanged += cmbSearch_SelectedValueChanged;
                isCmbSearchSubscribed = true;
            }

            cmbSearch.SelectedValue = 1; // Set default selection, adjust if needed
        }

        private void SetCmbSearchItems()
        {
            // for IsActive attribute in users table
            if (cmbSearch.Items.Count > 0)
                return;

            cmbSearch.DisplayMember = "Key";
            cmbSearch.ValueMember = "Value";

            cmbSearch.Items.Add(new KeyValuePair<string, bool>("Yes", true));
            cmbSearch.Items.Add(new KeyValuePair<string, bool>("No", false));
            cmbSearch.SelectedIndex = 0;
        }

        private void cmbSearch_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbSearch.SelectedItem is KeyValuePair<string, bool> selectedItem)
            {
                string colName = cmbFilter.SelectedItem.ToString();
                bool filterValue = selectedItem.Value;

                _dt.DefaultView.RowFilter = $"{colName} = {filterValue}";
            }

        }
        // -----------------------------------------------------
        
        // ----------------- Search Textbox --------------------
        private void StopTxtSearch()
        {
            if (isTxtSearchSubscribed)
            {
                txtSearch.TextChanged -= txtSearch_TextChanged;
                isTxtSearchSubscribed = false;
            }

            txtSearch.Clear();
            txtSearch.Visible = false;
        }

        private void PlayTxtSearch()
        {
            txtSearch.Visible = true;

            if (!isTxtSearchSubscribed)
            {
                txtSearch.TextChanged += txtSearch_TextChanged;
                isTxtSearchSubscribed = true;
            }
            else
            {
                txtSearch.Clear(); // already works
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearch.Text.Replace("'", "''"); // Escape single quotes
            if (cmbFilter.SelectedItem == null) return;

            string colName = cmbFilter.SelectedItem.ToString();

            // Ensure the column exists in the DataTable
            if (_dt.Columns.Contains(colName))
            {
                // Handle special characters in column name (dots, spaces, etc.)
                string safeColName = $"[{colName}]";

                if (colName == "PersonID" && txtSearch.Text != string.Empty)
                {
                    _dt.DefaultView.RowFilter = $"{safeColName} = {filterText}"; // int
                }
                else if (_dt.Columns[colName].DataType != typeof(string))
                {
                    _dt.DefaultView.RowFilter = $"Convert({safeColName}, 'System.String') LIKE '%{filterText}%'";
                }
                else
                {
                    _dt.DefaultView.RowFilter = $"{safeColName} LIKE '%{filterText}%'";
                }
            }
        }

        // ------------------------------------------------------
        private void SearchIconVisibility()
        {
            if (cmbFilter.SelectedItem.ToString() == "None")
            {
                StopTxtSearch();
                StopCmbSearch();
            }
            else if (cmbFilter.SelectedItem.ToString() == "IsActive")
            {
                // for IsActive property in users table
                StopTxtSearch();
                PlayCmbSearch();
            }
            else
            {
                StopCmbSearch();
                PlayTxtSearch();

            }
        }

        private void LoadTableHeadersInCmbFilters()
        {
            // function works one time
            if (cmbFilter.Items.Count > 0)
                return;

            cmbFilter.Items.Add("None");

            foreach (DataColumn column in _dt.Columns)
            {
                if (column.ColumnName == "DateOfBirth")
                    continue;

                cmbFilter.Items.Add(column.ColumnName);
            }
        
            cmbFilter.SelectedIndex = 0; // "NONE"
        }

        private void cmbFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            _dt.DefaultView.RowFilter = string.Empty;
            SearchIconVisibility();
        }

        public void LoadData(DataTable dt)
        {
            // Bind to DataGridView
            _dt = dt;

            if (dt == null || dt.Rows.Count == 0)
                return;

            ctrDataView1.LoadDataInDgvManageData(_dt);
            LoadTableHeadersInCmbFilters();
            SetCmbSearchItems();
        }

        public void LoadTitle(string title)
        {
            lblTitle.Text = title;
            lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2;
        }

        public void SetContextMenuStrip(ContextMenuStrip cms)
        {
            ctrDataView1.LoadContextMenuStrip(cms);
        }
    }
}
