using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsDataAccessApplicationTypes
    {
        public static DataTable GetAllApplicaitonTypes()
        {
            DataTable dt = new DataTable();
            string query = "Select * From ApplicationTypes;";

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

        public static bool FindApplicationTypeByID(int applicationTypeID, ref string title, ref decimal fees)
        {
            string commandStr = @"Select * From ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);
                    try
                    {
                        connection.Open();
                        SqlDataReader read = command.ExecuteReader();
                        if (read.Read())
                        {
                            title = (string)read["ApplicationTypeTitle"];
                            fees = (decimal)read["ApplicationFees"];

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

        public static bool UpdateApplicationType(int applicationTypeID, string title, decimal fees)
        {
            string commandStr = @"UPDATE ApplicationTypes SET 
                                  ApplicationTypeTitle = @ApplicationTypeTitle,
                                  ApplicationFees = @ApplicationFees
                                  WHERE ApplicationTypeID = @ApplicationTypeID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeTitle", title);
                    command.Parameters.AddWithValue("@ApplicationFees", fees);
                    command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);

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
