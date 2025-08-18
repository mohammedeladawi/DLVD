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
        private clsApplicationType _applicationType;
        public frmRenewLicenseApplication()
        {
            InitializeComponent();
        }

        private void ResetForm()
        {
            // all buttons
            ctrIssueBtn1.Enabled = false;
            llblShowLicenseHistory.Enabled = false;
            llblShowLicenseInfo.Enabled = false;

            // application info group
            DateTime todayDate = DateTime.Now;
            lblAppDate.Text = todayDate.ToString("dd/MM/yyyy");
            lblIssueDate.Text = todayDate.ToString("dd/MM/yyyy");
            lblApplicationFees.Text = _applicationType.Fees.ToString();
            lblCreatedBy.Text = clsGlobal.currentUser.UserName;

            lblRenewedLicenseID.Text = "????";
            lblLicenseFees.Text = "????";
            lblRLAppID.Text = "????";
            lblOldLicenseID.Text = "????";
            lblExpirationDate.Text = "????";
            lblTotalFees.Text = "????";
            txtNotes.Clear();
        }
       
        private void LoadRenewApplicationUIFields()
        {
            // load renew application fields
            lblLicenseFees.Text = _oldLicense.LicenseClassInfo.ClassFees.ToString();
            lblTotalFees.Text = (_oldLicense.LicenseClassInfo.ClassFees + _applicationType.Fees).ToString();
            lblOldLicenseID.Text = _oldLicense.LicenseID.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(_oldLicense.LicenseClassInfo.DefaultValidityLength).ToString();
        }

        private void EnableLicenseInfoLLs()
        {
            llblShowLicenseHistory.Enabled = true;
            llblShowLicenseInfo.Enabled = true;
        }
       
        private void ctrFindDLicenseInfo1_onLocalLicenseInfoLoaded_1(int licenseID)
        {
            ResetForm();

            _oldLicense = clsLicense.FindByLicenseID(licenseID);

            // is not expired
            if (!_oldLicense.IsExpired && _oldLicense.IsActive)
            {
                EnableLicenseInfoLLs();
                MessageBox.Show("License is still valid and cannot be renewed yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!_oldLicense.IsActive)
            {
                EnableLicenseInfoLLs();
                MessageBox.Show("This license is inactive. It cannot be renewed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadRenewApplicationUIFields();

            // user won't change license after issue
            ctrFindDLicenseInfo1.DisableFilter();            
            ctrIssueBtn1.Enabled = true;
        }

        private void ctrRenewBtn1_Click(object sender, EventArgs e)
        {
            int newLicenseID = _oldLicense.RenewLicense(clsGlobal.currentUser.UserID, txtNotes.Text.ToString());

            if (newLicenseID != -1)
            {
                _newLicense = clsLicense.FindByLicenseID(newLicenseID);

                // load new license in the ui fields
                lblRLAppID.Text = _newLicense.ApplicationID.ToString();
                lblRenewedLicenseID.Text = _newLicense.LicenseID.ToString();
                ctrIssueBtn1.Enabled = false;

                EnableLicenseInfoLLs();
                MessageBox.Show("License has been renewed successfully", "Renewed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Couldn't renew license!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);            

        }

        private void frmRenewLicenseApplication_Load(object sender, EventArgs e)
        {
            _applicationType = clsApplicationType.Find((int)clsApplicationType.enApplicationTypes.RenewDrivingLicenseService);
            ctrIssueBtn1.btnText = "Renew";
            ResetForm();

            // license info control
            ctrFindDLicenseInfo1.ResetForm();
        }

        private void llblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         
            Form showPersonLicenseHistory = new frmPersonLicenseHistory(_oldLicense.DriverInfo.PersonID);
            showPersonLicenseHistory.ShowDialog();
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm;
            if (_newLicense != null)
                frm = new frmDriverLicenseInfo(_newLicense.LicenseID);
            else
                frm = new frmDriverLicenseInfo(_oldLicense.LicenseID);

            frm.ShowDialog();
        }
    }
}
