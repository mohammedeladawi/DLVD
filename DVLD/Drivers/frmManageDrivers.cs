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
        private int GetSelectedPersonID()
        {
            DataGridView dgvDriver = ctrManageDataView1.dgvManageDate1;
            int personID = -1;

            if (dgvDriver.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvDriver.SelectedRows[0];
                personID = Convert.ToInt32(row.Cells[1].Value);
            }

            return personID;
        }

        private bool TryGetSelectedPersonID(out int personID)
        {
            personID = GetSelectedPersonID();
            if (personID == -1)
            {
                MessageBox.Show("There is no selected row");
                return false;
            }

            return true;
        }
        private void fmManageDrivers_Load(object sender, EventArgs e)
        {
            ctrManageDataView1.LoadTitle("Manage Drivers");
            DataTable dt = clsDriver.GetAllDrivers();
            ctrManageDataView1.LoadData(dt);
            ctrManageDataView1.LoadContextMenuStrip(cmsDrivers);
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedPersonID(out int personID))
            {
                Form frm = new frmPersonDetails(personID);
                frm.ShowDialog();
            }
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedPersonID(out int personID))
            {
                Form frm = new frmPersonLicenseHistory(personID);
                frm.ShowDialog();
            }
        }
    }
}
