using AirportTicketBooking.DBHandler;
using AirportTicketBooking.Enums;
using AirportTicketBooking.Models;

namespace AirportTicketBooking.Commands.ManagerCommands
{
    internal class FilterCommand : ICommandManager
    {
        private Dictionary<string, Func<Booking, Flight, string, bool>> parameterDictionary = new()
        {
                { "departurecountry", (booking, flight, value) => flight.DepartureCountry == value },
                { "depc", (booking, flight, value) => flight.DepartureCountry == value },
                { "passenger", (booking, flight, value) => booking.PassengerEmail == value },
                { "destinationcountry", (booking, flight, value) => flight.DestinationCountry == value },
                { "destc", (booking, flight, value) => flight.DestinationCountry == value },
                { "class", (booking, flight, value) => booking.Class == ParseClassType(value) },
                { "flightid", (booking, flight, value) => flight.Id == TryParseIntOrDefult(value) },
                { "departureairport", (booking, flight, value) => flight.DepartureAirport == value },
                { "depa", (biiking, flight, value) => flight.DepartureAirport == value },
                { "arrivalairport", (booking, flight, value) => flight.ArrivalAirport == value },
                { "arra", (booking, flight, value) => flight.ArrivalAirport == value },
                { "departuredate", (booking, flight, value) => flight.DepartureDate.Date! == TryParseDateOrDefult(value).Date},
                { "date", (booking, flight, value) => flight.DepartureDate.Date! == TryParseDateOrDefult(value).Date},
                { "price", getPriceExpression()},
                { "p", getPriceExpression()},
        };

        static Func<Booking, Flight, string, bool> getPriceExpression()
        {
            return (booking, flight, value) => (flight.EconomyPrice <= TryParseDecimalOrDefult(value) && booking.Class == ClassType.Economy) || (flight.BusinessPrice <= TryParseDecimalOrDefult(value) && booking.Class == ClassType.Business) || (flight.FirstClassPrice <= TryParseDecimalOrDefult(value) && booking.Class == ClassType.First);

        }
        public List<object> Execute(string[] parameters, FlightDataHandler flightDataHandler, BookingDataHandler bookingDataHandler)
        {
            List<(Func<Booking, Flight, string, bool> condition, string value)> filters = PrepareFilters(parameters);
            List<Booking> flights = bookingDataHandler.Filter(filters, flightDataHandler);
            List<object> flightsObject = flights.Cast<object>().ToList();
            return flightsObject;
        }

        private List<(Func<Booking, Flight, string, bool> condition, string value)> PrepareFilters(string[] parameters)
        {
            List<(Func<Booking, Flight, string, bool> condition, string value)> filters = new();
            foreach (var paramater in parameters)
            {
                (string parameterName, string value) = Utilities.SplitParameterNameFromValue(paramater);
                filters.Add((GetExpression(parameterName), value));
            }
            return filters;
        }

        private Func<Booking, Flight, string, bool> GetExpression(string paramaterName)
        {
            parameterDictionary!.TryGetValue(paramaterName, out var condition);
            return condition ?? ((booking, flight, value) => false);
        }
        private static int TryParseIntOrDefult(string value)
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
        private static decimal TryParseDecimalOrDefult(string value)
        {
            if (decimal.TryParse(value, out decimal result))
                return result;
            else
                return decimal.MinValue;
        }
        private static ClassType ParseClassType(string value)
        {
            string upperValue = char.ToUpperInvariant(value[0]) + value.Substring(1);
            Enum.TryParse(upperValue, out ClassType classType);
            return classType;
        }
    }
}