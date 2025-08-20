using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccessLayer
{
    public static class clsDataAccessDetainedLicenses
    {
        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();
            string query = @"
                            select 
                                D.DriverID,
                                L.LicenseID,
                                DL.DetainDate,
                                DL.IsReleased,
                                DL.FineFees,
                                DL.ReleaseDate,
                                P.NationalNo,
                                P.FirstName + ' ' + P.LastName as ""FullName"",
                                DL.ReleaseApplicationID
                            from DetainedLicenses DL
                            JOIN Licenses L ON L.LicenseID = DL.LicenseID
                            JOIN Drivers D ON D.DriverID = L.DriverID
                            JOIN People P ON P.PersonID = D.PersonID;";

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

        public static int AddNewDetainedLicenseRecord(int licenseID, DateTime detainDate, decimal fineFees, int createdByUserID)
        {
            string commandStr = @"INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
                                  VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, 0);
                                  SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);
                    command.Parameters.AddWithValue("@DetainDate", detainDate);
                    command.Parameters.AddWithValue("@FineFees", fineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int newID))
                        {
                            return newID;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            return -1; // Return -1 if insert fails
        }
       
        public static bool IsDetained(int licenseID)
        {
            string commandStr = @"SELECT 1 FROM DetainedLicenses
                                  WHERE LicenseID = @LicenseID 
                                  AND IsReleased = 0;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        return result != null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[IsDetained Error] {ex.Message}");
                    }
                }
            }

            return false;
        }

        public static bool UpdateDetainedLicenseRecord(
            int detainID,
            bool isReleased,
            DateTime? releaseDate,
            int releaseByUserID,
            int releaseApplicationID)
        {
            string commandStr = @"UPDATE DetainedLicenses
                                  SET IsReleased = @IsReleased,
                                      ReleaseDate = @ReleaseDate,
                                      ReleaseByUserID = @ReleaseByUserID,
                                      ReleaseApplicationID = @ReleaseApplicationID
                                  WHERE DetainID = @DetainID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@IsReleased", isReleased);
                    command.Parameters.AddWithValue("@ReleaseDate", releaseDate.HasValue ? (object)releaseDate.Value : DBNull.Value);
                    
                    if (releaseByUserID != -1)
                        command.Parameters.AddWithValue("@ReleaseByUserID", releaseByUserID);
                    else
                        command.Parameters.AddWithValue("@ReleaseByUserID", DBNull.Value);


                    if (releaseApplicationID != -1)
                        command.Parameters.AddWithValue("@ReleaseApplicationID", releaseApplicationID);
                    else
                        command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);

                    
                    command.Parameters.AddWithValue("@DetainID", detainID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Update Error] {ex.Message}");
                    }
                }
            }

            return false;
        }


        public static bool FindDetainedLicenseByLicenseID(
            int licenseID,
            ref int detainID,
            ref DateTime detainDate,
            ref decimal fineFees,
            ref int createdByUserID,
            ref bool isReleased,
            ref DateTime? releaseDate,
            ref int releaseByUserID,
            ref int releaseApplicationID)
        {
            string commandStr = @"SELECT * FROM DetainedLicenses 
                                  WHERE LicenseID = @LicenseID AND IsReleased = 0";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            detainID = (int)reader["DetainID"];
                            detainDate = (DateTime)reader["DetainDate"];
                            fineFees = (decimal)reader["FineFees"];
                            createdByUserID = (int)reader["CreatedByUserID"];
                            isReleased = (bool)reader["IsReleased"];

                            releaseDate = reader["ReleaseDate"] != DBNull.Value ? (DateTime?)reader["ReleaseDate"] : null;
                   
                            releaseByUserID = reader["ReleaseByUserID"] != DBNull.Value ? (int)reader["ReleaseByUserID"] : -1;
                            releaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value ? (int)reader["ReleaseApplicationID"] : -1;

                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[FindDetainedLicenseByLicenseID] Error: {ex.Message}");
                    }
                }
            }

            return false;
        }
    }

}
