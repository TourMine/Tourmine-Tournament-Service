using MediatR;
using Tourmine.Tournament.Application.Requests.TournamentManagement;

namespace Tourmine.Tournament.Application.Command.TournamentManagement
{
    public class GetTournamentAllQuery : IRequest<List<Domain.Entities.TournamentManagement.Tournament>>
    {
        public int Start { get; set; }
        public int Limit { get; set; }
        public GetTournamentAllRequest Request {  get; set; }

        public GetTournamentAllQuery(
            int start,
            int limit,
            GetTournamentAllRequest request)
        {
            Start = start;
            Limit = limit;
            Request = request;
        }
    }
}
