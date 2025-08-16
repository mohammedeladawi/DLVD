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
using System.Xml.Linq;

namespace DVLD
{
    public partial class frmScheduleTestAppointment: Form
    {
        enum enMode { AddNew, Update}
        enMode Mode;

        int _trialsCount;
        clsApplicationType _retakeTestType;

        clsLDLApplication _ldlApplication;
        clsTestAppointment _testAppointment;
        clsTestType _testType;

        private void InitializeFormData(int ldlApplicationID, int testTypeID)
        {
            _ldlApplication = clsLDLApplication.FindByLDLApplicationID(ldlApplicationID);
            _testType = clsTestType.Find(testTypeID);
            _trialsCount = clsTest.LDLApplicationTestTrials(ldlApplicationID, _testType.TestTypeID);
        }
       
        public frmScheduleTestAppointment(int ldlApplicationID, int testTypeID)
        {
            InitializeComponent();

            InitializeFormData(ldlApplicationID, testTypeID);
            _testAppointment = new clsTestAppointment();
            Mode = enMode.AddNew;

        }

        public frmScheduleTestAppointment(int ldlApplicationID, int testTypeID, int testAppointmentID)
        {

            InitializeComponent();
           
            InitializeFormData(ldlApplicationID, testTypeID);
            _testAppointment = clsTestAppointment.Find(testAppointmentID);
            Mode = enMode.Update;
        }

        private void LoadRetakeTestUIFields()
        {

            if (_trialsCount > 0)
            {
                 if (_retakeTestType == null)
                    return;

                decimal retakeTestFees = _retakeTestType.Fees;

                switch (Mode)
                {
                    case enMode.AddNew:
                        lblRetakeTestAppFees.Text = retakeTestFees.ToString();
                        lblTotalFees.Text = (_testType.Fees + retakeTestFees).ToString();
                        break;

                    case enMode.Update:
                        lblRetakeTestAppID.Text = 
                                _testAppointment.RetakeTestApplicationID.ToString();
                        lblRetakeTestAppFees.Text = retakeTestFees.ToString();
                        lblTotalFees.Text = (_testAppointment.PaidFees).ToString();

                        break;
                }
            }
            else
            {
                gpRetakeTestInfo.Enabled = false;
            }
        }

        private int CreateRetakeTestApplicationAndGetID()
        {            
            if (_retakeTestType == null)
                return -1;

            decimal retakeTestFees = _retakeTestType.Fees;

            clsApplication retakeTestApplication = new clsApplication();
            retakeTestApplication.ApplicationTypeID = _testType.TestTypeID;
            retakeTestApplication.ApplicationDate = DateTime.Now;
            retakeTestApplication.ApplicationPersonID = _ldlApplication.ApplicationPersonID;
            retakeTestApplication.CreatedByUserID = clsGlobal.currentUser.UserID;
            retakeTestApplication.PaidFees = retakeTestFees;

            if (retakeTestApplication.Save())
            {
                return retakeTestApplication.ApplicationID;
            }

            return -1;
        }
       
        private bool LoadUIFieldsIntoTestAppointment()
        {
            // AddNew or update
            _testAppointment.AppointmentDate = dtpAppointmentDate.Value;

            // AddNew
            if (Mode == enMode.AddNew)
            {
                _testAppointment.TestTypeID = _testType.TestTypeID;
                _testAppointment.LDLApplicationID = _ldlApplication.LocalDrivingLicenseApplicationID;
                _testAppointment.CreatedByUserID = clsGlobal.currentUser.UserID;
                _testAppointment.PaidFees = Convert.ToDecimal(lblTotalFees.Text);
                
                // retake test
                if (_trialsCount > 0)
                {
                    int retakeTestAppID = CreateRetakeTestApplicationAndGetID();
                    if (retakeTestAppID != -1)
                        _testAppointment.RetakeTestApplicationID = retakeTestAppID;
                    else
                    {
                        MessageBox.Show("Couldn't create retake test application for this appointment!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    
                }
            }

            return true;

        }
      
        private void LoadDataIntoUIFields()
        {

            lblDLApplicationID.Text = _ldlApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _ldlApplication.LicenseClassInfo.ClassName.ToString();
            lblName.Text = _ldlApplication.ApplicationPersonInfo.FullName; ;
            lblTrials.Text = _trialsCount.ToString();
            gpTest.Text = _testType.Title;
            lblFees.Text = _testType.Fees.ToString();

            if (Mode == enMode.Update)
                dtpAppointmentDate.Value = _testAppointment.AppointmentDate;

            LoadRetakeTestUIFields();
        }

        private void ResetUIFields()
        {
            // Test
            lblDLApplicationID.Text = "??";
            lblLicenseClass.Text = "??";
            lblName.Text = "??";
            lblTrials.Text = "??";
            dtpAppointmentDate.Value = DateTime.Now;
            lblFees.Text = "??";

            // Retake Test
            lblRetakeTestAppFees.Text = "0";
            lblTotalFees.Text = _testType.Fees.ToString();
            lblRetakeTestAppID.Text = "N/A";
        }
       
        private void CheckAppointmentIsLocked()
        {
            if (_testAppointment.IsLocked)
            {
                dtpAppointmentDate.Enabled = false;
                ctrSaveBtn1.Enabled = false;
            }
        }
       
        private void frmScheduleTestAppointment_Load(object sender, EventArgs e)
        {
            _retakeTestType =
                clsApplicationType.Find((int)clsApplicationType.enApplicationTypes.RetakeTest);

            if (_ldlApplication == null || _testType == null || _testAppointment == null)
            {
                MessageBox.Show("Couldn't load form data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ResetUIFields();
            if (Mode == enMode.AddNew)
                lblTestTitle.Text = "Schedule " + ((_trialsCount > 0) ? "Retake Test" : _testType.Title);
            else
                lblTestTitle.Text = "Update Test";

            lblTestTitle.Left = (this.ClientSize.Width - lblTestTitle.Width) / 2;
            dtpAppointmentDate.Format = DateTimePickerFormat.Custom;
            dtpAppointmentDate.CustomFormat = "dd/MM/yy";
            

            LoadDataIntoUIFields();
            CheckAppointmentIsLocked();
        }

        private void ctrSaveBtn1_Click(object sender, EventArgs e)
        {
            if (!LoadUIFieldsIntoTestAppointment())
                return;

            
            if (_testAppointment.Save())
            {
                MessageBox.Show($"Appointment has been {(Mode == enMode.AddNew ? "added" : "updated")} successfully.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show($"Couldn't {(Mode == enMode.AddNew ? "add" : "update")} the appointment", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
