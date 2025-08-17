using DVLD_BusinessLayer;
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
    public partial class frmManageApplicationTypes: Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }
        private int GetSelectedApplicationTypeID()
        {
            DataGridView dgvApplicationType = ctrDataView1.dgvManageDate1;
            int ApplicationTypeID = -1;

            if (dgvApplicationType.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvApplicationType.SelectedRows[0];
                ApplicationTypeID = Convert.ToInt32(row.Cells["ApplicationTypeID"].Value);
            }

            return ApplicationTypeID;
        }
        private void ReloadApplicationTypesData()
        {
            ctrDataView1.LoadData(clsApplicationType.GetAllTypes());
        }
        private void frmUpdateApplicationType_Closed(object sender, EventArgs e)
        {
            ReloadApplicationTypesData();
        }

        private void UpdateApplicationTypeDialog(int applicationTypeID)
        {
            Form updateApplicationType = new frmUpdateApplicationType(applicationTypeID);
            updateApplicationType.FormClosed += frmUpdateApplicationType_Closed;
            updateApplicationType.ShowDialog();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            ctrDataView1.LoadContextMenuStrip(cmsManageApplicationTypes);
            ctrDataView1.LoadData(clsApplicationType.GetAllTypes());
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int applicationTypeID = GetSelectedApplicationTypeID();

            if (applicationTypeID != -1)
            {
                UpdateApplicationTypeDialog(applicationTypeID);
            }
            else
            {
                MessageBox.Show("There is no selected row");
            }
        }



    }
}
