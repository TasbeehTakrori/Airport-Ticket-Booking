
using AirportTicketBooking.DBHandler;
using AirportTicketBooking.Models;

namespace AirportTicketBooking.Commands.PassengerCommands
{
    internal interface ICommand
    {
        List<object> Execute(string userEmail, string[] parameters, FlightDataHandler flightDataHandler, BookingDataHandler bookingDataHandler);
    }
}
