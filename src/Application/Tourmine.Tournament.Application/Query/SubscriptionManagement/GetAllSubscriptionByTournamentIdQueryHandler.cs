using MediatR;
using Tourmine.Tournament.Domain.Entities;
using Tourmine.Tournament.Domain.Interfaces.Repositories;

namespace Tourmine.Tournament.Application.Query.SubscriptionManagement
{
    public class GetAllSubscriptionByTournamentIdQueryHandler : IRequestHandler<GetAllSubscriptionByTournamentIdQuery, List<Subscription>>
    {
        private readonly ISubscriptionRepository _repository;
        public GetAllSubscriptionByTournamentIdQueryHandler(ISubscriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Subscription>> Handle(GetAllSubscriptionByTournamentIdQuery query, CancellationToken cancellationToken)
        {
            var request = query.Request;

            int start = request.Start ?? 0;
            int limit = request.Limit ?? 25;

            return await _repository.GetAllByTournamentId(start, limit, query.TournamentId);
        }
    }
}
