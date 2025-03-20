using MediatR;
using Tourmine.Tournament.Application.Command.SubscriptionManagement;
using Tourmine.Tournament.Application.Interfaces.SubscriptionManagement;

namespace Tourmine.Tournament.Application.UseCases.SubscriptionManagement
{
    public class CancelSubscriptionUseCase : BaseUseCase, ICancelSubscriptionUseCase
    {

        public CancelSubscriptionUseCase(IMediator mediator) : base(mediator)
        {}

        public async Task<bool> Execute(Guid tournamentId, Guid userId)
        {
            return await mediator.Send(new CancelSubscriptionCommand(tournamentId, userId));
        }
    }
}
