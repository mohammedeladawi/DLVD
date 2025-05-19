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
    public partial class frmManageLDLApplications : Form
    {
        public frmManageLDLApplications()
        {
            InitializeComponent();
        }

        private void frmManageLDLApplications_Load(object sender, EventArgs e)
        {
            ctrManageData1.LoadTitle("Local Driving License Applications");
            ctrManageData1.LoadData(clsLDLApplication.GetAllApplications());
        }
    }
}
