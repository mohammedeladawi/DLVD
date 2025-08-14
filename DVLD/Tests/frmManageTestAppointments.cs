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
        int _ldlApplicationID = -1;
        clsLDLApplication _ldlApplicationInfo;
        clsTestType.enTestTypes _testType;
        clsTestType _testTypeInfo;
        
        public frmManageTestAppointments(int ldlApplicationID, clsTestType.enTestTypes testType)
        {
            _ldlApplicationID = ldlApplicationID;
            _testType = testType;

            InitializeComponent();
        }

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

        private bool TryGetSelectedTestAppointmentID(out int appointmentID)
        {
            appointmentID = GetSelectedTestAppointmentID();
            if (appointmentID == -1)
            {
                MessageBox.Show("There is no selected row");
                return false;
            }

            return true;
        }

        private void ReloadAppointmentsView()
        {
            DataTable testAppointmentsDT = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_ldlApplicationID, _testTypeInfo.TestTypeID);
            ctrTestApplicationInfo1.LoadTestAppointments(testAppointmentsDT);
            ctrTestApplicationInfo1.LoadLDLApplicationInfo(_ldlApplicationID);
        }

        private void frmManageTestAppointments_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;

            _ldlApplicationInfo = clsLDLApplication.FindByLDLApplicationID(_ldlApplicationID);
            _testTypeInfo = clsTestType.Find((int)_testType);

            if (_testTypeInfo == null || _ldlApplicationInfo == null)
            {
                MessageBox.Show("Couldn't load form data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            
            
            DataTable testAppointmentsDT = clsTestAppointment.
                GetApplicationTestAppointmentsPerTestType(_ldlApplicationID, _testTypeInfo.TestTypeID);
            
            // ---------- Todo: remvoe this control ------------------
            ctrTestApplicationInfo1.LoadTitle("Manage " + _testTypeInfo.Title + " Appointments");
            ctrTestApplicationInfo1.LoadLDLApplicationInfo(_ldlApplicationID);
            ctrTestApplicationInfo1.LoadTestAppointments(testAppointmentsDT);
            ctrTestApplicationInfo1.LoadContextMenuStrip(cmsManageTestAppointment);
        }

        private bool IsTestAppointmentLocked(int appointmentID) 
        {
            clsTestAppointment testAppointment = clsTestAppointment.Find(appointmentID);
            if (testAppointment != null && testAppointment.IsLocked)
            {
                MessageBox.Show("This test appointment is locked!");
                return true;
            }

            return false;
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedTestAppointmentID(out int appointmentID))
            {
                if (IsTestAppointmentLocked(appointmentID))
                    return;   

                Form frmScheduleTestAppointment1 = 
                    new frmScheduleTestAppointment(_ldlApplicationID, _testTypeInfo.TestTypeID, appointmentID);
                frmScheduleTestAppointment1.FormClosed += frm_Closed;
                frmScheduleTestAppointment1.ShowDialog();
            }
        }

        private void tsmiTakeTest_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedTestAppointmentID(out int appointmentID))
            {
                if (IsTestAppointmentLocked(appointmentID))
                    return;

                Form takeTestForm = new frmTakeTest(_testTypeInfo.TestTypeID, appointmentID);
                takeTestForm.FormClosed += frm_Closed;
                takeTestForm.ShowDialog();
            }
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            // you passed it 
            if (_ldlApplicationInfo.IsPassedTest(_testTypeInfo.TestTypeID))
            {
                MessageBox.Show("You already passed this test!");
                return;
            }

            // you already have an active one 
            if (_ldlApplicationInfo.HasActiveAppointmentPerTestType(_testTypeInfo.TestTypeID))
            {
                MessageBox.Show("You already have an active appointment!");
                return;
            }
            
            Form frmScheduleTest = new frmScheduleTestAppointment(_ldlApplicationID, _testTypeInfo.TestTypeID);
            frmScheduleTest.FormClosed += frm_Closed;
            frmScheduleTest.ShowDialog();
        }

        private void frm_Closed(object sender, EventArgs e)
        {
            ReloadAppointmentsView();
        }

        private void cmsManageTestAppointment_Opening(object sender, CancelEventArgs e)
        {
            tsmiTakeTest.Enabled = false;
            tsmiEdit.Enabled = false;

            int appointmentID = GetSelectedTestAppointmentID();
            clsTestAppointment appointment =
                clsTestAppointment.Find(appointmentID);
            
            if (appointment != null && !appointment.IsLocked)
            {
                tsmiTakeTest.Enabled = true;
                tsmiEdit.Enabled = true;
            }
        }
    }
}
