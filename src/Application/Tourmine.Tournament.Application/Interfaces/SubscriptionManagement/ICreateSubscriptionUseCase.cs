using Tourmine.Tournament.Application.Requests.SubscriptionManagement;

namespace Tourmine.Tournament.Application.Interfaces.SubscriptionManagement
{
    public interface ICreateSubscriptionUseCase
    {
        Task<bool> Execute(CreateSubscriptionRequest request);
    }
}
