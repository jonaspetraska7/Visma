using Common.Resources;
using System.ComponentModel.DataAnnotations;
using Common.Extensions;

namespace Common.Entities.Attributes
{
    public class BirthdateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var entity = (Employee)validationContext.ObjectInstance;

            if (entity.Birthdate.Age() < 18 && entity.Birthdate.Age() > 70)
            {
                return new ValidationResult(ValidationMessages.Birthdate);
            }

            return ValidationResult.Success;
        }
    }
}
