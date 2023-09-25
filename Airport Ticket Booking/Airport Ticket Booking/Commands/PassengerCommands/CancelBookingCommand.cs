using AirportTicketBooking.DBHandler;

namespace AirportTicketBooking.Commands.PassengerCommands
{
    internal class CancelBookingCommand : ICommandPassenger
    {
        public List<object> Execute(string userEmail, string[] parameters, FlightDataHandler flightDataHandler, BookingDataHandler bookingDataHandler)
        {
            (string parameterName, string flightID) = FetchParameters(parameters);
            if (!parameterName.Equals("flightid"))
                return new() { "Failed! Make sure the parameter is spelled correctly." };
            if (!bookingDataHandler.AlreadyBooked(userEmail, flightID))
                return new() { "You cann't cancel a flight that you haven't previously booked! Use [ Book ] command to book!" };
            bookingDataHandler.DeleteRecord(Paths.BookingDBPath, flightID + userEmail);
            return new() { "Cancel Booking succeeded!" };
        }

        private (string parameterName, string parameterValue) FetchParameters(string[] parameters)
        {
            return Utilities.SplitParameterNameFromValue(parameters[0]);
        }
    }
}
