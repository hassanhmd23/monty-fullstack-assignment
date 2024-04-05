using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Subscription;
using backend.Models;

namespace backend.Mappers
{
    public static class SubscriptionMappers
    {
        public static SubscriptionDto ToSubscriptionDto(this Subscription subscription)
        {
            return new SubscriptionDto
            {
                Id = subscription.Id,
                UserId = subscription.UserId,
                SubscriptionType = subscription.SubscriptionType,
                StartDate = subscription.StartDate,
                EndDate = subscription.EndDate,
                CreatedAt = subscription.CreatedAt,
                UpdatedAt = subscription.UpdatedAt
            };
        }

        public static Subscription ToSubscriptionFromCreateDto(this CreateSubscriptionRequestDto createSubscriptionDto)
        {
            return new Subscription
            {
                UserId = createSubscriptionDto.UserId,
                SubscriptionType = createSubscriptionDto.SubscriptionType,
                StartDate = DateTime.SpecifyKind(createSubscriptionDto.StartDate, DateTimeKind.Utc),
                EndDate = DateTime.SpecifyKind(createSubscriptionDto.EndDate, DateTimeKind.Utc)
            };
        }
    }
}