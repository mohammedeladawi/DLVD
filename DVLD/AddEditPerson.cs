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
using System.Xml.Linq;
using System.Net.Mail;

namespace DVLD
{
    public partial class frmAddEditPerson : Form
    {
        // Reusable controls
        private ErrorProvider _addEditPersonErrProvider = new ErrorProvider();
        
        private enum enMode { AddNew, Update };
        private enMode Mode;
        private clsPerson Person;

        // Send data back to frmPersonDetails
        public delegate void DataBackEventHandler(object sender, clsPerson person);
        public event DataBackEventHandler DataBack;

        // Add New
        public frmAddEditPerson()
        {
            InitializeComponent();

            Person = new clsPerson();
            Mode = enMode.AddNew;
        }

        // Update
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            Person = clsPerson.FindByID(PersonID);
            Mode = enMode.Update;
        }

        private void _InitializeCmbCountries()
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
            {
                pbProfileImage.Load(Person.ImagePath);
                llblRemoveImage.Visible = true;
            }
            else
            {
                llblRemoveImage.Visible = false;
            }


            dtpDateOfBirth.Value = Person.DateOfBirth;
        }

        private void _LoadFrmAddUpdateData()
        {
            if (Mode == enMode.AddNew)
            {
                lblHeading.Text = "Add Person";
                lblPersonId.Text = "???";
                llblRemoveImage.Visible = false;
                rbMale.Checked = true;

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
            if ((Person.ImagePath != "" && File.Exists(Person.ImagePath)))
                return;

            string imageUrl;
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
                _LoadFrmAddUpdateData();
                DataBack?.Invoke(this, Person);
            }
            else
            {
                MessageBox.Show("Can't add/update the person");
            };
        }

        private string _CopyImageAndGetPath(OpenFileDialog ImageFileDialog)
        {
            string ImagePath = ImageFileDialog.FileName;

            string destinationFolder = Path.Combine(Application.StartupPath, "Images");
            Directory.CreateDirectory(destinationFolder);

            string extension = Path.GetExtension(ImagePath);
            string newFileName = Guid.NewGuid().ToString("N") + extension;
            string destinationPath = Path.Combine(destinationFolder, newFileName);

            File.Copy(ImagePath, destinationPath);
            return destinationPath;
        }
       
        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ImageFileDialog = new OpenFileDialog();

            ImageFileDialog.Title = "Set Image";
            ImageFileDialog.Filter = "JPG Images(*.jpg)|*.jpg|PNG Images(*.png)|*.png";
            ImageFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (ImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                string destinationPath = _CopyImageAndGetPath(ImageFileDialog);
                Person.ImagePath = destinationPath;
                pbProfileImage.Image = Image.FromFile(destinationPath);
                llblRemoveImage.Visible = true;
            }
        }

        private void llblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbProfileImage.Image = null;
            Person.ImagePath = "";
            llblRemoveImage.Visible = false;
        }

        private void CancelEventAndShowErr(TextBox txtBox, CancelEventArgs e, string message)
        {           
            e.Cancel = true;
            txtBox.Focus();
            _addEditPersonErrProvider.SetError(txtBox, message);
        }

        private void RunEventAndHideErr(TextBox txtBox, CancelEventArgs e)
        {
            e.Cancel = false;
            _addEditPersonErrProvider.SetError(txtBox, string.Empty);
        }

        private void txtName_ValidationSchema(object sender, CancelEventArgs e)
        {
            TextBox txtName = sender as TextBox;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                CancelEventAndShowErr(txtName, e, "Name Can't be Empty");
            }
            else
            {
                RunEventAndHideErr(txtName, e);
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtNationalNo = sender as TextBox;
            if (Mode == enMode.AddNew == clsPerson.IsExistByNationalNo(txtNationalNo.Text))
            {
                CancelEventAndShowErr(txtNationalNo, e, "National No. is already exist");
            } 
            else if (string.IsNullOrEmpty(txtNationalNo.Text)) 
            {
                CancelEventAndShowErr(txtNationalNo, e, "Can't be empty");
            }
            else
            {
                RunEventAndHideErr(txtNationalNo, e);
            }
        }

        private void _InitializeTheDtpDateOfBirth()
        {
            dtpDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);
        }
        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _InitializeCmbCountries();
            _InitializeTheDtpDateOfBirth();
            _LoadFrmAddUpdateData();

        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            string Phone = txtPhone.Text;
           
            if (!Phone.All(char.IsDigit))
            {
                CancelEventAndShowErr((sender as TextBox), e, "Please enter a valid phone number");
            }
            else
            {
                RunEventAndHideErr((sender as TextBox), e);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEmail.Text;

            try
            {
                RunEventAndHideErr(sender as TextBox, e);
                var addr = new MailAddress(email);
            }
            catch
            {
                CancelEventAndShowErr((sender as TextBox), e, "Please enter a valid email address.");
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                CancelEventAndShowErr(txtAddress, e, "Address Can't be Empty");
            }
            else
            {
                RunEventAndHideErr(txtAddress, e);
            }
        }
    }
}
