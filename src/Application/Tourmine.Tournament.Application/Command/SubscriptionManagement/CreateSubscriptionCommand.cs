using MediatR;
using Tourmine.Tournament.Application.Requests.SubscriptionManagement;

namespace Tourmine.Tournament.Application.Command.SubscriptionManagement
{
    public class CreateSubscriptionCommand : IRequest<bool>
    {
        public CreateSubscriptionRequest Request { get; set; }

        public CreateSubscriptionCommand(CreateSubscriptionRequest request)
        {
            Request = request;
        }
    }
}
