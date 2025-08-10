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
    public partial class frmManageTestAppointments: Form
    {
        int _ldlApplicationID;
        clsLDLApplication _ldlApplication;
        int _testTypeID;
        int _testOrder;
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
        
        public frmManageTestAppointments(int ldlApplicationID, int testTypeID, int testOrder)
        {
            _ldlApplicationID = ldlApplicationID;
            _ldlApplication = clsLDLApplication.FindByLDLApplicationID(_ldlApplicationID);
            _testTypeID = testTypeID;
            _testOrder = testOrder;

            InitializeComponent();
            this.AutoScroll = true;

        }

        private void ReloadAppointmentsView()
        {
            DataTable testAppointmentsDT = clsTestAppointment.GetAllTestAppointmentsByLDLAppID(_ldlApplicationID, _testTypeID);
            ctrTestApplicationInfo1.SetTestAppointmentsView(testAppointmentsDT);
            ctrTestApplicationInfo1.SetApplicationInfo(_ldlApplicationID);
        }

        private void frmManageTestAppointments_Load(object sender, EventArgs e)
        {
            string testTitle = clsTestType.Find(_testTypeID).Title;
            ctrTestApplicationInfo1.SetTestTitle("Manage " + testTitle + " Appointments");
            ctrTestApplicationInfo1.SetApplicationInfo(_ldlApplicationID);

            DataTable testAppointmentsDT = clsTestAppointment.GetAllTestAppointmentsByLDLAppID(_ldlApplicationID, _testTypeID);
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

            //if (_ldlApplication.Application.ApplicationStatus == 2)
            //{
            //    MessageBox.Show("can't update test for cancelled application");
            //}
            //else
            //{
            //    Form frmScheduleTest = new frmScheduleTestAppointment(_ldlApplication, _testTypeID, testAppointmentID);
            //    frmScheduleTest.FormClosed += frmScheduleTest_Closed;
            //    frmScheduleTest.ShowDialog();
            //}


        }

        private void cmsiTakeTest_Click(object sender, EventArgs e)
        {
            int testAppointmentID = GetSelectedTestAppointmentID();
            if (testAppointmentID == -1)
            {
                MessageBox.Show("There is no selected row");
                return;
            }
            //if (_ldlApplication.Application.ApplicationStatus == 2)
            //{
            //    MessageBox.Show("can't take test for cancelled application");
            //}
            else if (clsTest.PassedTestsCount(_ldlApplicationID) >= _testOrder)
            {
                MessageBox.Show("You already passed this test");
            }
            else if (clsTestAppointment.Find(testAppointmentID).IsLocked)
            {
                MessageBox.Show("You already took test for this appointment");
            }
            else
            {
                Form takeTestForm = new frmTakeTest(_testTypeID, testAppointmentID);
                takeTestForm.FormClosed += frmScheduleTest_Closed;
                takeTestForm.ShowDialog();
            }
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            if (clsTestAppointment.IsActiveAppointmentExist(_ldlApplicationID))
            {
                MessageBox.Show("You already have an active appointment");
            }
            else if (clsTest.PassedTestsCount(_ldlApplicationID) >= _testOrder)
            {
                MessageBox.Show("You already passed this test");
            }
            //else if (_ldlApplication.Application.ApplicationStatus == 2)
            //{
            //    MessageBox.Show("can't add test for cancelled application");
            //}
            else
            {
                Form frmScheduleVTest = new frmScheduleTestAppointment(_ldlApplication, _testTypeID);
                frmScheduleVTest.FormClosed += frmScheduleTest_Closed;
                frmScheduleVTest.ShowDialog();
            }

        }

        private void frmScheduleTest_Closed(object sender, EventArgs e)
        {
            ReloadAppointmentsView();
        }
    }
}
