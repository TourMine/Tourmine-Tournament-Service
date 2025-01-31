using Tourmine.Tournament.Domain.Enums;
namespace Tourmine.Tournament.Domain.Interfaces.Repositories
{
    public interface ITournamentRepository
    {
        Task<bool> Create(Entities.TournamentManagement.Tournament tournament);
        Task<Entities.TournamentManagement.Tournament?> GetById(Guid id);
        Task<Entities.TournamentManagement.Tournament> Update(Entities.TournamentManagement.Tournament entity);
        Task<List<Entities.TournamentManagement.Tournament>> GetAll(int start, int limit, EPlataforms? plataforms, EParticipantsType? teamsTypes, ESubscriptionType? subscriptionTypes);
    }
}
