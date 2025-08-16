using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsTest
    {
        private bool _AddNewTest()
        {
            clsTestAppointment testApointment = clsTestAppointment.Find(TestAppointmentID);
            testApointment.IsLocked = true;
            testApointment.Save();

            TestAppointmentID = clsDataAccessTests.AddNewTest(TestAppointmentID ,TestResult, Notes, CreatedByUserID);

            return TestAppointmentID != -1;
        }

        public int TestID { get; private set; }

        public int TestAppointmentID { get; set; }

        public bool TestResult { get; set; }

        public string Notes { get; set; }

        public int CreatedByUserID { get; set; }


        public clsTest()
        {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = string.Empty;
            CreatedByUserID = -1;
        }

        private clsTest(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            Notes = notes;
            CreatedByUserID = createdByUserID;
        }

        public static byte PassedTestsCount(int ldlApplicationID)
        {
            return clsDataAccessTests.PassedTestsCount(ldlApplicationID);
        }

        public static int LDLApplicationTestTrials(int ldlApplicaitonID, int testTypeID)
        {
            return clsDataAccessTests.LDLApplicationTestTrials(ldlApplicaitonID, testTypeID);
        }

        public static bool IsLDLApplicationTestPassed(int ldlApplicationID, int testTypeID)
        {
            return clsDataAccessTests.IsApplicationTestPassed(ldlApplicationID, testTypeID);
        }

        public static bool HasPassedAllTests(int ldlApplicationID)
        {
            return PassedTestsCount(ldlApplicationID) == 3;
        }

        public bool Save()
        {
            return _AddNewTest();
        }
    }
}
