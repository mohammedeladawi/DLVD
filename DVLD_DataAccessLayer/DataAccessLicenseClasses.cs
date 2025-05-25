using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public static class clsDataAccessLicenseClasses
    {
        // <id, name>
        public static Dictionary<int, string> GetClassesIDName()
        { 
            Dictionary<int, string> licenseClasses = new Dictionary<int, string>();

            string query = "select LicenseClassID, ClassName from LicenseClasses;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int licenseClassID = (int)reader["LicenseClassID"];
                                string className = (string)reader["ClassName"];

                                licenseClasses.Add(licenseClassID, className);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return licenseClasses;
        }

        public static bool FindByLicenseClassID(int licenseClassID, ref string className, ref string classDescription,
            ref byte minAllowedAge, ref byte defaultValidityLength, ref decimal classFees)
        {
            string commandStr = @"Select * From LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandStr, connection))
                {
                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
                    try
                    {
                        connection.Open();
                        SqlDataReader read = command.ExecuteReader();
                        if (read.Read())
                        {
                            className = (string)read["ClassName"];
                            classDescription = (string)read["ClassDescription"];
                            minAllowedAge = Convert.ToByte(read["MinimumAllowedAge"]);
                            defaultValidityLength = Convert.ToByte(read["DefaultValidityLength"]);
                            classFees = (decimal)read["ClassFees"];


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
