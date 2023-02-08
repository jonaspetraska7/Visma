using Common.Entities.Enums;
using Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities.Attributes
{
    public class BossValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var entity = (Employee) validationContext.ObjectInstance;
            
            if(entity.Role == Role.CEO && entity.BossId.HasValue)
            {
                return new ValidationResult(ValidationMessages.Boss);
            }

            if (entity.Role != Role.CEO && !entity.BossId.HasValue)
            {
                return new ValidationResult(ValidationMessages.BossEmpty);
            }

            return ValidationResult.Success;
        }
    }
}
