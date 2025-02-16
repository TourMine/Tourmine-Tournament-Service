using Microsoft.AspNetCore.Mvc;
using Tourmine.Tournament.Application.Interfaces.SubscriptionManagement;
using Tourmine.Tournament.Application.Requests.SubscriptionManagement;
using Tourmine.Tournament.Application.Requests.TournamentManagement;

namespace Tourmine.Tournament.API.Controller
{
    [ApiController]
    [Route("subscription")]
    public class SubscriptionController : ControllerBase
    {
        private const int LIMIT = 25;

        [HttpPost("v1/create")]
        public async Task<IActionResult> Create([FromBody] CreateSubscriptionRequest request, [FromServices] ICreateSubscriptionUseCase useCase)
        {
            var result = await useCase.Execute(request);
            return Ok(result);
        }

        // Request -> 
        // UseCase -> que recebe o request -> e ent envia para o command
        // Handler -> toda vez que o command for chamado ele irá pegar e então realizar oq precisa ser feito -> prepara o dado para ser enviado para o repository/algo externo


        [HttpGet("v1/{UserId}")]
        public async Task<IActionResult> GetAllByUserId(
            [FromServices] IGetAllSubscriptionByUserIdUseCase useCase,
            [FromRoute] Guid UserId,
            [FromQuery] int start = 0, 
            [FromQuery] int limit = LIMIT
            )
        {
            var result = await useCase.Execute(start, limit, UserId);
            return Ok(new
            {
                total = result.Count,
                items = result
            });
        }

        [HttpPut("v1/{UserId}/{TournamentId}")]
        public async Task<IActionResult> Update([FromRoute] Guid UserId, [FromRoute] Guid TournamentId, [FromBody] UpdateSubscriptionRequest request, [FromServices] IUpdateSubscriptionUseCase useCase)
        {
            try
            {
                var result = await useCase.Execute(UserId, TournamentId, request);
                return Ok(result);
            }
            catch (KeyNotFoundException knex)
            {
                return NotFound(knex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("v1/get-by-tournamentId/{tournamentId}")]
        public async Task<IActionResult> GetAll([FromRoute] Guid tournamentId, [FromQuery] GetAllSubscriptionByTournamentIdRequest request, [FromServices] IGetAllSubscriptionByTournamentIdUseCase useCase)
        {
            var result = await useCase.Execute(tournamentId, request);
            return Ok(new
            {
                total = result.Count,
                items = result
            });
        }
    }
}
