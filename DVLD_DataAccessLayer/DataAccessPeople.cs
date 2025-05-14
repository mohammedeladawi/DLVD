using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Net;
using System.Security.Policy;

namespace DVLD_DataAccessLayer
{
    public static class clsDataAccessPeople
    {
        public static DataTable GetAllPeopleInfo()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                                 CASE
                                    WHEN Gendor = 0 THEN 'Male'
                                    WHEN Gendor = 1 THEN 'Female'
                                    Else 'Unkown'
                                 END AS Gendor,
                                 DateOfBirth, Nationality = Countries.CountryName,
                                 Phone, Email FROM People
                             Join Countries ON Countries.CountryID = People.NationalityCountryID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                                return dt;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return dt;
        }

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName,
                                       string ThirdName, string LastName, DateTime DateOfBirth, byte Gendor, string Address,
                                       string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            string commandStr = @"Insert Into People (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath)
                                  values (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath)
                                  SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", Gendor);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    if (ImagePath == "")
                        command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);

                    try
                    {
                        connection.Open();
                        object PersonId = command.ExecuteScalar();
                        if (PersonId != null)
                        {
                            return Convert.ToInt16(PersonId);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return -1;
        }

        public static bool IsPersonExistByNationalNo(string NationalNo)
        {
            string query = "select x=1 from People where NationalNo = @NationalNo;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return false;
        }

        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName,
                                        string ThirdName, string LastName, DateTime DateOfBirth, byte Gendor, string Address,
                                        string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            string commandStr = @"UPDATE People SET 
                                  NationalNo = @NationalNo,
                                  FirstName = @FirstName,
                                  SecondName = @SecondName,
                                  ThirdName = @ThirdName,
                                  LastName = @LastName,
                                  DateOfBirth = @DateOfBirth,
                                  Gendor = @Gendor,
                                  Address = @Address,
                                  Phone = @Phone,
                                  Email = @Email,
                                  NationalityCountryID = @NationalityCountryID,
                                  ImagePath = @ImagePath
                                  WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", Gendor);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    if (ImagePath == "")
                        command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);

                    try
                    {
                        connection.Open();
                        int numberOfRows = command.ExecuteNonQuery();
                        if (numberOfRows > 0)
                        {
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return false;
        }


        public static bool FindPersonByID (int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName,
                                           ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address,
                                           ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {

            string commandStr = @"Select * From People WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        connection.Open();
                        SqlDataReader read = command.ExecuteReader();
                        if (read.Read())
                        {
                            NationalNo = (string)read["NationalNo"];
                            FirstName = (string)read["FirstName"];
                            SecondName = (string)read["SecondName"];
                            ThirdName = (string)read["ThirdName"];
                            LastName = (string)read["LastName"];
                            DateOfBirth = (DateTime)read["DateOfBirth"];
                            Gendor = (byte)read["Gendor"];
                            Address = (string)read["Address"];
                            Phone = (string)read["Phone"];
                            Email = (string)read["Email"];
                            NationalityCountryID = (int)read["NationalityCountryID"];

                            if (read["ImagePath"] != DBNull.Value)
                                ImagePath = (string)read["ImagePath"];

                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return false;
        }


        public static bool FindPersonByNationalNo(ref int PersonID, string NationalNo, ref string FirstName, ref string SecondName,
                                   ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address,
                                   ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {

            string commandStr = @"Select * From People WHERE NationalNo = @NationalNo";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    try
                    {
                        connection.Open();
                        SqlDataReader read = command.ExecuteReader();
                        if (read.Read())
                        {
                            PersonID = (int)read["PersonID"];
                            FirstName = (string)read["FirstName"];
                            SecondName = (string)read["SecondName"];
                            ThirdName = (string)read["ThirdName"];
                            LastName = (string)read["LastName"];
                            DateOfBirth = (DateTime)read["DateOfBirth"];
                            Gendor = (byte)read["Gendor"];
                            Address = (string)read["Address"];
                            Phone = (string)read["Phone"];
                            Email = (string)read["Email"];
                            NationalityCountryID = (int)read["NationalityCountryID"];

                            if (read["ImagePath"] != DBNull.Value)
                                ImagePath = (string)read["ImagePath"];

                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return false;
        }


        public static bool DeletePersonByID(int PersonID)
        {

            string commandStr = @"Delete From People Where PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();
                        int numberOfRows = command.ExecuteNonQuery();
                        if (numberOfRows > 0)
                        {
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return false;
        }
    }
}
