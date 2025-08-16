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
    public partial class frmIssueDrivingLicense : Form
    {
        private clsLDLApplication _ldlApplication;
        public frmIssueDrivingLicense(int ldlApplicationID)
        {
            InitializeComponent();
            _ldlApplication = clsLDLApplication.FindByLDLApplicationID(ldlApplicationID);
        }

        private void ctrIssueBtn1_Click(object sender, EventArgs e)
        {
            if (!_ldlApplication.HasPassedAllTests())
            {
                MessageBox.Show("Should pass all tests first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // check if already has active license
            if (clsLicense.GetActiveLicenseIDByPersonID(_ldlApplication.ApplicationPersonID, _ldlApplication.LicenseClassID) != -1)
            {
                MessageBox.Show("Person already has an active license for this class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_ldlApplication.IssueLicenseForTheFirstTime(txtNotes.Text.ToString(), clsGlobal.currentUser.UserID) != -1)
            {
                MessageBox.Show("License has been issued successfully", "Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Couldn't Issue License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {   
            if (_ldlApplication == null)
            {
                MessageBox.Show("No applicaiton with this ID", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Reset
            txtNotes.Clear();
            ctrLDLApplicationInfo1.LoadApplicationInfo(_ldlApplication.LocalDrivingLicenseApplicationID);
        }
    }
}
