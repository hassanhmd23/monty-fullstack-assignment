
using backend.Enums;

namespace backend.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public User User { get; set; }
    }
}