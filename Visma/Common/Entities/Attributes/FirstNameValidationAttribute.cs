using Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities.Attributes
{
    public class FirstNameValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var entity = (Employee)validationContext.ObjectInstance;

            if (entity.FirstName.ToLower() == entity.LastName.ToLower())
            {
                return new ValidationResult(ValidationMessages.FirstName);
            }

            return ValidationResult.Success;
        }
    }
}
