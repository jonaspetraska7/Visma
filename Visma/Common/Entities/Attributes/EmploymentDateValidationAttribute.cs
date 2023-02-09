using Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities.Attributes
{
    public class EmploymentDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var entity = (Employee)validationContext.ObjectInstance;
            var dateFrom = new DateTime(2000, 1, 1);

            if (entity == null || value == null)
            {
                return ValidationResult.Success;
            }

            if (entity.EmploymentDate < dateFrom || entity.EmploymentDate > DateTime.Now)
            {
                return new ValidationResult(ValidationMessages.EmploymentDate);
            }

            return ValidationResult.Success;
        }
    }
}
