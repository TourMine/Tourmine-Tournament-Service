using Tourmine.Tournament.Domain.Entities;

namespace Tourmine.Tournament.Application.Interfaces.SubscriptionManagement
{
    public interface IGetAllSubscriptionByUserIdUseCase
    {
        Task<List<Subscription>> Execute(int start, int limit, Guid UserId);
    }
}
