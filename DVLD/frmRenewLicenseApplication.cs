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
    public partial class frmRenewLicenseApplication : Form
    {
        private clsLicense _oldLicense, _newLicense;
        private clsApplicationType _applicationType = clsApplicationType.Find((int)enApplicationTypes.RenewDrivingLicenseService);
        private clsLicenseClass licenseClass;
        public frmRenewLicenseApplication()
        {
            InitializeComponent();
        }
        private void InitializeNewLicenseApplication()
        {
            ctrIssueBtn1.Enabled = false;
            llblShowLicenseHistory.Enabled = false;
            llblShowLicenseInfo.Enabled = false;

            DateTime todayDate = DateTime.Now;
            lblAppDate.Text = todayDate.ToString("dd/MM/yyyy");
            lblIssueDate.Text = todayDate.ToString("dd/MM/yyyy");
            lblApplicationFees.Text = _applicationType.Fees.ToString();
            lblCreatedBy.Text = clsGlobal.currentUser.UserName;
        }


       
        private void ctrFindDLicenseInfo1_onLocalLicenseInfoLoaded_1(int licenseID)
        {
            InitializeNewLicenseApplication();
            _oldLicense = clsLicense.FindByLicenseID(licenseID);
            if (_oldLicense == null)
                return;

            // is active 
            if (_oldLicense.ExpirationDate > DateTime.Now)
            {
                _newLicense = _oldLicense;
                llblShowLicenseHistory.Enabled = true;
                llblShowLicenseInfo.Enabled = true;
                MessageBox.Show("License is not yet expired!");
                return;
            }

            // load renew application fields
            licenseClass = clsLicenseClass.Find(_oldLicense.LicenseClassID);
            lblLicenseFees.Text = licenseClass.ClassFees.ToString();
            lblTotalFees.Text = (licenseClass.ClassFees + _applicationType.Fees).ToString();
            lblOldLicenseID.Text = _oldLicense.LicenseID.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(licenseClass.DefaultValidityLength).ToString();
            
            // enable fields 
            llblShowLicenseHistory.Enabled = true;
            ctrFindDLicenseInfo1.gbFilterLicense.Enabled = false;
            ctrIssueBtn1.Enabled = true;
        }

        private void llblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_newLicense == null)
                return;

            Form showPersonLicenseHistory = new frmPersonLicenseHistory(_newLicense.ApplicationID);
            showPersonLicenseHistory.ShowDialog();
        }

        private void LoadApplicationData(clsApplication application)
        {
            application.ApplicationPersonID = _oldLicense.DriverInfo.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = (byte)enApplicationTypes.RenewDrivingLicenseService;
            application.PaidFees = _applicationType.Fees;
            application.CreatedByUserID = clsGlobal.currentUser.UserID;
        }

        private bool DeactivateOldLicense()
        {
            _oldLicense.IsActive = false;
            return _oldLicense.Save();
        }
        
        private bool AddNewLicense(int renewApplicationID)
        {
            _newLicense = new clsLicense();
            _newLicense.ApplicationID = renewApplicationID;
            _newLicense.DriverID = _oldLicense.DriverID;
            _newLicense.LicenseClassID = _oldLicense.LicenseClassID;
            _newLicense.IssuanceDate = DateTime.Now;
            _newLicense.ExpirationDate = DateTime.Now.AddYears(licenseClass.DefaultValidityLength);
            _newLicense.Notes = txtNotes.Text;
            _newLicense.PaidFees = licenseClass.ClassFees;
            _newLicense.IsActive = true;
            _newLicense.IssueReason = (byte)enIssueReasons.Renew;
            _newLicense.CreatedByUserID = clsGlobal.currentUser.UserID;
            return _newLicense.Save();
        }
        private void ctrIssueBtn1_Click(object sender, EventArgs e)
        {
            clsApplication renewApplication = new clsApplication();
            LoadApplicationData(renewApplication);
            if (!renewApplication.Save())
                return;

            if (!DeactivateOldLicense())
                return;

            if (AddNewLicense(renewApplication.ApplicationID))
            {
                lblRLAppID.Text = _newLicense.ApplicationID.ToString();
                lblRenewedLicenseID.Text = _newLicense.LicenseID.ToString();
                llblShowLicenseInfo.Enabled = true;
                MessageBox.Show("License has been renewed successfully");
            }
            else
                MessageBox.Show("Couldn't renew license");

        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_newLicense == null)
                return;

            Form frmLicense = new frmDriverLicenseInfo(_newLicense);
            frmLicense.ShowDialog();
        }
    }
}
