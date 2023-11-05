using CsvHelper.Configuration;
using AirportTicketBooking.Models;

namespace AirportTicketBooking.DBHandler
{
    public class FlightMap : ClassMap<Flight>
    {
        public FlightMap()
        {
            Map(f => f.Id).Index(0);
            Map(f => f.DepartureCountry).Index(1);
            Map(f => f.DestinationCountry).Index(2);
            Map(f => f.DepartureDate).Index(3);
            Map(f => f.DepartureAirport).Index(4);
            Map(f => f.ArrivalAirport).Index(5);
            Map(f => f.EconomyPrice).Index(6);
            Map(f => f.BusinessPrice).Index(7);
            Map(f => f.FirstClassPrice).Index(8);
        }
    }
}
