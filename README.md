# Airport Ticket Booking Exercise



[![.NET Version](https://img.shields.io/badge/.NET-7.0-blue)](https://dotnet.microsoft.com/)

## Table of Contents

- [Project Title](#project-title)
- [Description](#description)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)

## Description

The Airport Ticket Booking project is a .NET console application developed to facilitate flight ticket reservations for passengers and booking management for the administrator. This application allows passengers to search for available flights and make reservations, choose the appropriate class for their flight based on various criteria such as price and dates, and more. Additionally, the administrator can use the application to manage bookings, filter data, and import batches of flight information from CSV files.
## Getting Started

### Prerequisites

Before you can use this Airport Ticket Booking system, you'll need the following prerequisites:

1. NET Core SDK: Make sure you have the .NET Core SDK installed on your machine.

2. Code Editor: You can use a code editor of your choice, such as Visual Studio or Visual Studio Code, for development (optional).

####   .NET Version

  This project is built using .NET 7.0 Ensure you have .NET 7.0 or later installed to run the application.

  You can download .NET 7.0 from [here](https://dotnet.microsoft.com/download/dotnet/7.0).

   
### Installation

Follow these steps to set up and run the Airport Ticket Booking system:

1. Clone the repository to your local machine:
  `https://github.com/TasbehTakrore/Airport-Ticket-Booking.git`
2. Navigate to the project directory:
  `cd airport-ticket-booking`
3. Change DB Paths in the Paths file.
4. Build and Run.

## Usage

### For Passengers
1. **Login.**

2. **Searching for Available Flights:**
   You can search for available flights with specific criteria:
   - Use `Search >` command to display all available flights.
   - Use `Search` and Specify parameters like price, departure country, destination country, etc.

        `Search > Price = 600 , DepartureCountry = Palestine`
     
   - View the search results with details.
    
3. **Booking a Flight:**
   To book a flight, follow these steps:
   - Find the right flight using Search Command. 
   - Choose the desired class (Economy, Business, First).
   - use `Book` Command as follow:
        `Book > flightId = 6 , Class = Economy`


4. **Managing Bookings:**
   If you need to manage your bookings:
   - Use `MyBookings` to display your bookings.
   - Use `ModifyBooking > flightId=? , newClass=?` to modify a booking.
   - Use `CancelBooking > flightId=?` to cancel a booking.

5. **Logout.**
   - Use `Logout` Command to return to Login Interface.
   
### For Managers

1. **Filtering Bookings:**
   As a manager, you can filter bookings using various criteria:
   - Use `Filter >` to display all bookings.
   - Use `Filter >` and Specify parameters like price, departure country, destination country, departure date, etc.
     
       `Filter > Price = 600 , Passenger = tasbeh@gg.cc`
     
   - Review the filtered bookings.

2. **Batch Flight Upload:**
   To import a list of flights:
   - Use the `UploadFlights > Path = FullPath` Command To upload csv file.
   - After uploading, the system will **perform data validation**.
   - If the data has Errors, the system will return an error list to review the validation errors and make necessary corrections.
   - If the data is Valid, the system will Append data with Database.

3. **Dynamic Model Validation Details:**
   To understand validation constraints for each field of the flight data model:
   - Use `ValidationDetails` Command.



Remember to run the application and follow these steps to make the most of its features. Enjoy using the Airport Ticket Booking system! :")


