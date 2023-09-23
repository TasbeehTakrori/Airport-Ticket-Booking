using System;

namespace AirportTicketBooking.Interfaces
{
    internal class ManagerInterface : IUserInterface
    {
        public void Start(string email)
        {
            Console.WriteLine("ManagerInterface");
        }
    }
}
