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
    public partial class ctrFindDLicenseInfo: UserControl
    {
        public ctrFindDLicenseInfo()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSearch.Text, out int result))
                return;

            clsLicense license = clsLicense.FindByLicenseID(result);
            if (license != null)
                ctrDriverLicenseInfo1.LoadLicenseInfo(license);

        }
    }
}
