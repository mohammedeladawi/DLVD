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
    public partial class ctrUserPersonInformation : UserControl
    {
        clsUser _user;
        public ctrUserPersonInformation()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(clsUser user)
        {
            _user = user;
            ctrPersonInformation1.LoadPersonInfo(_user.Person);
            ctrUserInformation1.LoadUserInfo(_user.UserID, _user.UserName,  _user.isActive);
        }
    }
}
