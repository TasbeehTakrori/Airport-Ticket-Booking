using AirportTicketBooking.DBHandler;
using AirportTicketBooking.Enums;

namespace AirportTicketBooking.Test
{
    public class UserDataHandlerTests
    {
        [Fact]
        public async void Validate_ShouldReturnFailure_WhenEmailIsNotValid()
        {
            //Arrange
            UserDataHandler sut = new();
            await sut.FetchData(Paths.UserDBPath, user => user.Email);

            //Act
            (bool success, UserType userType) = sut.Validate("NoOne@g.c", "123456");

            //Assert
            Assert.False(success);
            Assert.Equal(UserType.NotLoggedIn, userType);
        }

        [Fact]
        public async void Validate_ShouldReturnFailure_WhenEmailIsValidAndPasswordIsNotCorrected()
        {
            //Arrange
            UserDataHandler sut = new();
            await sut.FetchData(Paths.UserDBPath, user => user.Email);

            //Act
            (bool success, UserType userType) = sut.Validate("s@g.c", "1111");

            //Assert
            Assert.False(success);
            Assert.Equal(UserType.NotLoggedIn, userType);
        }

        [Fact]
        public async void Validate_ShouldReturnSuccessAndPassenger_WhenEmailIsValidAndPasswordIsCorrected()
        {
            //Arrange
            UserDataHandler sut = new();
            await sut.FetchData(Paths.UserDBPath, user => user.Email);

            //Act
            (bool success, UserType userType) = sut.Validate("s@g.c", "123456");

            //Assert
            Assert.True(success);
            Assert.Equal(UserType.Passenger, userType);
        }

        [Fact]
        public async void Validate_ShouldReturnSuccessAndManager_WhenEmailIsValidAndPasswordIsCorrected()
        {
            //Arrange
            UserDataHandler sut = new();
            await sut.FetchData(Paths.UserDBPath, user => user.Email);

            // Act
            (bool success, UserType userType) = sut.Validate("Admin@g.c", "123456");

            //Assert
            Assert.True(success);
            Assert.Equal(UserType.Manager, userType);
        }
    }
}

