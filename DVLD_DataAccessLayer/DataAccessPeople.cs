using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;

namespace DVLD_DataAccessLayer
{
    public static class clsDataAccessPeople
    {
        public static DataTable GetAllPeopleInfo()
        {
            DataTable dt = new DataTable();
            string query = "Select * From People;";

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
                        //Console.WriteLine(ex.Message);
                    }
                }
            }

            return dt;
        }
    
        public static int AddNewPerson( string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, byte Gendor, string Address,
            string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            string commandStr = @"Insert Into People (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOFBirth, Gendor, Addredd, Phone, Email, NationalCountryID, ImagePath)
                                  values (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOFBirth, @Gendor, @Addredd, @Phone, @Email, @NationalityCountryID, @ImagePath)
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
                    command.Parameters.AddWithValue("@NationalCountryID", NationalityCountryID);
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
                            return (int)PersonId;
                        }
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                    }
                }
            }

            return -1;
        }
    }
}
