using MediatR;
using Tourmine.Tournament.Domain.Entities;

namespace Tourmine.Tournament.Application.Query.SubscriptionManagement
{
    public class GetAllSubscriptionByUserIdQuery : IRequest<List<Subscription>>
    {
        public int Start { get; set; }
        public int Limit { get; set; }
        public Guid UserId{ get; set; }

        public GetAllSubscriptionByUserIdQuery(
            int start,
            int limit,
            Guid userId)
        {
            Start = start;
            Limit = limit;
            UserId = userId;
        }
    }
}
