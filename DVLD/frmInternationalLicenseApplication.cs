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
    public partial class frmInternationalLicenseApplication: Form
    {
        private clsLicense _localLicense;
        private clsApplicationType _applicationType = clsApplicationType.Find((int) enApplicationTypes.NewInternationalLicense);
        public frmInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void InitializeInternationalApplication()
        {
            ctrIssueBtn1.Enabled = false;
            llblShowLicenseHistory.Enabled = false;
            llblShowLicenseInfo.Enabled = false;

            DateTime todayDate = DateTime.Now;
            lblAppDate.Text = todayDate.ToString("dd/MM/yyyy");
            lblIssueDate.Text = todayDate.ToString("dd/MM/yyyy");
            lblExpirationDate.Text = todayDate.AddYears(1).ToString("dd/MM/yyyy");
            lblFees.Text = _applicationType.Fees.ToString();
            lblCreatedBy.Text = clsGlobal.currentUser.UserName;
        }
        
        private void frmInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            InitializeInternationalApplication();
        }
       
        private void ctrFindDLicenseInfo1_onLocalLicenseInfoLoaded(int licenseID)
        {
            _localLicense = clsLicense.FindByLicenseID(licenseID);
            if (_localLicense == null)
                return;

            if (_localLicense.LicenseClassID != (int)enLicenseClasses.Class3_OrdinaryDrivingLicense)
                return;

           // is active 
            if (_localLicense.IsActive == false)
            {
                MessageBox.Show("License is not active!");
                return;
            }

            // not already has an active international license 
            if (clsInternationalLicense.HasInternationalLicense(licenseID))
            {
                ctrFindDLicenseInfo1.gbFilterLicense.Enabled = false;
                llblShowLicenseHistory.Enabled = true;
                llblShowLicenseInfo.Enabled = true;
                MessageBox.Show("Driver already has international License!");
                return;
            }

            llblShowLicenseHistory.Enabled = true;
            ctrFindDLicenseInfo1.gbFilterLicense.Enabled = false;
            ctrIssueBtn1.Enabled = true;
           
        }

        private void llblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_localLicense == null)
                return;

            Form showPersonLicenseHistory = new frmPersonLicenseHistory(_localLicense.ApplicationID);
            showPersonLicenseHistory.ShowDialog();
        }

        private void LoadApplicationData(clsApplication application)
        {
            DateTime todayDate = DateTime.Now;
            application.ApplicationPersonID = _localLicense.Driver.PersonID;
            application.ApplicationDate = todayDate;
            application.ApplicationTypeID = Convert.ToByte(_applicationType.ApplicationTypeID);
            application.PaidFees = _applicationType.Fees;
            application.CreatedByUserID = clsGlobal.currentUser.UserID;
        }
        
        private void LoadILicenseData(clsInternationalLicense internationalLicense, int applicationID)
        {
            DateTime todayDate = DateTime.Now;
            internationalLicense.ApplicationID = applicationID;
            internationalLicense.DriverID = _localLicense.DriverID;
            internationalLicense.IssuedUsingLocalLicenseID = _localLicense.LicenseID;
            internationalLicense.IssueDate = todayDate;
            internationalLicense.ExpirationDate = todayDate.AddYears(1);
            internationalLicense.IsActive = true;
            internationalLicense.CreatedByUserID = clsGlobal.currentUser.UserID;
        }
        
        private void UpdateInternationApplicationFields(clsInternationalLicense internationalLicense)
        {
            lblILAppID.Text = internationalLicense.ApplicationID.ToString();
            lblILLicenseID.Text = internationalLicense.InternationalLicenseID.ToString();
            lblLLicenseID.Text = internationalLicense.IssuedUsingLocalLicenseID.ToString();
        }
       
        private void ctrIssueBtn1_Click(object sender, EventArgs e)
        {
            clsApplication application = new clsApplication();
            LoadApplicationData(application);
            if (!application.Save())
                return;

            clsInternationalLicense internationalLicense = new clsInternationalLicense();
            LoadILicenseData(internationalLicense, application.ApplicationID);
            if (internationalLicense.Save())
            {
                MessageBox.Show("International License Has Been Issued Succesfully");
                UpdateInternationApplicationFields(internationalLicense);
                llblShowLicenseInfo.Enabled = true;
            }
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_localLicense == null)
                return;

            Form frmDILicense = new frmInternationalLicenseInfo(_localLicense.LicenseID);
            frmDILicense.ShowDialog();
        }
    }
}
