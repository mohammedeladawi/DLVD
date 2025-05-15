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

        private bool _AddNewUser()
        {
            this.UserID = clsDataAccessUsers.AddNewUser(PerosnID, UserName, Password, isActive);
            bool isAdded = UserID != -1;
            
            if (isAdded)
                Mode = enMode.Update;

            return isAdded;
        }

        private bool _UpdateUser()
        {
            return clsDataAccessUsers.UpdateUser(UserID, PerosnID, UserName, Password, isActive);
        }
        
        private int _PersonID;
        public int UserID { get; set; }
        public int PerosnID 
        {
            get
            {
                return _PersonID;
            }

            set
            {
                _PersonID = value;
                Person = clsPerson.FindByID(_PersonID);
            }
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }

        public clsPerson Person { get; private set; }

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
            this.Person = clsPerson.FindByID(perosnID);
            
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

        public static clsUser FindByUsernameAndPassword(string username, string password )
        {
            int userID = -1;
            int personID = -1;
            bool isActive = false;

            bool isFound = clsDataAccessUsers.FindUserByUsernameAndPassword(ref userID, ref personID, username, password, ref isActive);
            if (isFound)
                return new clsUser(userID, personID, username, password, isActive);
            else
                return null;
        }

        public static bool IsExistByPersonID(int personID)
        {
            return clsDataAccessUsers.IsUserExistByPersonID(personID);
        }
        
        public static bool IsExistByUserName(string username)
        {
            return clsDataAccessUsers.IsUserNameExist(username);
        }

        public static bool DeleteByID(int userID)
        {
            return clsDataAccessUsers.DeleteUserByID(userID);
        }
       
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    return _AddNewUser();
                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }
    }
}
