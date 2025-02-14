using Tourmine.Tournament.Domain.Enums;

namespace Tourmine.Tournament.Domain.Entities
{
    public class Subscription
    {
        public Guid TournamentId { get; set; }
        public Guid UserId { get; set; }
        public DateTime SubscrpitionDate { get; set; }
        public ESubscriptionStatus Status { get; set; }
    }
}
