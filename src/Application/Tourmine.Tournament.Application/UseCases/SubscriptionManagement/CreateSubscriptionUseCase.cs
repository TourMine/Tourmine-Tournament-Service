using MediatR;
using Tourmine.Tournament.Application.Command.SubscriptionManagement;
using Tourmine.Tournament.Application.Interfaces.SubscriptionManagement;
using Tourmine.Tournament.Application.Requests.SubscriptionManagement;

namespace Tourmine.Tournament.Application.UseCases.SubscriptionManagement
{
    public class CreateSubscriptionUseCase : BaseUseCase, ICreateSubscriptionUseCase
    {
        public CreateSubscriptionUseCase(IMediator mediator) : base(mediator)
        {
            
        }

        public async Task<bool> Execute(CreateSubscriptionRequest request)
        {
            return await mediator.Send(new CreateSubscriptionCommand(request));
        }
    }
}
