using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsCountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public static DataTable GetAllCountires()
        {
            return clsDataAccessCountires.GetAllCountires();
        }

        private clsCountry(int CountryID, string CountryName)
        { 
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        public static clsCountry FindByName(string CountryName)
        {
            int CountryID = -1;

            bool isFound = clsDataAccessCountires.FindCountryByName(ref CountryID, CountryName);
            if (isFound)
                return new clsCountry(CountryID, CountryName);
            else
                return null;
        }

        public static clsCountry FindByID(int CountryID) {

            string CountryName = string.Empty;
            bool isFound = clsDataAccessCountires.FindCountryByID(CountryID, ref CountryName);
            if (isFound)
                return new clsCountry(CountryID, CountryName);
            else
                return null;
        }
    }
}
