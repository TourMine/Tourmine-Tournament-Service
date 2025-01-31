using Tourmine.Tournament.Application.Requests.TournamentManagement;

namespace Tourmine.Tournament.Application.Interface.TournamentManagement
{
    public interface IGetTournamentAllUseCase
    {
        Task<List<Domain.Entities.TournamentManagement.Tournament>> Execute(int start, int limit, GetTournamentAllRequest request);
    }
}
