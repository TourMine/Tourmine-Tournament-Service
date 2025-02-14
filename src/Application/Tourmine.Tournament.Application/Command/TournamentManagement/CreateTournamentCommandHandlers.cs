using MediatR;
using Tourmine.Tournament.Application.Requests.TournamentManagement;
using Tourmine.Tournament.Domain.Interfaces.Repositories;

namespace Tourmine.Tournament.Application.Command.TournamentManagement
{
    public class CreateTournamentCommandHandlers : IRequestHandler<CreateTournamentCommand, bool>
    {
        private readonly ITournamentRepository _repository;

        public CreateTournamentCommandHandlers(ITournamentRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(CreateTournamentCommand request, CancellationToken cancellationToken)
        {
            var entity = ConvertToEntity(request.Request);
            return await _repository.Create(entity);
        }

        private Domain.Entities.TournamentManagement.Tournament ConvertToEntity(CreateTournamentRequest request)
        {
            return new Domain.Entities.TournamentManagement.Tournament
            {
                UserId = request.UserId,
                Name = request.Name,
                Game = request.Game,
                Plataform = request.Plataform,
                MaxTeams = request.MaxTeams,
                TeamsType = request.TeamsType,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Prize = request.Prize,
                SubscriptionType = request.SubscriptionType,
                Status = request.Status,
                Description = request.Description
            };
        } 
    }
}
