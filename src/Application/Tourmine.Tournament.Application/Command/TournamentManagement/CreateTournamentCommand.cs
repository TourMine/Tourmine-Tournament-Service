using MediatR;
using Tourmine.Tournament.Application.Requests.TournamentManagement;

namespace Tourmine.Tournament.Application.Command.TournamentManagement
{
    public class CreateTournamentCommand : IRequest<bool>
    {
        public CreateTournamentRequest Request { get; set; }

        public CreateTournamentCommand(CreateTournamentRequest request)
        {
            Request = request;
        }
    }
}
