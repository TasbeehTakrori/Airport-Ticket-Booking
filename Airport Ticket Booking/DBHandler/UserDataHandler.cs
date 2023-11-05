using AirportTicketBooking.Models;
using AirportTicketBooking.Enums;

namespace AirportTicketBooking.DBHandler
{
    public class UserDataHandler : CsvDataHandler<string, User, UserMap>
    {
        public (bool, UserType) Validate(string email, string password)
        {
            if (!DataDictionary.ContainsKey(email))
                return (false, UserType.NotLoggedIn);
            if (DataDictionary[email].Password.Equals(password))
                return (true, DataDictionary[email].Type);
            else
                return (false, UserType.NotLoggedIn);
        }
    }
}
