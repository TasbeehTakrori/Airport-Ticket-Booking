using AirportTicketBooking.Enums;

namespace AirportTicketBooking.Models
{
    public class MyBooking
    {
        public required ClassType Type { get; set; }
        public required Flight Flight { get; set; }
        public override string ToString()
        {
            return $@"Your Booking Class Type is ({Type})
            Details:  {Flight}";
        }
    }
}
