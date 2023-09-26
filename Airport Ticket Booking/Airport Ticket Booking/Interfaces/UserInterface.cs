using AirportTicketBooking.DBHandler;
using AirportTicketBooking.Enums;
using System.Reflection.Metadata;

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
                string[] inputSplit = userInput.Trim().Split(">");
                commandName = inputSplit[0].Trim().ToLower();
                string[] parameters = CleanParameters(inputSplit[1]) ?? new string[] { string.Empty };
                return (commandName, parameters);
            }
            catch (Exception)
            {
                return (commandName, new string[] { string.Empty });
            }
        }
        private string[] CleanParameters(string parameters)
        {
            return parameters.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(word => word.Trim().ToLower()).ToArray();
        }
    }
}
