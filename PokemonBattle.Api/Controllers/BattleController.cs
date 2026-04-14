using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonBattle.Api.Dtos;
using PokemonBattle.Api.Services;

namespace PokemonBattle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleController : ControllerBase
    {
        private readonly IBattleService battleService;

        public BattleController(IBattleService _battleService)
        {
            battleService = _battleService;
        }


        [HttpPost("battle-simulation")]
        public async Task<ActionResult> BattleSimulator([FromBody]BattleRequestDto battleRequest)
        {
            var p1 = battleRequest.Pokemon1;
            var p2 = battleRequest.Pokemon2;

            return Ok(await battleService.SimulateBattle(p1, p2));
        }
    }
}
