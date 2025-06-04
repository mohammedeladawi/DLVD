using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccessLayer
{
    public class clsDataAccessLDLApplications
    {
        public static DataTable GetAllLDLApplicaitons()
        {
            DataTable dt = new DataTable();
            string query = "Select * From LocalDrivingLicenseApplications_View;";

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

        public static bool FindLDLApplicationByID(int ldlApplicationID, ref int applicationID, ref int licenseClassID)
        {
            string commandStr = @"Select * From LocalDrivingLicenseApplications 
                                  WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", ldlApplicationID);
                    try
                    {
                        connection.Open();
                        SqlDataReader read = command.ExecuteReader();
                        if (read.Read())
                        {
                            applicationID = (int)read["ApplicationID"];
                            licenseClassID = (int)read["LicenseClassID"];

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

        public static int AddNewLDLApplication(int applicationID, int licenseClassID)
        {
            string commandStr = @"INSERT INTO LocalDrivingLicenseApplications(ApplicationID, LicenseClassID)
                                  values(@ApplicationID, @LicenseClassID);
                                  SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", applicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

                    try
                    {
                        connection.Open();
                        object lDLapplication = command.ExecuteScalar();

                        if (lDLapplication != null)
                        {
                            return Convert.ToInt32(lDLapplication);
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

        public static bool UpdateLDLApplication(int ldlApplicationID, int licenseClassID)
        {
            string commandStr = @"UPDATE LocalDrivingLicenseApplications SET 
                                  LicenseClassID = @LicenseClassID
                                  WHERE LocalDrivingLicenseApplicationID = @LDLApplicationID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
                    command.Parameters.AddWithValue("@LDLApplicationID", ldlApplicationID);

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

        public static bool DeleteLDLApplicationByID(int ldlApplicationID)
        {
            string commandStr = @"Delete From LocalDrivingLicenseApplications
                                  Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", ldlApplicationID);

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
