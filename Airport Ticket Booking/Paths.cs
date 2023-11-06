namespace AirportTicketBooking
{
    static public class Paths
    {
        public static readonly string databaseDirectory = Environment.GetEnvironmentVariable("DB_PATH");
        public static readonly string UserDBPath = Path.Combine(databaseDirectory, "UserDB.csv");
        public static readonly string FlightDBPath = Path.Combine(databaseDirectory, "FlightDB.csv");
        public static readonly string BookingDBPath = Path.Combine(databaseDirectory, "BookingDB.csv");

    }
}
