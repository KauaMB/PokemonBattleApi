using System;
using PokemonBattle.Api.Dtos;
using PokemonBattle.Api.Models;

namespace PokemonBattle.Api.Services;

public interface IPokemonService
{
    Task<PokemonDataDto?> GetPokemonFromDb(string identifier);
}
