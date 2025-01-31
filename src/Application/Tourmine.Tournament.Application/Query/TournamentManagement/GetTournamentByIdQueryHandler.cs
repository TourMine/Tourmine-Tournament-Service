using MediatR;
using Tourmine.Tournament.Domain.Interfaces.Repositories;

namespace Tourmine.Tournament.Application.Command.TournamentManagement
{
    public class GetTournamentByIdQueryHandler : IRequestHandler<GetTournamentByIdQuery, Domain.Entities.TournamentManagement.Tournament?>
    {
        private readonly ITournamentRepository _repository;

        public GetTournamentByIdQueryHandler(ITournamentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.TournamentManagement.Tournament?> Handle(GetTournamentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetById(request.Id);
        }
    }
}
