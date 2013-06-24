using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm.SavePreferences
{
    class UserPreferences
    {
        private static readonly string saveRoot = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MyCompanyName\\MyApplicationName";

        public static int SaveSetting(string key, object value)
        {
            
            return -1;
        }

        public static int GetSetting(string key, ref object value)
        {

            return -1;
        }
    }
}
