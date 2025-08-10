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

        private void DisableFields()
        {
            ctrIssueBtn1.Enabled = false;
            llblShowLicenseHistory.Enabled = false;
            llblShowLicenseInfo.Enabled = false;
        }

        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            ctrIssueBtn1.btnText = "Release";
            DisableFields();
            ctrFindDLicenseInfo1.btnFindLicense.PerformClick();

        }

        private void LoadDetainedLicenseFields()
        {
            _detainedLicense = clsDetainedLicense.FindByLicenseID(_license.LicenseID);
            lblDetainID.Text = _detainedLicense.DetainID.ToString();
            lblDetainDate.Text = _detainedLicense.DetainDate.ToString();
            lblApplicationFees.Text = _applicationType.Fees.ToString();
            lblLicenseID.Text = _detainedLicense.LicenseID.ToString();

            var createdByUsername = clsUser.Find(_detainedLicense.CreatedByUserID)?.UserName;
            if (createdByUsername != null)
                lblCreatedBy.Text = createdByUsername;

            lblFineFees.Text = _detainedLicense.FineFees.ToString();
            lblTotalFees.Text = $"{_detainedLicense.FineFees + _applicationType.Fees}";
        }

        private void EnableFields()
        {
            ctrIssueBtn1.Enabled = true;
            llblShowLicenseHistory.Enabled = true;
            llblShowLicenseInfo.Enabled = true;
        }

        private void ctrFindDLicenseInfo1_onLocalLicenseInfoLoaded(int licenseID)
        {
            _license = clsLicense.FindByLicenseID(licenseID);
            if (_license == null)
            {
                MessageBox.Show("Could not find detained license info.");
                return;
            }

            if (!clsDetainedLicense.IsDetained(licenseID))
            {
                MessageBox.Show("License is not detained!");
                return;
            }

            ctrFindDLicenseInfo1.gbFilterLicense.Enabled = false;
            LoadDetainedLicenseFields();
            EnableFields();

        }

        private void llblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_license == null)
                return;

            Form showPersonLicenseHistory = new frmPersonLicenseHistory(_license.ApplicationID);
            showPersonLicenseHistory.ShowDialog();
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_license == null)
                return;

            Form frmDILicense = new frmDriverLicenseInfo(_license);
            frmDILicense.ShowDialog();
        }

        private void LoadApplicationData(clsApplication application)
        {
            application.ApplicationPersonID = _license.Driver.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = Convert.ToByte(_applicationType.ApplicationTypeID);
            application.PaidFees = _applicationType.Fees;
            application.CreatedByUserID = clsGlobal.currentUser.UserID;

        }

        private void LoadReleaseLicenseData(int applicationID)
        {
            _detainedLicense.IsReleased = true;
            _detainedLicense.ReleaseDate = DateTime.Now;
            _detainedLicense.ReleaseByUserID = clsGlobal.currentUser.UserID;
            _detainedLicense.ReleaseApplicationID = applicationID;
        }

        private void ctrIssueBtn1_Click(object sender, EventArgs e)
        {
            clsApplication releaseApplication = new clsApplication();
            LoadApplicationData(releaseApplication);
            if (!releaseApplication.Save())
            {
                MessageBox.Show("Couldn't add new application");
                return;
            }

            LoadReleaseLicenseData(releaseApplication.ApplicationID);
            if (!_detainedLicense.Save())
            {
                MessageBox.Show("Couldn't update detained license info!");
                return;
            }

            _license.IsActive = true;
            if (!_license.Save())
            {
                MessageBox.Show("Couldn't active license!");
                return;
            }

            clsApplication.Complete(releaseApplication.ApplicationID);
            ctrIssueBtn1.Enabled = false;
            lblApplicationID.Text = releaseApplication.ApplicationID.ToString();
            MessageBox.Show("License has been released successfully");

        }
    }
}
