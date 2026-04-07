using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonBattle.Api.Database;
using PokemonBattle.Api.Models;

namespace PokemonBattle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
         ApplicationDbContext PokeDb;

         public TestController(ApplicationDbContext context)
        {
            PokeDb = context;
        }

        [HttpPost]
        public ActionResult Post(Pokemon pokemon)
        {
            PokeDb.Pokemons.Add(pokemon);
            PokeDb.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult get()
        {
            return Ok(PokeDb.Pokemons.Include(p => p.Moves).ToList());
        }
        
    }
}
