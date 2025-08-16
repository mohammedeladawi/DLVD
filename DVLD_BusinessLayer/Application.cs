using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_BusinessLayer
{
    public class clsApplication
    {
        private bool _AddNewApplication()
        {
            
            this.ApplicationID = clsDataAccessApplications.AddNewApplication(ApplicationPersonID, ApplicationDate,
                ApplicationTypeID, ApplicationStatus, PaidFees, CreatedByUserID);

            bool isAdded = ApplicationID != -1;
            if (isAdded)
                Mode = enMode.Update;

            return isAdded;
        }

        private bool _UpdateApplication()
        {

            return clsDataAccessApplications.UpdateApplication(
                this.ApplicationID, this.ApplicationPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        protected enum enMode { AddNew, Update }
        protected enMode Mode;
        
        public enum enApplicationStatus
        {
            New = 1,
            Cancelled = 2,
            Completed = 3
        }

        public int ApplicationID { get; protected set; }
        public int ApplicationPersonID { get; set; }
        public clsPerson ApplicationPersonInfo { get; private set; }
        public DateTime ApplicationDate {get; set;}
        public int ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationTypeInfo { get; private set; }
        public byte ApplicationStatus { get; set; }
        public DateTime LastStatusDate {get; set;}
        public decimal PaidFees { get; set;}
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo { get; private set; }

        public string StatusText
        {
            get
            {
                switch((enApplicationStatus) ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unkown";
                }
            }
        }

        // new
        public clsApplication()
        {
            ApplicationID = -1;
            ApplicationPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            ApplicationStatus = (byte) enApplicationStatus.New;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
           
            Mode = enMode.AddNew;
        }

        // update
        protected clsApplication(
            int applicationID, int applicationPersonID, DateTime applicationDate,
            int applicationTypeID, byte applicationStatus, DateTime lastStatusDate,
            decimal paidFees, int createdByUserID)
        {
            ApplicationID = applicationID;
            ApplicationPersonID = applicationPersonID;
            ApplicationPersonInfo = clsPerson.Find(ApplicationPersonID);
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationTypeInfo = clsApplicationType.Find(applicationTypeID);
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            CreatedByUserInfo = clsUser.Find(CreatedByUserID);

            Mode = enMode.Update;
        }



        // --- ToDo: Protected in the future --------// 
        public static clsApplication FindBaseApplicationByID(int applicationID)
        {
            int applicationPersonID = -1;
            DateTime applicationDate = DateTime.MinValue;
            int applicationTypeID = -1;
            byte applicationStatus =(byte) enApplicationStatus.New;
            DateTime lastStatusDate = DateTime.MinValue;
            decimal paidFees = 0;
            int createdByUserID = -1;

            bool isFound = clsDataAccessApplications.FindApplicationByID(applicationID, ref applicationPersonID,
                ref  applicationDate, ref applicationTypeID, ref applicationStatus, ref lastStatusDate, ref paidFees, ref createdByUserID);

            if (isFound)
                return new clsApplication(applicationID, applicationPersonID, applicationDate, 
                    applicationTypeID, applicationStatus, lastStatusDate, paidFees, createdByUserID);

            return null;
        }

        // ---------------------------------------------
        protected static bool Delete(int applicationID)
        {
            return clsDataAccessApplications.DeleteApplicationByID(applicationID);
        }
        
        public static bool Complete(int applicationID)
        {
            return clsDataAccessApplications.UpdateApplicationStatus(applicationID, (byte) enApplicationStatus.Completed);
        }
        
        public bool Complete()
        {
            return Complete(this.ApplicationID);
        }
        public static bool Cancel (int applicationID)
        {
            return clsDataAccessApplications.UpdateApplicationStatus(applicationID, (byte) enApplicationStatus.Cancelled);
        }

        // Todo: protected in the future
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    return _AddNewApplication();
                case enMode.Update:
                    return _UpdateApplication();
            }

            return false;
        }

    }
}
