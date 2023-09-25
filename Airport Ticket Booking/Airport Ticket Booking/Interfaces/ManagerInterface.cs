using AirportTicketBooking.DBHandler;
using System;

namespace AirportTicketBooking.Interfaces
{
    internal class ManagerInterface : IUserInterface
    {
        public void Start(string email, FlightDataHandler flightDataHandler, BookingDataHandler bookingDataHandler)
        {
            Console.WriteLine("ManagerInterface");
        }
    }
}
