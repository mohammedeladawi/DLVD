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
using System.IO;


namespace DVLD
{
    public partial class ctrDriverLicenseInfo: UserControl
    {
        private readonly Dictionary<byte, string> IssueReasonsMap = new Dictionary<byte, string>
        {
            { 1, "First Time" },
            { 2, "Renew" },
            { 3, "Replacement For Damaged" },
            { 4, "Replacement For Lost" }
        };

        public ctrDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadLicenseInfo(clsLicense license)
        {
            clsPerson person = license.Driver.Person;
            string name = person.FirstName + " " + person.LastName;

            lblClass.Text = clsLicenseClass.Find(license.LicenseClassID).ClassName.ToString();
            lblName.Text = name;
            lblLicenseID.Text = license.LicenseID.ToString();
            lblNationalNo.Text = person.NationalNo;
            lblGendor.Text = person.Gendor == 0 ? "Male" : "Female";
            lblIssueDate.Text = license.IssuanceDate.ToString();
            lblIssueReason.Text = IssueReasonsMap[license.IssueReason];
            lblNotes.Text = license.Notes == string.Empty ? "No Notes" : license.Notes;
            lblIsActive.Text = license.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = person.DateOfBirth.ToString();
            lblDriverID.Text = license.DriverID.ToString();
            lblExpirationDate.Text = license.ExpirationDate.ToString();

            // ------------Todo: with detained classes----------------
            lblIsDetained.Text = "Will do it";

            LoadPersonImage(person);
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
