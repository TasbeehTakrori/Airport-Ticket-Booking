using AirportTicketBooking.Enums;

namespace AirportTicketBooking.Models
{
    public class User
    {
        public required String Email { get; set; }
        public required string Password { get; set; }
        public required UserType Type { get; set; }
    }
}
