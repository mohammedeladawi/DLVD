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
    public static class clsDataAccessLicenses
    {
        public static DataTable GetLicensesByDriverID(int driverID)
        {
            DataTable dt = new DataTable();
            string query = @"
                            SELECT 
                                L.LicenseID, 
                                L.ApplicationID, 
                                LC.ClassName, 
                                L.IssuanceDate, 
                                L.ExpirationDate, 
                                L.IsActive
                            FROM 
                                Licenses L
                            JOIN 
                                LicenseClasses LC ON LC.LicenseClassID = L.LicenseClassID
                            WHERE 
                                L.DriverID = @DriverID;";

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

        public static int AddNewLicense(int applicationID, int driverID, int licenseClassID,
                                        DateTime issuanceDate, DateTime expirationDate, string notes,
                                        decimal paidFees, bool isActive, byte issueReason, int createdByUserID)
        {
            string commandStr = @"Insert Into Licenses (ApplicationID, DriverID, LicenseClassID, IssuanceDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                                  values (@ApplicationID, @DriverID, @LicenseClassID, @IssuanceDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID)
                                  SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", applicationID);
                    command.Parameters.AddWithValue("@DriverID", driverID);
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
                    command.Parameters.AddWithValue("@IssuanceDate", issuanceDate);
                    command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                    command.Parameters.AddWithValue("@PaidFees", paidFees);
                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.Parameters.AddWithValue("@IssueReason", issueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    if (notes == string.Empty)
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Notes", notes);

                    try
                    {
                        connection.Open();
                        object licenseID = command.ExecuteScalar();
                        if (licenseID != null)
                        {
                            return Convert.ToInt16(licenseID);
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

        public static bool UpdateLicense(int licenseID, bool isActive)
        {
            string commandStr = @"UPDATE Licenses
                                  SET IsActive = @IsActive
                                  WHERE LicenseID = @LicenseID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);
                    command.Parameters.AddWithValue("@IsActive", isActive);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return false;
        }

        public static bool FindByApplicationID(
            ref int licenseID,
            int applicationID,
            ref int driverID,
            ref int licenseClassID,
            ref DateTime issuanceDate,
            ref DateTime expirationDate,
            ref string notes,
            ref decimal paidFees,
            ref bool isActive,
            ref byte issueReason,
            ref int createdByUserID)
        {

            string commandStr = @"Select * From Licenses WHERE ApplicationID = @ApplicationID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", applicationID);
                    try
                    {
                        connection.Open();
                        SqlDataReader read = command.ExecuteReader();
                        if (read.Read())
                        {
                            licenseID = (int)read["LicenseID"];
                            driverID = (int)read["DriverID"];
                            licenseClassID = (int)read["LicenseClassID"];
                            issuanceDate = (DateTime)read["IssuanceDate"];
                            expirationDate = (DateTime)read["ExpirationDate"];

                            notes = read["Notes"] != DBNull.Value
                                ? (string)read["Notes"]
                                : string.Empty;

                            paidFees = (decimal)read["PaidFees"];
                            isActive = (bool)read["IsActive"];
                            issueReason = (byte)read["IssueReason"];
                            createdByUserID = (int)read["CreatedByUserID"];

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

        public static bool FindByLicenseID(
            int licenseID,
            ref int applicationID,
            ref int driverID,
            ref int licenseClassID,
            ref DateTime issuanceDate,
            ref DateTime expirationDate,
            ref string notes,
            ref decimal paidFees,
            ref bool isActive,
            ref byte issueReason,
            ref int createdByUserID)
        {

            string commandStr = @"Select * From Licenses WHERE LicenseID = @LicenseID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);
                    try
                    {
                        connection.Open();
                        SqlDataReader read = command.ExecuteReader();
                        if (read.Read())
                        {
                            applicationID = (int)read["ApplicationID"];
                            driverID = (int)read["DriverID"];
                            licenseClassID = (int)read["LicenseClassID"];
                            issuanceDate = (DateTime)read["IssuanceDate"];
                            expirationDate = (DateTime)read["ExpirationDate"];

                            notes = read["Notes"] != DBNull.Value
                                ? (string)read["Notes"]
                                : string.Empty;

                            paidFees = (decimal)read["PaidFees"];
                            isActive = (bool)read["IsActive"];
                            issueReason = (byte)read["IssueReason"];
                            createdByUserID = (int)read["CreatedByUserID"];

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

        public static int GetActiveLicenseIDByPerson(int personID, int licenseClassID)
        {
            string query = @"SELECT L.LicenseID FROM Licenses L
                            Inner Join Drivers D
                                ON D.DriverID = L.DriverID
                                WHERE IsActive = 1 
                                AND D.PersonID = @PersonID
                                AND L.LicenseClassID = @LicenseClassID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);


                    try
                    {
                        connection.Open();
                        
                        object result = command.ExecuteScalar();
                        if (result != null )
                            return Convert.ToInt16(result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return -1;
        }


    }
}