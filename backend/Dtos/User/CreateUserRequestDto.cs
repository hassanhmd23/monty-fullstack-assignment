using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using backend.Validators;

namespace backend.Dtos.User
{
    public class CreateUserRequestDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Username must not be empty")]
        [UserNameAvailable(ErrorMessage = "The specified UserName already taken.")]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "First name must not be empty")]
        [MaxLength(255, ErrorMessage = "First name cannot be longer than 255 characters")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Last name must not be empty")]
        [MaxLength(255, ErrorMessage = "Last name cannot be longer than 255 characters")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [EmailAvailable(ErrorMessage = "The specified email is already in use.")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; } = string.Empty;
        [Required]
        [RegularExpression("^(Admin|User)$", ErrorMessage = "Role must be either Admin or User")]
        public string Role { get; set; } = string.Empty;
    }
}