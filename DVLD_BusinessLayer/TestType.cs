using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsTestType
    {

        private bool _UpdateTestTypes()
        {
            return clsDataAccessTestTypes.UpdateTestType(TestTypeID, Title, Description, Fees);
        }

        public enum enTestTypes
        {
            VisionTest = 1,
            WrittenTheoryTest = 2,
            PracticalStreetTest = 3
        }
        public int TestTypeID { get; private set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }

        public static DataTable GetAllTypes()
        {
            return clsDataAccessTestTypes.GetAllTestTypes();
        }
    
        private clsTestType(int testTypeID, string title, string description, decimal fees)
        {
            TestTypeID = testTypeID;
            Title = title;
            Description = description;
            Fees = fees;
        }
        public static clsTestType Find(int testTypeID)
        {
            string title = "";
            string description = "";
            decimal fees = 0;

            bool isFound = clsDataAccessTestTypes.FindTestTypeByID(testTypeID, ref title, ref description, ref fees);
            if (isFound)
                return new clsTestType(testTypeID, title, description, fees);
            else
                return null;
        }
       
        public bool Save()
        {
             return _UpdateTestTypes();
        }
    }
}
