using AirportTicketBooking.Models;
using AirportTicketBooking.Enums;

using System.Linq;
using System.Linq.Expressions;

namespace AirportTicketBooking.DBHandler
{
    internal class BookingDataHandler : CsvDataHandler<string, Booking, BookingMap>
    {
        internal bool AlreadyBooked(string userEmail, string flightID)
        {
            return DataDictionary.ContainsKey(flightID + userEmail);
        }

        internal bool TryBooking(string userEmail, int flightID, ClassType classType, FlightDataHandler flightDataHandler)
        {
            if (!flightDataHandler.IsAvilableFlightID(flightID))
                return false;
            else
                AppendData(Paths.BookingDBPath, new Booking() { FlightID = flightID, PassengerEmail = userEmail, Class = classType });
            return true;
        }

    }
}
