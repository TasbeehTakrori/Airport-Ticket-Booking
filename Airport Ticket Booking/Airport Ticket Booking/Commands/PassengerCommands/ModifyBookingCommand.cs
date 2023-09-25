using AirportTicketBooking.DBHandler;
using AirportTicketBooking.Enums;

namespace AirportTicketBooking.Commands.PassengerCommands
{
    internal class ModifyBookingCommand : BookCommand, ICommandPassenger
    {
        new public List<object> Execute(string userEmail, string[] parameters, FlightDataHandler flightDataHandler, BookingDataHandler bookingDataHandler)
        {
            Dictionary<string, string> parametersDictionary = FetchParameters(parameters);
            if (!AreParametersValid(parametersDictionary))
                return new() { "Failed!" };
            if (!bookingDataHandler.AlreadyBooked(userEmail, parametersDictionary["flightid"]))
                return new() { "You cann't Modify a flight that you haven't previously booked! Use [ Book ] command to book!" };
            int flightID = int.Parse(parametersDictionary["flightid"]);
            ClassType classType = ParseClassType(parametersDictionary["class"]);
            bookingDataHandler.ModifyBooking(userEmail, flightID, classType);
            return new() { "Modify flight succeeded!" };
        }
    }
}
