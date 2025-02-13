using Tourmine.Tournament.Application.Requests.TournamentManagement;

namespace Tourmine.Tournament.Application.Interfaces.SubscriptionManagement
{
    public interface IUpdateSubscriptionUseCase
    {
        Task<bool> Execute(Guid UserId, Guid TournamentId, UpdateSubscriptionRequest request);
    }
}
