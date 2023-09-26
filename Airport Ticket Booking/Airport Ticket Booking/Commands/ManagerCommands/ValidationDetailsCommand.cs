using AirportTicketBooking.DBHandler;
using AirportTicketBooking.Models;
using AirportTicketBooking.Validation;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace AirportTicketBooking.Commands.ManagerCommands
{
    internal class ValidationDetailsCommand : ICommandManager
    {
        public List<object> Execute(string[] parameters, FlightDataHandler flightDataHandler, BookingDataHandler bookingDataHandler)
        {
            string validationDetails = DesplayValidationFlightDetails(new Flight());
            return new() { validationDetails };
        }

        private string DesplayValidationFlightDetails(Object obj)
        {
            var instance = obj;
            var properties = instance.GetType().GetProperties();
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var property in properties)
            {
                if (property.Name.Equals("Id"))
                    continue;
                stringBuilder.AppendLine($"- {property.Name}:");

                var dataTypeAttribute = property.GetCustomAttribute<DataTypeAttribute>();
                if (dataTypeAttribute != null)
                {
                    stringBuilder.AppendLine($"    - Type: {dataTypeAttribute.DataType}");
                }
                stringBuilder.Append("    - Constraint: ");

                var requiredAttribute = property.GetCustomAttribute<RequiredAttribute>();
                if (requiredAttribute != null)
                {
                    stringBuilder.Append(" Required,");
                }

                var rangeAttribute = property.GetCustomAttribute<RangeAttribute>();
                if (rangeAttribute != null)
                {
                    if (rangeAttribute.Minimum.Equals(0))
                        stringBuilder.Append($" Should be Positive,)");
                }

                var futureDateAttribute = property.GetCustomAttribute<FutureDateValidationAttribute>();
                if (futureDateAttribute != null)
                {
                    stringBuilder.Append($" Allowed Range (today => future),");
                }

                var priceComparisonAttribute = property.GetCustomAttribute<PriceComparisonAttribute>();
                if (priceComparisonAttribute != null)
                {
                    stringBuilder.Append($" Higher than {priceComparisonAttribute.OtherPrice} Pice,");
                }
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }
    }
}
