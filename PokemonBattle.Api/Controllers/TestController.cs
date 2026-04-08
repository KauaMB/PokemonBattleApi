using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonBattle.Api.Database;
using PokemonBattle.Api.Dtos;
using PokemonBattle.Api.Models;
using PokemonBattle.Api.Services;

namespace PokemonBattle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly PokeApiService _pokeApiService;
        private readonly ApplicationDbContext PokeDb;

         public TestController(ApplicationDbContext context, IPokeApiService pokeApiService)
        {
            PokeDb = context;
            _pokeApiService = (PokeApiService)pokeApiService;
        }

        [HttpPost]
        public ActionResult Post(Pokemon pokemon)
        {
            PokeDb.Pokemons.Add(pokemon);
            PokeDb.SaveChanges();
            return Ok();
        }

        // [HttpGet]
        // public ActionResult get()
        // {
        //     return Ok(PokeDb.Pokemons.Include(p => p.Moves).ToList());
        // }
        
        [HttpGet("from-api")]
        public async Task<ActionResult<List<PokemonDto>>> getFromApi()
        {
            var requestResponse = await _pokeApiService.GetPokemon();
            return Ok(requestResponse);
        }
    }
}
