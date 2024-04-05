using System.ComponentModel.DataAnnotations;

namespace backend.Validators
{
    public class EnumValidationAttribute : ValidationAttribute
    {
        private readonly Type _enumType;

        public EnumValidationAttribute(Type enumType)
        {
            _enumType = enumType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !Enum.IsDefined(_enumType, value))
            {
                return new ValidationResult($"The {validationContext.DisplayName} field is not valid.");
            }

            return ValidationResult.Success;
        }
    }
}