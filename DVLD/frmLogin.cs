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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void ClearLoginFields()
        {
            txtUserName.Clear();
            txtPassword.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            clsGlobalSettings.currentUser = clsUser.FindByUsernameAndPassword(username, password);

            if (clsGlobalSettings.currentUser == null)
            {
                MessageBox.Show("Invalid UserName or Password!");
                return;
            }

            if (!cbRememberMe.Checked)
            {
                ClearLoginFields();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            // TODO: Rememmber ME (Functionality)
            //------------------------------------------ DX

            clsUser currUser = clsGlobalSettings.currentUser;

            if (currUser == null)
                return;

            txtUserName.Text = currUser.UserName;
            txtPassword.Text = currUser.Password;
        }
    }
}
