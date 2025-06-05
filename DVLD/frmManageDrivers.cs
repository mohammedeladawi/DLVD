using DVLD_BusinessLayer;
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
    public partial class frmManageDrivers: Form
    {
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void fmManageDrivers_Load(object sender, EventArgs e)
        {
            ctrManageDataView1.LoadTitle("Manage Drivers");
            DataTable dt = clsDriver.GetAllDrivers();
            ctrManageDataView1.LoadData(dt);
        }
    }
}
