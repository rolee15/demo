using Pimsporter.Service;
using System;
using System.Security;

namespace Pimsporter.Adapter
{
    public class ConsoleAdapter
    {
        private IConsoleWrapper consoleWrapper;
        private ISettingsService settingsService;

        public ConsoleAdapter(IConsoleWrapper consoleWrapper, ISettingsService settingsService)
        {
            this.consoleWrapper = consoleWrapper;
            this.settingsService = settingsService;
        }

        private SecureString GetPasswordFromConsole()
        {

            var pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = consoleWrapper.ReadKey(true);
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


        public SecureString GetPassword()
        {
            consoleWrapper.Write("Password: ");
            SecureString password = GetPasswordFromConsole();
            consoleWrapper.WriteLine();
            return password;
        }

        public string GetUsername()
        {
            var defaultUsername = settingsService.GetDefaultUsername();
            if (IsDefaultUsernameEmpty(defaultUsername))
            {
                string username = consoleWrapper.GetUsername();
                settingsService.SaveDefaultUsername(username);
                return username;
            }
            if (IsDefaultUsernameNotOkay(defaultUsername))
            {
                string username = consoleWrapper.GetUsername();
                settingsService.SaveDefaultUsername(username);
                return username;
            }

            return defaultUsername;
        }

        public bool IsDefaultUsernameNotOkay(string username)
        {
            consoleWrapper.Write("Do you want to sign in as {0}? y/n ", username);
            return consoleWrapper.ReadLine() == "n";

        }

        public bool IsDefaultUsernameEmpty(string username)
        {
            return username == "";
        }

    }

}
