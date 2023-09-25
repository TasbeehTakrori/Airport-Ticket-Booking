using AirportTicketBooking.Models;
using AirportTicketBooking.Enums;

namespace AirportTicketBooking.DBHandler
{
    internal class BookingDataHandler : CsvDataHandler<string, Booking, BookingMap>
    {
        internal bool AlreadyBooked(string userEmail, string flightID)
        {
            return DataDictionary.ContainsKey(flightID + userEmail);
        }
        public List<Booking> Filter(List<(Func<Booking, Flight, string, bool> condition, string value)> filters, FlightDataHandler flightDataHandler)
        {
            List<Booking> bookings = DataDictionary.Select(element => element.Value).ToList();

            foreach (var (condition, value) in filters)
            {
                var query = from booking in bookings
                            join flight in flightDataHandler.getFlightList() on booking.FlightId equals flight.Id
                            where condition(booking, flight, value)
                            select booking;
                bookings = query.ToList();
            }
            return bookings;
        }
        internal void ModifyBooking(string userEmail, int flightID, ClassType classType)
        {
            DeleteRecord(Paths.BookingDBPath, flightID + userEmail);
            Booking newBooking = new() { PassengerEmail = userEmail, FlightId = flightID, Class = classType };
            AppendData(Paths.BookingDBPath, newBooking);
            Task.Run(() => ReFetchData());
        }

        internal List<MyBooking> GetMyBookings(string userEmail, FlightDataHandler flightDataHandler)
        {
            return DataDictionary.Where(item => item.Key.Contains(userEmail)).
                Select(item => (item.Value.FlightId, item.Value.Class)).
                Select(data =>
                new MyBooking() { Type = data.Class, Flight = flightDataHandler.GetFlight(data.FlightId)! }).ToList();
        }

        internal bool TryBooking(string userEmail, int flightID, ClassType classType, FlightDataHandler flightDataHandler)
        {
            if (!flightDataHandler.IsAvilableFlightID(flightID))
                return false;
            else
                AppendData(Paths.BookingDBPath, new Booking() { FlightId = flightID, PassengerEmail = userEmail, Class = classType });
            Task.Run(() => ReFetchData());
            return true;
        }
        private async Task ReFetchData()
        {
            try
            {
                await FetchData(Paths.BookingDBPath, booking => booking.FlightId + booking.PassengerEmail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
