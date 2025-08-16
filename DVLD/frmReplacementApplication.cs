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
    public partial class frmReplacementApplication : Form
    {
        private clsLicense _oldLicense, _newLicense;
        private clsApplicationType _applicationType;
        public frmReplacementApplication()
        {
            InitializeComponent();
        }

        private void LoadApplicationType()
        {
            int applicationTypeID;
            if (rbDamagedLicense.Checked)
                applicationTypeID = (int)enApplicationTypes.ReplacementForDamagedDrivingLicense;
            else
                applicationTypeID = (int)enApplicationTypes.ReplacementForLostDrivingLicense;

            _applicationType = clsApplicationType.Find(applicationTypeID);
            lblApplicationFees.Text = _applicationType.Fees.ToString();

        }
        private void InitializeNewLicenseApplication()
        {
            ctrIssueBtn1.Enabled = false;
            llblShowLicenseHistory.Enabled = false;
            llblShowLicenseInfo.Enabled = false;
            DateTime todayDate = DateTime.Now;
            lblAppDate.Text = todayDate.ToString("dd/MM/yyyy");
            lblCreatedBy.Text = clsGlobal.currentUser.UserName;
        }

        private void frmReplacementApplication_Load(object sender, EventArgs e)
        {
            LoadApplicationType();
            InitializeNewLicenseApplication();
        }

        private void ctrFindDLicenseInfo1_onLocalLicenseInfoLoaded(int oldLicenseID)
        {
            _oldLicense = clsLicense.FindByLicenseID(oldLicenseID);
            if (_oldLicense == null)
                return;

            if (_oldLicense.ExpirationDate < DateTime.Now || !_oldLicense.IsActive)
            {
                _newLicense = _oldLicense;
                llblShowLicenseHistory.Enabled = true;
                llblShowLicenseInfo.Enabled = true;
                MessageBox.Show("License is expired!");
                return;
            }

            // load renew application fields
            lblOldLicenseID.Text = _oldLicense.LicenseID.ToString();

            // enable fields 
            llblShowLicenseHistory.Enabled = true;
            ctrFindDLicenseInfo1.gbFilterLicense.Enabled = false;
            ctrIssueBtn1.Enabled = true;
        }

        private void llblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form showPersonLicenseHistory = new frmPersonLicenseHistory(_oldLicense.ApplicationID);
            showPersonLicenseHistory.ShowDialog();
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_newLicense == null)
                return;

            Form frmLicense = new frmDriverLicenseInfo(_newLicense);
            frmLicense.ShowDialog();
        }

        private void LoadApplicationData(clsApplication application)
        {
            application.ApplicationPersonID = _oldLicense.DriverInfo.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = Convert.ToByte(_applicationType.ApplicationTypeID);
            application.PaidFees = _applicationType.Fees;
            application.CreatedByUserID = clsGlobal.currentUser.UserID;
        }

        private bool DeactivateOldLicense()
        {
            _oldLicense.IsActive = false;
            return _oldLicense.Save();
        }
        
        private byte GetIssueReason()
        {
            if (rbDamagedLicense.Checked)
                return (int)enIssueReasons.ReplacementForDamaged;
            else
                return (int)enIssueReasons.ReplacementForLost;
        }
        
        private bool AddNewLicense(int renewApplicationID)
        {
            _newLicense = new clsLicense();
            _newLicense.ApplicationID = renewApplicationID;
            _newLicense.DriverID = _oldLicense.DriverID;
            _newLicense.LicenseClassID = _oldLicense.LicenseClassID;
            _newLicense.IssuanceDate = _oldLicense.IssuanceDate;
            _newLicense.ExpirationDate = _oldLicense.ExpirationDate;
            _newLicense.Notes = _oldLicense.Notes;
            _newLicense.PaidFees = _applicationType.Fees;
            _newLicense.IsActive = true;
            _newLicense.IssueReason = GetIssueReason();
            _newLicense.CreatedByUserID = clsGlobal.currentUser.UserID;
            return _newLicense.Save();
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            LoadApplicationType();
        }

        private void ctrIssueBtn1_Click(object sender, EventArgs e)
        {
            clsApplication replacementLApplication = new clsApplication();
            LoadApplicationData(replacementLApplication);
            if (!replacementLApplication.Save())
                return;

            if (!DeactivateOldLicense())
                return;

            if (AddNewLicense(replacementLApplication.ApplicationID))
            {
                lblLRAppID.Text = _newLicense.ApplicationID.ToString();
                lblReplacedLicenseID.Text = _newLicense.LicenseID.ToString();
                llblShowLicenseInfo.Enabled = true;
                gbReplacement.Enabled = false;
                ctrIssueBtn1.Enabled = false;

                MessageBox.Show("License has been renewed successfully");
            }
            else
                MessageBox.Show("Couldn't renew license");
        }
    }
}
