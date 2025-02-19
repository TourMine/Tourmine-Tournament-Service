using Tourmine.Tournament.Domain.Enums;

namespace Tourmine.Tournament.Application.Requests.SubscriptionManagement
{
    public class GetAllSubscriptionByTournamentIdRequest
    {
        public ETournamentStatus Status { get; set; }
        public int? Start { get ; set; }
        public int? Limit { get; set; }
    }
}
