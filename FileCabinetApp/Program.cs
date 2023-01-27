using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace FileCabinetApp
{
    public static class Program
    {
        private const string DeveloperName = "Maxim Kazalov";
        private const string HintMessage = "Enter your command, or enter 'help' to get help.";
        private const int CommandHelpIndex = 0;
        private const int DescriptionHelpIndex = 1;
        private const int ExplanationHelpIndex = 2;
        private static readonly FileCabinetService ListRecords = new ();

        private static bool isRunning = true;

        private static Tuple<string, Action<string>>[] commands = new Tuple<string, Action<string>>[]
        {
            new Tuple<string, Action<string>>("help", PrintHelp),
            new Tuple<string, Action<string>>("exit", Exit),
            new Tuple<string, Action<string>>("stat", Stat),
            new Tuple<string, Action<string>>("create", Create),
            new Tuple<string, Action<string>>("list", List),
            new Tuple<string, Action<string>>("edit", Edit),
        };

        private static string[][] helpMessages = new string[][]
        {
            new string[] { "help", "prints the help screen", "The 'help' command prints the help screen." },
            new string[] { "exit", "exits the application", "The 'exit' command exits the application." },
            new string[] { "stat", "prints statistics on records", "The 'stat' command prints statistics on records." },
            new string[] { "create", "creates new record", "The 'create' command creates new record." },
            new string[] { "list", "prints current list of records.", "The 'list' command prints current list of records." },
            new string[] { "edit", "allow to edit record.", "The 'list' command edits record." },
        };

        public static void Main(string[] args)
        {
            Console.WriteLine($"File Cabinet Application, developed by {Program.DeveloperName}");
            Console.WriteLine(Program.HintMessage);
            Console.WriteLine();

            do
            {
                Console.Write("> ");
                var line = Console.ReadLine();
                var inputs = line != null ? line.Split(' ', 2) : new string[] { string.Empty, string.Empty };
                const int commandIndex = 0;
                var command = inputs[commandIndex];

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine(Program.HintMessage);
                    continue;
                }

                var index = Array.FindIndex(commands, 0, commands.Length, i => i.Item1.Equals(command, StringComparison.OrdinalIgnoreCase));
                if (index >= 0)
                {
                    const int parametersIndex = 1;
                    var parameters = inputs.Length > 1 ? inputs[parametersIndex] : string.Empty;
                    commands[index].Item2(parameters);
                }
                else
                {
                    PrintMissedCommandInfo(command);
                }
            }
            while (isRunning);
        }

        private static void PrintMissedCommandInfo(string command)
        {
            Console.WriteLine($"There is no '{command}' command.");
            Console.WriteLine();
        }

        private static void PrintHelp(string parameters)
        {
            if (!string.IsNullOrEmpty(parameters))
            {
                var index = Array.FindIndex(helpMessages, 0, helpMessages.Length, i => string.Equals(i[Program.CommandHelpIndex], parameters, StringComparison.OrdinalIgnoreCase));
                if (index >= 0)
                {
                    Console.WriteLine(helpMessages[index][Program.ExplanationHelpIndex]);
                }
                else
                {
                    Console.WriteLine($"There is no explanation for '{parameters}' command.");
                }
            }
            else
            {
                Console.WriteLine("Available commands:");

                foreach (var helpMessage in helpMessages)
                {
                    Console.WriteLine("\t{0}\t- {1}", helpMessage[Program.CommandHelpIndex], helpMessage[Program.DescriptionHelpIndex]);
                }
            }

            Console.WriteLine();
        }

        private static void Exit(string parameters)
        {
            Console.WriteLine("Exiting an application...");
            isRunning = false;
        }

        private static void Stat(string parameters)
        {
            int recordsCount = ListRecords.GetStat();
            Console.WriteLine($"{recordsCount} record(s).");
        }

        private static void Create(string parameters)
        {
            Console.WriteLine("<< Insert data >>");
            Console.Write("First name: ");
            string firstName = Console.ReadLine() ?? string.Empty;
            Console.Write("Last name: ");
            string lastName = Console.ReadLine() ?? string.Empty;
            Console.Write("Date of birth (MM/DD/YYYY): ");
            bool isValidDate = DateTime.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOfBirth);
            Console.Write("Access level: ");
            bool isValidLevel = short.TryParse(Console.ReadLine(),  out short acceessLevel);
            Console.Write("Salary($): ");
            bool isValidSalary = decimal.TryParse(Console.ReadLine(), NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal salary);
            Console.Write("Sex: ");
            bool isValidSex = char.TryParse(Console.ReadLine(), out char sex);

            if (!(isValidDate && isValidLevel && isValidSalary && isValidSex))
            {
                Console.WriteLine("\tInvalid data!\nInsert command 'create' again.");
                return;
            }

            try
            {
                int recordNumber = ListRecords.CreateRecord(firstName, lastName, dateOfBirth, acceessLevel, salary, char.ToUpper(sex, CultureInfo.InvariantCulture));
                Console.WriteLine($"Record #{recordNumber} is created.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("\tInvalid data!\nInsert command 'create' again.");
            }
        }

        private static void List(string parameters)
        {
            foreach (var record in ListRecords.GetRecords())
            {
                string date = record.DateOfBirth.ToString("yyyy-MMM-dd", CultureInfo.InvariantCulture);
                Console.WriteLine("#{0}, {1}, {2}, {5}, {3}, Level {4}, Salary {6}$", record.Id, record.FirstName, record.LastName, date, record.AccessLevel, record.Sex, record.Salary);
            }
        }

        private static void Edit(string parameters)
        {
            Console.Write("> edit ");
            string stringId = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(stringId, out int id) || id < 1 || id > ListRecords.GetStat())
            {
                Console.WriteLine($"#{id} record is not found.");
                return;
            }

            Console.Write("First name: ");
            string firstName = Console.ReadLine() ?? string.Empty;
            Console.Write("Last name: ");
            string lastName = Console.ReadLine() ?? string.Empty;
            Console.Write("Date of birth (MM/DD/YYYY): ");
            bool isValidDate = DateTime.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOfBirth);
            Console.Write("Access level: ");
            bool isValidLevel = short.TryParse(Console.ReadLine(), out short acceessLevel);
            Console.Write("Salary($): ");
            bool isValidSalary = decimal.TryParse(Console.ReadLine(), NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal salary);
            Console.Write("Sex: ");
            bool isValidSex = char.TryParse(Console.ReadLine(), out char sex);

            if (!(isValidDate && isValidLevel && isValidSalary && isValidSex))
            {
                Console.WriteLine("\tInvalid data!\nInsert command 'edit' again.");
                return;
            }

            ListRecords.EditRecord(id, firstName, lastName, dateOfBirth, acceessLevel, salary, sex);
            Console.WriteLine($"Record #{id} is updated.");
        }
    }
}