using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsTest
    {
       
        public static byte PassedTestsCount(int ldlApplicationID)
        {
            return clsDataAccessTests.PassedTestsCount(ldlApplicationID);
        }

    }
}
