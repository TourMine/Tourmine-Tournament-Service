using Tourmine.Tournament.Application.Requests.TournamentManagement;

namespace Tourmine.Tournament.Application.Interface.TournamentManagement
{
    public interface ICreateTournamentUseCase
    {
        Task<bool> Execute(CreateTournamentRequest request);
    }
}
