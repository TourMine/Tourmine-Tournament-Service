using MediatR;
using Tourmine.Tournament.Application.Interfaces.SubscriptionManagement;
using Tourmine.Tournament.Application.Query.SubscriptionManagement;
using Tourmine.Tournament.Domain.Entities;
using Newtonsoft.Json;
using Tourmine.Tournament.Domain.Interfaces.Caching;

namespace Tourmine.Tournament.Application.UseCases.SubscriptionManagement
{
    public class GetAllSubscriptionByUserIdUseCase : BaseUseCase, IGetAllSubscriptionByUserIdUseCase
    {
        private readonly ICachingService _cachingService;

        public GetAllSubscriptionByUserIdUseCase(IMediator mediator, ICachingService cachingService) : base(mediator)
        {
            _cachingService = cachingService;
        }

        public async Task<List<Subscription>> Execute(int start, int limit, Guid UserId)
        {
            var subscriptionCache = await _cachingService.GetAsync(UserId.ToString());

            List<Subscription>? subscriptions;

            if (!String.IsNullOrEmpty(subscriptionCache))
            {
                subscriptions = JsonConvert.DeserializeObject<List<Subscription>>(subscriptionCache);

                return subscriptions;
            }

            subscriptions = await mediator.Send(new GetAllSubscriptionByUserIdQuery(start, limit, UserId));

            await _cachingService.SetAsync(UserId.ToString(), JsonConvert.SerializeObject(subscriptions));

            return subscriptions;
        }
    }
}
