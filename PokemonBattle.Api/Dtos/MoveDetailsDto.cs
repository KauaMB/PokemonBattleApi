using System;
using System.Text.Json.Serialization;

namespace PokemonBattle.Api.Dtos;

public class MoveDetailsDto
{
    public string Name { get; set; }
    public int Id { get; set; }

    [JsonPropertyName("learned_by_pokemon")]
    public List<LearnedBy> LearnedByPokemon { get; set; }
}

public class LearnedBy
{
    public string Name { get; set; }
}
