using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsDetainedLicense
    {
        public enum enMode { AddNew, Update };
        private enMode Mode;

        public int DetainID { get; private set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleaseByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }

        public clsDetainedLicense()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = null;
            ReleaseByUserID = null;
            ReleaseApplicationID = null;

            Mode = enMode.AddNew;
        }

        private clsDetainedLicense(int detainID, int licenseID, DateTime detainDate, decimal fineFees,
                                    int createdByUserID, bool isReleased, DateTime? releaseDate,
                                    int? releaseByUserID, int? releaseApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleaseByUserID = releaseByUserID;
            ReleaseApplicationID = releaseApplicationID;

            Mode = enMode.Update;
        }

        private bool _AddNewDetainedLicense()
        {
            this.DetainID = clsDataAccessDetainedLicenses.AddNewDetainedLicenseRecord(
                LicenseID, DetainDate, FineFees, CreatedByUserID);

            Mode = DetainID != -1 ? enMode.Update : enMode.AddNew;

            return DetainID != -1;
        }

        private bool _UpdateDetainedLicense()
        {
            return clsDataAccessDetainedLicenses.UpdateDetainedLicenseRecord(DetainID, IsReleased,
                ReleaseDate, ReleaseByUserID, ReleaseApplicationID);
        }

        public static bool IsDetainedByLicenseID(int licenseID)
        {
            return clsDataAccessDetainedLicenses.IsDetained(licenseID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    return _AddNewDetainedLicense();

                case enMode.Update:
                    return _UpdateDetainedLicense();
            }

            return false;
        }

        public static clsDetainedLicense FindByLicenseID(int licenseID)
        {
            int detainID = -1, createdByUserID = -1;
            DateTime detainDate = DateTime.MinValue;
            decimal fineFees = 0;
            bool isReleased = false;
            DateTime? releaseDate = null;
            int? releaseByUserID = null, releaseApplicationID = null;

            bool isFound = clsDataAccessDetainedLicenses.FindDetainedLicenseByLicenseID(
                 licenseID, ref detainID, ref detainDate, ref fineFees, ref createdByUserID, 
                 ref isReleased, ref releaseDate, ref releaseByUserID, ref releaseApplicationID);

            if (isFound)
            {
                return new clsDetainedLicense(detainID, licenseID, detainDate, fineFees,
                                              createdByUserID, isReleased, releaseDate,
                                              releaseByUserID, releaseApplicationID);
            }

            return null;
        }

        public static DataTable GetAll()
        {
            return clsDataAccessDetainedLicenses.GetAllDetainedLicenses();
        }

    }
}
