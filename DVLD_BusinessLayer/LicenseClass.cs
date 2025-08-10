using DVLD_DataAccessLayer;
using System.Collections.Generic;

namespace DVLD_BusinessLayer
{
    public class clsLicenseClass
    {
        public int LicenseClassID { get; private set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinmumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }

        public static Dictionary<int, string> GetClassesIDName()
        {
            return clsDataAccessLicenseClasses.GetClassesIDName();
        }
    
        private clsLicenseClass(int licenseClassID, string className, string classDescription, 
            byte minAllowedAge, byte defaultValidityLength, decimal classFees )
        {
            this.LicenseClassID = licenseClassID;
            this.ClassName = className;
            this.ClassDescription = classDescription;
            this.MinmumAllowedAge = minAllowedAge;
            this.DefaultValidityLength = defaultValidityLength;
            this.ClassFees = classFees;

        }
        public static clsLicenseClass Find(int licenseClassID)
        {
            string className = "";
            string classDescription = "";
            byte minAllowedAge = 0;
            byte defaultValidityLength = 0;
            decimal classFees = 0;


            bool isFound = clsDataAccessLicenseClasses.FindByLicenseClassID(licenseClassID, ref className,
                ref classDescription, ref minAllowedAge, ref defaultValidityLength, ref classFees);

            if (isFound)
                return new clsLicenseClass(licenseClassID, className, classDescription,
                    minAllowedAge, defaultValidityLength, classFees);
            else
                return null;
        }
       
    }
}
