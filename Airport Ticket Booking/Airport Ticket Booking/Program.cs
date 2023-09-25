using AirportTicketBooking.DBHandler;
using AirportTicketBooking.Enums;
using AirportTicketBooking.Interfaces;
using AirportTicketBooking.Models;

namespace AirportTicketBooking
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            UserDataHandler userDataHandler = new();
            await userDataHandler.FetchData(Paths.UserDBPath, user => user.Email);
            PrintWelcome();
            LogInInterface logInInterface = new();
            (UserType userType, string email) = logInInterface.Start(userDataHandler);

            FlightDataHandler flightDataHandler = new();
            await flightDataHandler.FetchData(Paths.FlightDBPath, flight => flight.Id);
            IUserInterface userInterface;
            if (userType == UserType.Passenger)
            {
                userInterface = new PassengerInterface();
            }
            else
            {
                userInterface = new ManagerInterface();
            }
            userInterface.Start(email, flightDataHandler);
            Console.ReadKey();
        }

        static void PrintWelcome()
        {
            Console.WriteLine("**************************");
            Console.WriteLine("*****    WELCOM!     *****");
            Console.WriteLine("**************************");
            Console.WriteLine("Press any key to start..");
            Console.ReadKey();
        }
    }

}