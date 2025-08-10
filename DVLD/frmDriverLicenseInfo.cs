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
    public partial class frmDriverLicenseInfo : Form
    {

        clsLicense _license;
        
        public frmDriverLicenseInfo(int ldlApplicationID)
        {
            var ldlApp = clsLDLApplication.FindByLDLApplicationID(ldlApplicationID);
            if (ldlApp == null)
                return;

            _license = clsLicense.FindByAppID(ldlApp.ApplicationID);

            InitializeComponent();
        }

        public frmDriverLicenseInfo(clsLicense license)
        {
            _license = license;
            InitializeComponent();
        }

        private void frmDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrDriverLicenseInfo1.LoadLicenseInfo(_license);
        }


    }
}
