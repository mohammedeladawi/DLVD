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
            

            clsGlobal.currentUser = clsUser.FindByUsernameAndPassword(username, password);
            if (clsGlobal.currentUser == null)
            {
                MessageBox.Show("Invalid UserName or Password!");
                return;
            }

            if (cbRememberMe.Checked)
                clsGlobal.RememberUsernameAndPassword(username, password);
            else
                clsGlobal.RememberUsernameAndPassword("", "");

            this.Hide();
            Form frmMain1 = new frmMain(this);
            frmMain1.ShowDialog();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            ClearLoginFields();
            string username = "";
            string password = "";

            if (clsGlobal.GetStoredCredintials(ref username, ref password))
            {
                txtUserName.Text = username;
                txtPassword.Text = password;
                cbRememberMe.Checked = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
