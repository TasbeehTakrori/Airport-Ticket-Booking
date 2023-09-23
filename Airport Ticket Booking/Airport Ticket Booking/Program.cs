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
            UserHandler userHandler = new();
            await userHandler.FetchData<UserMap>(Paths.UserDBPath, user => user.Email);
            PrintWelcome();
            LogInInterface logInInterface = new();
            (UserType userType, string email) = logInInterface.Start(userHandler);
            IUserInterface userInterface;
            if (userType == UserType.Passenger)
                userInterface = new PassengerInterface();
            else
                userInterface = new ManagerInterface();
            userInterface.Start(email);
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