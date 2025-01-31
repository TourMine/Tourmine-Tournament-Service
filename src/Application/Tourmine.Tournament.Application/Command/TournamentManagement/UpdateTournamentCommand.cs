using MediatR;
using Tourmine.Tournament.Application.Requests.TournamentManagement;

namespace Tourmine.Tournament.Application.Command.TournamentManagement
{
    public class UpdateTournamentCommand : IRequest<Domain.Entities.TournamentManagement.Tournament>
    {
        public Guid Id { get; set; }
        public UpdateTournamentRequest Request { get; set; }

        public UpdateTournamentCommand(Guid id, UpdateTournamentRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}
