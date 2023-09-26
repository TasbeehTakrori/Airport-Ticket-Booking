using System.ComponentModel.DataAnnotations;

namespace AirportTicketBooking.Validation
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    sealed class PriceComparisonAttribute : ValidationAttribute
    {
        readonly public string OtherPrice;
        public PriceComparisonAttribute(string otherPrice) 
        {
            OtherPrice = otherPrice;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPriceInfo = validationContext.ObjectType.GetProperty(OtherPrice);
            if (otherPriceInfo == null)
            {
                throw new ArgumentException($"Property {OtherPrice} not found.");
            }
            var otherPriceValue = otherPriceInfo.GetValue(validationContext.ObjectInstance);
            if (value is IComparable comparableValue && otherPriceValue is IComparable comparableOther)
            {
                if (comparableValue.CompareTo(comparableOther) <= 0)
                {
                    return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} must be greater than {OtherPrice}.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
