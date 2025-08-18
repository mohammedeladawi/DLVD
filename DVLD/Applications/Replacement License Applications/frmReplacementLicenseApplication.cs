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
    public partial class frmReplacementLicenseApplication : Form
    {
        private clsLicense _oldLicense, _newLicense;
        private clsApplicationType _applicationType;

        public frmReplacementLicenseApplication()
        {
            InitializeComponent();
        }

        private void ResetForm()
        {
            // Disable buttons
            ctrIssueBtn1.Enabled = false;
            llblShowLicenseHistory.Enabled = false;
            llblShowLicenseInfo.Enabled = false;
            
            // application info
            DateTime todayDate = DateTime.Now;
            lblAppDate.Text = todayDate.ToString("dd/MM/yyyy");
            lblCreatedBy.Text = clsGlobal.currentUser.UserName;
            lblLicenseReplacementAppID.Text = "????";
            lblReplacedLicenseID.Text = "????";
            lblOldLicenseID.Text = "????";
            lblApplicationFees.Text = _applicationType != null ? _applicationType.Fees.ToString() :"????";
        }

        private void frmReplacementApplication_Load(object sender, EventArgs e)
        {
            ctrIssueBtn1.btnText = "Replace";
            ResetForm();
            rbDamagedLicense.Checked = true; // event will work
            ctrFindDLicenseInfo1.ResetForm();
        }

        private void EnableLicenseInfoLLs()
        {
            llblShowLicenseHistory.Enabled = true;
            llblShowLicenseInfo.Enabled = true;
        }

        private void ctrFindDLicenseInfo1_onLocalLicenseInfoLoaded(int oldLicenseID)
        {
            ResetForm();
            _oldLicense = clsLicense.FindByLicenseID(oldLicenseID);

            if (_oldLicense.IsExpired)
            {
                EnableLicenseInfoLLs();
                MessageBox.Show("This license has expired!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!_oldLicense.IsActive)
            {
                EnableLicenseInfoLLs();
                MessageBox.Show("This license is inactive. It cannot be replaced.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // load replacement application fields
            lblOldLicenseID.Text = _oldLicense.LicenseID.ToString();
            
            ctrFindDLicenseInfo1.DisableFilter();
            ctrIssueBtn1.Enabled = true;
        }
        
        private clsLicense.enIssueReasons GetIssueReason()
        {
            if (rbDamagedLicense.Checked)
                return clsLicense.enIssueReasons.ReplacementForDamaged;
            else
                return clsLicense.enIssueReasons.ReplacementForLost;
        }
        
        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            _applicationType = clsApplicationType.Find((int)clsApplicationType.enApplicationTypes.ReplacementForDamagedDrivingLicense);
            lblApplicationFees.Text = _applicationType.Fees.ToString();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            _applicationType = clsApplicationType.Find((int)clsApplicationType.enApplicationTypes.ReplacementForLostDrivingLicense);
            lblApplicationFees.Text = _applicationType.Fees.ToString();
        }

        private void ctrIssueBtn1_Click(object sender, EventArgs e)
        {

            int newLicenseID = _oldLicense.Replace(GetIssueReason(), clsGlobal.currentUser.UserID);
            _newLicense = clsLicense.FindByLicenseID(newLicenseID);
            if (_newLicense != null)
            {
                lblLicenseReplacementAppID.Text = _newLicense.ApplicationID.ToString();
                lblReplacedLicenseID.Text = _newLicense.LicenseID.ToString();

                EnableLicenseInfoLLs();
                gbReplacement.Enabled = false;
                ctrIssueBtn1.Enabled = false;

                MessageBox.Show("License has been replaced successfully.", "Replaced", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
               MessageBox.Show("Couldn't replace license!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
