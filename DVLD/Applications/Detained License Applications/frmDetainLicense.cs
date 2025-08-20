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
    public partial class frmDetainLicense : Form
    {
        private clsLicense _license;

        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void ResetForm()
        {
            ctrIssueBtn1.Enabled = false;
            llblShowLicenseHistory.Enabled = false;
            llblShowLicenseInfo.Enabled = false;

            DateTime todayDate = DateTime.Now;
            lblDetainDate.Text = todayDate.ToString("dd/MM/yyyy");
            lblCreatedBy.Text = clsGlobal.currentUser.UserName;
            txtFineFees.Text = "";
            lblDetainID.Text = "????";
            lblLicenseID.Text = "????";
        }

        private void EnableLicenseInfoLLs()
        {
            llblShowLicenseHistory.Enabled = true;
            llblShowLicenseInfo.Enabled = true;
        }
        
        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            ctrIssueBtn1.btnText = "Detain";
            ResetForm();
            ctrFindDLicenseInfo1.ResetForm();
        }

        private void ctrFindDLicenseInfo1_onLocalLicenseInfoLoaded(int licenseID)
        {
            _license = clsLicense.FindByLicenseID(licenseID);
            lblLicenseID.Text = licenseID.ToString();
            EnableLicenseInfoLLs();

            if (_license.IsDetained)
            {
                MessageBox.Show("License is already detained!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (_license.IsExpired)
            {
                MessageBox.Show("License is expired!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!_license.IsActive)
            {
                MessageBox.Show("License is not active!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // if found disable the filter
            ctrFindDLicenseInfo1.DisableFilter();
            ctrIssueBtn1.Enabled = true;
        }

        private void llblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_license != null)
            {
                Form showPersonLicenseHistory = new frmPersonLicenseHistory(_license.DriverInfo.PersonID);
                showPersonLicenseHistory.ShowDialog();
            }
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_license != null)
            {
                Form frmDILicense = new frmDriverLicenseInfo(_license.LicenseID);
                frmDILicense.ShowDialog();
            }
        }
        
        private void ctrIssueBtn1_Click(object sender, EventArgs e)
        {
            decimal fineFees;
            if (!decimal.TryParse(txtFineFees.Text, out fineFees))
                fineFees = 0;

            int detainID = _license.Detain(clsGlobal.currentUser.UserID, fineFees);
            if (detainID != -1)
            {
                lblDetainID.Text = detainID.ToString();
                ctrIssueBtn1.Enabled = false;
                MessageBox.Show("License has been detained successfully", "Detained", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Couldn't detain license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
