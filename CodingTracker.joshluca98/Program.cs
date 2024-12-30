using Spectre.Console;
using System.Globalization;
using CodingTracker.joshluca98;
UserMenu();

void UserMenu()
{
    while (true)
    {
        Console.Clear();
        var menuChoice = AnsiConsole.Prompt(
            new SelectionPrompt<Helper.MenuAction>()
            .Title("Selection Menu")
            .AddChoices(Enum.GetValues<Helper.MenuAction>()));

        switch (menuChoice)
        {
            case Helper.MenuAction.ViewRecords:
                Console.Clear();
                GetAllRecords();
                Console.ReadLine();
                break;
            case Helper.MenuAction.InsertRecord:
                Console.Clear();
                Insert();
                break;
            case Helper.MenuAction.DeleteRecord:
                Console.Clear();
                Delete();
                break;
            case Helper.MenuAction.UpdateRecord:
                Console.Clear();
                Update();
                break;
            case Helper.MenuAction.Exit:
                Environment.Exit(0);
                break;
        }
    }
}

void GetAllRecords()
{
    Console.WriteLine("Records List Will Go Here\n");
}

void Insert()
{
    string date = Helper.GetDateInput();
    int startTime = Helper.GetTime("Time started (####): ");
    int endTime = Helper.GetTime("Time ended (####): ");
   
    Console.WriteLine($"\n{date} - {startTime} - {endTime}");
    Console.ReadLine();
    //using (var connection = new SqliteConnection(_connectionString))
    //{
    //    connection.Open();
    //    var tableCmd = connection.CreateCommand();
    //    tableCmd.CommandText = $"INSERT INTO drinking_water(date, quantity) VALUES('{date}', {quantity})";
    //    tableCmd.ExecuteNonQuery();
    //    connection.Close();
    //}
}

void Delete()
{
    GetAllRecords();
    int id = Helper.GetId("Enter ID of record to delete: ");
    Console.ReadLine();
    //using (var connection = new SqliteConnection(_connectionString))
    //{
    //    connection.Open();
    //    var tableCmd = connection.CreateCommand();
    //    tableCmd.CommandText = $"DELETE from drinking_water WHERE Id = '{recordId}'";
    //    int rowCount = tableCmd.ExecuteNonQuery();
    //    if (rowCount == 0)
    //    {
    //        Console.WriteLine($"\nRecord with ID '{recordId}' does NOT exist.\n");
    //        Delete();
    //    }
    //    else
    //    {
    //        Console.WriteLine($"\nRecord with ID number '{recordId}' was deleted.\n");
    //        Console.WriteLine("Press ENTER to continue..");
    //        Console.ReadLine();
    //    }
    //    connection.Close();
    //}
}

void Update()
{
    GetAllRecords();
    int id = Helper.GetId("Enter ID of record to update: ");
    string date = Helper.GetDateInput();
    int startTime = Helper.GetTime("Time started (####): ");
    int endTime = Helper.GetTime("Time ended (####): ");
    Console.WriteLine($"\n{date} - {startTime} - {endTime}");
    Console.ReadLine();
    //using (var connection = new SqliteConnection(_connectionString))
    //{
    //    connection.Open();
    //    var checkCmd = connection.CreateCommand();
    //    checkCmd.CommandText = $"SELECT EXISTS(SELECT 1 FROM drinking_water WHERE Id = {recordId})";
    //    int checkQuery = Convert.ToInt32(checkCmd.ExecuteScalar());
    //    if (checkQuery == 0)
    //    {
    //        Console.WriteLine($"\n\nRecord with ID {recordId} doesn't exist.\n\n");
    //        connection.Close();
    //        Update();
    //    }
    //    var tableCmd = connection.CreateCommand();
    //    tableCmd.CommandText = $"UPDATE drinking_water SET date = '{date}', quantity = {quantity} WHERE Id =  {recordId}";
    //    tableCmd.ExecuteNonQuery();
    //    connection.Close();
    //}
    //Console.WriteLine($"\nRecord with Id {recordId} was updated.\n");
    //Console.WriteLine("Press ENTER to continue..");
    //Console.ReadLine();
}
