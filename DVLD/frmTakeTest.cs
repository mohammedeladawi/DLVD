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
    public partial class frmTakeTest : Form
    {
        clsTestAppointment _testAppointment;
        clsTestType _testType;
        clsLDLApplication _ldlApplication;
        public frmTakeTest(int testTypeID, int testAppointmentID)
        {
            _testAppointment = clsTestAppointment.Find(testAppointmentID);
            _testType = clsTestType.Find(testTypeID);
            _ldlApplication = clsLDLApplication.FindByLDLApplicationID(_testAppointment.LDLApplicationID);
            InitializeComponent();
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            // New Test 
            lblTestTitle.Text = "Schedule Test";
            gbTestType.Text = _testType.Title.ToString();
            lblLDLApplicationID.Text = _ldlApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDClass.Text = clsLicenseClass.Find(_ldlApplication.LicenseClassID).ClassName;
            lblName.Text = _ldlApplication.ApplicationPersonInfo.FirstName + " " + _ldlApplication.ApplicationPersonInfo.LastName;
            lblTrial.Text = clsTest.SpecificTestTrials(_ldlApplication.ApplicationID, _testType.TestTypeID).ToString();
            lblDate.Text = _testAppointment.AppointmentDate.ToString();
            lblFees.Text = _testType.Fees.ToString();

        }

        private void LoadUIFieldsIntoTest(clsTest test)
        {
            test.TestAppointmentID = _testAppointment.TestAppointmentID;
            test.TestResult = rbPass.Checked;
            test.Notes = txtNotes.Text;
            test.CreatedByUserID = clsGlobal.currentUser.UserID;
        }
        private void ctrSaveBtn1_Click(object sender, EventArgs e)
        {
            clsTest test = new clsTest();
            LoadUIFieldsIntoTest(test);
            if (test.Save())
            {
                MessageBox.Show("Test result has been added succesfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Couldn't add test result");
            }

        }
    }
}
