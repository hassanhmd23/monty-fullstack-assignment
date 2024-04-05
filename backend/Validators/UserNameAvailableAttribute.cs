using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using backend.Interfaces;

namespace backend.Validators
{
    public class UserNameAvailableAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value is not string userName)
            {
                return new ValidationResult("Invalid data type for UserName.");
            }

            var userRepository = (IUserRepository)validationContext
                .GetService(typeof(IUserRepository));

            if (userRepository.CheckUserNameExist(userName))
            {
                return new ValidationResult("The specified UserName already taken.");
            }

            return ValidationResult.Success;
        }
    }
}