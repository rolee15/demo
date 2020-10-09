using Pimsporter.Adapter;
using Pimsporter.Adapter;
using Pimsporter.Repository;
using Pimsporter.Service;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Pimsporter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create db connection
            var con = new SQLiteConnection("data source=database.db");

            //Get and save username as default
            var consoleWrapper = new ConsoleWrapper();
            var settingsService = new SettingsService();
            var console = new ConsoleAdapter(consoleWrapper, settingsService);
            var username = console.GetUsername();
            var password = console.GetPassword();

            //Get versions
            var sharePointAdapter = new SharePointAdapter(username, password);
            var repository = new AllVersionRepository(sharePointAdapter);
            List<Version> versions = repository.GetAllVersions();

            foreach (Version version in versions)
            {
                Console.WriteLine(version.VersionName);
            }
            Model.Database.SaveVersions(con, versions);

            // Wait for input before exit
            Console.ReadLine();
        }

        private static void Init()
        {
            // Initialize logger and set logging level
            _log = new Logger()
            {
                Target = Logger.LoggingTarget.CONSOLE,
                Level = Logger.LogLevel.DEBUG
            };
        }


        #region Members
        private static Logger _log;
        #endregion
    }
}
