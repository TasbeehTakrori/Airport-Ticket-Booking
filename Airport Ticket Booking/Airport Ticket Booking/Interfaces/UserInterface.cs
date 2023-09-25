using AirportTicketBooking.DBHandler;
using AirportTicketBooking.Enums;

namespace AirportTicketBooking.Interfaces
{
    internal class UserInterface
    {
        internal virtual void Start(string email, FlightDataHandler flightDataHandler, BookingDataHandler bookingDataHandler)
        { }
        internal virtual void Start(FlightDataHandler flightDataHandler, BookingDataHandler bookingDataHandler)
        { }

        internal void Desplay(List<object> result)
        {
            foreach (var item in result)
            {
                Utilities.PrintMessage(item.ToString()!, MessageType.Information);
                Console.WriteLine();
            }
        }
        internal (string, string[]) ReadCommand()
        {
            Console.Write("Type a command: ");
            string commandName = string.Empty;
            try
            {
                string userInput = Console.ReadLine() ?? string.Empty;
                string[] inputSplit = userInput.Trim().Split(":");
                commandName = inputSplit[0].Trim().ToLower();
                string[] parameters = CleanParameters(inputSplit[1]);
                return (commandName, parameters);
            }
            catch (Exception)
            {
                return (commandName, new string[0]);
            }
        }
        private string[] CleanParameters(string parameters)
        {
            return parameters.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(word => word.Trim().ToLower()).ToArray();
        }
    }
}
