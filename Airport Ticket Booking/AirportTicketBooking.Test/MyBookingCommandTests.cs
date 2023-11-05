using AirportTicketBooking;
using AirportTicketBooking.Commands.PassengerCommands;
using AirportTicketBooking.DBHandler;

public class MyBookingCommandTests
{
    [Fact]
    public async Task Should_ReturnListOfBookings_When_ExecuteAsync()
    {
        // Arrange
        string userEmail = "t";
        string[] parameters = { };
        FlightDataHandler flightDataHandler = new FlightDataHandler();
        await flightDataHandler.FetchData(Paths.FlightDBPath, flight => flight.Id ?? 0);
        BookingDataHandler bookingDataHandler = new BookingDataHandler();
        await bookingDataHandler.FetchData(Paths.BookingDBPath, booking => booking.FlightId + booking.PassengerEmail);
        var sut = new MyBookingCommand();

        // Act
        List<object> bookings = sut.Execute(userEmail, parameters, flightDataHandler, bookingDataHandler);

        // Assert
        Assert.NotNull(bookings);
        Assert.True(bookings.Count > 0);
    }
}
