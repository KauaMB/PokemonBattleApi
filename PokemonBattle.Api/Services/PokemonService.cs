using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using PokemonBattle.Api.Database;
using PokemonBattle.Api.Dtos;
using PokemonBattle.Api.Enums;
using PokemonBattle.Api.Models;

namespace PokemonBattle.Api.Services;

public class PokemonService : IPokemonService
{
    private readonly ApplicationDbContext dbContext;

    public PokemonService(ApplicationDbContext context)
    {
        dbContext = context;
    }

    public async Task<PokemonDataDto?> GetPokemonFromDb(string identifier)
    {
        Pokemon? pokemon;

        if (int.TryParse(identifier, out int id))
        {
            pokemon = await dbContext.Pokemons.Include(p => p.Moves).
                                            FirstOrDefaultAsync(x => x.Id == id);

        }
        else
        {
            pokemon = await dbContext.Pokemons.Include(p => p.Moves).
                                             FirstOrDefaultAsync(p => p.Name.ToLower() == identifier);
        }
        if (pokemon == null) return null;

        return new PokemonDataDto
        {
            Name = pokemon.Name,
            Id = pokemon.Id,
            Hp = pokemon.MaxHP,
            Attack = pokemon.Attack,
            SpecialAttack = pokemon.SpecialAttack,
            Defense = pokemon.Defense,
            SpecialDefense = pokemon.SpecialDefense,
            Speed = pokemon.Speed,

            Types = pokemon.Types.Select(x => x.ToString()).ToList(),

           Moves = pokemon.Moves.Select(m => new MoveDataDto
           {
               MoveName = m.Name,
               MoveId = m.Id,
               MovePower = m.Power ?? 0,
               MoveAccuracy = m.Accuracy ?? 0,
               MoveType = m.Type.ToString(),
               MoveDamageClass = m._damageClass
           }).ToList()
        };
    }
}
