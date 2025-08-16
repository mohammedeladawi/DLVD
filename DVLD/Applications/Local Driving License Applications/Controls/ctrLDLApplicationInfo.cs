using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class ctrLDLApplicationInfo: UserControl
    {
        private clsLDLApplication _ldlApplication;
       
        public ctrLDLApplicationInfo()
        {
            InitializeComponent();
        }

        private void LoadApplicationBasicInfo()
        {

            lblApplicationID.Text = _ldlApplication.ApplicationID.ToString();
            lblStatus.Text = _ldlApplication.StatusText;
            lblFees.Text = "$" + _ldlApplication.PaidFees;
            lblType.Text = _ldlApplication.ApplicationTypeInfo.Title.ToString();
            lblApplicant.Text = _ldlApplication.ApplicationPersonInfo.FullName;
            lblDate.Text = _ldlApplication.ApplicationDate.ToShortDateString();
            lblLastStatusDate.Text = _ldlApplication.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = _ldlApplication.CreatedByUserInfo.UserName;

        }
        
        private void LoadDLApplicationInfo()
        {
            lblDLAppID.Text = _ldlApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _ldlApplication.LicenseClassInfo.ClassName;
            lblPassedTests.Text = $"{_ldlApplication.GetPassedTestsCount()} / 3";
            llblShowLicenseInfo.Enabled = (_ldlApplication.GetActiveLicenseID() != -1);
      } 
        
        public void LoadApplicationInfo(int ldlApplicationID)
        {
            _ldlApplication = clsLDLApplication.FindByLDLApplicationID(ldlApplicationID);
            LoadDLApplicationInfo();
            LoadApplicationBasicInfo();
        }

        private void llblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form showPersonInfo = new frmPersonDetails(_ldlApplication.ApplicationPersonID);
            showPersonInfo.ShowDialog();
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo frm1 = new frmDriverLicenseInfo(_ldlApplication.GetActiveLicenseID());
            frm1.ShowDialog();
        }
    }
}
