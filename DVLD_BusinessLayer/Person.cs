using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew, Update }; 
        public int PersonId { get; private set; } //readonly
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public enMode Mode = enMode.AddNew;

        private bool _AddNewPerson()
        {
            this.PersonId = clsDataAccessPeople.AddNewPerson(NationalNo, FirstName, SecondName, ThirdName, LastName,
                                                        DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            if (PersonId != -1)
                Mode = enMode.Update;

            return PersonId != -1;
        }

        private bool _UpdatePerson()
        {
            return clsDataAccessPeople.UpdatePerson(PersonId, NationalNo, FirstName, SecondName, ThirdName, LastName,
                                                    DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath); ;
        }

        public clsPerson()
        {
            PersonId = -1;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gendor = 10;
            Address = "";
            Phone = "";
            Email = "";
            NationalityCountryID = -1;
            ImagePath = "";

            Mode = enMode.AddNew;
        }

        private clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName,
                                        string ThirdName, string LastName, DateTime DateOfBirth, byte Gendor, string Address,
                                        string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.PersonId = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }
        
        public static DataTable GetAllPersonsInfo()
        {
            return clsDataAccessPeople.GetAllPeopleInfo();
        }

        public clsPerson FindByID(int PersonID)
        {
            string NationalNo = "";
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = -1;
            string ImagePath = "";

            bool isFound = clsDataAccessPeople.FindPersonByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName,
                                                              ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email,
                                                              ref NationalityCountryID, ref ImagePath);
            if (isFound)
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName,
                                     LastName, DateOfBirth, Gendor, Address, Phone, Email,
                                     NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    return _AddNewPerson();

                case enMode.Update:
                    return _UpdatePerson();
            }

            return false;
        }


    }
}
