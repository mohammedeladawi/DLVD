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
        enum enMode { AddNew, Update }
        enMode Mode;

        public int LocalDrivingLicenseApplicationID { get; private set; }
        public int ApplicationID { get; private set; }
        public int LicenseClassID { get; set; }

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
        }

        private clsLDLApplication(int localDrivingLicenseApplicationID, int applicationID, int licenseClassID)
        {
            Mode = enMode.Update;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            ApplicationID = applicationID;
            LicenseClassID = licenseClassID;
        }
    }
}
