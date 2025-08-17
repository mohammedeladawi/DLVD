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
using System.IO;
using DVLD.Properties;

namespace DVLD
{
    public partial class frmInternationalLicenseInfo : Form
    {
        clsInternationalLicense _internationalLicense;

        public frmInternationalLicenseInfo(int internationalLicenseID)
        {
            InitializeComponent();

            _internationalLicense = clsInternationalLicense.FindByID(internationalLicenseID);
        }

        private void LoadInternationalLicenseIntoUIFields()
        {
            lblName.Text = _internationalLicense.DriverInfo.PersonInfo.FullName;
            lblInterLicenseID.Text = _internationalLicense.InternationalLicenseID.ToString();
            lblLicenseID.Text = _internationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = _internationalLicense.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = _internationalLicense.DriverInfo.PersonInfo.GenderText;
            lblIssueDate.Text = _internationalLicense.IssueDate.ToString();
            lblExpirationDate.Text = _internationalLicense.ExpirationDate.ToString();
            lblIApplicationID.Text = _internationalLicense.ApplicationID.ToString();
            lblIsActive.Text = _internationalLicense.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _internationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToString();
            lblDriverID.Text = _internationalLicense.DriverInfo.DriverID.ToString();
            LoadPersonImage();
        }

        private void LoadPersonImage()
        {
            clsPerson person = _internationalLicense.DriverInfo.PersonInfo;

            if (person.ImagePath != "" && File.Exists(person.ImagePath))
            {
                pbPersonImage.Image = Image.FromFile(person.ImagePath);
            }
            else
            {
                // not exist
                if (person.ImagePath != "")
                {
                    MessageBox.Show("Couldn't find person image in this path: " + person.ImagePath, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // not exist or empty
                pbPersonImage.Image = person.Gender == 0 ? Resources.Male : Resources.Female;
            }

        }
        
        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            if (_internationalLicense == null)
            {
                MessageBox.Show("Couldn't find international license with this ID", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            LoadInternationalLicenseIntoUIFields();
        }


    }
}
