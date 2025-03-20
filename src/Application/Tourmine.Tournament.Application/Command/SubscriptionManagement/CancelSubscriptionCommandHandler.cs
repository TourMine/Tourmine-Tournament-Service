using MediatR;
using Tourmine.Tournament.Domain.Entities;
using Tourmine.Tournament.Domain.Interfaces.Repositories;

namespace Tourmine.Tournament.Application.Command.SubscriptionManagement
{
    public class CancelSubscriptionCommandHandler : IRequestHandler<CancelSubscriptionCommand, bool>
    {
        private readonly ISubscriptionRepository _repository;

        public CancelSubscriptionCommandHandler(ISubscriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CancelSubscriptionCommand command, CancellationToken cancellationToken)
        {
            Subscription subscription = await _repository.GetByIds(command.TournamentId, command.UserId);

            return await _repository.Cancel(subscription!);
        }
    }
}
