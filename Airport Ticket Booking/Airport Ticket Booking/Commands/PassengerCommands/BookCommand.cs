using AirportTicketBooking.DBHandler;
using AirportTicketBooking.Enums;

namespace AirportTicketBooking.Commands.PassengerCommands
{
    internal class BookCommand : ICommand
    {
        public List<object> Execute(string userEmail, string[] parameters, FlightDataHandler flightDataHandler, BookingDataHandler bookingDataHandler)
        {
            Dictionary<string, string> parametersDictionary = FetchParameters(parameters);
            if (!AreParametersValid(parametersDictionary)) return new() { "Failed!" };
            if (bookingDataHandler.AlreadyBooked(userEmail, parametersDictionary["flightid"]))
                return new() { "You already booked it!" };
            int flightID = int.Parse(parametersDictionary["flightid"]);
            ClassType classType = ParseClassType(parametersDictionary["class"]);
            bool isBooking = bookingDataHandler.TryBooking(userEmail, flightID, classType, flightDataHandler);
            if (!isBooking)
                return new() { "This flight does not exist" };
            else
                return new() { "Flight booking was successful!" };
        }

        private ClassType ParseClassType(string value)
        {
            string upperValue = char.ToUpperInvariant(value[0]) + value.Substring(1);
            Enum.TryParse(upperValue, out ClassType classType);
            return classType;
        }

        private bool AreParametersValid(Dictionary<string, string> parametersDictionary)
        {
            if (parametersDictionary.Count != 2) return false;
            if (!AllParametersExist(parametersDictionary)) return false;
            else if (!AllParametersParsable(parametersDictionary)) return false;
            return true;
        }

        private bool AllParametersParsable(Dictionary<string, string> parametersDictionary)
        {
            return IsParsableClass(parametersDictionary["class"]) && IsParsableInt(parametersDictionary["flightid"]);
        }

        private static bool AllParametersExist(Dictionary<string, string> parametersDictionary)
        {
            return parametersDictionary.ContainsKey("class") && parametersDictionary.ContainsKey("flightid");
        }

        private bool IsParsableInt(string value)
        {
            if (int.TryParse(value, out int resulr))
                return true;
            else return false;
        }

        private bool IsParsableClass(string value)
        {
            string upperValue = char.ToUpperInvariant(value[0]) + value.Substring(1);
            if (Enum.TryParse(upperValue, out ClassType classType))
                return true;
            else return false;
        }

        private Dictionary<string, string> FetchParameters(string[] parameters)
        {
            Dictionary<string, string> parametersDictionary = new();
            foreach (var parameter in parameters)
            {
                (string parameterName, string value) = Utilities.SplitParameterNameFromValue(parameter);
                parametersDictionary.Add(parameterName, value);
            }
            return parametersDictionary;
        }
    }
}
