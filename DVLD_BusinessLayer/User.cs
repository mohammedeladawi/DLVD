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
    
        private clsUser(int userID, int perosnID, string userName, string password, bool isActive)
        {
            UserID = userID;
            PerosnID = perosnID;
            UserName = userName;
            Password = password;
            this.isActive = isActive;
            
            Mode = enMode.Update;
        }

        public clsUser()
        {
            UserID = -1;
            PerosnID = -1;
            UserName = "";
            Password = "";
            this.isActive = false;

            Mode = enMode.AddNew;
        }

        public static clsUser FindByID(int userID)
        {
            int personID = -1;
            string username = "";
            string password = "";
            bool isActive = false;

            bool isFound = clsDataAccessUsers.FindUserByID(userID, ref personID, ref username, ref password, ref isActive);
            if (isFound)
                return new clsUser(userID, personID, username, password, isActive);
            else
                return null;
        }
    }
}
