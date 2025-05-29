using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Policy;
using System.Net.NetworkInformation;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccessLayer
{
    public static class clsDataAccessTestAppointments
    {
        public static DataTable GetAllTestAppointmenstByLDLAppID(int ldlApplicationID)
        {
            DataTable dt = new DataTable();
            string query = @"select TestAppointmentID, AppointmentDate, PaidFees, IsLocked from TestAppointments
                             where LocalDrivingLicenseApplicationID = @LDLApplicationID; ";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LDLApplicationID", ldlApplicationID);

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

        public static bool IsActiveAppointmentExist(int ldlApplicationID)
        {
            string query = @"select 
                                1 from TestAppointments
                             where 
                                IsLocked = 0 
                                and LocalDrivingLicenseApplicationID = @LDLApplicationID ;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LDLApplicationID", ldlApplicationID);

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

        public static int AddNewTestAppointment(int testTypeID, int ldlApplicationID,
            DateTime appointmentDate, decimal paidFees, int createdByUserID,
            int? retakeTestApplicationID = null)
        {
            string commandStr = @"Insert Into TestAppointments(TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, IsLocked, CreatedByUserID, RetakeTestApplicationID)
                                  values (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @IsLocked, @CreatedByUserID, @RetakeTestApplicationID);;
                                  SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", ldlApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", paidFees);
                    command.Parameters.AddWithValue("@IsLocked", false);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                   
                    if (retakeTestApplicationID != null)
                        command.Parameters.AddWithValue("@RetakeTestApplicationID", retakeTestApplicationID);
                    else
                        command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);

                    try
                    {
                        connection.Open();
                        object testAppointmentID = command.ExecuteScalar();

                        if (testAppointmentID != null)
                        {
                            return Convert.ToInt32(testAppointmentID);
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

        public static bool FindByTestAppointmentID(int testAppointmentID, ref int testTypeID,
                ref int ldlApplicationID, ref DateTime appointmentDate, ref decimal paidFees,
                ref int createdByUserID, ref int? retakeTestApplicationID)
        {
            string commandStr = @"Select * From TestAppointments 
                                  WHERE TestAppointmentID = @TestAppointmentID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
                    try
                    {
                        connection.Open();
                        SqlDataReader read = command.ExecuteReader();
                        if (read.Read())
                        {
                            testTypeID = (int)read["TestTypeID"];
                            ldlApplicationID = (int)read["LocalDrivingLicenseApplicationID"];
                            appointmentDate = (DateTime)read["AppointmentDate"];
                            paidFees = (decimal)read["PaidFees"];
                            createdByUserID = (int)read["CreatedByUserID"];

                            retakeTestApplicationID =
                                read["RetakeTestApplicationID"] != DBNull.Value
                                ? (int)read["RetakeTestApplicationID"]
                                : (int?)null;

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

        public static bool UpdateTestAppointmentDate(int testAppointmentID, DateTime newDate)
        {
            string commandStr = @"UPDATE TestAppointments SET 
                                  AppointmentDate = @AppointmentDate
                                  WHERE TestAppointmentID = @TestAppointmentID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentDate", newDate);
                    command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);

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
