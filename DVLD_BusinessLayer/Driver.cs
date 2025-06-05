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
        public enum enMode { AddNew, Update };
        enMode Mode;

        private int _PersonID;
        public int DriverID {get; private set;}
        public int PersonID 
        {
            get
            {
                return _PersonID;
            }
            set
            {
                _PersonID = value;
                if (value != -1)
                    Person = clsPerson.FindByID(value);
            }
        }
        public int CreatedByUserID { get; set; }
        public clsPerson Person {  get; private set; }
        public DateTime CreatedDate { get; set; }

        private bool _AddNewDriver()
        {
            this.DriverID = clsDataAccessDrivers.AddNewDriver(PersonID, CreatedByUserID, CreatedDate);
            if (DriverID != -1)
                Mode = enMode.Update;

            return DriverID != -1;
        }

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
        
        public static DataTable GetAllDrivers()
        {
            return clsDataAccessDrivers.GetAllDrivers();
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
