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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        Form _managePeople = new frmManagePeople(),
             _manageUsers = new frmManageUsers(),
             _userDetails = new frmUserDetails(clsGlobalSettings.currentUser),
             _changeUserPassword = new frmChangeUserPassword(clsGlobalSettings.currentUser),
             _manageApplicationTypes = new frmManageApplicationTypes(),
             _manageTestTypes = new frmManageTestTypes(),
             _manageLDLApplications = new frmManageLDLApplications(),
             _manageDrivers = new frmManageDrivers(),
             _addEditLDLApp = new frmAddEditLDLApplication(),
             _issueInternationalDL = new frmInternationalLicenseApplication(),
             _renewDrivingLicense = new frmRenewLicenseApplication(),
             _replaceLostDamagedLicense = new frmReplacementApplication(),
             _releaseDetainedLicense = new frmReleaseDetainedLicense(),
            _manageIDLApplications = new frmManageILDApplications(),
            _detainLicense = new frmDetainLicense(), 
            _manageDetainedLicenses = new frmManageDetainedLicense();
            

        private void tsmiPeople_Click(object sender, EventArgs e)
        {
            if (_managePeople.IsDisposed)
            {
                _managePeople = new frmManagePeople();
            }

            _managePeople.MdiParent = this;
            _managePeople.Show();
        }

        private void tsmiSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageIDLApplications_Click(object sender, EventArgs e)
        {
            if (_manageIDLApplications.IsDisposed)
            {
                _manageIDLApplications = new frmManageILDApplications();
            }

            _manageLDLApplications.MdiParent = this;
            _manageIDLApplications.Show();
        }

        private void tsmiReleaseDetainedLicense2_Click(object sender, EventArgs e)
        {
            if (_releaseDetainedLicense.IsDisposed)
            {
                _releaseDetainedLicense = new frmReleaseDetainedLicense();
            }

            _releaseDetainedLicense.MdiParent = this;
            _releaseDetainedLicense.Show();
        }

        private void tsmiDetainLicense_Click_1(object sender, EventArgs e)
        {
            if (_detainLicense.IsDisposed)
            {
                _detainLicense = new frmDetainLicense();
            }

            _detainLicense.MdiParent = this;
            _detainLicense.Show();
        }

        private void tsmiManageDetainedLicense_Click(object sender, EventArgs e)
        {
            if (_manageDetainedLicenses.IsDisposed)
            {
                _manageDetainedLicenses = new frmManageDetainedLicense();
            }

            _manageDetainedLicenses.MdiParent = this;
            _manageDetainedLicenses.Show();
        }

        private void tsmiManageTestTypes_Click(object sender, EventArgs e)
        {
            if (_manageTestTypes.IsDisposed)
            {
                _manageTestTypes = new frmManageTestTypes();
            }

            _manageTestTypes.MdiParent = this;
            _manageTestTypes.Show();
        }

        private void tsmiManageApplicationTypes_Click(object sender, EventArgs e)
        {
            if (_manageApplicationTypes.IsDisposed)
            {
                _manageApplicationTypes = new frmManageApplicationTypes();
            }

            _manageApplicationTypes.MdiParent = this;
            _manageApplicationTypes.Show();
        }


        private void tsmiManageLDLApplications_Click(object sender, EventArgs e)
        {
            if (_manageLDLApplications.IsDisposed)
            {
                _manageLDLApplications = new frmManageLDLApplications();
            }

            _manageLDLApplications.MdiParent = this;
            _manageLDLApplications.Show();
        }

        private void tsmiRetakeTest_Click(object sender, EventArgs e)
        {
            //---------------Todo----------------------
        }

        private void tsmiReleaseDetainedLicense_Click(object sender, EventArgs e)
        {

            if (_releaseDetainedLicense.IsDisposed)
            {
                _releaseDetainedLicense = new frmReleaseDetainedLicense();
            }

            _releaseDetainedLicense.MdiParent = this;
            _releaseDetainedLicense.Show();
        }

        private void tsmiReplaceLostDamagedLicense_Click(object sender, EventArgs e)
        {
            if (_replaceLostDamagedLicense.IsDisposed)
            {
                _replaceLostDamagedLicense = new frmReplacementApplication();
            }

            _replaceLostDamagedLicense.MdiParent = this;
            _replaceLostDamagedLicense.Show();
        }

        private void tsmiRenewDrivingLicense_Click(object sender, EventArgs e)
        {
            if (_renewDrivingLicense.IsDisposed)
            {
                _renewDrivingLicense = new frmRenewLicenseApplication();
            }

            _renewDrivingLicense.MdiParent = this;
            _renewDrivingLicense.Show();
        }

        private void tsmiIssueInternationalLicense_Click(object sender, EventArgs e)
        {
            if (_issueInternationalDL.IsDisposed)
            {
                _issueInternationalDL = new frmInternationalLicenseApplication();
            }

            _issueInternationalDL.MdiParent = this;
            _issueInternationalDL.Show();
        }

        private void tsmiNewLDL_Click(object sender, EventArgs e)
        {
            if (_addEditLDLApp.IsDisposed)
            {
                _addEditLDLApp = new frmAddEditLDLApplication();
            }

            _addEditLDLApp.MdiParent = this;
            _addEditLDLApp.Show();
        }


        private void tsmiDrivers_Click(object sender, EventArgs e)
        {
            if (_manageDrivers.IsDisposed)
            {
                _manageDrivers = new frmManageDrivers();
            }

            _manageDrivers.MdiParent = this;
            _manageDrivers.Show();
        }


        private void tsmiCurrUserInfo_Click(object sender, EventArgs e)
        {
            if (_userDetails.IsDisposed)
            {
                _userDetails = new frmUserDetails(clsGlobalSettings.currentUser);
            }

            _userDetails.MdiParent = this;
            _userDetails.Show();
        }

        private void tsmiChangeCurrUserPassword_Click(object sender, EventArgs e)
        {
            if (_changeUserPassword.IsDisposed)
            {
                _changeUserPassword = new frmChangeUserPassword(clsGlobalSettings.currentUser);
            }

            _changeUserPassword.MdiParent = this;
            _changeUserPassword.Show();
        }

        private void tsmiUsers_Click(object sender, EventArgs e)
        {
            if (_manageUsers.IsDisposed)
            {
                _manageUsers = new frmManageUsers();
            }

            _manageUsers.MdiParent = this;
            _manageUsers.Show();
        }
    }
}
