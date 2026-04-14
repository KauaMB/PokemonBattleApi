using System;

namespace PokemonBattle.Api.Dtos;

public class AttackResultDto
{
    public int Damage { get; set; }
    public bool IsHit { get; set; }
    public bool IsCritical { get; set; }
}
