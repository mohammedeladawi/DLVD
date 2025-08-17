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
    public partial class frmPersonLicenseHistory: Form
    {
        int _personID;
        private clsDriver _driver;
        
        public frmPersonLicenseHistory(int personID)
        {
            InitializeComponent();

            _personID = personID;
            _driver = clsDriver.FindByPersonID(personID);
        }

        public frmPersonLicenseHistory(clsDriver driver)
        {
            _driver = driver;
            InitializeComponent();
        }

        private int GetSelectedLicenseID(DataGridView ctrlDGVGridView)
        {
            DataGridView dgvLicenses = ctrlDGVGridView;
            int licenseID = -1;

            if (dgvLicenses.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvLicenses.SelectedRows[0];
                licenseID = Convert.ToInt32(row.Cells[0].Value);
            }

            return licenseID;
        }

        private bool TryGetSelectedLicenseID(out int licenseID, DataGridView ctrlDGVGridView)
        {
            licenseID = GetSelectedLicenseID(ctrlDGVGridView);
            if (licenseID == -1)
            {
                MessageBox.Show("There is no selected row");
                return false;
            }

            return true;
        }

        private void frmPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_driver == null)
            {
                MessageBox.Show($"Couldn't find driver with this person ID = {_personID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrPersonInformation1.LoadPersonInfo(_personID);

            DataTable dtLocalDrivingLicenses = clsLicense.GetLicensesByDriverID(_driver.DriverID);
            ctrDVLocal.LoadData(dtLocalDrivingLicenses);
            ctrDVLocal.LoadContextMenuStrip(cmsLicence);

            DataTable dtInternational = clsInternationalLicense.GetInternationalLicensesByDriverID(_driver.DriverID);
            ctrDVInternational.LoadData(dtInternational);
            ctrDVInternational.LoadContextMenuStrip(cmsInternationalLicense);


        }

        private void tsmiShowLicense_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedLicenseID(out int licenseID, ctrDVLocal.dgvManageDate1))
            {
                Form frm1 = new frmDriverLicenseInfo(licenseID);
                frm1.Show();
            }
        }

        private void tsmiShowInternationalLicense_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedLicenseID(out int internationLicenseID, ctrDVInternational.dgvManageDate1))
            {
                Form frm1 = new frmInternationalLicenseInfo(internationLicenseID);
                frm1.Show();
            }
        }
    }
}
