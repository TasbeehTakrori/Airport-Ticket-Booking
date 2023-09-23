using AirportTicketBooking.DBHandler;
using AirportTicketBooking.Enums;

namespace AirportTicketBooking.Interfaces
{
    internal class LogInInterface
    {
        internal (UserType, string) Start(UserHandler userHandler)
        {
            Console.Clear();
            bool isValid = false;
            UserType type = UserType.NotLoggedIn;
            string email = string.Empty;
            while (!isValid)
            {
                (email, string password) = ReadUserInformation();
                (isValid, type) = userHandler.Validate(email, password);
                Console.Clear();
                if (!isValid)
                    Utilities.PrintMessage("Incorrect username or password, try again..", MessageType.Error);
            }
            Utilities.PrintMessage("Success LogIn, Welcome!", MessageType.Success);
            return (type, email);
        }

        (string, string) ReadUserInformation()
        {
            Console.Write("Your Email: ");
            string email = Console.ReadLine() ?? String.Empty;
            Console.Write("Your Password: ");
            string password = Console.ReadLine() ?? String.Empty;
            return (email, password);
        }
    }
}
