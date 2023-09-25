using AirportTicketBooking.Models;
using System.Linq;
using System.Linq.Expressions;

namespace AirportTicketBooking.DBHandler
{
    internal class FlightDataHandler : CsvDataHandler<int, Flight, FlightMap>
    {
        public List<Flight> Filter(List<(Func<Flight, string, bool> condition, string value)> filters)
        {
            List<Flight> flights = DataDictionary.Select(element => element.Value).ToList();
            foreach (var (condition, value) in filters)
            {
                flights = flights.Where(flight => condition(flight, value)).ToList();
            }
            return flights;
        }

        internal bool IsAvilableFlightID(int flightID)
        {
            return DataDictionary.ContainsKey(flightID);
        }
    }
}
