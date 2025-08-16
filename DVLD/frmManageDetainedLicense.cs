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

        private int GetSelectedDriverID()
        {
            DataGridView dgvDLicense = ctrManageDataView1.dgvManageDate1;
            int driverID = -1;

            if (dgvDLicense.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvDLicense.SelectedRows[0];
                driverID = Convert.ToInt32(row.Cells["DriverID"].Value);
            }

            return driverID;
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
        private void frmManageDetainedLicense_Load(object sender, EventArgs e)
        {
            ctrManageDataView1.LoadTitle("List Detained Licenses");
            ctrManageDataView1.LoadData(clsDetainedLicense.GetAll());
            ctrManageDataView1.SetContextMenuStrip(cmsManageDetainedLicenses);
        }

        private void ShowPersonDetails(int driverID)
        {
            clsDriver driver = clsDriver.Find(driverID);
            if (driver == null)
                return;


            Form frmPersonDetails = new frmPersonDetails(driver.PersonID);
            frmPersonDetails.ShowDialog();
        }
        private void tsmiShowPersonDetails_Click(object sender, EventArgs e)
        {
            int driverID = GetSelectedDriverID();
            if (driverID == -1)
            {
                MessageBox.Show("There is no selected row");
                return;
            }

            ShowPersonDetails(driverID);



                       
        }

        private void ShowLicenseInfoDialog(int licenseID)
        {
            clsLicense license = clsLicense.FindByLicenseID(licenseID);
            if (license == null)
                return;

            Form frmLicenseInfo = new frmDriverLicenseInfo(license);
            frmLicenseInfo.ShowDialog();
        }
        
        private void tsmiShowLicenseDetails_Click(object sender, EventArgs e)
        {
            int licenseID = GetSelectedLicenseID();
            if (licenseID == -1)
            {
                MessageBox.Show("There is no selected row");
                return;
            }

            ShowLicenseInfoDialog(licenseID);
        }

        private void ShowPersonLicenseHistory(int driverID)
        {
            clsDriver driver = clsDriver.Find(driverID);
            if (driver == null)
                return;

            Form frmPLicenseHistory = new frmPersonLicenseHistory(driver);
            frmPLicenseHistory.ShowDialog();

        }
        private void tsmiShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int driverID = GetSelectedDriverID();
            if (driverID == -1)
            {
                MessageBox.Show("There is no selected row");
                return;
            }

            ShowPersonLicenseHistory(driverID);
        }


        private void ShowReleaseDetainedLicenseDialog(int licenseID)
        {
            Form frmReleaseDetainedLDialog = new frmReleaseDetainedLicense(licenseID);
            frmReleaseDetainedLDialog.FormClosed += frm_Closed;
            frmReleaseDetainedLDialog.ShowDialog();

        }
        private void tsmiReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            // open dialog
            int licenseID = GetSelectedLicenseID();
            if (licenseID == -1)
            {
                MessageBox.Show("There is no selected row");
                return;
            }

            ShowReleaseDetainedLicenseDialog(licenseID);

        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            Form frmDetain = new frmDetainLicense();
            frmDetain.FormClosed += frm_Closed;
            frmDetain.ShowDialog();
        }

        private void frm_Closed(object sender, FormClosedEventArgs e)
        {
            ReloadDetainedLicenses();
        }
        
        private void ReloadDetainedLicenses()
        {
            ctrManageDataView1.LoadData(clsDetainedLicense.GetAll());
        }
        private void btnRelease_Click(object sender, EventArgs e)
        {
            Form frmRelease = new frmReleaseDetainedLicense();
            frmRelease.FormClosed += frm_Closed;
            frmRelease.ShowDialog();    
        }

        private void cmsManageDetainedLicenses_Opening(object sender, CancelEventArgs e)
        {
            int licenseID = GetSelectedLicenseID();
            if (licenseID == -1)
                return;

            tsmiReleaseDetainedLicense.Enabled = clsDetainedLicense.IsDetainedByLicenseID(licenseID);
            

        }
    }
}
