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
        private int _userID;

        public frmUserDetails(int userID)
        {
            InitializeComponent();
            this._userID = userID;
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            ctrUserInformation11.LoadUserInfo(_userID);
        }

    }
}
