using Spectre.Console;
using System.Globalization;
using CodingTracker.joshluca98;

Database.CreateDatabaseTable();
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
                AnsiConsole.Markup("[default on blue]Records List[/]\n\n");
                Database.GetAllRecords();
                AnsiConsole.Markup("[green]Press ENTER to continue[/] ");
                Console.ReadLine();
                break;
            case Helper.MenuAction.InsertRecord:
                Console.Clear();
                Database.Insert();
                break;
            case Helper.MenuAction.DeleteRecord:
                Console.Clear();
                Database.Delete();
                break;
            case Helper.MenuAction.UpdateRecord:
                Console.Clear();
                Database.Update();
                break;
            case Helper.MenuAction.Exit:
                Environment.Exit(0);
                break;
        }
    }
}