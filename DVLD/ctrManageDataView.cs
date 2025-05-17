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
            SearchIconVisibility();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearch.Text;
            string colName = cmbFilter.SelectedItem.ToString();

            if (_dt.Columns.Contains(colName) && _dt.Columns[colName].DataType != typeof(string))
                _dt.DefaultView.RowFilter = $"Convert({colName}, 'System.String') Like '%{filterText}%'";
            else
                _dt.DefaultView.RowFilter = $"{colName} Like '%{filterText}%'";
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
        }

        public void LoadTitle(string title)
        {
            lblTitle.Text = title;
        }

        public void SetContextMenuStrip(ContextMenuStrip cms)
        {
            //ctrDataView1.SetContextMenuStrip(cms);
        }
    }
}
