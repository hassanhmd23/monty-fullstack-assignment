using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using backend.Enums;
using backend.Validators;

namespace backend.Dtos.Subscription
{
    public class CreateSubscriptionRequestDto : SubscriptionRequestDto
    {
        [Required]
        [UserIdExists(ErrorMessage = "The specified UserId does not exist.")]
        public string UserId { get; set; }
    }
}