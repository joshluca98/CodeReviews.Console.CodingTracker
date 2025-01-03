using Spectre.Console;
using System.Globalization;

namespace CodingTracker.joshluca98
{
    public static class Helper
    {
        public static string GetDateInput()
        {
            Console.Write("Enter date (MM-dd-yyyy): ");
            string dateInput = Console.ReadLine();
            DateTime dateOutput;
            while (!DateTime.TryParseExact(dateInput, "MM-dd-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out dateOutput))
            {
                AnsiConsole.Markup("\n[red]Invalid date entered![/]\n");
                Console.Write("\nEnter a VALID date (MM-dd-yyyy): ");
                dateInput = Console.ReadLine();
            }
            return dateOutput.ToString("MM-dd-yyyy");
        }

        public static int GetId(string message)
        {
            Console.Write(message);
            string numberInput = Console.ReadLine();
            int finalInput;
            while (!int.TryParse(numberInput, out finalInput) || finalInput < 0)
            {
                Console.Clear();
                AnsiConsole.Markup("[red]Invalid ID entered![/]\n\n");
                Database.GetAllRecords();
                Console.Write($"{message}");
                numberInput = Console.ReadLine();
            }
            return finalInput;
        }

        public static TimeSpan GetTime(string message)
        {
            Console.Write(message);
            string timeInput = Console.ReadLine();
            TimeSpan timeOutput;
            while (!TimeSpan.TryParseExact(timeInput, "hh\\:mm", null, out timeOutput))
            {
                AnsiConsole.Markup("\n[red]Invalid time entered![/]\n\n");
                Console.Write(message);
                timeInput = Console.ReadLine();
            }
            return timeOutput;
        }

        public enum MenuAction
        {
            ViewRecords,
            InsertRecord,
            DeleteRecord,
            UpdateRecord,
            Exit,
        }
    }
}