using DVLD.Global_Classes;
using DVLD_BusinessLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddEditPerson : Form
    {
        
        private enum enMode { AddNew, Update };
        private enum enGender { Male = 0, Female = 1 };

        private enMode Mode;
        private clsPerson _person;

        // Send data back to frmPersonDetails
        public delegate void DataBackEventHandler(object sender, int personID);
        public event DataBackEventHandler DataBack;

        // Add New
        public frmAddEditPerson()
        {
            InitializeComponent();

            _person = new clsPerson();
            Mode = enMode.AddNew;
        }

        // Update
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            _person = clsPerson.FindByID(PersonID);
            Mode = enMode.Update;
        }

        private void LoadAllCountriesInComboBox()
        {
            DataTable dt = clsCountry.GetAllCountires();
            cmbCountry.DataSource = dt;
            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.ValueMember = "CountryID";

            // select the person country automaticly
            if (_person.NationalityCountryID != -1)
                cmbCountry.SelectedValue = _person.NationalityCountryID;
            else
                cmbCountry.SelectedValue = 2; // default

        }
       
        private void LoadPersonIntoUIFields()
        {
            lblPersonId.Text = Convert.ToString(_person.PersonId);

            txtFirstName.Text = _person.FirstName;
            txtSecondName.Text = _person.SecondName;
            txtThirdName.Text = _person.ThirdName;
            txtLastName.Text = _person.LastName;
            txtNationalNo.Text = _person.NationalNo;

            txtEmail.Text = _person.Email;
            txtAddress.Text = _person.Address;
            txtPhone.Text = _person.Phone;

            clsCountry NationalityCountry = clsCountry.FindByID(_person.NationalityCountryID);
            cmbCountry.SelectedItem = NationalityCountry.CountryName;

            // gendor
            switch (_person.Gendor)
            {
                case ((int)enGender.Male):
                    rbMale.Checked = true;
                    break;
                case ((int)enGender.Female):
                    rbFemale.Checked = true;
                    break;
            }

            // load image
            if (_person.ImagePath != "" && File.Exists(_person.ImagePath))
            {
                pbProfileImage.Load(_person.ImagePath);
            }
               
            llblRemoveImage.Visible = (_person.ImagePath != "" && File.Exists(_person.ImagePath));

            // date of birth
            dtpDateOfBirth.Value = _person.DateOfBirth;
        }

        private void ChangeImage()
        {
            if (rbFemale.Checked)
                pbProfileImage.Image = Properties.Resources.Female;
            else
                pbProfileImage.Image = Properties.Resources.Male;

            llblRemoveImage.Visible = false;

        }

        private void LoadUIFieldsIntoPerson()
        {
            _person.FirstName = txtFirstName.Text;
            _person.SecondName = txtSecondName.Text;
            _person.ThirdName = txtThirdName.Text;
            _person.LastName = txtLastName.Text;
            _person.Email = txtEmail.Text;
            _person.Phone = txtPhone.Text;
            _person.NationalNo = txtNationalNo.Text;
            _person.Gendor = rbMale.Checked ? (byte)enGender.Male : (byte)enGender.Female;
            _person.DateOfBirth = dtpDateOfBirth.Value;
            _person.Address = txtAddress.Text;
            _person.NationalityCountryID = (int)cmbCountry.SelectedValue;   
            _person.ImagePath = pbProfileImage.ImageLocation == null ? "" : pbProfileImage.ImageLocation.ToString();
        }

        private void rbGendor_CheckedChanged(object sender, EventArgs e)
        {
            if ((_person.ImagePath != "" && File.Exists(_person.ImagePath)))
                return;

            ChangeImage();
        }

        private void HandlePersonImage()
        {
            if (_person.ImagePath != pbProfileImage.ImageLocation)
            {
                // remove
                if (_person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_person.ImagePath);
                    }
                    catch
                    {
                        // do some exception
                    }
                }
                
                // set new image
                if (pbProfileImage.ImageLocation != null)
                {
                    string sourcePath = pbProfileImage.ImageLocation.ToString();
                    if (clsUtil.CopyImageAndGetPath(ref sourcePath))
                    {
                        pbProfileImage.ImageLocation = sourcePath; // destinationPath
                    }
                    else
                    {
                        pbProfileImage.ImageLocation = null;
                        return;
                    }

                }
            }
        }

        private void ctrSaveBtn1_MouseClick(object sender, MouseEventArgs e)
        {
            HandlePersonImage();
            LoadUIFieldsIntoPerson();
            
            if (_person.Save())
            {
                MessageBox.Show($"Person has been {(Mode == enMode.AddNew ? "added" : "updated")} succeessfully");
                Mode = enMode.Update;
                DataBack?.Invoke(this, _person.PersonId);
                this.Close();
            }
            else
            {
                MessageBox.Show($"Couldn't {(Mode == enMode.AddNew ? "add" : "update")} the person");
            };
        }
       
        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ImageFileDialog = new OpenFileDialog();

            ImageFileDialog.Title = "Set Image";
            ImageFileDialog.Filter = "JPG Images(*.jpg)|*.jpg|PNG Images(*.png)|*.png";
            ImageFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (ImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = ImageFileDialog.FileName;
                pbProfileImage.ImageLocation = sourcePath;
                llblRemoveImage.Visible = true;
            }
        }

        private void llblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeImage();
            pbProfileImage.ImageLocation = null;
            llblRemoveImage.Visible = false;
        }

        private void SetMaxMinDtpBirth()
        {
            dtpDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);
            dtpDateOfBirth.MinDate = DateTime.Today.AddYears(-100);
        }
        
        private void ClearAllTextBoxes()
        {
            txtFirstName.Clear();
            txtSecondName.Clear();
            txtThirdName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtNationalNo.Clear();

        }
        
        private void ResetfrmAddUpdateUI()
        {
            ClearAllTextBoxes();
            LoadAllCountriesInComboBox();
            SetMaxMinDtpBirth();
            rbMale.Checked = true; // default

        }
   
        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            // Reset
            ResetfrmAddUpdateUI();

            // if update load
            if (Mode == enMode.AddNew)
            {
                lblHeading.Text = "Add Person";
                lblPersonId.Text = "???";
            }
            else
            {
                // update 
                lblHeading.Text = "Update Person";
                LoadPersonIntoUIFields();
            }
        }

        // ------------------- Validation --------------------
        private void txtName_ValidationSchema(object sender, CancelEventArgs e)
        {
            TextBox txtName = sender as TextBox;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                clsErrProviderUtilities.CancelEventAndShowErr(txtName, e, "Name Can't be Empty");
            }
            else
            {
                clsErrProviderUtilities.RunEventAndHideErr(txtName, e);
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtNationalNo = sender as TextBox;
            if (Mode == enMode.AddNew && clsPerson.IsExistByNationalNo(txtNationalNo.Text))
            {
                clsErrProviderUtilities.CancelEventAndShowErr(txtNationalNo, e, "National No. is already exist");
            }
            else if (string.IsNullOrEmpty(txtNationalNo.Text))
            {
                clsErrProviderUtilities.CancelEventAndShowErr(txtNationalNo, e, "Can't be empty");
            }
            else
            {
                clsErrProviderUtilities.RunEventAndHideErr(txtNationalNo, e);
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            string Phone = txtPhone.Text;
           
            if (!Phone.All(char.IsDigit))
            {
                clsErrProviderUtilities.CancelEventAndShowErr((sender as TextBox), e, "Please enter a valid phone number");
            }
            else
            {
                clsErrProviderUtilities.RunEventAndHideErr((sender as TextBox), e);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEmail.Text;

            try
            {
                clsErrProviderUtilities.RunEventAndHideErr(sender as TextBox, e);
                var addr = new MailAddress(email);
            }
            catch
            {
                clsErrProviderUtilities.CancelEventAndShowErr((sender as TextBox), e, "Please enter a valid email address.");
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                clsErrProviderUtilities.CancelEventAndShowErr(txtAddress, e, "Address Can't be Empty");
            }
            else
            {
                clsErrProviderUtilities.RunEventAndHideErr(txtAddress, e);
            }
        }
       // -------------------------------------------------------
    }
}
