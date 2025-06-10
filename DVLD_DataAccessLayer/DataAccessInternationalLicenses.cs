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
    public static class clsDataAccessInternationalLicenses
    {
        public static DataTable GetAllIDLApplicaitons()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT 
                                   IL.internationalLicenseID,
                                   A.ApplicationID,
                                   IL.DriverID, 
                                   IL.IssuedUsingLocalLicenseID,
                                   IL.IssueDate, 
                                   IL.ExpirationDate, 
                                   IL.IsActive
                            FROM InternationalLicenses IL
                            JOIN Applications A ON A.ApplicationID = IL.ApplicationID;";

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

        public static DataTable GetILicensesByDriverID(int driverID)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT
                               InternationalLicenseID,
                               ApplicationID, 
                               IssuedUsingLocalLicenseID, 
                               IssueDate, 
                               ExpirationDate, 
                               IsActive 
                             FROM InternationalLicenses;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", driverID);

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

        public static bool HasActiveInternationalLicense(int driverID)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT 1 FROM InternationalLicenses
                             WHERE IsActive = 1 
                             AND DriverID = @DriverID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", driverID);

                    try
                    {
                        connection.Open();
                        object result= command.ExecuteScalar();
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

        public static int AddNewInternationalLicense(int applicationID, int driverID, int issuedUsingLocalLicenseID,
                                              DateTime issueDate, DateTime expirationDate,
                                              bool isActive, int createdByUserID)
        {
            string commandStr = @"
                INSERT INTO InternationalLicenses 
                (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
                VALUES 
                (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID);
                SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", applicationID);
                    command.Parameters.AddWithValue("@DriverID", driverID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", issuedUsingLocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", issueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    try
                    {
                        connection.Open();
                        object internationalLicenseID = command.ExecuteScalar();
                        if (internationalLicenseID != null)
                        {
                            return Convert.ToInt32(internationalLicenseID);
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

        public static bool FindILicenseByApplicationID(
            ref int internationalLicenseID,
            int applicationID,
            ref int driverID,
            ref int issuedUsingLocalLicenseID,
            ref DateTime issueDate,
            ref DateTime expirationDate,
            ref bool isActive,
            ref int createdByUserID)
        {
            string commandStr = @"SELECT * FROM InternationalLicenses WHERE ApplicationID = @ApplicationID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", applicationID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader read = command.ExecuteReader())
                        {
                            if (read.Read())
                            {
                                internationalLicenseID = (int)read["InternationalLicenseID"];
                                driverID = (int)read["DriverID"];
                                issuedUsingLocalLicenseID = (int)read["IssuedUsingLocalLicenseID"];
                                issueDate = (DateTime)read["IssueDate"];
                                expirationDate = (DateTime)read["ExpirationDate"];
                                isActive = (bool)read["IsActive"];
                                createdByUserID = (int)read["CreatedByUserID"];

                                return true;
                            }
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

        public static bool FindByILicenseID(
            int internationalLicenseID,
            ref int applicationID,
            ref int driverID,
            ref int issuedUsingLocalLicenseID,
            ref DateTime issueDate,
            ref DateTime expirationDate,
            ref bool isActive,
            ref int createdByUserID)
        {
            string commandStr = @"SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(commandStr, connection))
            {
                command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            applicationID = (int)reader["ApplicationID"];
                            driverID = (int)reader["DriverID"];
                            issuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                            issueDate = (DateTime)reader["IssueDate"];
                            expirationDate = (DateTime)reader["ExpirationDate"];
                            isActive = (bool)reader["IsActive"];
                            createdByUserID = (int)reader["CreatedByUserID"];

                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return false;
        }
    
        public static bool FindByLocalLicenseID(
            ref int internationalLicenseID,
            ref int applicationID,
            ref int driverID,
            int issuedUsingLocalLicenseID,
            ref DateTime issueDate,
            ref DateTime expirationDate,
            ref bool isActive,
            ref int createdByUserID)
        {
            string commandStr = @"SELECT * FROM InternationalLicenses 
                                  WHERE IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(commandStr, connection))
            {
                command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", issuedUsingLocalLicenseID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            internationalLicenseID = (int)reader["InternationalLicenseID"];
                            applicationID = (int)reader["ApplicationID"];
                            driverID = (int)reader["DriverID"];
                            issueDate = (DateTime)reader["IssueDate"];
                            expirationDate = (DateTime)reader["ExpirationDate"];
                            isActive = (bool)reader["IsActive"];
                            createdByUserID = (int)reader["CreatedByUserID"];

                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return false;
        }
    }
}
