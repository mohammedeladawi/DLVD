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
    public static class clsDataAccessTests
    {
      public static byte PassedTestsCount(int ldlApplicationID)
        {
            string commandStr = @"
                            select COUNT(T.TestID) from TestAppointments TA
                            inner Join tests T on T.TestAppointmentID = TA.TestAppointmentID
                            where LocalDrivingLicenseApplicationID = @LDLApplicationID 
                            And TestResult = 1;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@LDLApplicationID", ldlApplicationID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        return (result != null ? Convert.ToByte(result) : (byte)0);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return 0;

        }
    
      public static int SpecificTestTrialsByLDLAppIdAndTestTypeID(int ldlApplicationID, int testTypeID)
        {
            string commandStr = @"select count(1) from tests T
                                  JOIN TestAppointments TA on TA.TestAppointmentID = T.TestAppointmentID
                                  JOIN LocalDrivingLicenseApplications LDLApp on LDLApp.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                                  where LDLApp.LocalDrivingLicenseApplicationID = @LDLApplicationID
                                    and TestTypeID = @TestTypeID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@LDLApplicationID", ldlApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);

                    try
                    {
                        connection.Open();
                        SqlDataReader read = command.ExecuteReader();
                        if (read.Read())
                        {
                            int testsCount = (int)read[0];
                            return testsCount;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return 0;
        }
      
      public static int AddNewTest( int testAppointmentID, bool testResult, string notes, int createdByUserID) 
        { string commandStr = @"Insert Into Tests(TestAppointmentID, TestResult, Notes, CreatedByUserID)
                                  values (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
                                  SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", testResult);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    if (notes == string.Empty)  
                        command.Parameters.AddWithValue("Notes", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("Notes", notes);


                    try
                    {
                            connection.Open();
                            object testID = command.ExecuteScalar();

                            if (testID != null)
                            {
                                return Convert.ToInt32(testID);
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
    }
}
