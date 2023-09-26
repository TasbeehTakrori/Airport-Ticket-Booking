using AirportTicketBooking.DBHandler;
using AirportTicketBooking.Models;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace AirportTicketBooking.Commands.ManagerCommands
{
    internal class UploadFlightsCommand : ICommandManager
    {
        public List<object> Execute(string[] parameters, FlightDataHandler flightDataHandler, BookingDataHandler bookingDataHandler)
        {
            (string parameterName, string fullPath) = FetchParameters(parameters);
            if (!parameterName.Equals("path"))
                return new() { "Failed! Make sure the parameter is spelled correctly." };
            if (!File.Exists(fullPath))
                return new() { "Failed! Make sure the FULL path is correct." };
            FlightDataHandler newFlightHandler = new FlightDataHandler();
            int startAvailableID = flightDataHandler.GetStartAavilableID() + 1;
            (bool IsSucceed, List<Flight> newFlights) = FetchNewFlights(newFlightHandler, fullPath, startAvailableID);
            if (!IsSucceed) return new() { "Failed!" };
            List<string> errors = Validate(newFlights);
            if (errors.Count() > 0)
            {
                List<object> errorsObject = errors.Cast<object>().ToList();
                return errorsObject;
            }
            newFlightHandler.ResetNewFlightsIDs();
            bool isSucceed = flightDataHandler.TryToAppendToFlightsDB(newFlights);
            if (isSucceed)
                return new() { $"Successfully adding {newFlights.Count()} new flights." };
            return new() { "Failed! Try again.." };
        }

        private (bool IsSuccessed, List<Flight> newFlights) FetchNewFlights(FlightDataHandler newFlightHandler, string fullPath, int startAvailableID)
        {
            try
            {
                Task.Run(() => newFlightHandler.FetchData(fullPath, flight => startAvailableID++)).Wait();
                return (true, newFlightHandler.getFlightList());
            }
            catch (Exception e)
            {
                return (false, new() { });
            }
        }

        private (string parameterName, string parameterValue) FetchParameters(string[] parameters)
        {
            return Utilities.SplitParameterNameFromValue(parameters[0]);
        }

        public List<string> Validate(List<Flight> flightsData)
        {
            List<string> errors = new List<string>();
            int lineNumber = 0;
            foreach (var flightData in flightsData)
            {
                List<ValidationResult> validationResults = new List<ValidationResult>();
                var context = new ValidationContext(flightData, null, null);
                lineNumber++;
                if (!Validator.TryValidateObject(flightData, context, validationResults, true))
                {
                    var flightError = validationResults.Select(result => result.ErrorMessage).ToList();
                    flightError.Insert(0, $"Flight Line # {lineNumber}: ");
                    errors.Add(string.Join(" ", flightError));
                }
            }
            return errors;
        }
    }
}
