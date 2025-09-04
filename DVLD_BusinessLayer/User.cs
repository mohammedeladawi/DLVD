using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsUser
    {
        enum enMode { AddNew, Update }
        enMode Mode;

        public static string _ComputeHash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        private bool _AddNewUser()
        {
            this.UserID = clsDataAccessUsers.AddNewUser(PersonID, UserName, _ComputeHash(Password), IsActive);
            bool isAdded = UserID != -1;
            
            if (isAdded)
                Mode = enMode.Update;

            return isAdded;
        }

        private bool _UpdateUser()
        {
            return clsDataAccessUsers.UpdateUser(UserID, PersonID, UserName, _ComputeHash(Password), IsActive);
        }
        
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsPerson Person { get; private set; }

        public static DataTable GetAllUsersData()
        {
            return clsDataAccessUsers.GetAllUsersInfo();
        }
    
        private clsUser(int userID, int perosnID, string userName, string password, bool isActive)
        {
            UserID = userID;
            PersonID = perosnID;
            UserName = userName;
            Password = password;
            this.IsActive = isActive;
            this.Person = clsPerson.Find(perosnID);
            
            Mode = enMode.Update;
        }

        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            this.IsActive = false;

            Mode = enMode.AddNew;
        }

        public static clsUser Find(int userID)
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
            password = _ComputeHash(password);

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
       
        public bool VerifyPassword(string password)
        {
            return _ComputeHash(password) == this.Password;
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
