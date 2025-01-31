using MediatR;
using Tourmine.Tournament.Application.Command.TournamentManagement;
using Tourmine.Tournament.Application.Interface.TournamentManagement;
using Tourmine.Tournament.Application.Requests.TournamentManagement;

namespace Tourmine.Tournament.Application.UseCases.TournamentManagement
{
    public class GetTournamentAllUseCase : BaseUseCase, IGetTournamentAllUseCase
    {
        public GetTournamentAllUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<List<Domain.Entities.TournamentManagement.Tournament>> Execute(int start, int limit, GetTournamentAllRequest request)
        {
            return await mediator.Send(new GetTournamentAllQuery(start, limit, request));
        }
    }
}
