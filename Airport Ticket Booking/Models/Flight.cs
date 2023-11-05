using AirportTicketBooking.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace AirportTicketBooking.Models
{
    public class Flight
    {
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Departure Country Is Required!")]
        [DataType(DataType.Text, ErrorMessage = "Invalid Departure Country.")]
        public string? DepartureCountry { get; set; }

        [Required(ErrorMessage = "Destination Country Is Required!")]
        [DataType(DataType.Text, ErrorMessage = "Invalid Destination Country.")]
        public string? DestinationCountry { get; set; }

        [Required(ErrorMessage = "Departure Date Is Required!")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid Departure Date.")]
        [FutureDateValidation]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "Departure Airport Is Required!")]
        [DataType(DataType.Text, ErrorMessage = "Invalid Departure Airport.")]
        public string? DepartureAirport { get; set; }

        [Required(ErrorMessage = "Arrival Airport Is Required!")]
        [DataType(DataType.Text, ErrorMessage = "Invalid Arrival Airport.")]
        public string? ArrivalAirport { get; set; }

        [Required(ErrorMessage = "Economy Price Is Required!")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid Economy Price.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "The Economy Class Price Should be Positive.")]

        public decimal? EconomyPrice { get; set; }

        [Required(ErrorMessage = "Business Price Is Required!")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid Business Price.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "The Business Class Price Should be Positive.")]
        [PriceComparison(nameof(EconomyPrice))]
        public decimal? BusinessPrice { get; set; }

        [Required(ErrorMessage = "Class Price Is Required!")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid First Class Price.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "The First Class Price Should be Positive.")]
        [PriceComparison(nameof(BusinessPrice))]
        public decimal? FirstClassPrice { get; set; }

        public override string ToString()
        {
            return @$"Flight ID: {Id}
                      Departure Country: {DepartureCountry}
                      Destination Country: {DestinationCountry}
                      Departure Date: {DepartureDate}
                      Departure Airport: {DepartureAirport}
                      Arrival Airport: {ArrivalAirport}
                      Economy Price: {EconomyPrice}
                      Business Price: {BusinessPrice}
                      First Class Price: {FirstClassPrice}";
        }
    }
}
