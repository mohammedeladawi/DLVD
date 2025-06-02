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
        private Form _showPersonInfo;
        public ctrLDLApplicationInfo()
        {
            InitializeComponent();
        }

        private void SetApplicationBasicInfo()
        {
            clsApplication App = _ldlApplication.Application;
            Dictionary<byte, string> StatusDict = new Dictionary<byte, string>
            {
                {1, "New" },
                {2, "Cancelled" },
                {3, "Completed" }
            };

            lblApplicationID.Text = App.ApplicationID.ToString();
            lblStatus.Text = StatusDict[App.ApplicationStatus];
            lblFees.Text = "$" + App.PaidFees;
            lblType.Text = App.ApplicationType.Title.ToString();
            lblApplicant.Text = App.Person.FirstName + " " + App.Person.LastName;
            lblDate.Text = App.ApplicationDate.ToShortDateString();
            lblLastStatusDate.Text = App.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = clsUser.FindByID(App.CreatedByUserID).UserName;
            _showPersonInfo = new frmPersonDetails(_ldlApplication.Application.ApplicationPersonID);

        }
        private void SetDLApplicationInfo()
        {
            byte passedTests = clsTest.PassedTestsCount(_ldlApplication.LocalDrivingLicenseApplicationID);
            lblDLAppID.Text = _ldlApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _ldlApplication.LicenseClass.ClassName;
            lblPassedTests.Text = $"{passedTests} / 3";

            // ------ TODO if there a license -----//
            llblShowLicenseInfo.Enabled = false;
      } 
        public void setApplicationInfo(int ldlApplicationID)
        {
            _ldlApplication = clsLDLApplication.FindByID(ldlApplicationID);
            SetDLApplicationInfo();
            SetApplicationBasicInfo();
        }

        private void llblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _showPersonInfo.ShowDialog();
        }
    }
}
