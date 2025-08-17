using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsDriver
    {
        private enum enMode { AddNew, Update };
        enMode Mode;
        private bool _AddNewDriver()
        {
            this.DriverID = clsDataAccessDrivers.AddNewDriver(PersonID, CreatedByUserID, CreatedDate);
            if (DriverID != -1)
                Mode = enMode.Update;

            return DriverID != -1;
        }

        public int DriverID {get; private set;}
        public int PersonID {get; set;}
        public int CreatedByUserID { get; set; }
        public clsPerson PersonInfo {  get; private set; }
        public DateTime CreatedDate { get; set; }


        public clsDriver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
            Mode = enMode.AddNew;
        }

        public clsDriver(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            PersonInfo = clsPerson.Find(PersonID);
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
            Mode = enMode.Update;
        }

        public static clsDriver Find(int driverID)
        {
            int personID = -1;
            int createdByUserID = -1;
            DateTime createdDate = DateTime.MinValue;

            bool isFound = clsDataAccessDrivers.FindByID(
                driverID,
                ref personID,
                ref createdByUserID,
                ref createdDate
            );

            if (isFound)
            {
                return new clsDriver(driverID, personID, createdByUserID, createdDate);
            }

            return null;
        }
        
        public static clsDriver FindByPersonID(int personID)
        {
            int driverID = -1;
            int createdByUserID = -1;
            DateTime createdDate = DateTime.MinValue;

            bool isFound = clsDataAccessDrivers.FindDriverByPersonID(
                ref driverID,
                personID,
                ref createdByUserID,
                ref createdDate
            );

            if (isFound)
            {
                return new clsDriver(driverID, personID, createdByUserID, createdDate);
            }

            return null;
        }
        public static DataTable GetAllDrivers()
        {
            return clsDataAccessDrivers.GetAllDrivers();
        }

        public bool HasInternationalLicense()
        {
            return clsInternationalLicense.HasInternationalLicense(this.DriverID);

        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    return _AddNewDriver();

                case enMode.Update:
                    return false;
            }

            return false;
        }


    }
}
