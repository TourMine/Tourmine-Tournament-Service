using Microsoft.AspNetCore.Mvc;
using Tourmine.Tournament.Application.Interface.TournamentManagement;
using Tourmine.Tournament.Application.Requests.TournamentManagement;

namespace Tourmine.Tournament.API.Controller
{
    [ApiController]
    [Route("tournament")]
    public class TournamentManagementController : ControllerBase
    {
        private const int LIMIT = 25;

        [HttpPost("v1/create")]
        public async Task<IActionResult> Create([FromBody] CreateTournamentRequest request, [FromServices] ICreateTournamentUseCase useCase)
        {
            var result = await useCase.Execute(request);
            return Ok(result);
        }

        [HttpGet("v1/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, [FromServices] IGetTournamentByIdUseCase useCase)
        {
            var result = await useCase.Execute(id);
            return Ok(result);
        }

        [HttpGet("v1/all")]
        public async Task<IActionResult> GetAll([FromQuery] GetTournamentAllRequest request, [FromServices] IGetTournamentAllUseCase useCase, int start = 0, int limit = LIMIT)
        {
            var result = await useCase.Execute(start, limit, request);
            return Ok(new 
            { 
                total = result.Count,
                items = result
            });
        }
    }
}
