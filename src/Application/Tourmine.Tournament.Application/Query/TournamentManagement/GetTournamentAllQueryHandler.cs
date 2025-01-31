using MediatR;
using Tourmine.Tournament.Domain.Interfaces.Repositories;

namespace Tourmine.Tournament.Application.Command.TournamentManagement
{
    public class GetTournamentAllQueryHandler : IRequestHandler<GetTournamentAllQuery, List<Domain.Entities.TournamentManagement.Tournament>>
    {
        private readonly ITournamentRepository _repository;

        public GetTournamentAllQueryHandler(ITournamentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Domain.Entities.TournamentManagement.Tournament>> Handle(GetTournamentAllQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll(request.Start, request.Limit, request.Request.plataforms, request.Request.teamsTypes, request.Request.subscriptionTypes);
        }
    }
}
