using Tourmine.Tournament.Domain.Enums;

namespace Tourmine.Tournament.Application.Requests.TournamentManagement
{
    public class GetTournamentAllRequest
    {
        public EPlataforms? plataforms { get; set; }
        public EParticipantsType? teamsTypes { get; set; }
        public ESubscriptionType? subscriptionTypes { get; set; }
    }
}
