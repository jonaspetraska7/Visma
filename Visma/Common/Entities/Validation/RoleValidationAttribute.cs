using Common.Entities.Enums;
using Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities.Validation
{
    public class RoleValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var entity = (Employee) validationContext.ObjectInstance;

            if (entity.Role == Role.CEO)
            {
                return new ValidationResult(ValidationMessages.Ceo);
            }

            return ValidationResult.Success;
        }
    }
}
