using AirportTicketBooking.Enums;

namespace AirportTicketBooking.Models
{
    public class Booking
    {
        public required int FlightId { get; set; }
        public required string PassengerEmail { get; set; }
        public required ClassType Class { get; set; }
        public override string ToString()
        {
            return $"Booking for [ FlightId: {FlightId} | PassengerEmail: {PassengerEmail} | Class: {Class} ]";
        }
    }
}
