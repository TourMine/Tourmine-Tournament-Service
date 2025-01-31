using Tourmine.Tournament.Application.Requests.TournamentManagement;

namespace Tourmine.Tournament.Application.Interface.TournamentManagement
{
    public interface IUpdateTournamentUseCase
    {
        Task<Domain.Entities.TournamentManagement.Tournament> Execute(Guid id, UpdateTournamentRequest request);
    }
}
