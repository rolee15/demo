using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SharePointConsoleApp1.CLI
{
    class Console
    {
        private static SecureString GetPasswordFromConsole()
        {
           
            var pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = System.Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                    }
                }
                else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd.AppendChar(i.KeyChar);
                }
            }
            return pwd;
        }


        public static SecureString GetPassword()
        {
            System.Console.Write("Password: ");
            SecureString password = GetPasswordFromConsole();
            System.Console.WriteLine();
            return password;
        }

        public static string GetUsername(string defaultUsername)
        {
            if (IsDefaultUsernameEmpty(defaultUsername))
            {
                return GetUsernameFromConsole();
            }
            if (IsDefaultUsernameNotOkay(defaultUsername))
            {
                return GetUsernameFromConsole();
            }

            return defaultUsername;
        }


        private static string GetUsernameFromConsole()
        {
            System.Console.Write("Username: ");
            string username = System.Console.ReadLine();

            return username;
        }

        private static bool IsDefaultUsernameNotOkay(string username)
        {
            System.Console.Write("Do you want to sign in as {0}? y/n ", username);
            return System.Console.ReadLine() == "n";

        }

        private static bool IsDefaultUsernameEmpty(string username)
        {
            return username == "";
        }

    }

}
