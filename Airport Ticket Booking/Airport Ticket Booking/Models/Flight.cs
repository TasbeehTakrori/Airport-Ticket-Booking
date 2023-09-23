
namespace AirportTicketBooking.Models
{
    internal class Flight
    {
        public required int Id { get; set; }
        public required string DepartureCountry { get; set; }
        public required string DestinationCountry { get; set; }
        public required DateTime DepartureDate { get; set; }
        public required string DepartureAirport { get; set; }
        public required string ArrivalAirport { get; set; }
        public required int EconomyPrice { get; set; }
        public required int BusinessPrice { get; set; }
        public required int FirstClassPrice { get; set; }

    }
}
