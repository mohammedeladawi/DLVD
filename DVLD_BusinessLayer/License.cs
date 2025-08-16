using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsLicense
    {
        private string _GetIssueReasonText(byte issueReason)
        {
            switch ((enIssueReasons)issueReason)
            {
                case enIssueReasons.FirstTime:
                    return "First Time";
                case enIssueReasons.Renew:
                    return "Renew";
                case enIssueReasons.ReplacementForDamaged:
                    return "Replacement For Damaged";
                case enIssueReasons.ReplacementForLost:
                    return "Replacement For Lost";
                default:
                    return "None";
            }
        }
        private enum enMode { AddNew, Update };
        enMode Mode;

        public enum enIssueReasons
        {
            FirstTime = 1,
            Renew = 2,
            ReplacementForDamaged = 3,
            ReplacementForLost = 4
        }
       
        public int LicenseID {  get; private set; }
        public int ApplicationID { get; set; }
        public clsApplication ApplicationInfo { get; private set; }
        
        public int DriverID { get; set; }

        public clsDriver DriverInfo { get; private set; }
        
        public int LicenseClassID {  get; set; }
        public clsLicenseClass LicenseClassInfo { get; private set; }

        public DateTime IssuanceDate { get; set; } 
        
        public DateTime ExpirationDate { get; set; }
       
        public string Notes { get; set; }

        public decimal PaidFees { get; set; }

        public bool IsActive { get; set; }

        public byte IssueReason { get; set; }

        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo { get; private set; }

        public string IssueReasonText
        {
            get
            {
                return _GetIssueReasonText(IssueReason);
            }
        }

        public bool IsDetained
        {
            get
            {
                return clsDetainedLicense.IsDetainedByLicenseID(this.LicenseID);
            }
        }
       
        
        private bool _UpdateLicense()
        {
            return clsDataAccessLicenses.UpdateLicense(LicenseID, IsActive);
        }
        private bool _AddNewLicense()
        {
            this.LicenseID = clsDataAccessLicenses.AddNewLicense(ApplicationID, DriverID, LicenseClassID, IssuanceDate, 
                                                                 ExpirationDate, Notes, PaidFees, IsActive, IssueReason, 
                                                                 CreatedByUserID);
            if (LicenseID != -1)
                Mode = enMode.Update;

            return LicenseID != -1;
        }

        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssuanceDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = string.Empty;
            PaidFees = 0;
            IsActive = false;
            IssueReason = 0;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;

        }

        private clsLicense(
           int licenseID,
           int applicationID,
           int driverID,
           int licenseClassID,
           DateTime issuanceDate,
           DateTime expirationDate,
           string notes,
           decimal paidFees,
           bool isActive,
           byte issueReason,
           int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            ApplicationInfo = clsApplication.FindBaseApplicationByID(applicationID);
            DriverID = driverID;
            DriverInfo = clsDriver.Find(driverID);
            LicenseClassID = licenseClassID;
            LicenseClassInfo = clsLicenseClass.Find(licenseClassID);
            IssuanceDate = issuanceDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
            CreatedByUserInfo = clsUser.Find(createdByUserID);

            Mode = enMode.Update;
        }

        public static clsLicense FindByAppID(int applicationID)
        {
            int licenseID = -1,
                driverID = -1,
                licenseClassID = -1,
                createdByUserID = -1;

            DateTime issuanceDate = DateTime.MinValue,
                     expirationDate = DateTime.MinValue;

            string notes = string.Empty;

            decimal paidFees = 0;
            bool isActive = false;
            byte issueReason = 0;

            bool isFound = clsDataAccessLicenses.FindByApplicationID(
                ref licenseID,
                applicationID,
                ref driverID,
                ref licenseClassID,
                ref issuanceDate,
                ref expirationDate,
                ref notes,
                ref paidFees,
                ref isActive,
                ref issueReason,
                ref createdByUserID
            );

            if (isFound)
            {
                return new clsLicense(
                    licenseID,
                    applicationID,
                    driverID,
                    licenseClassID,
                    issuanceDate,
                    expirationDate,
                    notes,
                    paidFees,
                    isActive,
                    issueReason,
                    createdByUserID
                );
            }

            return null;
        }
        
        public static clsLicense FindByLicenseID(int licenseID)
        {
            int applicationID = -1,
                driverID = -1,
                licenseClassID = -1,
                createdByUserID = -1;

            DateTime issuanceDate = DateTime.MinValue,
                     expirationDate = DateTime.MinValue;

            string notes = string.Empty;

            decimal paidFees = 0;
            bool isActive = false;
            byte issueReason = 0;

            bool isFound = clsDataAccessLicenses.FindByLicenseID(
                licenseID,
                ref applicationID,
                ref driverID,
                ref licenseClassID,
                ref issuanceDate,
                ref expirationDate,
                ref notes,
                ref paidFees,
                ref isActive,
                ref issueReason,
                ref createdByUserID
            );

            if (isFound)
            {
                return new clsLicense(
                    licenseID,
                    applicationID,
                    driverID,
                    licenseClassID,
                    issuanceDate,
                    expirationDate,
                    notes,
                    paidFees,
                    isActive,
                    issueReason,
                    createdByUserID
                );
            }

            return null;
        }
        
        public static DataTable GetLicensesByDriverID(int driverID)
        {
            return clsDataAccessLicenses.GetLicensesByDriverID(driverID);
        }

        public static int GetActiveLicenseIDByPersonID(int personID, int licenseClassID)
        {
            return clsDataAccessLicenses.GetActiveLicenseIDByPerson(personID, licenseClassID);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    return _AddNewLicense();

                case enMode.Update:
                    return _UpdateLicense();
            }

            return false;
        }


    }
}
