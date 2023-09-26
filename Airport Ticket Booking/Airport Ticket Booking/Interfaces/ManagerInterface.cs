using AirportTicketBooking.Commands.ManagerCommands;
using AirportTicketBooking.DBHandler;
using AirportTicketBooking.Enums;

namespace AirportTicketBooking.Interfaces
{
    internal class ManagerInterface : UserInterface
    {
        Dictionary<string, ICommandManager> _managerCommands = new()
        {
            { "exit",  new ExitCommand() },
            { "filter", new FilterCommand() },
            { "validationdetails", new ValidationDetailsCommand() },
            { "uploadflights", new UploadFlightsCommand() },

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
            * Enter [ Filter > One Or More Available Parameters ] to filter booking..

                     Available Parameters: DepartureCountry = ?  DestinationCountry = ? , DepartureDate = ?
                     DepartureAirport = ? ,  ArrivalAirport = ?  passenger = ? , class = ? Price = ? , 

            * Enter [ ValidationDetails ] to display validation details flight..
            * Enter [ UploadFlights > path = FullPath ] to Upload Flights..
            * Enter [ LogOut ] to return to LogIn Interface..
            * Enter Exit to exit..", MessageType.Menu);
        }
    }
}
