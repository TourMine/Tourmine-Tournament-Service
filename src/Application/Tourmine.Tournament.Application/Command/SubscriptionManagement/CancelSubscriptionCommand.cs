using MediatR;

namespace Tourmine.Tournament.Application.Command.SubscriptionManagement
{
    public class CancelSubscriptionCommand : IRequest<bool>
    {
        public Guid TournamentId { get; set; }
        public Guid UserId { get; set; }


        public CancelSubscriptionCommand(Guid tournamentId, Guid userId)
        {
            TournamentId = tournamentId;
            UserId = userId;
        }
    }
}
