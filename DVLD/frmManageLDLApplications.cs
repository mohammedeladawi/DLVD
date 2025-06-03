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
        enum enTestTypes : byte { Vision = 1, Written = 2, Practical = 3 };
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
            ctrManageData1.SetContextMenuStrip(cmsManageLDLApplications);
        }

        private void ReloadApplicationData()
        {
            ctrManageData1.LoadData(clsLDLApplication.GetAllApplications());
        }

        private void ShowDeleteApplicationDialog(int ldlApplicationID)
        {
            if (MessageBox.Show("Are you sure you want to cancel this application?",
                   "Cancel Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                   == DialogResult.OK)
            {
                if (clsLDLApplication.Cancel(ldlApplicationID))
                {
                    MessageBox.Show("Application has been canceled succesfully.");
                    ReloadApplicationData();
                }
                else
                {
                    MessageBox.Show("Could't cancel this application.");
                }
            }
        }
      
        private void tsmiCancelApplication_Click(object sender, EventArgs e)
        {
            int ldlApplicationID = GetSelectedLDLApplicationID();

            if (ldlApplicationID != -1)
            {
                ShowDeleteApplicationDialog(ldlApplicationID);
            }
            else
            {
                MessageBox.Show("There is no selected row");
            }
        }

        private void tsmiAddNewLDLApplication_Click(object sender, EventArgs e)
        {
            Form addUpdateLDLApplication = new frmAddEditLDLApplication();
            addUpdateLDLApplication.FormClosed += frm_Closed;
            addUpdateLDLApplication.ShowDialog();
        }

        private void ShowUpdateLDLApplicationDialog(int ldlApplicationID)
        {
            Form editUpdateLDLApplication = new frmAddEditLDLApplication(ldlApplicationID);
            editUpdateLDLApplication.FormClosed += frm_Closed;
            editUpdateLDLApplication.ShowDialog();
        }

        private void frm_Closed(object sender, FormClosedEventArgs e)
        {
            ReloadApplicationData();
        }

        private void ShowMangageVTestDialog(int ldlApplicationID)
        {
            Form scheduleVTest = new frmManageTestAppointments(ldlApplicationID, (int)enTestTypes.Vision, 1);
            scheduleVTest.FormClosed += frm_Closed;
            scheduleVTest.ShowDialog();
        }

        private void ShowMangageWrittenTestDialog(int ldlApplicationID)
        {
            Form scheduleVTest = new frmManageTestAppointments(ldlApplicationID, (int)enTestTypes.Written, 2);
            scheduleVTest.FormClosed += frm_Closed;
            scheduleVTest.ShowDialog();
        }
        private void ShowMangageStreetTestDialog(int ldlApplicationID)
        {
            Form scheduleVTest = new frmManageTestAppointments(ldlApplicationID, (int)enTestTypes.Practical, 3);
            scheduleVTest.FormClosed += frm_Closed;
            scheduleVTest.ShowDialog();
        }

        private void tsmiEditApplication_Click(object sender, EventArgs e)
        {
            int ldlApplicationID = GetSelectedLDLApplicationID();
            if (ldlApplicationID != -1)
            {
                ShowUpdateLDLApplicationDialog(ldlApplicationID);
            }
            else
            {
                MessageBox.Show("There is no selected row");
            }
        }

        private void tsmiScheduleVisionTest_Click(object sender, EventArgs e)
        {
            int ldlApplicationID = GetSelectedLDLApplicationID();
            if (ldlApplicationID != -1)
            {
                ShowMangageVTestDialog(ldlApplicationID);
            }
            else
            {
                MessageBox.Show("There is no selected row");
            }

        }

        private void tsmiScheduleWrittenTest_Click(object sender, EventArgs e)
        {
            int ldlApplicationID = GetSelectedLDLApplicationID();
            if (ldlApplicationID != -1)
            {
                ShowMangageWrittenTestDialog(ldlApplicationID);
            }
            else
            {
                MessageBox.Show("There is no selected row");
            }
        }

        private void tsmiScheduleStreetTest_Click(object sender, EventArgs e)
        {
            int ldlApplicationID = GetSelectedLDLApplicationID();
            if (ldlApplicationID != -1)
            {
                ShowMangageStreetTestDialog(ldlApplicationID);
            }
            else
            {
                MessageBox.Show("There is no selected row");
            }
        }

        private void tsmiTestsDisability()
        {
            tsmiScheduleTest.Enabled = false;
            tsmiScheduleVisionTest.Enabled = false;
            tsmiScheduleWrittenTest.Enabled = false;
            tsmiScheduleStreetTest.Enabled = false;

            int passedTests = GetSelectedPassedTests();
            int ldlApplicaitonID = GetSelectedLDLApplicationID();
            
            var application = clsLDLApplication.FindByID(ldlApplicaitonID)?.Application;
            if (application == null || application.ApplicationStatus == 2)
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

            var application = clsLDLApplication.FindByID(ldlApplicaitonID)?.Application;
            if (application == null || application.ApplicationStatus == 2)
                return;



            if (passedTests == 3 && application.ApplicationStatus != 3)
                tsmiIssueDrivingLicense.Enabled = true;
 
               

        }
        
        private void tsmiRemainingItemsDisability()
        {
            tsmiEditApplication.Enabled = false;
            tsmiCancelApplication.Enabled = false;
            tsmiDeleteApplication.Enabled  = false;
            tsmiShowLicense.Enabled = false;

            int ldlApplicationID = GetSelectedLDLApplicationID();
            
            var application = clsLDLApplication.FindByID(ldlApplicationID)?.Application;
            if (application == null || application.ApplicationStatus == 2)
                return; 
            
            if (application.ApplicationStatus != 3)
            {
                tsmiEditApplication.Enabled = true;
                tsmiCancelApplication.Enabled = true;
                tsmiDeleteApplication.Enabled = true;
            }
            else
            {
                tsmiShowLicense.Enabled = true;
            }
        }

        private void cmsManageLDLApplications_Opening(object sender, CancelEventArgs e)
        {

            tsmiShowLicense.Enabled = false;

            tsmiTestsDisability();
            tsmiIssueDrivingLicenseDisability();
            tsmiRemainingItemsDisability();
        }

        private void ShowIssueDirvingLicenseDialog(int ldlApplicaitonID)
        {
            Form issueDLForm = new frmIssueDrivingLicense(ldlApplicaitonID);
            issueDLForm.FormClosed += frm_Closed;
            issueDLForm.ShowDialog();
        }
        
        private void tsmiIssueDrivingLicense_Click(object sender, EventArgs e)
        {
            int ldlApplicationID = GetSelectedLDLApplicationID();
            if (ldlApplicationID != -1)
            {
                ShowIssueDirvingLicenseDialog(ldlApplicationID);
            }
            else
            {
                MessageBox.Show("There is no selected row");
            }

        }

        private void ShowLicenseInfoDialog(int ldlApplicationID)
        {
            Form showLicenseInfo = new frmDriverLicenseInfo(ldlApplicationID);
            showLicenseInfo.ShowDialog();
        }

        private void tsmiShowLicense_Click(object sender, EventArgs e)
        {
            int ldlApplicationID = GetSelectedLDLApplicationID();
            if (ldlApplicationID != -1)
            {
                ShowLicenseInfoDialog(ldlApplicationID);
            }
            else
            {
                MessageBox.Show("There is no selected row");
            }
        }
    }
}
