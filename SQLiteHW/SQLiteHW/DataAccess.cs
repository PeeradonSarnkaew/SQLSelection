using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using Windows.Storage;
using Z.EntityFramework.Extensions;

namespace SQLiteHW
{
    class DataAccess
    {
        public async static void InitializeDatabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("sqliteSample2.db", Windows.Storage.CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample2.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename=sqlitSample2.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS MyTable (UID INTEGER PRIMARY KEY, " +
                    "Text_Entry NVARCHAR(50) NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }
        public static void AddData(string inputName)
        {
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqlitSample.db");
            using (SqliteConnection db = new SqliteConnection($"Filename=sqlitSample2.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "INSERT INTO MyTable VALUES (Null,@Entry1);";
                insertCommand.Parameters.AddWithValue("@Entry1", inputName);
                insertCommand.ExecuteReader();

                db.Close();
            }
        }
        public static List<String> GetData()
        {
            List<String> entries = new List<string>();

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample2.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename=sqlitSample2.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Text_Entry from MyTable", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }

                db.Close();
            }

            return entries;
        }
    }
}
