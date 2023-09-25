using AirportTicketBooking.Commands.ManagerCommands;
using AirportTicketBooking.DBHandler;
using AirportTicketBooking.Enums;

namespace AirportTicketBooking.Interfaces
{
    internal class ManagerInterface : UserInterface
    {
        Dictionary<string, ICommandManager> _managerCommands = new()
        {
            //{ "exit", new ExitCommand() },
        };
        internal override void Start(FlightDataHandler flightDataHandler, BookingDataHandler bookingDataHandler)
        {
            Console.WriteLine("*** ManagerInterface ***");
            ICommandManager command;
            List<object> result;
            while (true)
            {
                PrintManagerMenu();
                (string commandName, string[] commandParameters) = ReadCommand();
                if (_managerCommands.ContainsKey(commandName))
                {
                    command = _managerCommands[commandName];
                    result = command.Execute(commandParameters, flightDataHandler, bookingDataHandler);
                    Desplay(result);
                }
                else if (commandName.ToLower().Equals("logout"))
                {
                    return;
                }
                else
                {
                    Utilities.PrintMessage($"{commandName} Command does not exist! enter Help to learn more..", MessageType.Error);
                }
            }
        }
        void PrintManagerMenu()
        {
            Utilities.PrintMessage(@"
            * Enter Help to learn how to use each command..
            * Enter Exit to exit..", MessageType.Menu);
        }
    }
}
