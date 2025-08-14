using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_BusinessLayer
{
    public class clsLDLApplication: clsApplication
    {      
        private bool _AddNewLDLApplication()
        {
            this.LocalDrivingLicenseApplicationID =
                clsDataAccessLDLApplications.AddNewLDLApplication(ApplicationID, LicenseClassID);

            bool isAdded = LocalDrivingLicenseApplicationID != -1;
            if (isAdded)
                Mode = enMode.Update;

            return isAdded;

        }
       
        private bool _UpdateLDLApplication()
        {
            // update ldlApplication
            return clsDataAccessLDLApplications.UpdateLDLApplication(
                this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID
                );

        }

        enum enMode { AddNew, Update }
        enMode Mode;
        
        public int LocalDrivingLicenseApplicationID { get; private set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo { get; set; }
        
        public static DataTable GetAllApplications()
        {
            return clsDataAccessLDLApplications.GetAllLDLApplicaitons();
        }

        public clsLDLApplication()
        {
            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;
            Mode = enMode.AddNew;
        }

        private clsLDLApplication(
            int localDrivingLicenseApplicationID, int licenseClassID,
            int applicationID, int applicationPersonID, DateTime applicationDate,
            int applicationTypeID, byte applicationStatus, DateTime lastStatusDate,
            decimal paidFees, int createdByUserID
            ) 
            : base (applicationID, applicationPersonID, applicationDate,
            applicationTypeID, applicationStatus, lastStatusDate,
            paidFees, createdByUserID)
        {
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            LicenseClassID = licenseClassID;
            LicenseClassInfo = clsLicenseClass.Find(licenseClassID);
            
            Mode = enMode.Update;
        }

        public static bool Delete(int ldlApplicationID)
        {
            // find applicationID
            var applicationID = clsLDLApplication.FindByLDLApplicationID(ldlApplicationID)?.ApplicationID;
            if (applicationID == null)
                return false;

            // delete ldl application
            if (!clsDataAccessLDLApplications.DeleteLDLApplicationByID(ldlApplicationID))
                return false;

            // delete application
            return clsApplication.Delete((int)applicationID);
 
        }

        public static bool Cancel(int ldlApplicationID)
        {
            clsLDLApplication ldlApplication = clsLDLApplication.FindByLDLApplicationID(ldlApplicationID);

            if (ldlApplication != null)
                return clsApplication.Cancel(ldlApplication.ApplicationID);
            
            return false;
        }

        public static clsLDLApplication FindByLDLApplicationID(int ldlAplicationID)
        {
            int applicationID = -1, licenseClassID = -1;
            bool isFound = 
                clsDataAccessLDLApplications.FindLDLApplicationByID(ldlAplicationID, ref applicationID, ref licenseClassID);

            if (!isFound)
                return null;
            
            clsApplication baseApplication = clsApplication.FindBaseApplicationByID(applicationID);
            
            if (baseApplication != null)
            {
                return new clsLDLApplication(ldlAplicationID, licenseClassID, applicationID,
                    baseApplication.ApplicationPersonID, baseApplication.ApplicationDate,
                    baseApplication.ApplicationTypeID, baseApplication.ApplicationStatus,
                    baseApplication.LastStatusDate, baseApplication.PaidFees,
                    baseApplication.CreatedByUserID);
            }
            else
                return null;

        }

        public static bool IsAlreadyExist(int applicationID, int licenseClassID)
        {
            return clsDataAccessLDLApplications.DoesPersonHaveActiveOrCompleteApplication(applicationID, licenseClassID);
        }
        
        public byte GetPassedTestsCount()
        {
            return clsTest.PassedTestsCount(this.LocalDrivingLicenseApplicationID);
        }

        public bool IsPassedTest(int testTypeID)
        {
            return
                clsTest.IsLDLApplicationTestPassed(this.LocalDrivingLicenseApplicationID, testTypeID);
        }
     
        public bool HasActiveAppointmentPerTestType(int testTypeID)
        {
            return clsTestAppointment.IsActiveAppointmentExist(this.LocalDrivingLicenseApplicationID, testTypeID);
        }

        public int GetTestTrialsPerTestType(int testTypeID)
        {
            return clsTest.LDLApplicationTestTrials(this.LocalDrivingLicenseApplicationID, testTypeID);
        }

        public bool Save()
        {
            base.Mode = (clsApplication.enMode)this.Mode;
            // Application
            if (!base.Save()) 
                return false;

            // Local Driving License Application
            switch (Mode)
            {
                case enMode.AddNew:
                    return _AddNewLDLApplication();
                case enMode.Update:
                    return _UpdateLDLApplication();
            }

            return false;
        }
    }
}
