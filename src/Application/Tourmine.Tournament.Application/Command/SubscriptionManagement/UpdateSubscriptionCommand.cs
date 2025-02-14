using MediatR;
using Tourmine.Tournament.Application.Requests.TournamentManagement;
using Tourmine.Tournament.Domain.Entities;

namespace Tourmine.Tournament.Application.Command.TournamentManagement
{
    public class UpdateSubscriptionCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid TournamentId { get; set; }
        public UpdateSubscriptionRequest Request { get; set; }

        public UpdateSubscriptionCommand(Guid userId, Guid tournamentId, UpdateSubscriptionRequest request)
        {
            UserId = userId;
            TournamentId = tournamentId;
            Request = request;
        }
    }
}
