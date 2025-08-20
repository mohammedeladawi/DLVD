using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Applications.Local_Driving_License;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class frmManageLDLApplications : Form
    {
        public frmManageLDLApplications()
        {
            InitializeComponent();
        }

        private int GetSelectedLDLApplicationID()
        {
            DataGridView dgvLDLApplication = ctrManageData1.dgvManageDate1;
            int ldlApplicationID = -1;

            if (dgvLDLApplication.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvLDLApplication.SelectedRows[0];
                ldlApplicationID = Convert.ToInt32(row.Cells["L.D.L. AppID"].Value);
            }

            return ldlApplicationID;
        }

        private bool TryGetSelectedLDLApplicationID(out int ldlApplicationID)
        {
            ldlApplicationID = GetSelectedLDLApplicationID();
            if (ldlApplicationID == -1)
            {
                MessageBox.Show("There is no selected row");
                return false;
            }

            return true;
        }

        private int GetSelectedPassedTests()
        {
            DataGridView dgvLDLApplication = ctrManageData1.dgvManageDate1;
            int passedTests = -1;

            if (dgvLDLApplication.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvLDLApplication.SelectedRows[0];
                passedTests = Convert.ToInt32(row.Cells["Passed Tests"].Value);
            }

            return passedTests;
        }

        private void frmManageLDLApplications_Load(object sender, EventArgs e)
        {

            ctrManageData1.LoadTitle("Local Driving License Applications");
            ctrManageData1.LoadData(clsLDLApplication.GetAllApplications());
            ctrManageData1.LoadContextMenuStrip(cmsManageLDLApplications);
        }

        private void ReloadLDLApplications()
        {
            ctrManageData1.LoadData(clsLDLApplication.GetAllApplications());
        }

        private void ShowDeleteApplicationDialog(int ldlApplicationID)
        {
            if (MessageBox.Show("Are you sure you want to delete this application?",
                   "Delete Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                   == DialogResult.OK)
            {
                if (clsLDLApplication.Delete(ldlApplicationID))
                {
                    MessageBox.Show("Application has been deleted succesfully.");
                    ReloadLDLApplications();
                }
                else
                {
                    MessageBox.Show("Couldn't deleted this application.");
                }
            }
        }

        private void ShowCancelApplicationDialog(int ldlApplicationID)
        {
            if (MessageBox.Show("Are you sure you want to cancel this application?",
                   "Cancel Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                   == DialogResult.OK)
            {
                if (clsLDLApplication.Cancel(ldlApplicationID))
                {
                    MessageBox.Show("Application has been canceled succesfully.");
                    ReloadLDLApplications();
                }
                else
                {
                    MessageBox.Show("Couldn't cancel this application.");
                }
            }
        }

        private void ShowUpdateLDLApplication(int ldlApplicationID)
        {
            Form editUpdateLDLApplication = new frmAddEditLDLApplication(ldlApplicationID);
            editUpdateLDLApplication.FormClosed += frm_Closed;
            editUpdateLDLApplication.ShowDialog();
        }


        private void ShowIssueDrivingLicense(int ldlApplicationID)
        {
            clsLDLApplication ldlApplicaiton = clsLDLApplication.FindByLDLApplicationID(ldlApplicationID);
            if (ldlApplicaiton == null) 
                return;

            if (ldlApplicaiton.HasPassedAllTests())
            {
                Form issueDLForm = new frmIssueDrivingLicenseFirstTime(ldlApplicationID);
                issueDLForm.FormClosed += frm_Closed;
                issueDLForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Should pass all tests first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowLicenseInfo(int ldlApplicationID)
        {
            clsLDLApplication ldlApplication = clsLDLApplication.FindByLDLApplicationID(ldlApplicationID);
            if (ldlApplication == null)
                return;


            Form showLicenseInfo = new frmDriverLicenseInfo(ldlApplication.GetActiveLicenseID());
            showLicenseInfo.ShowDialog();
        }

        private void ShowPersonLicenseHistory(int ldlApplicationID)
        {
            var ldlApp = clsLDLApplication.FindByLDLApplicationID(ldlApplicationID);
            if (ldlApp == null)
                return;

            Form showPersonLicenseHistory = new frmPersonLicenseHistory(ldlApp.ApplicationPersonID);
            showPersonLicenseHistory.ShowDialog();
        }

        private void frm_Closed(object sender, FormClosedEventArgs e)
        {
            ReloadLDLApplications();
        }

        //-------- Disable tool strip menu items ----------//
        private void tsmiTestsDisability()
        {
            tsmiScheduleTest.Enabled = false;
            tsmiScheduleVisionTest.Enabled = false;
            tsmiScheduleWrittenTest.Enabled = false;
            tsmiScheduleStreetTest.Enabled = false;

            int passedTests = GetSelectedPassedTests();
            int ldlApplicaitonID = GetSelectedLDLApplicationID();

            var ldlApplication = clsLDLApplication.FindByLDLApplicationID(ldlApplicaitonID);
            if (
                ldlApplication == null || 
                ldlApplication.ApplicationStatus == (byte) enApplicationStatus.Cancelled)
                return;

            if (passedTests >= 0 && passedTests <= 2)
                tsmiScheduleTest.Enabled = true;

            switch (passedTests)
            {
                case 0:
                    tsmiScheduleVisionTest.Enabled = true;
                    break;
                case 1:
                    tsmiScheduleWrittenTest.Enabled = true;
                    break;
                case 2:
                    tsmiScheduleStreetTest.Enabled = true;
                    break;
            }

        }

        private void tsmiIssueDrivingLicenseDisability()
        {
            tsmiIssueDrivingLicense.Enabled = false;

            int passedTests = GetSelectedPassedTests();
            int ldlApplicaitonID = GetSelectedLDLApplicationID();

            var ldlApplication = clsLDLApplication.FindByLDLApplicationID(ldlApplicaitonID);
            if (
                ldlApplication == null || 
                ldlApplication.ApplicationStatus == (byte)enApplicationStatus.Cancelled
               )
                return;

            // not already completed
            if (
                passedTests == 3 && 
                ldlApplication.ApplicationStatus != (byte)enApplicationStatus.Completed
               )
                tsmiIssueDrivingLicense.Enabled = true;



        }

        private void tsmiRemainingItemsDisability()
        {
            tsmiEditApplication.Enabled = false;
            tsmiCancelApplication.Enabled = false;
            tsmiDeleteApplication.Enabled = false;
            tsmiShowLicense.Enabled = false;

            int ldlApplicationID = GetSelectedLDLApplicationID();

            clsLDLApplication ldlApplication = clsLDLApplication.FindByLDLApplicationID(ldlApplicationID);
            if (ldlApplication == null)
                return;

            switch(ldlApplication.ApplicationStatus)
            {
                case (byte)clsApplication.enApplicationStatus.Cancelled:
                    tsmiDeleteApplication.Enabled = true;
                    break;
                case (byte)clsApplication.enApplicationStatus.Completed:
                    tsmiShowLicense.Enabled = true;
                    break;
                default:
                    // new
                    tsmiEditApplication.Enabled = true;
                    tsmiCancelApplication.Enabled = true;
                    tsmiDeleteApplication.Enabled = true;
                    break;
            }
        }
        // -------------------------------------------------

        private void cmsManageLDLApplications_Opening(object sender, CancelEventArgs e)
        {

            tsmiShowLicense.Enabled = false;

            tsmiTestsDisability();
            tsmiIssueDrivingLicenseDisability();
            tsmiRemainingItemsDisability();
        }

        private void ShowLDLApplicationDetails(int ldlApplicationID)
        {
            Form frmLDLApplicationDetails1 = new frmLDLApplicationDetails(ldlApplicationID);
            frmLDLApplicationDetails1.FormClosed += frm_Closed;
            frmLDLApplicationDetails1.ShowDialog();
        }

        private void tsmiAddNewLDLApplication_Click(object sender, EventArgs e)
        {
            Form addUpdateLDLApplication = new frmAddEditLDLApplication();
            addUpdateLDLApplication.FormClosed += frm_Closed;
            addUpdateLDLApplication.ShowDialog();
        }

        private void tsmiCancelApplication_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedLDLApplicationID(out int ldlApplicationID))
                ShowCancelApplicationDialog(ldlApplicationID);
        }

        private void tsmiEditApplication_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedLDLApplicationID(out int ldlApplicationID))
                ShowUpdateLDLApplication(ldlApplicationID);
        }


        private bool CanOpenScheduleTest(int ldlApplicationID, clsTestType.enTestTypes testType)
        {
            clsLDLApplication ldlApplication = clsLDLApplication.FindByLDLApplicationID(ldlApplicationID);
            if (ldlApplication == null)
                return false;

            switch (testType)
            {
                case clsTestType.enTestTypes.VisionTest:
                    // check if already passed it
                    if (ldlApplication.IsPassedTest((int)testType))
                    {
                        MessageBox.Show("Person already passed this test!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false ;
                    }
                    break;

                case clsTestType.enTestTypes.WrittenTheoryTest:
                    if (!ldlApplication.IsPassedTest((int)clsTestType.enTestTypes.VisionTest))
                    {
                        MessageBox.Show("Person should pass vision test first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (ldlApplication.IsPassedTest((int)testType))
                    {
                        MessageBox.Show("Person already passed this test!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    break;

                case clsTestType.enTestTypes.PracticalStreetTest:
                    if (!ldlApplication.IsPassedTest((int)clsTestType.enTestTypes.VisionTest))
                    {
                        MessageBox.Show("Person should pass vision test and then written test!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    
                    if (!ldlApplication.IsPassedTest((int)clsTestType.enTestTypes.WrittenTheoryTest))
                    {
                        MessageBox.Show("Person should pass written test first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (ldlApplication.IsPassedTest((int)testType))
                    {
                        MessageBox.Show("Person already passed this test!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    break;

                default:
                    return false;

            }
            return true;
        }

        private void ShowManageTestAppointments(clsTestType.enTestTypes testType)
        {
            if (TryGetSelectedLDLApplicationID(out int ldlApplicationID))
            {
                if (!CanOpenScheduleTest(ldlApplicationID, testType))
                    return;

                Form scheduleVTest = new frmManageTestAppointments(ldlApplicationID, testType);
                scheduleVTest.FormClosed += frm_Closed;
                scheduleVTest.ShowDialog();

            }
        }

        private void tsmiScheduleVisionTest_Click(object sender, EventArgs e)
        {
                ShowManageTestAppointments(clsTestType.enTestTypes.VisionTest);
        }

        private void tsmiScheduleWrittenTest_Click(object sender, EventArgs e)
        {
                ShowManageTestAppointments(clsTestType.enTestTypes.WrittenTheoryTest);
        }

        private void tsmiScheduleStreetTest_Click(object sender, EventArgs e)
        {
                ShowManageTestAppointments(clsTestType.enTestTypes.PracticalStreetTest);
        }

        private void tsmiIssueDrivingLicense_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedLDLApplicationID(out int ldlApplicationID))
                ShowIssueDrivingLicense(ldlApplicationID);
        }

        private void tsmiShowLicense_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedLDLApplicationID(out int ldlApplicationID))
                ShowLicenseInfo(ldlApplicationID);
        }

        private void tsmiDeleteApplication_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedLDLApplicationID(out int ldlApplicationID))
                ShowDeleteApplicationDialog(ldlApplicationID);
        }

        private void tsmiShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedLDLApplicationID(out int ldlApplicationID))
                ShowPersonLicenseHistory(ldlApplicationID);
        }

        private void tsmiShowApplicationDetails_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedLDLApplicationID(out int ldlApplicationID))
                ShowLDLApplicationDetails(ldlApplicationID);
        }
    }
}
