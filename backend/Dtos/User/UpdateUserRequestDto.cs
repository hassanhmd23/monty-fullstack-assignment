using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.User
{
    public class UpdateUserRequestDto
    {
        [Required]
        [MinLength(1, ErrorMessage ="First name must not be empty")]
        [MaxLength(255, ErrorMessage ="First name cannot be longer than 255 characters")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage ="Last name must not be empty")]
        [MaxLength(255, ErrorMessage ="Last name cannot be longer than 255 characters")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email {get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}