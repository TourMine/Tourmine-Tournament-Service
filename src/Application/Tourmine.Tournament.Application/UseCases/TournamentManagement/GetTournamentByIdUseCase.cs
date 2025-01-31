using MediatR;
using Tourmine.Tournament.Application.Command.TournamentManagement;
using Tourmine.Tournament.Application.Interface.TournamentManagement;
using Tourmine.Tournament.Application.Requests.TournamentManagement;

namespace Tourmine.Tournament.Application.UseCases.TournamentManagement
{
    public class GetTournamentByIdUseCase : BaseUseCase, IGetTournamentByIdUseCase
    {
        public GetTournamentByIdUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<Domain.Entities.TournamentManagement.Tournament?> Execute(Guid id)
        {
            return await mediator.Send(new GetTournamentByIdQuery(id));
        }
    }
}
