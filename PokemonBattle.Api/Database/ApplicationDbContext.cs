using System;
using Microsoft.EntityFrameworkCore;
using PokemonBattle.Api.Enums;
using PokemonBattle.Api.Models;

namespace PokemonBattle.Api.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<Move> Moves { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pokemon>()
         .Property(p => p.Types)
         .HasConversion(
             v => string.Join(",", v),
             v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                   .Select(s => (TypesEnum)Enum.Parse(typeof(TypesEnum), s))
                   .ToList());
            
        modelBuilder.Entity<Move>().Property(m => m.Type)
                                    .HasConversion<string>();
        modelBuilder.Entity<Move>().Property(m => m._damageClass)
                                    .HasConversion<string>();
    }

}
