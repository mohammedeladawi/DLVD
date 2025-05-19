using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLDLApplication
    {
        public static DataTable GetAllApplications()
        {
            return clsDataAccessLDLApplications.GetAllLDLApplicaitons();
        }

    }
}
