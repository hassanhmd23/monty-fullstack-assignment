using System.ComponentModel.DataAnnotations;
using backend.Validators;

namespace backend.Dtos.User
{
    public class UpdateUserRequestDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Username must not be empty")]
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
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        [Required]
        [RegularExpression("^(Admin|User)$", ErrorMessage = "Role must be either Admin or User")]
        public string Role { get; set; } = string.Empty;
        [Required]
        [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be either Male or Female")]
        public string Gender { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Country must not be empty")]
        public string Country { get; set; } = string.Empty;
    }
}