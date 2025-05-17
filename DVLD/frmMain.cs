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
             _manageTestTypes = new frmManageTestTypes();

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
