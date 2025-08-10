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
        public static int AddNewApplication(int applicationPersonID, DateTime applicationDate, int applicationTypeID, byte applicationStatus, decimal paidFees, int createdByUserID)
        {
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
                    command.Parameters.AddWithValue("@ApplicationPersonID", applicationPersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", applicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", applicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", applicationDate); // Use the same date in new applications
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

        public static bool UpdateApplication(int applicationID, int applicationPersonID, DateTime applicationDate, int applicationTypeID, byte applicationStatus, DateTime lastStatusDate, decimal paidFees, int createdByUserID)
        {
            int rowsAffected = 0;
            string commandStr = @"Update Applications  
                            set ApplicationPersonID = @ApplicationPersonID,
                                ApplicationDate = @ApplicationDate,
                                ApplicationTypeID = @ApplicationTypeID,
                                ApplicationStatus = @ApplicationStatus, 
                                LastStatusDate = @LastStatusDate,
                                PaidFees = @PaidFees,
                                CreatedByUserID=@CreatedByUserID
                            where ApplicationID=@ApplicationID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", applicationID);
                    command.Parameters.AddWithValue("@ApplicationPersonID", applicationPersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", applicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", applicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", lastStatusDate); // Use the same date in new applications
                    command.Parameters.AddWithValue("@PaidFees", paidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }

            return rowsAffected > 0;
        }
        
        public static bool UpdateApplicationStatus(int applicationID, byte applicationStatus)
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
                    command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);
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
   
        public static bool FindApplicationByID(int applicationID, ref int applicationPersonID, ref DateTime applicationDate,
            ref int applicationTypeID, ref byte applicationStatus, ref DateTime lastStatusDate,
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
