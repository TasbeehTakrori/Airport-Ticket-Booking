using AirportTicketBooking.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using AirportTicketBooking.Enums;

namespace AirportTicketBooking.DBHandler
{
    internal class UserHandler : CsvDataHandler<User>
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
