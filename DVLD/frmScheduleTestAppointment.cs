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
    public partial class frmScheduleTestAppointment: Form
    {
        enum enMode { AddNew, Update}
        enMode Mode;
        clsLDLApplication _ldlApplication;
        clsTestAppointment _testAppointment;
        clsTestType _testType;
        public frmScheduleTestAppointment(clsLDLApplication ldlApplication, int testTypeID)
        {
            Mode = enMode.AddNew;
            _ldlApplication = ldlApplication;
            _testType = clsTestType.Find(testTypeID);
            _testAppointment = new clsTestAppointment();
            InitializeComponent();
        }

        public frmScheduleTestAppointment(clsLDLApplication ldlApplication, int testTypeID, int testAppointmentID)
        {
            Mode = enMode.Update;
            _ldlApplication = ldlApplication;
            _testType = clsTestType.Find(testTypeID);
            _testAppointment = clsTestAppointment.Find(testAppointmentID);
            InitializeComponent();
        }

        private void SetGPRetakeTest(int trials)
        {
            // ------ ToDo: Get Trials the right way ----------//
            if (trials > 0)
            {
                decimal retakeTestFees = clsApplicationType.Find(7).Fees;
                gpRetakeTestInfo.Enabled = true;
                lblRetakeTestAppFees.Text = retakeTestFees.ToString();
                lblTotalFees.Text = (retakeTestFees + _testType.Fees).ToString();
            }
            else
            {
                decimal retakeTestFees = clsApplicationType.Find(7).Fees;
                gpRetakeTestInfo.Enabled = false;
                lblRetakeTestAppFees.Text = "0";
                lblTotalFees.Text = _testType.Fees.ToString();
                lblRetakeTestAppID.Text = "N/A";
            }
        }

        private void SetTestAppointmentInfo()
        {
            // ---- To Do Get Test Trials -------//
            int trials = 0;
            clsPerson person = _ldlApplication.Application.Person;
            string name = person.FirstName + " " + person.LastName;
            
            if (Mode == enMode.AddNew)
            {
                lblTestTitle.Text = "Schedule " + _testType.Title;
                lblDLApplicationID.Text = _ldlApplication.LocalDrivingLicenseApplicationID.ToString();
                lblLicenseClass.Text = _ldlApplication.LicenseClass.ClassName.ToString();
                lblName.Text = name;
                lblTrials.Text = trials.ToString();
                gpTest.Text = _testType.Title;
                lblFees.Text = _testType.Fees.ToString();
            }
            else if (Mode == enMode.Update)
            {
                //----- TODO Update Logic ---------

            }

            SetGPRetakeTest(trials);

        }

        private void frmAddEditVisionTestAppointment_Load(object sender, EventArgs e)
        {
            SetTestAppointmentInfo();
        }
    }
}
