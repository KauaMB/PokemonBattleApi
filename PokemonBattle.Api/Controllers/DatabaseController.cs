using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonBattle.Api.Database;
using PokemonBattle.Api.Services;

namespace PokemonBattle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly IPokeApiService pokeApi;

        public DatabaseController(IPokeApiService _pokeApi)
        {
            pokeApi = _pokeApi;
        }

        [HttpPost]
        public async Task<ActionResult> PopulateDatabase()
        {
            var pokemonRequestResponse = await pokeApi.GetPokemon();
            var moveRequestResponse = await pokeApi.GetMoves();

            return Ok($"You got {pokemonRequestResponse} pokemons! \nYou updated {moveRequestResponse} moves");
        }

    }
}
