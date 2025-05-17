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
        public static DataTable GetAllTypes()
        {
            return clsDataAccessApplicationTypes.GetAllApplicaitonTypes();
        }
    }
}
