using MediatR;
using Tourmine.Tournament.Application.Interfaces.SubscriptionManagement;
using Tourmine.Tournament.Application.Query.SubscriptionManagement;
using Tourmine.Tournament.Application.Requests.SubscriptionManagement;
using Tourmine.Tournament.Domain.Entities;

namespace Tourmine.Tournament.Application.UseCases.SubscriptionManagement
{
    public class GetAllSubscriptionByTournamentIdUseCase : BaseUseCase, IGetAllSubscriptionByTournamentIdUseCase
    {
        public GetAllSubscriptionByTournamentIdUseCase(IMediator mediator) : base(mediator)
        {}

        public async Task<List<Subscription>> Execute(Guid tournamentId, GetAllSubscriptionByTournamentIdRequest request)
        {
            return await mediator.Send(new GetAllSubscriptionByTournamentIdQuery(tournamentId, request));
        }
    }
}
