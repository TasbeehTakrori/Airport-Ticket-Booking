using AirportTicketBooking.DBHandler;

namespace AirportTicketBooking.Interfaces
{
    internal interface IUserInterface
    {
        void Start(string email, FlightDataHandler flightDataHandler,BookingDataHandler bookingDataHandler);
    }
}
