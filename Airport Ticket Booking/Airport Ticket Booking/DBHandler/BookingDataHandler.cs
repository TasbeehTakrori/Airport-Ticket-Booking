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

        internal List<MyBooking> GetMyBookings(string userEmail, FlightDataHandler flightDataHandler)
        {
            return DataDictionary.Where(item => item.Key.Contains(userEmail)).
                Select(item => (item.Value.FlightID, item.Value.Class)).
                Select(data =>
                new MyBooking() { Type = data.Class, Flight = flightDataHandler.GetFlight(data.FlightID)! }).ToList();
        }

        internal bool TryBooking(string userEmail, int flightID, ClassType classType, FlightDataHandler flightDataHandler)
        {
            if (!flightDataHandler.IsAvilableFlightID(flightID))
                return false;
            else
                AppendData(Paths.BookingDBPath, new Booking() { FlightID = flightID, PassengerEmail = userEmail, Class = classType });
            Task.Run(() => ReFetchData());
            return true;
        }
        private async Task ReFetchData()
        {
            try
            {
                await FetchData(Paths.BookingDBPath, booking => booking.FlightID + booking.PassengerEmail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
