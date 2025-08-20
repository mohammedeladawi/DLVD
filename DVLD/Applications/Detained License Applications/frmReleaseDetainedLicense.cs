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
    public partial class frmReleaseDetainedLicense : Form
    {
        private clsApplicationType _applicationType = clsApplicationType.Find((int)enApplicationTypes.ReleaseDetainedDrivingLicense);
        private clsLicense _license;
        private clsDetainedLicense _detainedLicense;
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicense(int licenseID)
        {
            // fire click bntFind
            //ctrFindDLicenseInfo1.btnFindLicense.

            InitializeComponent();
            ctrFindDLicenseInfo1.txtSearchText = licenseID.ToString();
        }

        private void ResetForm()
        {
            ctrIssueBtn1.Enabled = false;
            llblShowLicenseHistory.Enabled = false;
            llblShowLicenseInfo.Enabled = false;

            lblDetainID.Text = "????";
            lblDetainDate.Text = "????";
            lblApplicationFees.Text = "????";
            lblTotalFees.Text = "????";
            lblLicenseID.Text = "????";
            lblCreatedBy.Text = "????";
            lblFineFees.Text = "????";
            lblApplicationID.Text = "????";
        }

        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            ctrIssueBtn1.btnText = "Release";
            ResetForm();
            ctrFindDLicenseInfo1.ResetForm();

            if (ctrFindDLicenseInfo1.txtSearchText != string.Empty)
                ctrFindDLicenseInfo1.btnFindLicense.PerformClick();

        }

        private void LoadDetainInfoUIFields()
        {
            lblDetainID.Text = _detainedLicense.DetainID.ToString();
            lblDetainDate.Text = _detainedLicense.DetainDate.ToString();
            lblApplicationFees.Text = _applicationType.Fees.ToString();
            lblLicenseID.Text = _detainedLicense.LicenseID.ToString();
            lblCreatedBy.Text = _detainedLicense.CreatedByUserInfo.UserName.ToString();
            lblFineFees.Text = _detainedLicense.FineFees.ToString();
            lblTotalFees.Text = $"{_detainedLicense.FineFees + _applicationType.Fees}";
        }

        private void EnableLicenseInfoLLs()
        {
            llblShowLicenseHistory.Enabled = true;
            llblShowLicenseInfo.Enabled = true;
        }

        private void ctrFindDLicenseInfo1_onLocalLicenseInfoLoaded(int licenseID)
        {
            _license = clsLicense.FindByLicenseID(licenseID);
            
            EnableLicenseInfoLLs();
            if (!_license.IsDetained)
            {
                MessageBox.Show("License is not detained!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _detainedLicense = clsDetainedLicense.FindByLicenseID(_license.LicenseID);
            if ( _detainedLicense == null )
            {
                MessageBox.Show("Couldn't find detianed license info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrFindDLicenseInfo1.DisableFilter();
            LoadDetainInfoUIFields();
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
            int releaseApplicationID = -1;

            if (_license.ReleaseDetainedLicense(clsGlobal.currentUser.UserID, ref releaseApplicationID))
            {
                ctrIssueBtn1.Enabled = false;
                MessageBox.Show("License has been released successfully", "Released", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Couldn't release license!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationID.Text = releaseApplicationID.ToString();
        }
    }
}
