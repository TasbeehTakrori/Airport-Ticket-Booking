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

        internal bool IsAvailableFlightID(int flightID)
        {
            return DataDictionary.ContainsKey(flightID);
        }

        public Flight GetFlight(int flightID)
        {
            if (IsAvailableFlightID(flightID))
                return DataDictionary[flightID];
            else
                return null;
        }
        internal int GetStartAavilableID()
        {
            return DataDictionary.Keys.Max();
        }
        private async Task ReFetchData()
        {
            try
            {
                await FetchData(Paths.FlightDBPath, flight => flight.Id ?? 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        internal void ResetNewFlightsIDs()
        {
            foreach (var item in DataDictionary)
            {
                item.Value.Id = item.Key;
            }
        }
        public bool TryToAppendToFlightsDB(List<Flight> newFlights) 
        {
            try
            {
                AppendDatas(Paths.FlightDBPath, newFlights);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
