using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SharePointConsoleApp1.Model
{
    class Database
    {
        
        public static void SaveVersions(SQLiteConnection connection,List<Version> versions)
        {
            SQLiteCommand com = new SQLiteCommand(connection);
            connection.Open();
            
            foreach (Version version in versions)
            {
                com.CommandText = "INSERT INTO Versions (ProductNumber,VersionNumber,VersionName) Values ('" +
                    version.ProductNumber + "','" +
                    version.VersionNumber + "','" +
                    version.VersionName + "')";

                com.ExecuteNonQuery();
            }
            connection.Close();
        }
        public static List<Version> GetVersions(SQLiteConnection connection)
        {
            SQLiteCommand com = new SQLiteCommand(connection);
            connection.Open();

            com.CommandText = "Select * FROM Versions";      // Select all rows from our database table
            
            List<Version> versions = new List<Version>();

            SQLiteDataReader reader = com.ExecuteReader();            
            while (reader.Read())
            {
                versions.Add(new Version() { ProductNumber = reader["ProductNumber"].ToString(), 
                                            VersionNumber = reader["VersionNumber"].ToString(), 
                                            VersionName = reader["VersionName"].ToString() });
            }
            connection.Close();
            return versions;
        }

    }
}
