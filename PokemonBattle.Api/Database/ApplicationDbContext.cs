using System;
using Microsoft.EntityFrameworkCore;
using PokemonBattle.Api.Models;

namespace PokemonBattle.Api.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<Move> Moves { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

}
