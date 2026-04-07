using System;
using PokemonBattle.Api.Dtos;

namespace PokemonBattle.Api.Models;

public class PokeApiResponse
{
    public int Count { get; set; }
    public List<PokemonDto> Results { get; set; } = new();
}
