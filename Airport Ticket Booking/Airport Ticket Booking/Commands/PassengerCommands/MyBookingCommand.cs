using AirportTicketBooking.DBHandler;
using AirportTicketBooking.Models;

namespace AirportTicketBooking.Commands.PassengerCommands
{
    internal class MyBookingCommand : ICommandPassenger
    {
        public List<object> Execute(string userEmail, string[] parameters, FlightDataHandler flightDataHandler, BookingDataHandler bookingDataHandler)
        {
            List<MyBooking> myBookings = bookingDataHandler.GetMyBookings(userEmail, flightDataHandler);
            List<object> myBookingsObject = myBookings.Cast<object>().ToList();
            return myBookingsObject;
        }
    }
}
