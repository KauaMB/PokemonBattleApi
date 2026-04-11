using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonBattle.Api.Models;
using PokemonBattle.Api.Services;

namespace PokemonBattle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService PokeService;

        public PokemonController(IPokemonService pokemonService)
        {
            PokeService = pokemonService;
        }

        [HttpGet("{identifier}")]
        public async Task<ActionResult> GetPokemon(string identifier)
        {
            var pokemon = await PokeService.GetPokemonFromDb(identifier);

            if (pokemon == null) return NotFound($"The pokemon {identifier} does not exist");

            return Ok(pokemon);
        }
    }
}
