using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Policy;

namespace DVLD_DataAccessLayer
{
    public static class clsDataAccessUsers
    {
        public static DataTable GetAllUsersInfo()
        {
            DataTable dt = new DataTable();
            string query = @"select Users.UserID, Users.PersonID, 
                             people.FirstName + ' ' + people.SecondName + ' ' + people.ThirdName + ' ' + people.LastName as FullName,
                             Users.UserName, Users.IsActive 
                             From Users
                             Join People ON People.PersonID = Users.PersonID;";

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
 
    
        public static bool FindUserByID(int userID, ref int personID, ref string username, ref string password, ref bool isActive)
        {
            string commandStr = @"Select * From Users WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    try
                    {
                        connection.Open();
                        SqlDataReader read = command.ExecuteReader();
                        if (read.Read())
                        {
                            personID = (int)read["PersonID"];
                            username = (string)read["UserName"];
                            password = (string)read["Password"];
                            isActive = (bool)read["IsActive"];

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
