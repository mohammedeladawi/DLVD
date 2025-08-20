using DVLD.Properties;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLD
{
    public partial class ctrDriverLicenseInfo: UserControl
    {

        clsLicense _license;

        public bool HasLicenseFound
        {
            get { return _license != null; }
        }
       
        public ctrDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(int licenseID)
        {
            _license = clsLicense.FindByLicenseID(licenseID);
            if (_license == null)
            {
                ResetForm();
                MessageBox.Show($"Couldn't find license with ID = {licenseID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblClass.Text = _license.LicenseClassInfo.ClassName.ToString();
            lblName.Text = _license.DriverInfo.PersonInfo.FullName;
            lblLicenseID.Text = _license.LicenseID.ToString();
            lblNationalNo.Text = _license.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = _license.DriverInfo.PersonInfo.GenderText;
            lblIssueDate.Text = _license.IssuanceDate.ToString();
            lblIssueReason.Text = _license.IssueReasonText;
            lblNotes.Text = _license.Notes == string.Empty ? "No Notes" : _license.Notes;
            lblIsActive.Text = _license.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _license.DriverInfo.PersonInfo.DateOfBirth.ToString();
            lblDriverID.Text = _license.DriverID.ToString();
            lblExpirationDate.Text = _license.ExpirationDate.ToString();
            lblIsDetained.Text = _license.IsDetained ? "Yes" : "No";

            LoadPersonImage();
        }

        private void LoadPersonImage()
        {
            string imagePath = _license.DriverInfo.PersonInfo.ImagePath;
            if (_license.DriverInfo.PersonInfo.ImagePath != "" && File.Exists(imagePath))
            {
                pbPersonImage.Image = Image.FromFile(imagePath);
            }
            else
            {
                // not exist
                if (imagePath != "")
                {
                    MessageBox.Show("Couldn't find person image in this path: " + imagePath, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // not exist or empty
                pbPersonImage.Image = _license.DriverInfo.PersonInfo.Gender == 0 ? Resources.Male : Resources.Female;
            }

        }

        public void ResetForm()
        {
            lblClass.Text = "????";
            lblName.Text = "????";
            lblLicenseID.Text = "????";
            lblNationalNo.Text = "????";
            lblGendor.Text = "????";
            lblIssueDate.Text = "????";
            lblIssueReason.Text = "????";
            lblNotes.Text = "????";
            lblIsActive.Text = "????";
            lblDateOfBirth.Text = "????";
            lblDriverID.Text = "????";
            lblExpirationDate.Text = "????";
            lblIsDetained.Text = "????";
            pbPersonImage.Image = null;

        }

    }
}
