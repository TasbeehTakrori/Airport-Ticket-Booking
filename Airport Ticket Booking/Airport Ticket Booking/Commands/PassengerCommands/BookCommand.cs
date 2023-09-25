
using AirportTicketBooking.DBHandler;

namespace AirportTicketBooking.Commands.PassengerCommands
{
    internal class BookCommand : ICommand
    {
        public List<object> Execute(string userEmail, string[] Parameters, FlightDataHandler flightDataHandler)
        {
            Console.WriteLine("Book Command");
            return null;
        }
    }
}
