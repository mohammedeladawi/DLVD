using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrManageTestApplicationInfo: UserControl
    {
        public DataGridView dgvManageDate1
        {
            get { return ctrDataView1.dgvManageDate1; }
        }

        private int _ldlApplicationID;

        public void SetApplicationInfo(int ldlApplicationID)
        {
            _ldlApplicationID = ldlApplicationID;
            ctrApplicationInfo1.setApplicationInfo(_ldlApplicationID);
        }

        public ctrManageTestApplicationInfo()
        {
            InitializeComponent();
        }

        public void SetTestTitle(string title)
        {
            lblTestTitle.Text = title;
        }

        public void SetTestAppointmentsView(DataTable dt)
        {
            ctrDataView1.LoadDataInDgvManageData(dt);
        }

        public void SetContextMenuStrip(ContextMenuStrip cms)
        {
            ctrDataView1.SetContextMenuStrip(cms);
        }

    }
}
