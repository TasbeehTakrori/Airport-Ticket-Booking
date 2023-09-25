
using AirportTicketBooking.DBHandler;
using AirportTicketBooking.Models;
using System.Diagnostics.Metrics;

namespace AirportTicketBooking.Commands.PassengerCommands
{
    internal class SearchCommand : ICommand
    {
        private Dictionary<string, Func<Flight, string, bool>> parameterDictionary = new()
        {
                { "departurecountry", (flight, value) => flight.DepartureCountry == value },
                { "depc", (flight, value) => flight.DepartureCountry == value },
                { "destinationcountry", (flight, value) => flight.DestinationCountry == value },
                { "desc", (flight, value) => flight.DestinationCountry == value },
                { "departureairport", (flight, value) => flight.DepartureAirport == value },
                { "depa", (flight, value) => flight.DepartureAirport == value },
                { "arrivalairport", (flight, value) => flight.ArrivalAirport == value },
                { "arra", (flight, value) => flight.ArrivalAirport == value },
                { "departuredate", (flight, value) => flight.DepartureDate.Date == TryParseDateOrDefult(value)},
                { "date", (flight, value) => flight.DepartureDate.Date == TryParseDateOrDefult(value).Date},
                { "price", (flight, value) => flight.EconomyPrice <= TryParsePriceOrDefult(value) || flight.BusinessPrice <= TryParsePriceOrDefult(value) || flight.FirstClassPrice <= TryParsePriceOrDefult(value) },
                { "p", (flight, value) => flight.EconomyPrice <= TryParsePriceOrDefult(value) || flight.BusinessPrice <= TryParsePriceOrDefult(value) || flight.FirstClassPrice <= TryParsePriceOrDefult(value) },
        };

        public List<object> Execute(string userEmail, string[] Parameters, FlightDataHandler flightDataHandler)
        {
            List<(Func<Flight, string, bool> condition, string value)> filters = new();
            foreach (var paramater in Parameters)
            {
                (string parameterName, string value) = SplitParameterNameFromValue(paramater);
                filters.Add((GetExpression(parameterName), value));
            }
            List<Flight> flights = flightDataHandler.Filter(filters);
            List<object> flightsObject = flights.Cast<object>().ToList();
            return flightsObject;
        }

        private (string parameterName, string value) SplitParameterNameFromValue(string paramater)
        {
            string[] paramaterSplit = paramater.Split('=');
            if (paramaterSplit.Length < 2)
                paramaterSplit = paramater.Split(' ');
            string paramaterName = paramaterSplit[0].Trim();
            string value = paramaterSplit[1].Trim() ?? string.Empty;
            return (paramaterName, value);
        }

        private Func<Flight, string, bool> GetExpression(string paramaterName)
        {
            parameterDictionary!.TryGetValue(paramaterName, out var condition);
            return condition ?? ((flight, value) => false);
        }
        private static int TryParsePriceOrDefult(string value)
        {
            if (int.TryParse(value, out int result))
                return result;
            else
                return int.MinValue;
        }

        private static DateTime TryParseDateOrDefult(string value)
        {
            if (DateTime.TryParse(value, out DateTime result))
                return result;
            else
                return DateTime.MaxValue;
        }
    }
}
