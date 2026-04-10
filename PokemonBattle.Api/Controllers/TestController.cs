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

        [HttpPost("reset")]
    public async Task<IActionResult> ResetDatabase()
    {
        // 1. Deleta o banco de dados se ele existir
        await PokeDb.Database.EnsureDeletedAsync();

        // 2. Cria o banco de dados do zero com base nas suas Entities
        // Nota: Isso cria as tabelas mas NÃO aplica o histórico de migrations.
        // Para ambiente de teste, é perfeito.
        await PokeDb.Database.EnsureCreatedAsync();

        return Ok("Banco de dados explodido e recriado com sucesso! 🚀");
    }

        // [HttpGet]
        // public ActionResult get()
        // {
        //     return Ok(PokeDb.Pokemons.Include(p => p.Moves).ToList());
        // }
        
        [HttpGet("from-api")]
        public async Task<ActionResult<List<PokemonDto>>> getFromApi()
        {
            var requestPokemonResponse = await _pokeApiService.GetPokemon();
            var requestMoveResponse = await _pokeApiService.GetMoves();
            return Ok($"Got {requestPokemonResponse} Pokemons \nUpdated {requestMoveResponse} Moves");
        }
    }
}
