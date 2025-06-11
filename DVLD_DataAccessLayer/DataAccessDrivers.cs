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

        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT 
                                D.DriverID,
                                D.PersonID, 
                                P.NationalNo,
                                CONCAT_WS(' ', P.FirstName, P.SecondName, P.ThirdName, P.LastName) AS FullName,
                                D.CreatedDate,
                                COUNT(L.LicenseID) AS ActiveLicenses
                            FROM Drivers D
                            JOIN People P ON P.PersonID = D.PersonID
                            LEFT JOIN Licenses L ON L.DriverID = D.DriverID AND L.IsActive = 1
                            GROUP BY 
                                D.DriverID, D.PersonID, P.NationalNo, 
                                P.FirstName, P.SecondName, P.ThirdName, P.LastName,
                                D.CreatedDate;
";

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
        public static bool HasActiveLicense(int driverID, int licenseClassID)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT 1 FROM Licenses
                             WHERE IsActive = 1 
                             AND DriverID = @DriverID
                             AND LicenseClassID = @LicenseClassID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", driverID);
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);


                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        return result != null;
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
