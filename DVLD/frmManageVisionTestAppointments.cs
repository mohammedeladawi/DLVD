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
    public partial class frmManageVisionTestAppointments: Form
    {
        private int GetSelectedTestAppointmentID()
        {
            DataGridView dgvTestType = ctrTestApplicationInfo1.dgvManageDate1;
            int AppointmentID = -1;

            if (dgvTestType.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvTestType.SelectedRows[0];
                AppointmentID = Convert.ToInt32(row.Cells["TestAppointmentID"].Value);
            }

            return AppointmentID;
        }
        int _ldlApplicationID;
        clsLDLApplication _ldlApplication;
        
        public frmManageVisionTestAppointments(int ldlApplicationID)
        {
            _ldlApplicationID = ldlApplicationID;
            _ldlApplication = clsLDLApplication.FindByID(_ldlApplicationID);

            InitializeComponent();
            this.AutoScroll = true;

        }

        private void ReloadAppointmentsView()
        {
            DataTable testAppointmentsDT = clsTestAppointment.GetAllTestAppointmentsByLDLAppID(_ldlApplicationID);
            ctrTestApplicationInfo1.SetTestAppointmentsView(testAppointmentsDT);
        }
        private void frmVisionTestAppointments_Load(object sender, EventArgs e)
        {
            ctrTestApplicationInfo1.SetTestTitle("Vision Test Appointments");
            ctrTestApplicationInfo1.SetApplicationInfo(_ldlApplicationID);

            DataTable testAppointmentsDT = clsTestAppointment.GetAllTestAppointmentsByLDLAppID(_ldlApplicationID);
            ctrTestApplicationInfo1.SetTestAppointmentsView(testAppointmentsDT);
            ctrTestApplicationInfo1.SetContextMenuStrip(cmsVisionTestAppointment);

        }

        private void tmsiEdit_Click(object sender, EventArgs e)
        {
            int testAppointmentID = GetSelectedTestAppointmentID();
            if (testAppointmentID == -1)
            {
                MessageBox.Show("There is no selected row");
                return;
            }

            if (_ldlApplication.Application.ApplicationStatus == 2)
            {
                MessageBox.Show("can't update test for cancelled application");
            }
            else
            {
                Form frmScheduleVTest = new frmScheduleTestAppointment(_ldlApplication, 1, testAppointmentID);
                frmScheduleVTest.FormClosed += frmScheduleVTest_Closed;
                frmScheduleVTest.ShowDialog();
            }


        }

        private void cmsiTakeTest_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            if (clsTestAppointment.IsActiveAppointmentExist(_ldlApplicationID))
            {
                MessageBox.Show("You already have an active appointment");
            }
            else if (_ldlApplication.PassedTestsCount >= 1)
            {
                MessageBox.Show("You already passed this test");
            }
            else if (_ldlApplication.Application.ApplicationStatus == 2)
            {
                MessageBox.Show("can't add test for cancelled application");
            }
            else
            {
                Form frmScheduleVTest = new frmScheduleTestAppointment(_ldlApplication, 1);
                frmScheduleVTest.FormClosed += frmScheduleVTest_Closed;
                frmScheduleVTest.ShowDialog();

            }

        }

        private void frmScheduleVTest_Closed(object sender, EventArgs e)
        {
            ReloadAppointmentsView();
        }
    }
}
