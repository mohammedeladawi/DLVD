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
        enMode _Mode;
        clsUser _user;

        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            _user = new clsUser();
        }
     
        public frmAddUpdateUser(int userID)
        {   
            InitializeComponent();
            _Mode = enMode.Update;
            _user = clsUser.Find(userID);
        }

        private void LoadUIFieldsIntoUser()
        {
            _user.UserName = txtUserName.Text;
            _user.Password = txtPassword.Text;
            _user.IsActive = cbIsActive.Checked;
        }
        
        private void LoadUserIntoTpLoginInfoFields()
        {
            txtUserName.Text = _user.UserName;
            txtPassword.Text = _user.Password;
            txtConfirmPassword.Text = _user.Password;
            lblUserId.Text = _user.UserID.ToString();
            cbIsActive.Checked = _user.IsActive;
        }
       
        private void HandleClickTpLoginInfo(TabControlCancelEventArgs e)
        {
            clsPerson person = ctrFindPerson1.person;

            if (person == null)
            {
                e.Cancel = true;
                MessageBox.Show("Please add a person first");
            }
            else if (clsUser.IsExistByPersonID(person.PersonID) && _Mode == enMode.AddNew)
            {
                e.Cancel=true;
                MessageBox.Show("This person is already a user");
            }
            else
            {
                _user.PersonID = ctrFindPerson1.person.PersonID;
                tctrlAddEditUser.SelectedTab = tpLoginInfo;
                
                // buttons
                ctrNextBtn1.Visible = false;
                ctrSaveBtn1.Enabled = true;

            }
        }

        private void ResetButtons()
        {
            ctrNextBtn1.Visible = true;
            ctrSaveBtn1.Enabled = false;
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                lblAddUpdateTitle.Text = "Add New User";
            }
            else if (_Mode == enMode.Update)
            {
                lblAddUpdateTitle.Text = "Update User";
                ctrFindPerson1.LoadPerson(_user.PersonID);
                LoadUserIntoTpLoginInfoFields();
            }

            ResetButtons();
        }

        private void ctrNextBtn1_Click(object sender, EventArgs e)
        {
            tctrlAddEditUser.SelectedTab = tpLoginInfo;
        }

        private void tctrlAddEditUser_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tctrlAddEditUser.SelectedTab == tpLoginInfo)
                HandleClickTpLoginInfo(e);
            else if (tctrlAddEditUser.SelectedTab == tpPersonInfo)
                ResetButtons();
        }

        private void ctrSaveBtn1_Click(object sender, EventArgs e)
        {
            LoadUIFieldsIntoUser();

            if (_user.Save())
            {
                MessageBox.Show($"User has been {(_Mode == enMode.AddNew ? "added" : "updated")} sucessfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Couldn't update user");
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
                (_Mode == enMode.AddNew && clsUser.IsExistByUserName(usernameText)) ||
                (_Mode == enMode.Update && clsUser.IsExistByUserName(usernameText) && _user.UserName != usernameText)
                ) 
            {
                clsErrProviderUtilities.CancelEventAndShowErr(txtUserName, e, "UserName is used by another user");
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

            if (txtPassword.Text != string.Empty && txtConfirmPassword.Text != txtPassword.Text)
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
