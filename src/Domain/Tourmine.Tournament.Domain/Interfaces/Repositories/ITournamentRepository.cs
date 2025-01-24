namespace Tourmine.Tournament.Domain.Interfaces.Repositories
{
    public interface ITournamentRepository
    {
        Task<bool> Create(Entities.TournamentManagement.Tournament tournament);
    }
}
