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
            string commandStr = @"SELECT COUNT(1) 
                                  FROM LocalDrivingLicenseApplications L
                                  JOIN TestAppointments TA 
                                      ON L.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                                  JOIN Tests T 
                                      ON TA.TestAppointmentID = T.TestAppointmentID
                                  WHERE L.LocalDrivingLicenseApplicationID = @LDLApplicationID
                                      AND T.TestResult = 1;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@LDLApplicationID", ldlApplicationID);
                    try
                    {
                        connection.Open();
                        SqlDataReader read = command.ExecuteReader();
                        if (read.Read())
                        {
                            int count = Convert.ToInt32(read[0]);
                            return (byte)count;
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
    }
}
