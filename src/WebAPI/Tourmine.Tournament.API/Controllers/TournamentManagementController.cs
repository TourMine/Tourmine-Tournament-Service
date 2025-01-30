using Microsoft.AspNetCore.Mvc;
using Tourmine.Tournament.Application.Interface.TournamentManagement;
using Tourmine.Tournament.Application.Requests.TournamentManagement;

namespace Tourmine.Tournament.API.Controller
{
    [ApiController]
    [Route("tournament")]
    public class TournamentManagementController : ControllerBase
    {
        [HttpPost("v1/create")]
        public async Task<IActionResult> Create([FromBody] CreateTournamentRequest request, [FromServices] ICreateTournamentUseCase useCase)
        {
            var result = await useCase.Execute(request);
            return Ok(result);
        }
    }
}
