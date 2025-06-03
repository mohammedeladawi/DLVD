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
    public static class clsDataAccessDrivers
    {
        public static int AddNewDriver(int personID, int createdByUserID, DateTime createdDate)
        {
            string commandStr = @"Insert Into Drivers (PersonID, CreatedByUserID, CreatedDate)
                                  values (@PersonID, @CreatedByUserID, @CreatedDate)
                                  SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                    command.Parameters.AddWithValue("@CreatedDate", createdDate);

                    try
                    {
                        connection.Open();
                        object driverID = command.ExecuteScalar();
                        if (driverID != null)
                        {
                            return Convert.ToInt16(driverID);
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

        public static bool FindByID(int driverID, ref int personID, ref int createdByUserID, ref DateTime createdDate)
        {

            string commandStr = @"SELECT * FROM Drivers WHERE DriverID = @DriverID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(commandStr, connection))
            {
                command.Parameters.AddWithValue("@DriverID", driverID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        personID = (int)reader["PersonID"];
                        createdByUserID = (int)reader["CreatedByUserID"];
                        createdDate = (DateTime)reader["CreatedDate"];

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in FindByID (Driver): " + ex.Message);
                }
            }

            return false;
        }
    }
}
