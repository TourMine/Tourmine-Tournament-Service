using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpPut("v1/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTournamentRequest request, [FromServices] IUpdateTournamentUseCase useCase)
        {
            try
            {
                var result = await useCase.Execute(id, request);
                return Ok(result);
            }
            catch (KeyNotFoundException knex)
            {
                return NotFound(knex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
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
