using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLDLApplication
    {

        private bool _IsAllowedAge()
        {
            int applicantPersonAge = DateTime.Now.Year - Application.Person.DateOfBirth.Year;
            clsLicenseClass licenseClass = clsLicenseClass.Find(LicenseClassID);
            return licenseClass.MinmumAllowedAge <= applicantPersonAge;
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

        //--------------------- ToDo if needed --------------
        private bool _UpdateLDLApplication()
        {
            return false;
        }

        enum enMode { AddNew, Update }
        enMode Mode;

        public int _ApplicationID;
        public int LocalDrivingLicenseApplicationID { get; private set; }
        public int ApplicationID
        {
            get
            {
                return _ApplicationID;
            }
            set
            {
                _ApplicationID = value;
                Application = clsApplication.Find(_ApplicationID);
            }
        }
        public int LicenseClassID { get; set; }

        public clsApplication Application;

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
            Application.ApplicationTypeID = 1;
        }

        private clsLDLApplication(int localDrivingLicenseApplicationID, int applicationID, int licenseClassID)
        {
            Mode = enMode.Update;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            ApplicationID = applicationID;
            LicenseClassID = licenseClassID;
        }

        //---------------- ToDo ---------------
        public static bool Delete()
        { 
            return false;
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
                    return false;
            }

            return false;
        }
    }
}
