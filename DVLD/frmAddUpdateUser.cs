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

namespace DVLD
{
    public partial class frmAddUpdateUser : Form
    {
        enum enMode { AddNew, Update}
        enMode Mode;
        clsUser _user;

        public frmAddUpdateUser()
        {
            Mode = enMode.AddNew;
            _user = new clsUser();

            InitializeComponent();
        }
     
        public frmAddUpdateUser(int userID)
        {
            Mode = enMode.Update;
            _user = clsUser.FindByID(userID);
            
            InitializeComponent();
        }

        private void AddFieldsDataToUser()
        {
            _user.UserName = txtUserName.Text;
            _user.Password = txtPassword.Text;
            _user.isActive = cbIsActive.Checked;
        }
        
        private void AddUserDataToTpLoginInfo()
        {
            txtUserName.Text = _user.UserName;
            txtPassword.Text = _user.Password;
            txtConfirmPassword.Text = _user.Password;
            lblUserId.Text = _user.UserID.ToString();
            cbIsActive.Checked = _user.isActive;
        }
       
        private void HandleClickTpLoginInfo(TabControlCancelEventArgs e)
        {
            clsPerson person = ctrFindPerson1.person;


            if (person == null)
            {
                e.Cancel = true;
                MessageBox.Show("Please add/find person first");
            }
            else if (clsUser.IsExistByPersonID(person.PersonId) && Mode == enMode.AddNew)
            {
                e.Cancel=true;
                MessageBox.Show("This person is already a user");
            }
            else
            {
                _user.PerosnID = ctrFindPerson1.person.PersonId;
                tcAddEditUser.SelectedTab = tpLoginInfo;
                ctrNextBtn1.Visible = false;
                ctrSaveBtn1.Enabled = true;

            }
        }

        private void DefaultTapInitialization()
        {
            ctrNextBtn1.Visible = true;
            ctrSaveBtn1.Enabled = false;
        }

        private void SetFrmAddUpdateFields()
        {
            if (Mode == enMode.AddNew)
            {
                lblAddUpdateTitle.Text = "Add New User";
            }
            else if (Mode == enMode.Update)
            {
                lblAddUpdateTitle.Text = "Update User";
                ctrFindPerson1.person = _user.Person;
                AddUserDataToTpLoginInfo();
            }
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            SetFrmAddUpdateFields();
            DefaultTapInitialization();
        }

        private void ctrNextBtn1_Click(object sender, EventArgs e)
        {
            tcAddEditUser.SelectedTab = tpLoginInfo;
        }

        private void tcAddEditUser_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tcAddEditUser.SelectedTab == tpLoginInfo)
                HandleClickTpLoginInfo(e);
            else if (tcAddEditUser.SelectedTab == tpPersonInfo)
                DefaultTapInitialization();
        }

        private void ctrSaveBtn1_Click(object sender, EventArgs e)
        {
            AddFieldsDataToUser();

            if (_user.Save())
            {
                Mode = enMode.Update;
                SetFrmAddUpdateFields();
                MessageBox.Show("User Has Been Added/Updated Succesfully");
            }
            else
            {
                MessageBox.Show("Can't Update User");
            }
                
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            string usernameText = txtUserName.Text;

            if (txtUserName.Text == string.Empty)
            {
                clsErrProviderUtilities.CancelEventAndShowErr(txtUserName, e, "UserName can't be empty");
            }
            else if (
                (Mode == enMode.AddNew && clsUser.IsExistByUserName(usernameText)) ||
                (Mode == enMode.Update && clsUser.IsExistByUserName(usernameText) && _user.UserName != usernameText)
                ) 
            {
                clsErrProviderUtilities.CancelEventAndShowErr(txtUserName, e, "UserName is already exist");
            }
            else
            {
                clsErrProviderUtilities.RunEventAndHideErr(txtUserName, e);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text == string.Empty)
            {
                clsErrProviderUtilities.CancelEventAndShowErr(txtPassword, e, "Password can't be empty");
            }
            else
            {
                clsErrProviderUtilities.RunEventAndHideErr(txtPassword, e);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text == string.Empty)
            {
                clsErrProviderUtilities.CancelEventAndShowErr(txtConfirmPassword, e, "Password can't be empty");
            }
            else if (txtConfirmPassword.Text != txtPassword.Text)
            {
                clsErrProviderUtilities.CancelEventAndShowErr(txtConfirmPassword, e, "Password confirmation doesn't match password!");
            }
            else
            {
                clsErrProviderUtilities.RunEventAndHideErr(txtConfirmPassword, e);
            }
        }
    }
}
