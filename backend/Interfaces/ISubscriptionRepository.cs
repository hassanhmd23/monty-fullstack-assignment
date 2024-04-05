using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Subscription;
using backend.Models;

namespace backend.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<List<Subscription>> GetAllSubscriptionsAsync();
        Task<Subscription?> GetSubscriptionByIdAsync(int id);
        Task<Subscription> CreateSubscriptionAsync(Subscription subscription);
        Task<Subscription?> UpdateSubscriptionAsync(int id, UpdateSubscriptionRequestDto updateSubscriptionRequestDto);
        Task<Subscription?> DeleteSubscriptionAsync(int id);
    }
}