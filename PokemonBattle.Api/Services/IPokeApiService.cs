using System;
using PokemonBattle.Api.Models;

namespace PokemonBattle.Api.Services;

public interface IPokeApiService
{
    Task<List<Pokemon>> GetPokemon();
}
