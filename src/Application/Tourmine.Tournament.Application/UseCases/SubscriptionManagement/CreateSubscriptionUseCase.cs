using MediatR;
using Tourmine.Tournament.Application.Command.SubscriptionManagement;
using Tourmine.Tournament.Application.Interfaces.SubscriptionManagement;
using Tourmine.Tournament.Application.Requests.SubscriptionManagement;
using Tourmine.Tournament.Domain.Interfaces.Services;

namespace Tourmine.Tournament.Application.UseCases.SubscriptionManagement
{
    public class CreateSubscriptionUseCase : BaseUseCase, ICreateSubscriptionUseCase
    {
        private readonly IRabbitMqPublisher _rabbitMqPublisher;

        public CreateSubscriptionUseCase(IMediator mediator, IRabbitMqPublisher rabbitMqPublisher) : base(mediator)
        {
            _rabbitMqPublisher = rabbitMqPublisher;
        }

        public async Task<bool> Execute(CreateSubscriptionRequest request)
        {
            var result = await mediator.Send(new CreateSubscriptionCommand(request));

            if (result)
            {
               await _rabbitMqPublisher.PublishSubscriptionCreatedEvent(request.TournamentId, request.UserId);
            }

            return result;
        }
    }
}
