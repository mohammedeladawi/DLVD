using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class ctrUserInformation: UserControl
    {
        public ctrUserInformation()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int userID)
        {
            clsUser user = clsUser.Find(userID);
            if (user == null)
            {
                MessageBox.Show("No User with UserID = " + userID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrPersonInformation1.LoadPersonInfo(user.PersonID);
            lblUserID.Text = user.UserID.ToString();
            lblUserName.Text = user.UserName.ToString();
            lblIsActive.Text = user.IsActive ? "Yes" : "No";
        }
    }
}
