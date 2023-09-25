using AirportTicketBooking.Enums;

namespace AirportTicketBooking
{
    static internal class Utilities
    {
        static internal void PrintMessage(string message, MessageType type)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = (ConsoleColor)type;
            Console.WriteLine(message);
            Console.WriteLine();
            Console.ForegroundColor = originalColor;
        }
        static public (string parameterName, string value) SplitParameterNameFromValue(string paramater)
        {
            try
            {
                string[] paramaterSplit = paramater.Split('=');
                if (paramaterSplit.Length < 2)
                    paramaterSplit = paramater.Split(' ');
                string paramaterName = paramaterSplit[0].Trim().ToLower();
                string value = paramaterSplit[1].Trim() ?? string.Empty;
                return (paramaterName, value);
            }
            catch
            {
                return ("", "");
            }
        }

    }
}
