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
    public partial class frmChangeUserPassword : Form
    {
        int _userID;
        clsUser _user;
        public frmChangeUserPassword(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private bool IsCurrPasswordRight()
        {
            string currPasswordTxt = txtCurrentPassword.Text;
            return currPasswordTxt == _user.Password;
        }
        
        private void ResetDefaultValues()
        {
            txtCurrentPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();

            txtCurrentPassword.Focus();
        }
        
        private void ctrSaveBtn1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsCurrPasswordRight())
            {
                _user.Password = txtConfirmPassword.Text;
                if (_user.Save())
                {
                    MessageBox.Show("Password has been updated succesfully");
                }
                else
                {
                    MessageBox.Show("Couldn't update password");
                }
            }
            else
            {
                MessageBox.Show("Current password is not right!");
            }
 
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ResetDefaultValues();
            _user = clsUser.Find(_userID);

            if (_user == null)
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Could not Find User with id = " + _userID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;
            }

            ctrUserInformation11.LoadUserInfo(_user.UserID);
        }

        private void txtCurrAndNewPassword_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtPassword = (sender) as TextBox;
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
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                clsErrProviderUtilities.CancelEventAndShowErr(txtConfirmPassword, e, "Password confirmation is not matched with the new password!");
            }
            else
            {
                clsErrProviderUtilities.RunEventAndHideErr(txtConfirmPassword, e);
            }
        }
    }
}
