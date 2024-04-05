using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using backend.Interfaces;

namespace backend.Validators
{
    public class UserIdExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value is not int userId)
            {
                return new ValidationResult("Invalid data type for UserId.");
            }

            var userRepository = (IUserRepository)validationContext
                .GetService(typeof(IUserRepository));

            if (!userRepository.CheckUserExist(userId))
            {
                return new ValidationResult("The specified UserId does not exist.");
            }

            return ValidationResult.Success;
        }
    }
}