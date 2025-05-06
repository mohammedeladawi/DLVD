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

        public static DataTable GetAllPersonsInfo()
        {
            return clsDataAccessPeople.GetAllPeopleInfo();
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
