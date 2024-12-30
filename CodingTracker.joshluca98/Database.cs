using CodingTracker.joshluca98.Models;
using System.Configuration;
using System.Collections.Specialized;
using Dapper;
using Microsoft.Data.Sqlite;
using Spectre.Console;

namespace CodingTracker.joshluca98
{
    public static class Database
    {
        static string connectionString = ConfigurationManager.AppSettings.Get("connectionString");

        public static void CreateDatabaseTable()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS coding_log (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date TEXT NOT NULL,
                    Start_Time TEXT NOT NULL,
                    End_Time TEXT NOT NULL,
                    Duration TEXT NOT NULL
                );";
                connection.Execute(createTableQuery);
            }
        }

        public static void GetAllRecords()
        {
            Console.WriteLine("Records List\n");
            using (var connection = new SqliteConnection(connectionString))
            {
                var sql = "SELECT * FROM coding_log;";
                var records = connection.Query<CodingSession>(sql);
                if (records.Count() == 0) { Console.WriteLine("No records found in the database."); }
                else { Console.WriteLine("ID\tDate\t\tStart Time\tEnd Time\tDuration\n"); }

                foreach (var record in records)
                {
                    Console.WriteLine($"{record.Id}\t{record.Date.ToString("MM-dd-yyyy")}\t{record.Start_Time}\t{record.End_Time}\t{record.Duration}");
                }
                Console.WriteLine();
            }
        }

        public static void Insert()
        {
            Console.WriteLine("Insert Record");
            string date = Helper.GetDateInput();
            TimeSpan startTime = Helper.GetTime("Time started (HH:mm): ");
            TimeSpan endTime = Helper.GetTime("Time ended (HH:mm): ");
            TimeSpan duration = endTime - startTime;

            using (var connection = new SqliteConnection(connectionString))
            {
                string insertQuery = @$"
                    INSERT INTO coding_log(Date, Start_Time, End_Time, Duration)
                    VALUES ('{date}', '{startTime.ToString()}', '{endTime.ToString()}', '{duration.ToString()}');";
                  
                connection.Execute(insertQuery);
                Console.WriteLine($"\nRecord has been created.");
                Console.ReadLine();
            }
        }

        public static void Update()
        {
            Console.WriteLine("Update Record\n");
            GetAllRecords();
            int id = 0;
            using (var connection = new SqliteConnection(connectionString))
            {
                int count = 0;
                while (count < 1)
                {
                    id = Helper.GetId("Enter ID of record to update: ");
                    string checkIdQuery = $"SELECT COUNT(*) FROM coding_log WHERE Id = {id};";
                    count = connection.QuerySingle<int>(checkIdQuery);
                    if (count < 1)
                    {
                        Console.Clear();
                        GetAllRecords();
                        Console.WriteLine($"(!) Enter an ID from the list above.");
                    }
                }
            }

            string date = Helper.GetDateInput();
            TimeSpan startTime = Helper.GetTime("Time started (HH:mm): ");
            TimeSpan endTime = Helper.GetTime("Time ended (HH:mm): ");
            TimeSpan duration = endTime - startTime;

            using (var connection = new SqliteConnection(connectionString))
            {
                string updateQuery = @$"
                    UPDATE coding_log 
                    SET Date = '{date}', 
                        Start_Time = '{startTime.ToString()}',  
                        End_Time = '{endTime.ToString()}',  
                        Duration = '{duration.ToString()}' 
                    WHERE Id = {id};";

                connection.Execute(updateQuery);
                Console.WriteLine($"\nRecord with ID {id} has been updated.");
                Console.ReadLine();
            }
        }

        public static void Delete()
        {
            Console.WriteLine("Delete Record\n");
            GetAllRecords();
            int id = 0;
            using (var connection = new SqliteConnection(connectionString))
            {
                int count = 0;
                while (count < 1)
                {
                    id = Helper.GetId("Enter ID of record to delete: ");
                    string checkIdQuery = $"SELECT COUNT(*) FROM coding_log WHERE Id = {id};";
                    count = connection.QuerySingle<int>(checkIdQuery);
                    if (count < 1)
                    {
                        Console.Clear();
                        GetAllRecords();
                        Console.WriteLine($"(!) Enter an ID from the list above.");
                    }
                }
            }
            using (var connection = new SqliteConnection(connectionString))
            {
                string deleteQuery = $"DELETE from coding_log WHERE Id = '{id}';";
                connection.Execute(deleteQuery);
                Console.WriteLine($"\nRecord with ID {id} has been deleted.");
                Console.WriteLine("Press ENTER to continue..");
                Console.ReadLine();
            }
               
        }
    }
}