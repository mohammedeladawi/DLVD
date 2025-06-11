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
        public frmPersonLicenseHistory(int applicationID)
        {
            var license = clsLicense.FindByAppID(applicationID);
            if (license == null)
                return;

            _driver = license.Driver;
            InitializeComponent();
        }

        public frmPersonLicenseHistory(clsDriver driver)
        {
            _driver = driver;
            InitializeComponent();
        }


        private void frmPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_driver == null)
                return;

            ctrPersonInformation1.LoadPersonInfo(_driver.Person);

            DataTable dtLocal = clsLicense.GetLicenses(_driver.DriverID);
            ctrDVLocal.LoadDataInDgvManageData(dtLocal);

            DataTable dtInternational = clsInternationalLicense.GetILicensesByDriverID(_driver.DriverID);
            ctrDVInternational.LoadDataInDgvManageData(dtInternational);

        }
    }
}
