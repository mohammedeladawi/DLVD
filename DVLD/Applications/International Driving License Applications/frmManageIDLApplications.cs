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
    public partial class frmManageIDLApplications : Form
    {
        public frmManageIDLApplications()
        {
            InitializeComponent();
        }

        private int GetSelectedILicenseID()
        {
            DataGridView dgvIDLApplication = ctrManageData1.dgvManageDate1;
            int IDLicenseID = -1;

            if (dgvIDLApplication.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvIDLApplication.SelectedRows[0];
                IDLicenseID = Convert.ToInt32(row.Cells["internationalLicenseID"].Value);
            }

            return IDLicenseID;
        }

        private int GetSelectedDriverID()
        {
            DataGridView dgvIDLApplication = ctrManageData1.dgvManageDate1;
            int driverID = -1;

            if (dgvIDLApplication.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvIDLApplication.SelectedRows[0];
                driverID = Convert.ToInt32(row.Cells["DriverID"].Value);
            }

            return driverID;
        }

        private bool TryGetSelectedDriverID(out int driverID)
        {
            driverID = GetSelectedDriverID();
            if (driverID == -1)
            {
                MessageBox.Show("There is no selected row");
                return false;
            }

            return true;
        }

        private void frmManageILDApplications_Load(object sender, EventArgs e)
        {
            ctrManageData1.LoadTitle("International Driving License Applications");
            ctrManageData1.LoadData(clsInternationalLicense.GetAllInternationalLicenses());
            ctrManageData1.LoadContextMenuStrip(cmsIDLApplications);
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedDriverID(out int driverID))
            {
                clsDriver driver = clsDriver.Find(driverID);
                if (driver != null)
                {
                    Form perosnDetailsDialog = new frmPersonDetails(driver.PersonID);
                    perosnDetailsDialog.ShowDialog();
                }
            }
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int internationalDrivingLicenseID = GetSelectedILicenseID();
            if (internationalDrivingLicenseID != -1)
            {
                Form frm1 = new frmInternationalLicenseInfo(internationalDrivingLicenseID);
                frm1.ShowDialog();
            }
            else
                MessageBox.Show("There is no selected row");

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedDriverID(out int driverID))
            {
                clsDriver driver = clsDriver.Find(driverID);
                if (driver != null)
                {
                    Form personLicensesHistory = new frmPersonLicenseHistory(driver.PersonID);
                    personLicensesHistory.ShowDialog();
                }
            }
        }

        private void addNewInternationaLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm1 = new frmInternationalLicenseApplication();
            frm1.ShowDialog();
        }

        private void btnAddNewIDLApp_Click(object sender, EventArgs e)
        {
            Form frm1 = new frmInternationalLicenseApplication();
            frm1.ShowDialog();
        }
    }
}
