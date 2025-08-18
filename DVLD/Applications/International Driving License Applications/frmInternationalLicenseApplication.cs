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

        public frmInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void ResetForm()
        {
            // disable all buttons 
            ctrIssueBtn1.Enabled = false;
            llblShowLicenseHistory.Enabled = false;
            llblShowLicenseInfo.Enabled = false;

            // driving license info control
            ctrFindDLicenseInfo1.ResetForm();
            
            // application
            clsApplicationType applicationType = clsApplicationType.Find((int)clsApplicationType.enApplicationTypes.NewInternationalLicense);
            DateTime todayDate = DateTime.Now;
            lblAppDate.Text = todayDate.ToString("dd/MM/yyyy");
            lblIssueDate.Text = todayDate.ToString("dd/MM/yyyy");
            lblExpirationDate.Text = todayDate.AddYears(1).ToString("dd/MM/yyyy");
            lblFees.Text = applicationType.Fees.ToString();
            lblCreatedBy.Text = clsGlobal.currentUser.UserName;
        }
        
        private void frmInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            ResetForm();
        }
       
        private void ctrFindDLicenseInfo1_onLocalLicenseInfoLoaded(int licenseID)
        {
            _localLicense = clsLicense.FindByLicenseID(licenseID);

            if (_localLicense.LicenseClassID != (int)clsLicenseClass.enLicenseClasses.Class3_OrdinaryDrivingLicense)
            {
                MessageBox.Show("License class is not Ordinary Driving License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           // is active 
            if (!_localLicense.IsActive)
            {
                MessageBox.Show("License is not active!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // already has an active international license 
            if (_localLicense.DriverInfo.HasInternationalLicense())
            {
                LoadInternationalLicenseAppUIFields();
                EnableLicenseInfoLLs();
                MessageBox.Show("Driver already has an international License!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ctrFindDLicenseInfo1.DisableFilter();
            ctrIssueBtn1.Enabled = true;
           
        }

        private void llblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form showPersonLicenseHistory = new frmPersonLicenseHistory(_localLicense.DriverInfo.PersonID);
            showPersonLicenseHistory.ShowDialog();
        }
     
        private void LoadInternationalLicenseAppUIFields()
        {
            clsInternationalLicense internationalLicense = clsInternationalLicense.FindByLocalLicenseID(_localLicense.LicenseID);
            lblILAppID.Text = internationalLicense.ApplicationID.ToString();
            lblILLicenseID.Text = internationalLicense.InternationalLicenseID.ToString();
            lblLLicenseID.Text = internationalLicense.IssuedUsingLocalLicenseID.ToString();
        }
       
        private void EnableLicenseInfoLLs()
        {
            llblShowLicenseHistory.Enabled = true;
            llblShowLicenseInfo.Enabled = true;
        }

        private void ctrIssueBtn1_Click(object sender, EventArgs e)
        {
            int internationalLicenseID = _localLicense.IssueNewInternationalLicense(clsGlobal.currentUser.UserID);
            if (internationalLicenseID != -1)
            {
                MessageBox.Show("International license has been issued succesfully", "Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInternationalLicenseAppUIFields();
                EnableLicenseInfoLLs();
                ctrIssueBtn1.Enabled = false;
            }
            else
                MessageBox.Show("Couldn't issue international license!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsInternationalLicense internationalLicense = clsInternationalLicense.FindByLocalLicenseID(_localLicense.LicenseID);
            if (internationalLicense != null)
            {
                Form frmDILicense = new frmInternationalLicenseInfo(internationalLicense.InternationalLicenseID);
                frmDILicense.ShowDialog();
            }
        }
    }
}
