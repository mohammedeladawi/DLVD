using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsUser
    {
        enum enMode { AddNew, Update }
        enMode Mode;

        public int UserID { get; set; }
        public int PerosnID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }

        public static DataTable GetAllUsersData()
        {
            return clsDataAccessUsers.GetAllUsersInfo();
        }
    
    }
}
