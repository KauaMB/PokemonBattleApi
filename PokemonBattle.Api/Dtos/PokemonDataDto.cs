using System;

namespace PokemonBattle.Api.Dtos;

public class PokemonDataDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Hp { get; set; }
    public int Attack { get; set; }
    public int SpecialAttack { get; set; }
    public int Defense { get; set; }
    public int SpecialDefense { get; set; }
    public int Speed { get; set; }

    public List<string> Types { get; set; } = new();
    public List<MoveDataDto> Moves { get; set; } = new();
}

public class MoveDataDto
{
    public string MoveName { get; set; }
    public int MoveId { get; set; }
    public int MovePower { get; set; }
    public int MoveAccuracy { get; set; }
    public string MoveType { get; set; }
    public string MoveDamageClass { get; set; }
}