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
    public partial class frmManageILDApplications : Form
    {
        public frmManageILDApplications()
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

        private int GetSelectedLDLicenseID()
        {
            DataGridView dgvIDLApplication = ctrManageData1.dgvManageDate1;
            int LDLicenseID = -1;

            if (dgvIDLApplication.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvIDLApplication.SelectedRows[0];
                LDLicenseID = Convert.ToInt32(row.Cells["IssuedUsingLocalLicenseID"].Value);
            }

            return LDLicenseID;
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

        private void frmManageILDApplications_Load(object sender, EventArgs e)
        {
            ctrManageData1.LoadTitle("International Driving License Applications");
            ctrManageData1.LoadData(clsInternationalLicense.GetAllILicensesApplications());
            ctrManageData1.SetContextMenuStrip(cmsIDLApplications);
        }

        private void ShowPersonDetails(int personID)
        {
            Form perosnDetailsDialog = new frmPersonDetails(personID);
            perosnDetailsDialog.ShowDialog();
        }
        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int IDLicense = GetSelectedILicenseID();
            if (IDLicense == -1)
                return;

            clsInternationalLicense internationalLicense = clsInternationalLicense.FindByID(IDLicense);
            if (internationalLicense == null)
                return;

            clsDriver driver = clsDriver.Find(internationalLicense.DriverID);
            if (driver == null) return;


            ShowPersonDetails(driver.PersonID);
        }

        private void ShowILicenseInfo(int lDLicenseID)
        {
            Form licenseInfoDialog = new frmInternationalLicenseInfo(lDLicenseID);
            licenseInfoDialog.ShowDialog();
        }
        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int lDLicenseID = GetSelectedLDLicenseID();
            if (lDLicenseID == -1)
                return;

            ShowILicenseInfo(lDLicenseID);

        }

        private void ShowPersonLicensesHistory(clsDriver driver)
        {
            Form personLicensesHistory = new frmPersonLicenseHistory(driver);
            personLicensesHistory.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int driverID = GetSelectedDriverID();
            if (driverID == -1)
                return;

            clsDriver driver = clsDriver.Find(driverID);
            if (driver == null)
                return;

            ShowPersonLicensesHistory(driver);
        }
    }
}
