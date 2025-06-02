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
        clsLDLApplication _ldlApplication;
        clsTestAppointment _testAppointment;
        clsTestType _testType;
        int _trials;
        decimal retakeTestFees = clsApplicationType.Find(7).Fees;
        public frmScheduleTestAppointment(clsLDLApplication ldlApplication, int testTypeID)
        {
            Mode = enMode.AddNew;
            _ldlApplication = ldlApplication;
            _testType = clsTestType.Find(testTypeID);
            _testAppointment = new clsTestAppointment();
            _trials = clsTest.SpecificTestTrials(_ldlApplication.LocalDrivingLicenseApplicationID, _testType.TestTypeID);

            InitializeComponent();
        }

        public frmScheduleTestAppointment(clsLDLApplication ldlApplication, int testTypeID, int testAppointmentID)
        {
            Mode = enMode.Update;
            _ldlApplication = ldlApplication;
            _testType = clsTestType.Find(testTypeID);
            _testAppointment = clsTestAppointment.Find(testAppointmentID);
            _trials = clsTest.SpecificTestTrials(_ldlApplication.LocalDrivingLicenseApplicationID, _testType.TestTypeID);
            InitializeComponent();
        }

        private void SetGPRetakeTest()
        {
            // Reset values
            lblRetakeTestAppFees.Text = "0";
            lblTotalFees.Text = _testType.Fees.ToString();
            lblRetakeTestAppID.Text = "N/A";
            gpRetakeTestInfo.Enabled = false;

            if (_trials <= 0)
                return;

            switch (Mode)
            {
                case enMode.AddNew:
                    gpRetakeTestInfo.Enabled = true;
                    lblRetakeTestAppFees.Text = retakeTestFees.ToString();
                    lblTotalFees.Text = (_testType.Fees + retakeTestFees).ToString();
                    break;

                case enMode.Update:
                    if (_testAppointment?.RetakeTestApplicationID != null)
                    {
                        gpRetakeTestInfo.Enabled = true;
                        lblRetakeTestAppID.Text = _testAppointment.RetakeTestApplicationID.ToString();
                    }
                    break;
            }
        }

        private int AddNewRetakeTestApplication()
        {
            clsApplication retakeTestApplication = new clsApplication();
            retakeTestApplication.ApplicationTypeID = 7;
            retakeTestApplication.ApplicationDate = DateTime.Now;
            retakeTestApplication.ApplicationPersonID = _ldlApplication.Application.ApplicationPersonID;
            retakeTestApplication.CreatedByUserID = clsGlobalSettings.currentUser.UserID;
            retakeTestApplication.PaidFees = retakeTestFees;

            if (retakeTestApplication.Save())
            {
                return retakeTestApplication.ApplicationID;
            }

            return -1;
        }
       
        private void SetTestAppointmentData()
        {
            var selectedDate = dtpAppointmentDate.Value;
            _testAppointment.AppointmentDate = selectedDate;
            _testAppointment.TestTypeID = _testType.TestTypeID;
            _testAppointment.LDLApplicationID = _ldlApplication.LocalDrivingLicenseApplicationID;
            _testAppointment.CreatedByUserID = clsGlobalSettings.currentUser.UserID;
            _testAppointment.PaidFees = _testType.Fees;

            // retake test
            if (_trials > 0)
            {
                int retakeTestAppID = AddNewRetakeTestApplication();
                if (retakeTestAppID != -1)
                {
                    _testAppointment.RetakeTestApplicationID = retakeTestAppID;
                }
            }
        }
      
        private void SetDataIntoUIFields()
        {
            clsPerson person = _ldlApplication.Application.Person;
            string name = person.FirstName + " " + person.LastName;

            lblDLApplicationID.Text = _ldlApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _ldlApplication.LicenseClass.ClassName.ToString();
            lblName.Text = name;
            lblTrials.Text = _trials.ToString();
            gpTest.Text = _testType.Title;
            lblFees.Text = _testType.Fees.ToString();


            if (_testAppointment.IsLocked)
            {
                dtpAppointmentDate.Enabled = false;
                ctrSaveBtn1.Enabled = false;
            }
        }
      
        private void SetAddEditFrmFields()
        {
            
            if (Mode == enMode.AddNew)
            {
                lblTestTitle.Text = "Schedule " + ((_trials > 0) ? "Retake Test" : _testType.Title);
            }
            else if (Mode == enMode.Update)
            {
                lblTestTitle.Text = "Update " + _testType.Title;
                dtpAppointmentDate.Value = _testAppointment.AppointmentDate;
            }

            SetDataIntoUIFields();
            SetGPRetakeTest();

        }

        private void frmAddEditVisionTestAppointment_Load(object sender, EventArgs e)
        {
            dtpAppointmentDate.Format = DateTimePickerFormat.Custom;
            dtpAppointmentDate.CustomFormat = "dd/MM/yy";

            SetAddEditFrmFields();
        }

        private void ctrSaveBtn1_Click(object sender, EventArgs e)
        {
            SetTestAppointmentData();
            if (_testAppointment.Save())
            {
                MessageBox.Show("Appointment has been added/updated successfully.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Couldn't add/update the appointment");
            }
        }
    }
}
