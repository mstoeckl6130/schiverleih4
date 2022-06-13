using System.ComponentModel.DataAnnotations;

namespace schiverleih4.CustomValidations
{
    public class PriceValidation:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string str_value;
            str_value = value.ToString();
            if (str_value.Contains("."))
            {
                return base.IsValid(value, validationContext);
            }
            else
            {
                return new ValidationResult("Bitte geben Sie einen gültigen Preis ein.");
            }
            
        }
    }
}
