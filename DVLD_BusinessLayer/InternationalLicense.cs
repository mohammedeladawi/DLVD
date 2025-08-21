using System;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsInternationalLicense
    {
        private enum enMode { AddNew, Update }
        private enMode Mode;

        public int InternationalLicenseID { get; private set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public clsDriver DriverInfo { get; private set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public clsInternationalLicense()
        {
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = false;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsInternationalLicense(
            int internationalLicenseID,
            int applicationID,
            int driverID,
            int issuedUsingLocalLicenseID,
            DateTime issueDate,
            DateTime expirationDate,
            bool isActive,
            int createdByUserID)
        {
            InternationalLicenseID = internationalLicenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            DriverInfo = clsDriver.Find(driverID);
            IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            CreatedByUserID = createdByUserID;

            Mode = enMode.Update;
        }

        private bool _AddNewInternationalLicense()
        {
            var application = clsApplication.FindBaseApplicationByID(ApplicationID);
            if (application == null)
                return false;

            this.InternationalLicenseID = clsDataAccessInternationalLicenses.AddNewInternationalLicense(
                ApplicationID,
                DriverID,
                IssuedUsingLocalLicenseID,
                IssueDate,
                ExpirationDate,
                IsActive,
                CreatedByUserID
            );

            if (InternationalLicenseID != -1)
                Mode = enMode.Update;

            return InternationalLicenseID != -1;
        }
        public static DataTable GetInternationalLicensesByDriverID(int driverID)
        {
            return clsDataAccessInternationalLicenses.GetInternationalLicensesByDriverID(driverID);
        }
        public static DataTable GetAllInternationalLicenses()
        {
            return clsDataAccessInternationalLicenses.GetAllInternationalLicenses();
        }
              
        public static clsInternationalLicense FindByID(int internationalLicenseID)
        {
            int applicationID = -1,
                driverID = -1,
                issuedUsingLocalLicenseID = -1,
                createdByUserID = -1;

            DateTime issueDate = DateTime.MinValue,
                     expirationDate = DateTime.MinValue;

            bool isActive = false;

            bool isFound = clsDataAccessInternationalLicenses.FindInternationalLicenseByID(
                internationalLicenseID,
                ref applicationID,
                ref driverID,
                ref issuedUsingLocalLicenseID,
                ref issueDate,
                ref expirationDate,
                ref isActive,
                ref createdByUserID
            );

            if (isFound)
            {
                return new clsInternationalLicense(
                    internationalLicenseID,
                    applicationID,
                    driverID,
                    issuedUsingLocalLicenseID,
                    issueDate,
                    expirationDate,
                    isActive,
                    createdByUserID
                );
            }

            return null;
        }
        
        public static clsInternationalLicense FindByLocalLicenseID(int localLicenseID)
        {
            int internationalLicenseID = -1, applicationID = -1,
                      driverID = -1,
                      createdByUserID = -1;

            DateTime issueDate = DateTime.MinValue,
                     expirationDate = DateTime.MinValue;

            bool isActive = false;

            bool isFound = clsDataAccessInternationalLicenses.FindByLocalLicenseID(
                ref internationalLicenseID,
                ref applicationID,
                ref driverID,
                localLicenseID,
                ref issueDate,
                ref expirationDate,
                ref isActive,
                ref createdByUserID
            );

            if (isFound)
            {
                return new clsInternationalLicense(
                    internationalLicenseID,
                    applicationID,
                    driverID,
                    localLicenseID,
                    issueDate,
                    expirationDate,
                    isActive,
                    createdByUserID
                );
            }

            return null;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    return _AddNewInternationalLicense();
                case enMode.Update:
                    // Update logic here if needed
                    return false;
            }

            return false;
        }
    }
}