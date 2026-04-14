using System;
using PokemonBattle.Api.Dtos;

namespace PokemonBattle.Api.Services;

public interface IBattleService
{
    Task<BattleResultDto?> SimulateBattle(string identifier1, string identifier2);
    
}
