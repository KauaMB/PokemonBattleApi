using System;

namespace PokemonBattle.Api.Dtos;

public class BattleResultDto
{
    public PokemonDataDto Winner { get; set; }
    public PokemonDataDto Loser { get; set; }
    public List<string> BattleLog { get; set; } = new();
}
