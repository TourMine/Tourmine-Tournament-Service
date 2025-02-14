using MediatR;
using Tourmine.Tournament.Domain.Entities;
using Tourmine.Tournament.Domain.Interfaces.Repositories;

namespace Tourmine.Tournament.Application.Query.SubscriptionManagement
{
    public class GetAllSubscriptionByUserIdHandler : IRequestHandler<GetAllSubscriptionByUserIdQuery, List<Subscription>>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public GetAllSubscriptionByUserIdHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }
        public async Task<List<Subscription>> Handle(GetAllSubscriptionByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _subscriptionRepository.GetAllByUserId(request.Start, request.Limit, request.UserId);
        }
    }
}
