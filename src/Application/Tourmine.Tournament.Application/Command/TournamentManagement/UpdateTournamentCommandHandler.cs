using MediatR;
using Tourmine.Tournament.Application.Requests.TournamentManagement;
using Tourmine.Tournament.Domain.Interfaces.Repositories;

namespace Tourmine.Tournament.Application.Command.TournamentManagement
{
    public class UpdateTournamentCommandHandler : IRequestHandler<UpdateTournamentCommand, Domain.Entities.TournamentManagement.Tournament>
    {
        private readonly ITournamentRepository _tournamentRepository;
        public UpdateTournamentCommandHandler(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public async Task<Domain.Entities.TournamentManagement.Tournament> Handle(UpdateTournamentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingTournament = await _tournamentRepository.GetById(request.Id);

                if (existingTournament == null)
                {
                    throw new KeyNotFoundException($"Torneio com Id {request.Id} não encontrado.");
                }

                var updatedEntity = ToUpdate(existingTournament, request.Request);

                return await _tournamentRepository.Update(updatedEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private Domain.Entities.TournamentManagement.Tournament ToUpdate(Domain.Entities.TournamentManagement.Tournament entity, UpdateTournamentRequest request)
        {
            entity.Name = request.Name;
            entity.Game = request.Game;
            entity.Plataform = request.Plataform;
            entity.MaxTeams = request.MaxTeams;
            entity.TeamsType = request.TeamsType;
            entity.StartDate = request.StartDate;
            entity.EndDate = request.EndDate;
            entity.Prize = request.Prize;
            entity.SubscriptionType = request.SubscriptionType;
            entity.Status = request.Status;
            entity.Description = request.Description;
            entity.ModifiedDate = DateTime.Now;

            return entity;
        }
    }
}
