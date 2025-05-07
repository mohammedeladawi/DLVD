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
    public partial class frmAddEditPerson : Form
    {
        private enum enMode { AddNew, Update };
        private enMode Mode;
        private clsPerson Person;

        // Add New
        public frmAddEditPerson()
        {
            InitializeComponent();

            Person = new clsPerson();
            Mode = enMode.AddNew;

            _LoadFormData();
        }

        // Update
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            Person = clsPerson.FindByID(PersonID);
            Mode = enMode.Update;
            _LoadFormData();
        }

        private void _SetCmbCountries()
        {
            DataTable dt = clsCountry.GetAllCountires();
            cmbCountry.DataSource = dt;
            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.ValueMember = "CountryID";

            if (Person.NationalityCountryID != -1)
                cmbCountry.SelectedValue = Person.NationalityCountryID;
            else
                cmbCountry.SelectedValue = 2;

        }
       
        public void _LoadFormDataForUpdate()
        {
            lblPersonId.Text = Convert.ToString(Person.PersonId);

            txtFirstName.Text = Person.FirstName;
            txtSecondName.Text = Person.SecondName;
            txtThirdName.Text = Person.ThirdName;
            txtLastName.Text = Person.LastName;
            txtNationalNo.Text = Person.NationalNo;

            txtEmail.Text = Person.Email;
            txtAddress.Text = Person.Address;
            txtPhone.Text = Person.Phone;

            clsCountry NationalityCountry = clsCountry.FindByID(Person.NationalityCountryID);
            cmbCountry.SelectedItem = NationalityCountry.CountryName;

            switch (Person.Gendor)
            {
                case 0:
                    rbMale.Checked = true;
                    break;
                case 1:
                    rbFemale.Checked = true;
                    break;
            }

            if (Person.ImagePath != "" && File.Exists(Person.ImagePath))
                pbProfileImage.Load(Person.ImagePath);

            dtpDateOfBirth.Value = Person.DateOfBirth;
        }

        private void _LoadFormData()
        {
            _SetCmbCountries();
            if (Mode == enMode.AddNew)
            {
                lblHeading.Text = "Add Person";
                lblPersonId.Text = "???";

                // DX
                txtFirstName.Text = "Mohammed";
                txtSecondName.Text = "Ibraheem";
                txtThirdName.Text = "Eladawi";
                txtLastName.Text = "Ahmed";
                txtNationalNo.Text = "1212sa312A";

                txtEmail.Text = "myEmail@yahoo.com";
                txtAddress.Text = "Abu Dhabi, Mushrif";
                txtPhone.Text = "00009943290";
            }
            else if (Mode == enMode.Update) 
            {
                lblHeading.Text = "Update Person";
                _LoadFormDataForUpdate();   
            }
        }

        private void _ChangeImage()
        {
            string imageUrl;

            // Todo Later;
            if (rbFemale.Checked)
                imageUrl = @"C:\Users\mazik\Desktop\19. Full Real Project\03. DVLD Project\DVLD\assets\images\woman.png";
            else
                imageUrl = @"C:\Users\mazik\Desktop\19. Full Real Project\03. DVLD Project\DVLD\assets\images\man.png";

            pbProfileImage.Image = Image.FromFile(imageUrl);
        }

        private void _SetPersonFields()
        {
            Person.FirstName = txtFirstName.Text;
            Person.SecondName = txtSecondName.Text;
            Person.ThirdName = txtThirdName.Text;
            Person.LastName = txtLastName.Text;
            Person.Email = txtEmail.Text;
            Person.Phone = txtPhone.Text;
            Person.NationalNo = txtNationalNo.Text;
            Person.Gendor = (byte)((rbMale.Checked) ? 0 : 1);
            Person.DateOfBirth = dtpDateOfBirth.Value;
            Person.Address = txtAddress.Text;
            Person.NationalityCountryID = (int)cmbCountry.SelectedValue;
            
            //Person.ImagePath = pbProfileImage.ImageLocation;
        }

        private void rbGendor_CheckedChanged(object sender, EventArgs e)
        {
            _ChangeImage();
        }

        private void ctrSaveBtn1_MouseClick(object sender, MouseEventArgs e)
        {
            _SetPersonFields();
            if (Person.Save())
            {
                MessageBox.Show("Person has been added/updated succeessfully");
                Mode = enMode.Update;
                _LoadFormData();   
            }
            else
            {
                MessageBox.Show("Can't add/update the person");
            };
        }

        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
