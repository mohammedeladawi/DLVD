﻿using System;
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
             _issueInternationalDL = new frmInternationalLicenseApplication();
            

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

        private void internationalLiceToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void localDrivingLicenseApplicationsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_manageLDLApplications.IsDisposed)
            {
                _manageLDLApplications = new frmManageLDLApplications();
            }

            _manageLDLApplications.MdiParent = this;
            _manageLDLApplications.Show();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_manageTestTypes.IsDisposed)
            {
                _manageTestTypes = new frmManageTestTypes();
            }

            _manageTestTypes.MdiParent = this;
            _manageTestTypes.Show();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_manageApplicationTypes.IsDisposed)
            {
                _manageApplicationTypes = new frmManageApplicationTypes();
            }

            _manageApplicationTypes.MdiParent = this;
            _manageApplicationTypes.Show();
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
