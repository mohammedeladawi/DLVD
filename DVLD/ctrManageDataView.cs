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
    public partial class ctrManageDataView : UserControl
    {
        public DataGridView dgvManageDate1
        {
            get {return ctrDataView1.dgvManageDate1;}
        }

        private DataTable _dt; 
        public ctrManageDataView()
        {
            InitializeComponent();
        }

        private bool isTxtSearchSubscribed = false;
        private bool isCmbSearchSubscribed = false;
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
                txtSearch.Clear();
            }
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
        private void SearchIconVisibility()
        {
            if (cmbFilter.SelectedItem.ToString() == "None")
            {
                StopTxtSearch();
                StopCmbSearch();
            }
            else if (cmbFilter.SelectedItem.ToString() == "IsActive")
            {
                StopTxtSearch();
                PlayCmbSearch();
            }
            else
            {
                StopCmbSearch();
                PlayTxtSearch();

            }
        }

        private void InitializeCmbSearchItems()
        {
            if (cmbSearch.Items.Count > 0)
                return;

            cmbSearch.DisplayMember = "Key";
            cmbSearch.ValueMember = "Value";

            cmbSearch.Items.Add(new KeyValuePair<string, bool>("Yes", true));
            cmbSearch.Items.Add(new KeyValuePair<string, bool>("No", false));
            cmbSearch.SelectedIndex = 0;
        }

        private void LoadTableHeadersInCmbFilters()
        {
            // function works one time
            if (cmbFilter.Items.Count > 0)
                return;

            cmbFilter.Items.Add("None");

            foreach (DataColumn column in _dt.Columns)
            {
                cmbFilter.Items.Add(column.ColumnName);
            }
        
            cmbFilter.SelectedIndex = 0; // "NONE"
        }

        private void cmbFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            _dt.DefaultView.RowFilter = string.Empty;
            SearchIconVisibility();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearch.Text.Replace("'", "''"); // Escape single quotes
            if (cmbFilter.SelectedItem == null) return;

            string colName = cmbFilter.SelectedItem.ToString();

            // Ensure the column exists in the DataTable
            if (_dt.Columns.Contains(colName))
            {
                // Escape special characters in column name (dots, spaces, etc.)
                string safeColName = $"[{colName}]";

                if (_dt.Columns[colName].DataType != typeof(string))
                {
                    _dt.DefaultView.RowFilter = $"Convert({safeColName}, 'System.String') LIKE '%{filterText}%'";
                }
                else
                {
                    _dt.DefaultView.RowFilter = $"{safeColName} LIKE '%{filterText}%'";
                }
            }
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

        public void LoadData(DataTable dt)
        {
            // Bind to DataGridView
            _dt = dt;

            if (dt == null || dt.Rows.Count == 0)
                return;

            ctrDataView1.LoadDataInDgvManageData(_dt);
            LoadTableHeadersInCmbFilters();
            InitializeCmbSearchItems();
        }

        public void LoadTitle(string title)
        {
            lblTitle.Text = title;
        }

        public void SetContextMenuStrip(ContextMenuStrip cms)
        {
            ctrDataView1.SetContextMenuStrip(cms);
        }
    }
}
