using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_BusinessLayer;

namespace DVLD
{
    internal static class clsGlobal
    {
        public static clsUser currentUser;
      
        public static bool RememberUsernameAndPassword(string username, string password)
        {
            // write username and password in data.txt file with #//# seperator
            string filePath = "data.txt";

            try
            {
                if (username == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }

                string dataLine = username + "#//#" + password;
                File.WriteAllText(filePath, dataLine);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving data: " + ex.Message);
                return false;
            }

        }

        public static bool GetStoredCredintials(ref string username, ref string password)
        {
            string filePath = "data.txt";

            try
            {
                if (File.Exists(filePath))
                {
                    string firstLine = File.ReadLines(filePath).FirstOrDefault();
                    string[] credintials = firstLine.Split(new string[] { "#//#" }, StringSplitOptions.None);

                    username = credintials[0];
                    password = credintials[1];
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking data" + ex.Message);
                return false;
            }
            

        }
    }
}
