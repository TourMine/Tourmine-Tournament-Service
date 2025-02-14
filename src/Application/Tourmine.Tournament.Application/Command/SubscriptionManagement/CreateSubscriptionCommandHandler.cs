using MediatR;
using Tourmine.Tournament.Application.Requests.SubscriptionManagement;
using Tourmine.Tournament.Domain.Entities;
using Tourmine.Tournament.Domain.Enums;
using Tourmine.Tournament.Domain.Interfaces.Repositories;

namespace Tourmine.Tournament.Application.Command.SubscriptionManagement
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, bool>
    {
        private readonly ISubscriptionRepository _repository;
        public CreateSubscriptionCommandHandler(ISubscriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var entity = ConvertToEntity(request.Request);
            return await _repository.Create(entity);
        }

        private Subscription ConvertToEntity(CreateSubscriptionRequest request)
        {
            return new Subscription
            {
                UserId = request.UserId,
                TournamentId = request.TournamentId,
                SubscrpitionDate = DateTime.UtcNow,
                Status = ESubscriptionStatus.ACTIVE
            };
        }
    }
}
