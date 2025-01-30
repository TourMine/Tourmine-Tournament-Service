using MediatR;
using Tourmine.Tournament.Application.Command.TournamentManagement;
using Tourmine.Tournament.Application.Interface.TournamentManagement;
using Tourmine.Tournament.Application.Requests.TournamentManagement;

namespace Tourmine.Tournament.Application.UseCases.TournamentManagement
{
    public class CreateTournamentUseCase : BaseUseCase, ICreateTournamentUseCase
    {
        public CreateTournamentUseCase(IMediator mediator) : base(mediator)
        {
            
        }

        public async Task<bool> Execute(CreateTournamentRequest request)
        {
            return await mediator.Send(new CreateTournamentCommand(request));
        }
    }
}
