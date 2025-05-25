using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_BusinessLayer;

namespace DVLD
{
    internal static class clsGlobalSettings
    {
        public static clsUser currentUser = clsUser.FindByUsernameAndPassword("mohammed", "1233");
    }
}
