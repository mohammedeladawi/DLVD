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
    public static class clsDataAccessApplications
    { 
        enum enStatus:byte { New = 1, Cancelled = 2, Completed = 3}

        public static int AddNewApplication(int personID, DateTime date, byte typeID, decimal paidFees, int createdByUserID)
        {
            byte status = (byte)enStatus.New;
            string commandStr = @"INSERT INTO Applications(ApplicationPersonID, ApplicationDate, 
                                                           ApplicationTypeID, ApplicationStatus, 
                                                           LastStatusDate, PaidFees, CreatedByUserID)
                                  
                                  VALUES (@ApplicationPersonID, @ApplicationDate, @ApplicationTypeID, 
                                          @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID)
                                  
                                  SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationPersonID", personID);
                    command.Parameters.AddWithValue("@ApplicationDate", date);
                    command.Parameters.AddWithValue("@ApplicationTypeID", typeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", status);
                    command.Parameters.AddWithValue("@LastStatusDate", date); // Use the same date in new applications
                    command.Parameters.AddWithValue("@PaidFees", paidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    try
                    {
                        connection.Open();
                        object applicationID = command.ExecuteScalar();
                        
                        if (applicationID != null)
                        {
                            return Convert.ToInt16(applicationID);
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

        private static bool _UpdateApplication(int applicationID, byte applicationStatus, DateTime lastStatusDate)
        {
            string commandStr = @"UPDATE Applications SET 
                                  ApplicationStatus = @ApplicationStatus,
                                  LastStatusDate = @LastStatusDate
                                  WHERE ApplicationID = @ApplicationID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationStatus", applicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", lastStatusDate);
                    command.Parameters.AddWithValue("@ApplicationID", applicationID);


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

        // For New and Completed ApplicationStatus
        public static bool IsSameApplicationExist(int personID, int licenseClassID)
        {
            string query = @"select x=1 from Applications
                             JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                             where Applications.ApplicationStatus IN (@NewStatus, @CompletedStatus) 
                                AND LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                                AND Applications.ApplicationPersonID = @PersonID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewStatus", (byte)enStatus.New);
                    command.Parameters.AddWithValue("@CompletedStatus", (byte)enStatus.Completed);
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
                    command.Parameters.AddWithValue("@PersonID", personID);

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

        public static bool DeleteApplicationByID(int applicationID)
        {
            string commandStr = @"Delete From Applications Where ApplicationID = @ApplicationID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", applicationID);

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

        public static bool CancelApplicationByID(int applicationID)
        {
            byte status = (byte)enStatus.Cancelled;
            return _UpdateApplication(applicationID, status, DateTime.Now);
        }
       
        public static bool CompleteApplicationByID(int applicationID)
        {
            byte status = (byte)enStatus.Completed;
            return _UpdateApplication(applicationID, status, DateTime.Now);
        }
   
        public static bool FindApplicationByID(int applicationID, ref int applicationPersonID, ref DateTime applicationDate,
            ref byte applicationTypeID, ref byte applicationStatus, ref DateTime lastStatusDate,
            ref decimal paidFees, ref int createdByUserID)
        {
            string commandStr = @"Select * From Applications WHERE ApplicationID = @ApplicationID";

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
                            applicationID = (int)read["ApplicationID"];
                            applicationPersonID = (int)read["ApplicationPersonID"];
                            applicationDate = (DateTime)read["ApplicationDate"];
                            applicationTypeID = Convert.ToByte(read["ApplicationTypeID"]);
                            applicationStatus = (byte)read["ApplicationStatus"];
                            lastStatusDate = (DateTime)read["LastStatusDate"];
                            paidFees = (decimal)read["PaidFees"];
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
    }
}
