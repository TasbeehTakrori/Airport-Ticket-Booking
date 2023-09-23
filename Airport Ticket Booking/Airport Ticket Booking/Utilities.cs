using AirportTicketBooking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
