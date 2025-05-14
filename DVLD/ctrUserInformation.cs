using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrUserInformation : UserControl
    {
        public ctrUserInformation()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int userID, string userName, bool isActive) 
        {
            lblUserID.Text = userID.ToString();
            lblUserName.Text = userName.ToString();
            lblIsActive.Text = isActive ? "Yes" : "No";
        }
    }
}
