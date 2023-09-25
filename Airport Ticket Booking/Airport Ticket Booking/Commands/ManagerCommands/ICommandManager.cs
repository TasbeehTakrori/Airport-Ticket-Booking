using AirportTicketBooking.DBHandler;

namespace AirportTicketBooking.Commands.ManagerCommands
{
    internal interface ICommandManager
    {
        List<object> Execute(string[] parameters, FlightDataHandler flightDataHandler, BookingDataHandler bookingDataHandler);
    }
}
