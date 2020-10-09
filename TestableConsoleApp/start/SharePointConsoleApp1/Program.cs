using SharePointConsoleApp1.Repository;
using SharePointConsoleApp1.SharePoint;
using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;

namespace SharePointConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create db connection
            SQLiteConnection con = new SQLiteConnection("data source=database.db");

            //Get and save username as default
            string username = Local.DefaultUsername.GetUsername();
            username = CLI.Console.GetUsername(username);
            Local.DefaultUsername.SaveUsername(username);

            //Get password
            var password = CLI.Console.GetPassword();
            
            //Get versions
            var sharePointAdapter = new SharePointAdapter(username, password);
            var repository = new AllVersionRepository(sharePointAdapter);
            List<Version> versions = repository.GetAllVersions();

            foreach (Version version in versions)
            {
                Console.WriteLine(version.VersionName);
            }
            Model.Database.SaveVersions(con,versions);

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
