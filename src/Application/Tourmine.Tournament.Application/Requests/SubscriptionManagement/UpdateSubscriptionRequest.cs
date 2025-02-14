using Tourmine.Tournament.Domain.Enums;

namespace Tourmine.Tournament.Application.Requests.TournamentManagement
{
    public class UpdateSubscriptionRequest
    {
        public ESubscriptionStatus Status { get; set; }
    }
}
