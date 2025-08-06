using System;
using System.Windows.Forms;


namespace DVLD
{
    public partial class frmMain : Form
    {
        Form _frmLogin;
        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;
        }

        private void tsmiPeople_Click(object sender, EventArgs e)
        {
            using (var frm = new frmManagePeople())
            {
                frm.ShowDialog();
            }
        }

        private void tsmiSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
            _frmLogin.Show();
        }

        private void frmManageIDLApplications_Click(object sender, EventArgs e)
        {
            using (var frm = new frmManageILDApplications())
            {
                frm.ShowDialog();
            }
        }

        private void tsmiReleaseDetainedLicense2_Click(object sender, EventArgs e)
        {
            using (var frm = new frmReleaseDetainedLicense())
            {
                frm.ShowDialog();
            }
        }

        private void tsmiDetainLicense_Click_1(object sender, EventArgs e)
        {
            using (var frm = new frmDetainLicense())
            {
                frm.ShowDialog();
            }
        }

        private void tsmiManageDetainedLicense_Click(object sender, EventArgs e)
        {
            using (var frm = new frmManageDetainedLicense())
            {
                frm.ShowDialog();
            }
        }

        private void tsmiManageTestTypes_Click(object sender, EventArgs e)
        {
            using (var frm = new frmManageTestTypes())
            {
                frm.ShowDialog();
            }
        }

        private void tsmiManageApplicationTypes_Click(object sender, EventArgs e)
        {
            using (var frm = new frmManageApplicationTypes())
            {
                frm.ShowDialog();
            }
        }

        private void tsmiManageLDLApplications_Click(object sender, EventArgs e)
        {
            using (var frm = new frmManageLDLApplications())
            {
                frm.ShowDialog();
            }
        }

        private void tsmiReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            using (var frm = new frmReleaseDetainedLicense())
            {
                frm.ShowDialog();
            }
        }

        private void tsmiReplaceLostDamagedLicense_Click(object sender, EventArgs e)
        {
            using (var frm = new frmReplacementApplication())
            {
                frm.ShowDialog();
            }
        }

        private void tsmiRenewDrivingLicense_Click(object sender, EventArgs e)
        {
            using (var frm = new frmRenewLicenseApplication())
            {
                frm.ShowDialog();
            }
        }

        private void tsmiIssueInternationalLicense_Click(object sender, EventArgs e)
        {
            using (var frm = new frmInternationalLicenseApplication())
            {
                frm.ShowDialog();
            }
        }

        private void tsmiNewLDL_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAddEditLDLApplication())
            {
                frm.ShowDialog();
            }
        }

        private void tsmiDrivers_Click(object sender, EventArgs e)
        {
            using (var frm = new frmManageDrivers())
            {
                frm.ShowDialog();
            }
        }

        private void tsmiCurrUserInfo_Click(object sender, EventArgs e)
        {
            using (var frm = new frmUserDetails(clsGlobal.currentUser.UserID))
            {
                frm.ShowDialog();
            }
        }

        private void tsmiChangeCurrUserPassword_Click(object sender, EventArgs e)
        {
            using (var frm = new frmChangeUserPassword(clsGlobal.currentUser))
            {
                frm.ShowDialog();
            }
        }

        private void tsmiUsers_Click(object sender, EventArgs e)
        {
            using (var frm = new frmManageUsers())
            {
                frm.ShowDialog();
            }
        }
    }
}
