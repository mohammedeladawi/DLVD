using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmLDLApplicationDetails : Form
    {
        int _ldlApplicationID = -1;
        public frmLDLApplicationDetails(int ldlApplicationID)
        {
            _ldlApplicationID = ldlApplicationID;
            InitializeComponent();
        }

        private void frmLDLApplicationDetails_Load(object sender, EventArgs e)
        {
            ctrLDLApplicationInfo1.LoadApplicationInfo(_ldlApplicationID);
        }
    }
}
