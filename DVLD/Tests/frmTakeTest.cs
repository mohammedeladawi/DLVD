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
        private clsTestAppointment _testAppointment;
        private clsTestType _testType;
        private clsLDLApplication _ldlApplication;
        public frmTakeTest(int testTypeID, int testAppointmentID)
        {
            InitializeComponent();
            
            _testAppointment = clsTestAppointment.Find(testAppointmentID);
            _testType = clsTestType.Find(testTypeID);
            _ldlApplication = clsLDLApplication.FindByLDLApplicationID(_testAppointment.LDLApplicationID);
        }

        private void LoadDataIntoUIFields()
        {
            lblTestTitle.Text = "Schedule Test";
            gbTestType.Text = _testType.Title.ToString();
            lblLDLApplicationID.Text = _ldlApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDClass.Text = _ldlApplication.LicenseClassInfo.ClassName;
            lblName.Text = _ldlApplication.ApplicationPersonInfo.FirstName + " " + _ldlApplication.ApplicationPersonInfo.LastName;
            lblTrial.Text = _ldlApplication.GetTestTrialsPerTestType(_testType.TestTypeID).ToString();
            lblDate.Text = _testAppointment.AppointmentDate.ToString();
            lblFees.Text = _testType.Fees.ToString();
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            if (_testAppointment == null || _testType == null || _ldlApplication == null)
            {
                MessageBox.Show("Couldn't load form data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblTestTitle.Text = _testType.Title;
            LoadDataIntoUIFields();

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
                MessageBox.Show("Test result has been added succesfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Couldn't add test result", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
