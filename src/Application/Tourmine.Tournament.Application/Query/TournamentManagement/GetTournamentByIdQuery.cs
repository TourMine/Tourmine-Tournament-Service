using MediatR;

namespace Tourmine.Tournament.Application.Command.TournamentManagement
{
    public class GetTournamentByIdQuery : IRequest<Domain.Entities.TournamentManagement.Tournament?>
    {
        public Guid Id { get; set; }

        public GetTournamentByIdQuery(Guid id)
        {
           Id = id;
        }
    }
}
