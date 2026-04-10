using System;
using System.Text.Json.Serialization;
using PokemonBattle.Api.Enums;

namespace PokemonBattle.Api.Dtos;

public class MoveDetailsDto
{
    public int? Accuracy { get; set; }

    public int? Power { get; set; }

    public MoveType Type { get; set; }

    [JsonPropertyName("damage_class")]
    public MoveDamageClass? _damageClass { get; set; }
}

//Types Class
public class MoveType
{
    public string name { get; set; }
}

//DamageClass Class
public class MoveDamageClass
{
    public string? name { get; set; }
}


