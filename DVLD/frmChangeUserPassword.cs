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
        clsUser _user;
        public frmChangeUserPassword(int userID)
        {
            _user = clsUser.FindByID(userID);
            InitializeComponent();
        }
        private bool IsCurrPasswordRight()
        {
            string currPasswordTxt = txtCurrentPassword.Text;
            return currPasswordTxt == _user.Password;
        }
        
        private void ctrSaveBtn1_Click(object sender, EventArgs e)
        {
            if (_user == null)
                return;

            if (IsCurrPasswordRight())
            {
                _user.Password = txtConfirmPassword.Text;
                if (_user.Save())
                {
                    MessageBox.Show("Password Has Been Changed Succesfully");
                }
                else
                {
                    MessageBox.Show("Couldn't Update Password");
                }
            }
            else
            {
                MessageBox.Show("Current password is not right!");
            }
 
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            if (_user != null)
                ctrUserPersonInformation1.LoadUserInfo(_user);
        }

        private void txtCurrAndNewPassword_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtPassword = (sender) as TextBox;
            if (txtPassword.Text == string.Empty)
            {
                clsErrProviderUtilities.CancelEventAndShowErr(txtPassword, e, "Password can't empty");
            }
            else
            {
                clsErrProviderUtilities.RunEventAndHideErr(txtPassword, e);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtNewPassword.Text != string.Empty && txtConfirmPassword.Text == "")
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
