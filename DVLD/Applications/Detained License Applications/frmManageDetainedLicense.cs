using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class frmManageDetainedLicense : Form
    {
        public frmManageDetainedLicense()
        {
            InitializeComponent();
        }

        private int GetSelectedLicenseID()
        {
            DataGridView dgvDLicense = ctrManageDataView1.dgvManageDate1;
            int licenseID = -1;

            if (dgvDLicense.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvDLicense.SelectedRows[0];
                licenseID = Convert.ToInt32(row.Cells["LicenseID"].Value);
            }

            return licenseID;
        }
            
        private bool TryGetSelectedLicenseID(out int licenseID)
        {
            licenseID = GetSelectedLicenseID();
            if (licenseID == -1)
            {
                MessageBox.Show("There is no selected row", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void frmManageDetainedLicense_Load(object sender, EventArgs e)
        {
            ctrManageDataView1.LoadTitle("Manage Detained Licenses");
            ctrManageDataView1.LoadData(clsDetainedLicense.GetAllDetainedLicenses());
            ctrManageDataView1.LoadContextMenuStrip(cmsManageDetainedLicenses);
        }

        private void tsmiShowPersonDetails_Click(object sender, EventArgs e)
        {


            if (TryGetSelectedLicenseID(out int licenseID))
            {
                clsLicense license = clsLicense.FindByLicenseID(licenseID);
                if (license != null)
                {
                    Form frmPersonDetails = new frmPersonDetails(license.DriverInfo.PersonID);
                    frmPersonDetails.ShowDialog();
                }
            }



        }
        
        private void tsmiShowLicenseDetails_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedLicenseID(out int licenseID))
            {
                Form frmLicenseInfo = new frmDriverLicenseInfo(licenseID);
                frmLicenseInfo.ShowDialog();
            }
        }

        private void tsmiShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedLicenseID(out int licenseID))
            {
                clsLicense license = clsLicense.FindByLicenseID(licenseID);
                if (license != null)
                {
                    Form frmPLicenseHistory = new frmPersonLicenseHistory(license.DriverInfo.PersonID);
                    frmPLicenseHistory.ShowDialog();
                }
            }          
        }

        private void tsmiReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedLicenseID(out int licenseID))
            {
                Form frmReleaseDetainedLDialog = new frmReleaseDetainedLicense(licenseID);
                frmReleaseDetainedLDialog.FormClosed += frm_Closed;
                frmReleaseDetainedLDialog.ShowDialog();
            }

        }
        private void frm_Closed(object sender, FormClosedEventArgs e)
        {
            ReloadDetainedLicenses();
        }
       
        private void ReloadDetainedLicenses()
        {
            ctrManageDataView1.LoadData(clsDetainedLicense.GetAllDetainedLicenses());
        }
        
        private void btnDetain_Click(object sender, EventArgs e)
        {
            Form frmDetain = new frmDetainLicense();
            frmDetain.FormClosed += frm_Closed;
            frmDetain.ShowDialog();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            Form frmRelease = new frmReleaseDetainedLicense();
            frmRelease.FormClosed += frm_Closed;
            frmRelease.ShowDialog();    
        }
        
        private void cmsManageDetainedLicenses_Opening(object sender, CancelEventArgs e)
        {
            if (GetSelectedLicenseID() != -1)
                tsmiReleaseDetainedLicense.Enabled = !(bool)ctrManageDataView1.dgvManageDate1.CurrentRow.Cells["IsReleased"].Value;
        }
    }
}
