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
            Dictionary<byte, string> StatusDict = new Dictionary<byte, string>
            {
                {1, "New" },
                {2, "Cancelled" },
                {3, "Completed" }
            };

            lblApplicationID.Text = _ldlApplication.ApplicationID.ToString();
            lblStatus.Text = StatusDict[_ldlApplication.ApplicationStatus];
            lblFees.Text = "$" + _ldlApplication.PaidFees;
            lblType.Text = _ldlApplication.ApplicationTypeInfo.Title.ToString();
            lblApplicant.Text = _ldlApplication.ApplicationPersonInfo.FirstName + " " + _ldlApplication.ApplicationPersonInfo.LastName;
            lblDate.Text = _ldlApplication.ApplicationDate.ToShortDateString();
            lblLastStatusDate.Text = _ldlApplication.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = _ldlApplication.CreatedByUserInfo.UserName;

        }
        
        private void LoadDLApplicationInfo()
        {
            lblDLAppID.Text = _ldlApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _ldlApplication.LicenseClassInfo.ClassName;
            lblPassedTests.Text = $"{_ldlApplication.GetPassedTestsCount()} / 3";

            // ------ TODO if there a license -----//
            llblShowLicenseInfo.Enabled = false;
            // if clsLicense.IsExistByApplicationID then enable 
            // else disable 
            //llblShowLicenseInfo.Enabled = ;
      } 
        
        public void LoadApplication(int ldlApplicationID)
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
    }
}
