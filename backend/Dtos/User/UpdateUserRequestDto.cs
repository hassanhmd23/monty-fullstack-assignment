using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.User
{
    public class UpdateUserRequestDto
    {
        [Required]
        [MaxLength(255, ErrorMessage ="First name cannot be longer than 255 characters")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(255, ErrorMessage ="Last name cannot be longer than 255 characters")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email {get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}