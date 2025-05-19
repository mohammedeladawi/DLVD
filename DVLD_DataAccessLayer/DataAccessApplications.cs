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
                        object userID = command.ExecuteScalar();
                        
                        if (userID != null)
                        {
                            return Convert.ToInt16(userID);
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
                    command.Parameters.AddWithValue("@ApplicationStatus", applicationID);
                    command.Parameters.AddWithValue("@LastStatusDateUserName", applicationStatus);
                    command.Parameters.AddWithValue("@ApplicationID", lastStatusDate);


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
        public static bool IsSameApllicationExist(int personID, byte licenseClassID)
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
            string commandStr = @"Delete From Applications Where UserID = @ApplicationID";

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
    }
}
