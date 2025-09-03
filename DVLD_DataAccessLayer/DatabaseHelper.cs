using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DVLD_DataAccessLayer
{
    internal static class clsDatabaseHelper
    {
        private static void Log(string message, EventLogEntryType type)
        {
            string sourceName = "DVLD";

            if (!EventLog.SourceExists(sourceName))
                EventLog.CreateEventSource(sourceName, "Application");

            EventLog.WriteEntry(sourceName, message, type);
        }
    

        public static void LogError(string message) => Log(message, EventLogEntryType.Error);
    
    }
}
