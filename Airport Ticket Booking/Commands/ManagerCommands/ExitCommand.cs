using AirportTicketBooking.DBHandler;

namespace AirportTicketBooking.Commands.ManagerCommands
{
    internal class ExitCommand : ICommandManager
    {
        public List<object> Execute(string[] parameters, FlightDataHandler flightDataHandler, BookingDataHandler bookingDataHandler)
        {
            Environment.Exit(0);
            return null;
        }
    }
}
