using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using System.IO;

namespace DVLD
{
    public partial class ctrPersonInformation : UserControl
    {

        private clsPerson _person = null;

        public ctrPersonInformation()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(clsPerson person)
        {
            _person = person;
            
            if (_person == null)
            {
                llblEditPersonInfo.Visible = false;
                MessageBox.Show("There is no person with this ID");
                return;
            }

            lblPersonID.Text = Convert.ToString(_person.PersonId);
            lblFullName.Text = _person.FirstName + " " + _person.LastName;
            lblNationalNo.Text = _person.NationalNo;
            lblGendor.Text = _person.Gendor == 0 ? "Male" : "Female";
            lblEmail.Text = _person.Email;
            lblAddress.Text = _person.Address;
            lblDateOfBirth.Text = _person.DateOfBirth.ToString("F");
            lblPhone.Text = _person.Phone;
            lblCountry.Text = clsCountry.FindByID(_person.NationalityCountryID).CountryName;


            if (_person.ImagePath != "" && File.Exists(_person.ImagePath))
            {
                pbPersonImage.Image = Image.FromFile(_person.ImagePath);
            }
            else
            {
                string imageUrl;

                switch (_person.Gendor)
                { 
                    case 0:
                        imageUrl = @"C:\Users\mazik\Desktop\19. Full Real Project\03. DVLD Project\DVLD\assets\images\man.png";
                        break;
                    
                    default:
                        imageUrl = @"C:\Users\mazik\Desktop\19. Full Real Project\03. DVLD Project\DVLD\assets\images\woman.png";
                        break;
                }
                
                if (File.Exists(imageUrl))
                    pbPersonImage.Image = Image.FromFile(imageUrl);
            }

        }

        private void llblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_person == null) return;

            frmAddEditPerson frmEditPerson = new frmAddEditPerson(_person.PersonId);
            frmEditPerson.DataBack += frmAddEditPerson_DataBackEvent;
            frmEditPerson.ShowDialog();
        }

        private void frmAddEditPerson_DataBackEvent(object sender, clsPerson person)
        {
            _person = person;
            LoadPersonInfo(_person);
        }
    }
}
