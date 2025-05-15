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
    public partial class frmUserDetails : Form
    {
        private clsUser _user;
        public frmUserDetails(int userID)
        {
            this._user = clsUser.FindByID(userID);
            InitializeComponent();
        }

        public frmUserDetails(clsUser user)
        {
            this._user = user;
            InitializeComponent();
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            if (_user == null)
                return;

            ctrUserPersonInformation1.LoadUserInfo(_user);
        }
    }
}
