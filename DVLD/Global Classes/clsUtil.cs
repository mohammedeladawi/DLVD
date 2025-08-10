using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Global_Classes
{
    public class clsUtil
    {
        public static bool CopyImageAndGetPath(ref string sourcePath)
        {
            string destinationFolder = @"C:\DVLD-Person-Images";

            // make sure folder is exist
            Directory.CreateDirectory(destinationFolder);

            string extension = Path.GetExtension(sourcePath);

            string newFileName = Guid.NewGuid().ToString("N") + extension; // No dashes

            string destinationPath = Path.Combine(destinationFolder, newFileName); // C:\folder\file

            try
            {
                File.Copy(sourcePath, destinationPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourcePath = destinationPath;
            return true;
        }
    
        public static bool IsAllowedAge(DateTime dateOfBirth, int minmumAllowedAge)
        {
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Today.AddYears(-age))
                age--;
            return minmumAllowedAge <= age;

        }
    }
}
