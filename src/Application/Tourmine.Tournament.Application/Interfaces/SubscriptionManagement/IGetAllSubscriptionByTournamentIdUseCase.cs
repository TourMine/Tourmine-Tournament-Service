using Tourmine.Tournament.Application.Requests.SubscriptionManagement;
using Tourmine.Tournament.Domain.Entities;

namespace Tourmine.Tournament.Application.Interfaces.SubscriptionManagement
{
    public interface IGetAllSubscriptionByTournamentIdUseCase
    {
        Task<List<Subscription>> Execute(Guid tournamentId, GetAllSubscriptionByTournamentIdRequest request);
    }    
}
