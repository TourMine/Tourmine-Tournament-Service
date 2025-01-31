using MediatR;
using Tourmine.Tournament.Application.Command.TournamentManagement;
using Tourmine.Tournament.Application.Interface.TournamentManagement;
using Tourmine.Tournament.Application.Requests.TournamentManagement;

namespace Tourmine.Tournament.Application.UseCases.TournamentManagement
{
    public class UpdateTournamentUseCase : BaseUseCase, IUpdateTournamentUseCase
    {
        public UpdateTournamentUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<Domain.Entities.TournamentManagement.Tournament> Execute(Guid id, UpdateTournamentRequest request)
        {
            return await mediator.Send(new UpdateTournamentCommand(id, request)); 
        }
    }
}
