using System;

namespace PokemonBattle.Api.Dtos;

public class BattleResultDto
{
    public string Winner { get; set; }
    public string Loser { get; set; }
    public List<string> BattleLog { get; set; } = new();
}
