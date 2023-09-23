using CsvHelper.Configuration;
using AirportTicketBooking.Models;

namespace AirportTicketBooking.DBHandler
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Map(u => u.Email).Index(0);
            Map(u => u.Password).Index(1);
            Map(u => u.Type).Index(2);
        }
    }
}
