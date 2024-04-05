using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Subscription;
using backend.Helpers;
using backend.Models;

namespace backend.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<List<Subscription>> GetAllSubscriptionsAsync(SubscriptionQueryObject query);
        Task<Subscription?> GetSubscriptionByIdAsync(int id);
        Task<Subscription> CreateSubscriptionAsync(Subscription subscription);
        Task<Subscription?> UpdateSubscriptionAsync(int id, UpdateSubscriptionRequestDto updateSubscriptionRequestDto);
        Task<Subscription?> DeleteSubscriptionAsync(int id);
    }
}