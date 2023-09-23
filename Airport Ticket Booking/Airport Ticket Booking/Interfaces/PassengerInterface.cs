using System;

namespace AirportTicketBooking.Interfaces
{
    internal class PassengerInterface : IUserInterface
    {
        public void Start(string email)
        {
            Console.WriteLine("PassangerInterface");
        }
    }
}
