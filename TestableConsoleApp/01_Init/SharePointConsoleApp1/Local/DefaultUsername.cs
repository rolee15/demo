using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointConsoleApp1.Local
{
    class DefaultUsername
    {
        
        public static string GetUsername()
        {
            return Properties.Settings.Default.DefaultUsername;
        }

        public static void SaveUsername(string username)
        {
            Properties.Settings.Default.DefaultUsername = username;
            Properties.Settings.Default.Save();
        }


    }
}
