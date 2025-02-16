using MediatR;
using Tourmine.Tournament.Application.Requests.SubscriptionManagement;
using Tourmine.Tournament.Domain.Entities;

namespace Tourmine.Tournament.Application.Query.SubscriptionManagement
{
    public class GetAllSubscriptionByTournamentIdQuery : IRequest<List<Subscription>>
    {
        public Guid TournamentId { get; set; }
        public GetAllSubscriptionByTournamentIdRequest Request { get; set; }
        
        public GetAllSubscriptionByTournamentIdQuery(Guid TournamentId, GetAllSubscriptionByTournamentIdRequest Request)
        {
            this.TournamentId = TournamentId;
            this.Request = Request;
        }
    }
}
