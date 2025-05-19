using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsApplicationType
    {
        private bool _UpdateApplicationType()
        {
            return clsDataAccessApplicationTypes.UpdateApplicationType(ApplicationTypeID, Title, Fees);
        }

        public int ApplicationTypeID { get; private set; }

        public string Title { get; set; }
        public decimal Fees { get; set; }
        public static DataTable GetAllTypes()
        {
            return clsDataAccessApplicationTypes.GetAllApplicaitonTypes();
        }

        private clsApplicationType(int applicationTypeID, string title, decimal fees)
        {
            ApplicationTypeID = applicationTypeID;
            Title = title;
            Fees = fees;
        }
        public static clsApplicationType Find(int applicationTypeID)
        {
            string title = "";
            decimal fees = 0;

            bool isFound = clsDataAccessApplicationTypes.FindApplicationTypeByID(applicationTypeID, ref title, ref fees);
            if (isFound)
                return new clsApplicationType(applicationTypeID, title, fees);
            else
                return null;
        }

        public bool Save()
        {
            return _UpdateApplicationType();
        }
    }
}
