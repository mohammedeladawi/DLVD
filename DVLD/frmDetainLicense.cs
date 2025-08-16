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

        private void InitializeDetainApplication()
        {
            ctrIssueBtn1.Enabled = false;
            llblShowLicenseHistory.Enabled = false;
            llblShowLicenseInfo.Enabled = false;

            DateTime todayDate = DateTime.Now;
            lblDetainDate.Text = todayDate.ToString("dd/MM/yyyy");
            lblCreatedBy.Text = clsGlobal.currentUser.UserName;
            txtFineFees.Text = "";
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            ctrIssueBtn1.btnText = "Detain";
            InitializeDetainApplication();
        }

        private void UpdateDetainLicenseInfoFields(clsDetainedLicense detainedLicense)
        {
            if (_license == null)
                return;

            lblDetainID.Text = detainedLicense.DetainID.ToString();
            lblLicenseID.Text = detainedLicense.LicenseID.ToString();
            lblDetainDate.Text = detainedLicense.DetainDate.ToString();

        }
        private void ctrFindDLicenseInfo1_onLocalLicenseInfoLoaded(int licenseID)
        {
            _license = clsLicense.FindByLicenseID(licenseID);
            if (_license == null)
                return;

            if (clsDetainedLicense.IsDetainedByLicenseID(licenseID))
            {
                MessageBox.Show("License is already detained");
                return;
            }
            else if(_license.IsActive == false)
            {
                MessageBox.Show("License is not active!");
                return;
            }
             

            llblShowLicenseHistory.Enabled = true;
            llblShowLicenseInfo.Enabled = true;
            ctrFindDLicenseInfo1.gbFilterLicense.Enabled = false;
            ctrIssueBtn1.Enabled = true;

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

        private void LoadDetainLicenseData(clsDetainedLicense detainLicense)
        {
            detainLicense.LicenseID = _license.LicenseID;
            detainLicense.CreatedByUserID = clsGlobal.currentUser.UserID;
            detainLicense.DetainDate = DateTime.Now;
            if (decimal.TryParse(txtFineFees.Text, out decimal fineFees))
                detainLicense.FineFees = fineFees;
            else
                detainLicense.FineFees  = 0;
        }
        private void ctrIssueBtn1_Click(object sender, EventArgs e)
        {
            _license.IsActive = false;
            if (!_license.Save())
                return;
            
            clsDetainedLicense detainLicense = new clsDetainedLicense();
            LoadDetainLicenseData(detainLicense);
            if (detainLicense.Save())
            {
                MessageBox.Show("License has been detained successfully");
                UpdateDetainLicenseInfoFields(detainLicense);
                ctrIssueBtn1.Enabled = false;
            }
        }
    }
}
