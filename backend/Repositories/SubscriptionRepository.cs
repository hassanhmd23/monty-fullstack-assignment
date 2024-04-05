using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Dtos.Subscription;
using backend.Helpers;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApplicationContext _context;

        public SubscriptionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Subscription> CreateSubscriptionAsync(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
            await _context.SaveChangesAsync();
            return subscription;
        }

        public async Task<Subscription?> DeleteSubscriptionAsync(int id)
        {
            var subscription = await _context.Subscriptions.FindAsync(id);

            if (subscription == null)
            {
                return null;
            }

            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();
            return subscription;
        }

        public async Task<List<Subscription>> GetAllSubscriptionsAsync(SubscriptionQueryObject query)
        {
            var subscriptions = _context.Subscriptions.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.UserId)) {
                subscriptions = subscriptions.Where(s => s.UserId == query.UserId);
            }

            return await subscriptions.ToListAsync();
        }

        public async Task<Subscription?> GetSubscriptionByIdAsync(int id)
        {
            return await _context.Subscriptions.FindAsync(id);
        }

        public async Task<Subscription?> UpdateSubscriptionAsync(int id, UpdateSubscriptionRequestDto updateSubscriptionRequestDto)
        {
            var subscription = await _context.Subscriptions.FindAsync(id);

            if (subscription == null)
            {
                return null;
            }

            subscription.SubscriptionType = updateSubscriptionRequestDto.SubscriptionType;
            subscription.StartDate = DateTime.SpecifyKind(updateSubscriptionRequestDto.StartDate, DateTimeKind.Utc);
            subscription.EndDate = DateTime.SpecifyKind(updateSubscriptionRequestDto.EndDate, DateTimeKind.Utc);
            subscription.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return subscription;
        }
    }
}