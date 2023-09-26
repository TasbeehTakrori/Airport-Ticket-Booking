using AirportTicketBooking.Models;

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
        public List<Flight> getFlightList() 
        {
            return DataDictionary.Values.ToList();
        }

        internal bool IsAvilableFlightID(int flightID)
        {
            return DataDictionary.ContainsKey(flightID);
        }

        public Flight GetFlight(int flightID)
        {
            if (IsAvilableFlightID(flightID))
                return DataDictionary[flightID];
            else
                return null;
        }
    }
}
