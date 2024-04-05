using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using backend.Enums;
using backend.Helpers;

namespace backend.Dtos.Subscription
{
    public class SubscriptionRequestDto
    {
        [Required]
        [EnumValidation(typeof(SubscriptionType))]
        public SubscriptionType SubscriptionType { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [StartDateBeforeEndDate(ErrorMessage = "Start date must be before end date.")]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}