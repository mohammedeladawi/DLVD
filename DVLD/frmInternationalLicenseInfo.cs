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

namespace DVLD
{
    public partial class frmInternationalLicenseInfo : Form
    {
        clsInternationalLicense _internationalLicense;
        clsDriver _driver;
        public frmInternationalLicenseInfo(int localLicenseID)
        {
            _internationalLicense = clsInternationalLicense.FindByLocalLicenseID(localLicenseID);
            if (_internationalLicense == null)
                return;

            _driver = clsDriver.Find(_internationalLicense.DriverID);
            InitializeComponent();
        }

        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            if (_internationalLicense == null || _driver == null) return;
            lblName.Text = _driver.Person.FirstName + " " + _driver.Person.LastName;
            lblInterLicenseID.Text = _internationalLicense.InternationalLicenseID.ToString();
            lblLicenseID.Text = _internationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = _driver.Person.NationalNo;
            lblGendor.Text = _driver.Person.Gendor == 0 ? "Male" : "Female";
            lblIssueDate.Text = _internationalLicense.IssueDate.ToString();
            lblExpirationDate.Text = _internationalLicense.ExpirationDate.ToString();
            lblIApplicationID.Text = _internationalLicense.ApplicationID.ToString();
            lblIsActive.Text = _internationalLicense.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _driver.Person.DateOfBirth.ToString();
            lblDriverID.Text = _driver.DriverID.ToString();
            LoadPersonImage(_driver.Person);
        }

        private void LoadPersonImage(clsPerson person)
        {
            string defaultImagePath;

            if (!string.IsNullOrWhiteSpace(person.ImagePath) && File.Exists(person.ImagePath))
            {
                pbPersonImage.Image = Image.FromFile(person.ImagePath);
            }
            else
            {
                defaultImagePath = person.Gendor == 0
                    ? @"C:\Users\mazik\Desktop\19. Full Real Project\03. DVLD Project\DVLD\assets\images\man.png"
                    : @"C:\Users\mazik\Desktop\19. Full Real Project\03. DVLD Project\DVLD\assets\images\woman.png";

                if (File.Exists(defaultImagePath))
                    pbPersonImage.Image = Image.FromFile(defaultImagePath);
                else
                    pbPersonImage.Image = null; // or set to a placeholder if you want
            }
        }
    }
}
