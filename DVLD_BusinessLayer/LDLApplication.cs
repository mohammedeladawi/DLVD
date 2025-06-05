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
    public class clsLDLApplication
    {
        public enum enApplicationType
        {
            LocalDrivingLicense = 1,
        }

        private bool _IsAllowedAge()
        {
            int age = DateTime.Today.Year - Application.Person.DateOfBirth.Year;
            if (Application.Person.DateOfBirth.Date > DateTime.Today.AddYears(-age))
                age--;
            return LicenseClass.MinmumAllowedAge <= age;

        }
        private bool _AddNewLDLApplication()
        {
            bool IsDoublicate = clsApplication.IsExist(Application.ApplicationPersonID, LicenseClassID);
            if (_IsAllowedAge() && !IsDoublicate)
            {
                // add new application
                if (!Application.Save())
                    return false;

                this.ApplicationID = Application.ApplicationID;

                // add new ldl application
                this.LocalDrivingLicenseApplicationID =
                    clsDataAccessLDLApplications.AddNewLDLApplication(ApplicationID, LicenseClassID);

                bool isAdded = LocalDrivingLicenseApplicationID != -1;
                if (isAdded)
                    Mode = enMode.Update;

                return isAdded;
            }

            return false;
        }
        private bool _UpdateLDLApplication()
        {
            bool IsDoublicate = clsApplication.IsExist(Application.ApplicationPersonID, LicenseClassID);
            if (!IsDoublicate)
            {
                // update ldlApplication
                return 
                    clsDataAccessLDLApplications.UpdateLDLApplication(LocalDrivingLicenseApplicationID, LicenseClassID);

            }
            return false;
        }

        enum enMode { AddNew, Update }
        enMode Mode;

        private int _ApplicationID;
        private int _LicenseClassID;
        public int LocalDrivingLicenseApplicationID { get; private set; }
        public int ApplicationID
        {
            get
            {
                return _ApplicationID;
            }
           private set
            {
                _ApplicationID = value;
                Application = clsApplication.Find(_ApplicationID);
            }
        }
        public int LicenseClassID 
        {
            get
            {
                return _LicenseClassID;
            }

            set
            {
                _LicenseClassID = value;
                if (_LicenseClassID != -1)
                    LicenseClass = clsLicenseClass.Find(_LicenseClassID);
            }
        }
        
        public clsLicenseClass LicenseClass { get; set; }
        
        public clsApplication Application { get; set; }

        public static DataTable GetAllApplications()
        {
            return clsDataAccessLDLApplications.GetAllLDLApplicaitons();
        }

        public clsLDLApplication()
        {
            Mode = enMode.AddNew;
            LocalDrivingLicenseApplicationID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;

            // application logic
            Application = new clsApplication();
            Application.ApplicationTypeID = (int)enApplicationType.LocalDrivingLicense;
        }

        private clsLDLApplication(int localDrivingLicenseApplicationID, int applicationID, int licenseClassID)
        {
            Mode = enMode.Update;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            ApplicationID = applicationID;
            LicenseClassID = licenseClassID;
        }

        public static bool Delete(int ldlApplicationID)
        {
            // find applicationID
            var applicationID = clsLDLApplication.FindByID(ldlApplicationID)?.ApplicationID;
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
            clsLDLApplication ldlApplication = FindByID(ldlApplicationID);

            if (ldlApplication != null)
                return clsApplication.Cancel(ldlApplication.ApplicationID);
            
            return false;
        }

        public static clsLDLApplication FindByID(int ldlAplicationID)
        {
            int applicationID = -1;
            int licenseClassID = -1;
            bool isFound = 
                clsDataAccessLDLApplications.FindLDLApplicationByID(ldlAplicationID, ref applicationID, ref licenseClassID);

            if (isFound)
                return new clsLDLApplication(ldlAplicationID, applicationID, licenseClassID);
            else
                return null;

        }
        public bool Save()
        {
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
