using CodingTracker.joshluca98.Models;
using Dapper;
using Microsoft.Data.Sqlite;
using Spectre.Console;

namespace CodingTracker.joshluca98
{
    public static class Database
    {
        static string connectionString = $"Data Source=CodingTracker.db;";
        
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
            GetAllRecords();
            int id = Helper.GetId("Enter ID of record to update: ");
            string date = Helper.GetDateInput();
            TimeSpan startTime = Helper.GetTime("Time started (HH:mm): ");
            TimeSpan endTime = Helper.GetTime("Time ended (HH:mm): ");
            TimeSpan duration = endTime - startTime;

            using (var connection = new SqliteConnection(connectionString))
            {
                string checkIdQuery = $"SELECT COUNT(*) FROM coding_log WHERE Id = {id};";
                int count = connection.QuerySingle<int>(checkIdQuery);
                if (count > 0)
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
                }
                else
                {
                    Console.WriteLine($"\nRecord with ID {id} was not found. No changes have been made.");
                }
                Console.ReadLine();
            }
        }

        public static void Delete()
        {
            GetAllRecords();
            int id = Helper.GetId("Enter ID of record to delete: ");
            using (var connection = new SqliteConnection(connectionString))
            {
                string checkIdQuery = $"SELECT COUNT(*) FROM coding_log WHERE Id = {id};";
                int count = connection.QuerySingle<int>(checkIdQuery);

                if (count > 0)
                {
                    string deleteQuery = $"DELETE from coding_log WHERE Id = '{id}';";
                    connection.Execute(deleteQuery);
                    Console.WriteLine($"\nRecord with ID {id} has been deleted.");
                }
                else
                {
                    Console.WriteLine($"\nRecord with ID {id} was not found. No changes have been made.");
                }
                Console.ReadLine();
            }
        }
    }
}