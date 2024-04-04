using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Dtos.User
{
    public class CreateUserRequestDto
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
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}