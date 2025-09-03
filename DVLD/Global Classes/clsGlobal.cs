using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_BusinessLayer;
using Microsoft.Win32;

namespace DVLD
{
    internal static class clsGlobal
    {
        public static clsUser currentUser;

        private static readonly string keyName = @"HKEY_CURRENT_USER\Software\DVLD";
        private static readonly string keyPath = @"Software\DVLD";
        private static readonly string valueName = "credintials";

        public static bool RememberUsernameAndPassword(string username, string password)
        {
            // write username and password in windows registry with #//# seperator

            try
            {
                if (username == "")
                {
                    // delete the valueName
                    using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                    {
                        using (RegistryKey key = baseKey.OpenSubKey(keyPath, true))
                        {
                            if (key != null)
                            {
                                // Delete the specified value
                                key.DeleteValue(valueName);
                            }
                        }
                    }

                    return false;
                }

                string value = username + "#//#" + password;
                Registry.SetValue(keyName, valueName, value, RegistryValueKind.String);
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
            // read user credinrials from windows registry
            try
            {
                string value = (string)Registry.GetValue(keyName, valueName, null);

                if (value != null)
                {
                    string[] credintials = value.Split(new string[] { "#//#" }, StringSplitOptions.None);

                    if (credintials.Length == 2)
                    {
                        username = credintials[0];
                        password = credintials[1];
                        return true;
                    }
                }

                return false;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking data" + ex.Message);
                return false;
            }
            

        }
    }
}
