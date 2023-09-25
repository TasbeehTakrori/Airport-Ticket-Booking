
using AirportTicketBooking.DBHandler;

namespace AirportTicketBooking.Commands.PassengerCommands
{
    internal class ExitCommand : ICommandPassenger
    {
        public List<object> Execute(string userEmail, string[] parameters, FlightDataHandler flightDataHandler, BookingDataHandler bookingDataHandler)
        {
            Environment.Exit(0);
            return null;
        }
    }
}
