using System.Globalization;

namespace CodingTracker.joshluca98
{
    public static class Helper
    {
        public static string GetDateInput()
        {
            Console.Write("\nEnter date (MM-dd-yyyy): ");
            string dateInput = Console.ReadLine();
            DateTime dateOutput;
            while (!DateTime.TryParseExact(dateInput, "MM-dd-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out dateOutput))
            {
                Console.Clear();
                Console.WriteLine("\nEnter date (MM-dd-yyyy): ");
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
                Database.GetAllRecords();
                Console.WriteLine("(!) Invalid ID entered");
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
                Console.WriteLine("(!) Invalid time entered");
                Console.Write($"{message}");
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