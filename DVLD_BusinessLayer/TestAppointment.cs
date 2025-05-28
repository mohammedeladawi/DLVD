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
        private bool _UpdateAppointmentDate()
        {
            return clsDataAccessTestAppointments.UpdateTestAppointmentDate(TestAppointmentID, AppointmentDate);
        }
        private enum enMode { AddNew, Update}
        enMode Mode;

        public int TestAppointmentID {get; private set;}
        public int LDLApplicationID { get; set; }
        public int TestTypeID { get; set; }
        public DateTime AppointmentDate { get; set; } 
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public int? RetakeTestApplicationID { get; set; }

        public static bool IsActiveAppointmentExist(int ldlApplicationID)
        {
            return clsDataAccessTestAppointments.IsActiveAppointmentExist(ldlApplicationID);
        }
        public static DataTable GetAllTestAppointmentsByLDLAppID(int ldlApplicationID)
        {
            return clsDataAccessTestAppointments.GetAllTestAppointmenstByLDLAppID(ldlApplicationID);
        }

        public clsTestAppointment()
        {
            TestAppointmentID = -1;
            LDLApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            RetakeTestApplicationID = null;
            Mode = enMode.AddNew;
        }

        private clsTestAppointment(int testAppointmentID, int testTypeID, int ldlApplicationID,
            DateTime appointmentDate, decimal paidFees, int createdByUserID, int? retakeTestApplicationID)
        {
            TestAppointmentID = testAppointmentID;
            TestAppointmentID = testTypeID;
            LDLApplicationID = ldlApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
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
            int createdByUserID = -1;
            int? retakeTestApplicationID = null;

            bool isFound = clsDataAccessTestAppointments.FindByTestAppointmentID(testAppointmentID, ref testTypeID,
                ref ldlApplicationID, ref appointmentDate, ref paidFees, ref createdByUserID, ref retakeTestApplicationID);
            if (isFound)
                return new clsTestAppointment(testAppointmentID, testTypeID,
                ldlApplicationID, appointmentDate, paidFees, createdByUserID, retakeTestApplicationID);
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
                    return _UpdateAppointmentDate();
            }

            return false;
        }
    }
}
