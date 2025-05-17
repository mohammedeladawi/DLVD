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
    public static class clsDataAccessTestTypes
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();
            string query = @"Select * from TestTypes";

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
 
        public static bool FindTestTypeByID(int testTypeID, ref string title, ref string description, ref decimal fees)
        {
            string commandStr = @"Select * From TestTypes WHERE TestTypeID = @TestTypeID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);
                    try
                    {
                        connection.Open();
                        SqlDataReader read = command.ExecuteReader();
                        if (read.Read())
                        {
                            title = (string)read["TestTypeTitle"];
                            description = (string)read["TestTypeDescription"];
                            fees = (decimal)read["TestTypeFees"];

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

        public static bool UpdateTestType(int testTypeID, string title, string description, decimal fees)
        {
            string commandStr = @"UPDATE TestTypes SET 
                                  TestTypeTitle = @TestTypeTitle,
                                  TestTypeDescription = @TestTypeDescription,
                                  TestTypeFees = @TestTypeFees
                                  WHERE TestTypeID = @TestTypeID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@TestTypeTitle", title);
                    command.Parameters.AddWithValue("@TestTypeDescription", description);
                    command.Parameters.AddWithValue("@TestTypeFees", fees);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);

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
