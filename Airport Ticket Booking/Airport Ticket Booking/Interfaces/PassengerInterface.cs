using AirportTicketBooking.DBHandler;
using AirportTicketBooking.Enums;
using AirportTicketBooking.Commands.PassengerCommands;

namespace AirportTicketBooking.Interfaces
{
    internal class PassengerInterface : IUserInterface
    {
        Dictionary<string, ICommand> passangerCommands = new()
        {
                { "search", new SearchCommand()},
                { "book", new BookCommand()},
                { "exit", new ExitCommand() }
        };

        public void Start(string email, FlightDataHandler flightDataHandler, BookingDataHandler bookingDataHandler)
        {

            Console.WriteLine("*** PassangerInterface ***");
            ICommand command;
            List<object> result;
            while (true)
            {
                PrintPassengermenu();
                (string commandName, string[] commandParameters) = ReadPassengerCommand();
                if (passangerCommands.ContainsKey(commandName))
                {
                    command = passangerCommands[commandName];
                    result = command.Execute(email, commandParameters, flightDataHandler, bookingDataHandler);
                    Desplay(result);
                }
                else
                {
                    Utilities.PrintMessage($"{commandName} Command does not exist! enter Help to learn more..", MessageType.Error);
                }
            }

        }

        private void Desplay(List<object> result)
        {

            foreach (var item in result)
            {
                Utilities.PrintMessage(item.ToString()!, MessageType.Information);
                Console.WriteLine();
            }
        }

        void PrintPassengermenu()
        {
            Utilities.PrintMessage(@"
            * Enter Help to learn how to use each command..
            * Enter [ Serch : your arguments ] to search for a flight..
            * Enter [ Book : BookID=? , Class=? ] to book a flight..
            * Enter Exit to exit..", MessageType.Menu);
        }
        private (string, string[]) ReadPassengerCommand()
        {
            Console.Write("Type a command: ");
            string commandName = string.Empty;
            try
            {
                string userInput = Console.ReadLine() ?? string.Empty;
                string[] inputSplit = userInput.Trim().Split(":");
                commandName = inputSplit[0].Trim();
                string[] parameters = CleanParameters(inputSplit[1]);
                return (commandName, parameters);
            }
            catch (Exception)
            {
                return (commandName, new string[0]);
            }
        }
        private string[] CleanParameters(string parameters)
        {
            return parameters.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(word => word.Trim().ToLower()).ToArray();
        }
    }
}