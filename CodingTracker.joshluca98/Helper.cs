using System.Globalization;

namespace CodingTracker.joshluca98
{
    public static class Helper
    {
        public static string GetDateInput()
        {
            Console.WriteLine("\nEnter date (MM-dd-yyyy):\n");
            string dateInput = Console.ReadLine();

            while (!DateTime.TryParseExact(dateInput, "MM-dd-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out _))
            {
                if (dateInput == "0") return dateInput;
                Console.Clear();
                Console.WriteLine("\nPlease type a date (MM-dd-yyyy):\n");
                dateInput = Console.ReadLine();
            }
            return dateInput;
        }

        public static int GetId(string message)
        {
            Console.Write(message);
            string numberInput = Console.ReadLine();

            int finalInput;
            while (!int.TryParse(numberInput, out finalInput) || finalInput < 0)
            {
                Console.WriteLine($"\n{message}\n");
                numberInput = Console.ReadLine();
            }
            return finalInput;
        }

        public static int GetTime(string message)
        {
            Console.Write(message);
            string numberInput = Console.ReadLine();

            int finalInput;
            while (!int.TryParse(numberInput, out finalInput) || finalInput.ToString().Length != 4)
            {
                Console.Write($"{message}");
                numberInput = Console.ReadLine();
            }
            return finalInput;
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
