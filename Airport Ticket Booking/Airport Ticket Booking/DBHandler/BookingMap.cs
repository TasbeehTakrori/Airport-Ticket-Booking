using CsvHelper.Configuration;
using AirportTicketBooking.Models;

namespace AirportTicketBooking.DBHandler
{
    public class BookingMap : ClassMap<Booking>
    {
        public BookingMap()
        {
            Map(b => b.FlightID).Index(0);
            Map(b => b.PassengerEmail).Index(1);
            Map(b => b.Class).Index(2);
        }
    }
}
