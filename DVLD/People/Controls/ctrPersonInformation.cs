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
using DVLD.Properties;

namespace DVLD
{
    public partial class ctrPersonInformation : UserControl
    {

        private clsPerson _person = null;

        public ctrPersonInformation()
        {
            InitializeComponent();
        }

        public void ResetPersonInfoUI()
        {
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblFullName.Text = "[????]";
            lblGendor.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbPersonImage.Image = Resources.Male;
        }

        private void FillPersonInfoUI()
        {
            llblEditPersonInfo.Enabled = true;
            lblPersonID.Text = Convert.ToString(_person.PersonID);
            lblFullName.Text = _person.FullName;
            lblNationalNo.Text = _person.NationalNo;
            lblGendor.Text = _person.Gender == 0 ? "Male" : "Female";
            lblEmail.Text = _person.Email;
            lblAddress.Text = _person.Address;
            lblDateOfBirth.Text = _person.DateOfBirth.ToString("F");
            lblPhone.Text = _person.Phone;
            lblCountry.Text = clsCountry.FindByID(_person.NationalityCountryID).CountryName;
            LoadImage();
        }

        private void LoadImage()
        {
            if (_person.ImagePath != "" && File.Exists(_person.ImagePath))
            {
                pbPersonImage.Image = Image.FromFile(_person.ImagePath);
            }
            else
            {
                // not exist
                if (_person.ImagePath != "")
                {
                    MessageBox.Show("Couldn't find person image in this path: " + _person.ImagePath, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // not exist or empty
                pbPersonImage.Image = _person.Gender == 0 ? Resources.Male : Resources.Female;
            }



        }
        
        public void LoadPersonInfo(int personID)
        {
            _person = clsPerson.Find(personID);
            
            if (_person == null)
            {
                ResetPersonInfoUI();
                MessageBox.Show("There is no person with this ID");
                return;
            }

            FillPersonInfoUI();
        }
     
        public void LoadPersonInfo(clsPerson person)
        {
            _person = person;
            
            if (_person == null)
            {
                ResetPersonInfoUI();
                MessageBox.Show("There is no person with this ID");
                return;
            }

            FillPersonInfoUI();
        }

        private void llblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_person == null) return;

            frmAddEditPerson frmEditPerson = new frmAddEditPerson(_person.PersonID);
            frmEditPerson.DataBack += frmAddEditPerson_DataBackEvent;
            frmEditPerson.ShowDialog();
        }

        private void frmAddEditPerson_DataBackEvent(object sender, int personID)
        {
            LoadPersonInfo(personID);
        }
    }
}
