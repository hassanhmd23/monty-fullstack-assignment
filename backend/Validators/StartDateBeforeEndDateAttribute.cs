using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Subscription;

namespace backend.Validators
{
    public class StartDateBeforeEndDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dto = (SubscriptionRequestDto)validationContext.ObjectInstance;

            if (dto.StartDate >= dto.EndDate)
            {
                return new ValidationResult("Start date must be before end date.");
            }

            return ValidationResult.Success;
        }
    }
}