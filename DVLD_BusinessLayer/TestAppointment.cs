using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsTestAppointment
    {
        private bool _AddNewAppointment()
        {
            this.TestAppointmentID = clsDataAccessTestAppointments.AddNewTestAppointment
                (TestTypeID, LDLApplicationID, AppointmentDate, PaidFees, CreatedByUserID, RetakeTestApplicationID);

            bool isAdded = TestAppointmentID != -1;
            if (isAdded)
                Mode = enMode.Update;
                

            return isAdded;
        }
        private bool _UpdateAppointment()
        {
            return clsDataAccessTestAppointments.UpdateTestAppointment(TestAppointmentID, AppointmentDate, IsLocked);
        }
        private enum enMode { AddNew, Update}
        enMode Mode;

        public int TestAppointmentID {get; private set;}
        public int LDLApplicationID { get; set; }
        public int TestTypeID { get; set; }
        public DateTime AppointmentDate { get; set; } 
        public decimal PaidFees { get; set; }
        public bool IsLocked { get; set; }
        public int CreatedByUserID { get; set; }
        public int RetakeTestApplicationID { get; set; }

        public static bool IsActiveAppointmentExist(int ldlApplicationID, int testTypeID)
        {
            return clsDataAccessTestAppointments.
                IsActiveAppointmentExist(ldlApplicationID, testTypeID);
        }
        public static DataTable GetApplicationTestAppointmentsPerTestType(int ldlApplicationID, int testTypeID)
        {
            return clsDataAccessTestAppointments.GetAllTestAppointmenstByLDLAppID(ldlApplicationID, testTypeID);
        }

        public clsTestAppointment()
        {
            TestAppointmentID = -1;
            TestTypeID = -1;
            LDLApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            IsLocked = false;
            CreatedByUserID = -1;
            RetakeTestApplicationID = -1;
            Mode = enMode.AddNew;
        }

        private clsTestAppointment(int testAppointmentID, int testTypeID, int ldlApplicationID,
            DateTime appointmentDate, decimal paidFees, bool isLocked, int createdByUserID, int retakeTestApplicationID)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LDLApplicationID = ldlApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            IsLocked = isLocked;
            CreatedByUserID = createdByUserID;
            RetakeTestApplicationID = retakeTestApplicationID;
            Mode = enMode.Update;
        }

        public static clsTestAppointment Find(int testAppointmentID)
        {
            int testTypeID = -1;
            int ldlApplicationID = -1;
            DateTime appointmentDate = DateTime.Now;
            decimal paidFees = 0;
            bool isLocked = false;
            int createdByUserID = -1;
            int retakeTestApplicationID = -1;

            bool isFound = clsDataAccessTestAppointments.FindByTestAppointmentID(testAppointmentID, ref testTypeID,
                ref ldlApplicationID, ref appointmentDate, ref paidFees, ref isLocked, ref createdByUserID, ref retakeTestApplicationID);
            if (isFound)
                return new clsTestAppointment(testAppointmentID, testTypeID,
                ldlApplicationID, appointmentDate, paidFees, isLocked, createdByUserID, retakeTestApplicationID);
            else
                return null;
        }
        
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    return _AddNewAppointment();
                case enMode.Update:
                    return _UpdateAppointment();
            }

            return false;
        }
    }
}
