using Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities.Attributes
{
    public class SalaryValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var entity = (Employee)validationContext.ObjectInstance;

            if (entity.Salary < 0)
            {
                return new ValidationResult(ValidationMessages.Salary);
            }

            return ValidationResult.Success;
        }
    }
}
