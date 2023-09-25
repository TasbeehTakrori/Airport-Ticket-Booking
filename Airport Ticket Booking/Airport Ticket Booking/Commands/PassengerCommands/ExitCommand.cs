
using AirportTicketBooking.DBHandler;

namespace AirportTicketBooking.Commands.PassengerCommands
{
    internal class ExitCommand : ICommand
    {
        public List<object> Execute(string userEmail, string[] Parameters, FlightDataHandler flightDataHandler)
        {
            Environment.Exit(0);
            return null;
        }
    }
}
