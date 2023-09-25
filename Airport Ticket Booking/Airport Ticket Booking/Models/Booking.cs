using AirportTicketBooking.Enums;

namespace AirportTicketBooking.Models
{
    public class Booking
    {
        public required int FlightID { get; set; }
        public required string PassengerEmail { get; set; }
        public required ClassType Class { get; set; }
    }
}
