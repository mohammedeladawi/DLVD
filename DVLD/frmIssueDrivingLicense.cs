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
            _ldlApplication = clsLDLApplication.FindByID(ldlApplicationID);
            InitializeComponent();
        }
        private bool InsertDriverData(clsDriver driver)
        {
            driver.PersonID = _ldlApplication.Application.Person.PersonID;
            driver.CreatedByUserID = clsGlobal.currentUser.UserID;
            driver.CreatedDate = DateTime.Now;

            return driver.Save();
        }
        private bool InsertLicenseDate(clsLicense license, int driverID)
        {
            license.ApplicationID = _ldlApplication.ApplicationID;
            license.DriverID = driverID;
            license.LicenseClassID = _ldlApplication.LicenseClassID;
            license.IssuanceDate = DateTime.Now;
            byte validityLength = clsLicenseClass.Find(_ldlApplication.LicenseClassID).DefaultValidityLength;
            license.ExpirationDate = license.IssuanceDate.AddYears(validityLength);
            license.Notes = txtNotes.Text;
            license.PaidFees = _ldlApplication.LicenseClass.ClassFees;
            license.IsActive = true;
            license.IssueReason = 1;
            license.CreatedByUserID = clsGlobal.currentUser.UserID;

            return license.Save();
        }
        private void ctrIssueBtn1_Click(object sender, EventArgs e)
        {
            clsDriver driver = new clsDriver();
            if (!InsertDriverData(driver))
                return;

            // insert License
            clsLicense license = new clsLicense();
            if (!InsertLicenseDate(license, driver.DriverID))
                return;
            
            // complete application
            clsApplication.Complete(_ldlApplication.ApplicationID);

            MessageBox.Show("License has been issued successfully");
        }
        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrLDLApplicationInfo1.setApplicationInfo(_ldlApplication.LocalDrivingLicenseApplicationID);
        }
    }
}
