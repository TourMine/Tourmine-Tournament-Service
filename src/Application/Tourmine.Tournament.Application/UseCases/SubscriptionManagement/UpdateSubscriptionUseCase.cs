using MediatR;
using Tourmine.Tournament.Application.Command.TournamentManagement;
using Tourmine.Tournament.Application.Interfaces.SubscriptionManagement;
using Tourmine.Tournament.Application.Requests.TournamentManagement;

namespace Tourmine.Tournament.Application.UseCases.SubscriptionManagement
{
    public class UpdateSubscriptionUseCase : BaseUseCase, IUpdateSubscriptionUseCase
    {
        public UpdateSubscriptionUseCase(IMediator mediator) : base(mediator) { }

        public async Task<bool> Execute(Guid UserId, Guid TournamentId, UpdateSubscriptionRequest request)
        {
            return await mediator.Send(new UpdateSubscriptionCommand(UserId, TournamentId, request));

        }
    }
}
