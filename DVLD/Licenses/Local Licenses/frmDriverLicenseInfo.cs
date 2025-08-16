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
        int _licenseID;
        
        public frmDriverLicenseInfo(int licenseID)
        {
            InitializeComponent();

            _licenseID = licenseID;
        }

        public frmDriverLicenseInfo(clsLicense license)
        {
            InitializeComponent();
        }

        private void frmDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrDriverLicenseInfo1.LoadInfo(_licenseID);
        }

    }
}
