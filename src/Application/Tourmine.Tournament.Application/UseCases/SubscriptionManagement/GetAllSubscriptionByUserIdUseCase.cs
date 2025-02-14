using MediatR;
using Tourmine.Tournament.Application.Interfaces.SubscriptionManagement;
using Tourmine.Tournament.Application.Query.SubscriptionManagement;
using Tourmine.Tournament.Domain.Entities;

namespace Tourmine.Tournament.Application.UseCases.SubscriptionManagement
{
    public class GetAllSubscriptionByUserIdUseCase : BaseUseCase, IGetAllSubscriptionByUserIdUseCase
    {
        public GetAllSubscriptionByUserIdUseCase(IMediator mediator) : base(mediator)
        {}

        public async Task<List<Subscription>> Execute(int start, int limit, Guid UserId)
        {
            return await mediator.Send(new GetAllSubscriptionByUserIdQuery(start, limit, UserId));
        }
    }
}
