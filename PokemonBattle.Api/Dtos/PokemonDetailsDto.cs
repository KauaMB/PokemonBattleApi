using System;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using PokemonBattle.Api.Enums;
using PokemonBattle.Api.Models;

namespace PokemonBattle.Api.Dtos;

public class PokemonDetailsDto
{
    //soltos
    public int Id { get; set; }
    public string Name { get; set; }

    //nested
    public List<Stats> Stats { get; set; }
    public List<PokemonTypes> Types { get; set; }
}



//Stats Classes
public class Stats
{
    [JsonPropertyName("base_stat")]
    public int StatValue { get; set; }

    [JsonPropertyName("stat")]
    public StatNameClass StatName { get; set; }
}

public class StatNameClass
{
    public string Name { get; set; }
}

//Types classes
public class PokemonTypes
{
    public PokemonTypeDto Type { get; set; }
}

public class PokemonTypeDto
{
    public string Name { get; set; }
}