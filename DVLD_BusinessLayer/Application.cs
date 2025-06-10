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
                ApplicationTypeID, PaidFees, CreatedByUserID);

            bool isAdded = ApplicationID != -1;
            if (isAdded)
                Mode = enMode.Update;

            return isAdded;
        }

        //--------------------- ToDo if needed --------------
        private bool _UpdateApplication()
        {
            return false;
        }

        enum enMode { AddNew, Update }
        enMode Mode;

        private int _ApplicationPersonID;
        private byte _ApplicationTypeID;
        public clsPerson Person { get; private set; }
        public clsApplicationType ApplicationType;
        public int ApplicationID { get; private set; }
        public int ApplicationPersonID
        {
            get
            {
                return _ApplicationPersonID;
            }

            set
            {
                _ApplicationPersonID = value;
                Person = clsPerson.FindByID(_ApplicationPersonID);
            }
        }
        public DateTime ApplicationDate {get; set;}
        public byte ApplicationTypeID 
        {
            get
            {
                return _ApplicationTypeID;
            }
            set
            {
                _ApplicationTypeID = value;
                ApplicationType = clsApplicationType.Find(ApplicationTypeID);
            }
        }
        public byte ApplicationStatus { get; set; }
        public DateTime LastStatusDate {get; set;}
        public decimal PaidFees { get; set;}
        public int CreatedByUserID { get; set; }

        // new
        public clsApplication()
        {
            Mode = enMode.AddNew;
            ApplicationID = -1;
            ApplicationPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID =0;
            ApplicationStatus = 0;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
        }

        // update
        private clsApplication(
            int applicationID, int applicationPersonID, DateTime applicationDate,
            byte applicationTypeID, byte applicationStatus, DateTime lastStatusDate,
            decimal paidFees, int createdByUserID)
        {
            Mode = enMode.Update;
            ApplicationID = applicationID;
            ApplicationPersonID = applicationPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
        }


        public static clsApplication Find(int applicationID)
        {
            int applicationPersonID = -1;
            DateTime applicationDate = DateTime.MinValue;
            byte applicationTypeID = 0;
            byte applicationStatus = 0;
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

        public static bool IsExist(int applicationID, int licenseClassID)
        {
            return clsDataAccessApplications.IsSameApplicationExist(applicationID, licenseClassID);
        }

        public static bool Delete(int applicationID)
        {
            return clsDataAccessApplications.DeleteApplicationByID(applicationID);
        }
                
        public static bool Complete(int applicationID)
        {
            return clsDataAccessApplications.CompleteApplicationByID(applicationID);
        }
                
        public static bool Cancel (int applicationID)
        {
            return clsDataAccessApplications.CancelApplicationByID(applicationID);
        }

        public bool Save()
        {
            switch (Mode)
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
