using AirportTicketBooking.DBHandler;
using AirportTicketBooking.Enums;
using AirportTicketBooking.Commands.PassengerCommands;

namespace AirportTicketBooking.Interfaces
{
    internal class PassengerInterface : UserInterface
    {
        Dictionary<string, ICommandPassenger> _passengerCommands = new()
        {
                { "search", new SearchCommand()},
                { "book", new BookCommand()},
                { "exit", new ExitCommand() },
                { "mybookings", new MyBookingCommand() },
                { "modifybooking", new ModifyBookingCommand() },
                { "cancelbooking", new CancelBookingCommand() }
        };

        internal override void Start(string email, FlightDataHandler flightDataHandler, BookingDataHandler bookingDataHandler)
        {

            Console.WriteLine("*** PassangerInterface ***");
            ICommandPassenger command;
            List<object> result;
            while (true)
            {
                PrintPassengerMenu();
                (string commandName, string[] commandParameters) = ReadCommand();
                if (_passengerCommands.ContainsKey(commandName))
                {
                    command = _passengerCommands[commandName];
                    result = command.Execute(email, commandParameters, flightDataHandler, bookingDataHandler);
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

        void PrintPassengerMenu()
        {
            Utilities.PrintMessage(@"
            * Enter Help to learn how to use each command..
            * Enter [ Serch : your arguments ] to search for a flight..
            * Enter [ Book : BookID=? , Class=? ] to book a flight..
            * Enter [ MyBookings ] to desplay your bookings..
            * Enter [ ModifyBooking : flightId=? , newClass=? ] to edit specific booking..
            * Enter [ CancelBooking : flightId=? ] to cancle specific booking..
            * Enter [ LogOut ] to return to LogIn Interface..
            * Enter Exit to exit..", MessageType.Menu);
        }
    }
}
