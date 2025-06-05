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
    public partial class frmPersonLicenseHistory: Form
    {
        private clsDriver _driver;
        public frmPersonLicenseHistory(int ldlApplicationID)
        {
            var ldlApp = clsLDLApplication.FindByID(ldlApplicationID);
            if (ldlApp == null)
                return;

            var license = clsLicense.FindByAppID(ldlApp.ApplicationID);
            if (license == null)
                return;

            _driver = license.Driver;
            InitializeComponent();
        }

        private void frmPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_driver == null)
                return;

            ctrPersonInformation1.LoadPersonInfo(_driver.Person);

            DataTable dt = clsLicense.GetLicenses(_driver.DriverID, (int)enApplicationTypes.LocalDrivingLicenseApplication);
            ctrDVLocal.LoadDataInDgvManageData(dt);
            
        }
    }
}
