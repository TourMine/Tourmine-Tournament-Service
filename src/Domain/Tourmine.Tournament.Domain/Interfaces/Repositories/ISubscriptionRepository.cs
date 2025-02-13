using Tourmine.Tournament.Domain.Entities;
using Tourmine.Tournament.Domain.Enums;
namespace Tourmine.Tournament.Domain.Interfaces.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<bool> Create(Subscription subscription);
        Task<Subscription?> GetByIds(Guid tournamentId, Guid userId); 
        Task<List<Subscription>> GetAllByUserId(int start, int limit, Guid userId);
        Task<List<Subscription>> GetAllByTournamentId(int start, int limit, Guid tournamentId);
    }
}
