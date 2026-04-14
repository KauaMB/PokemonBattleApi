using System;
using System.Runtime.ExceptionServices;
using Microsoft.VisualBasic;
using PokemonBattle.Api.Dtos;
using PokemonBattle.Api.Enums;
using PokemonBattle.Api.Models;
using PokemonBattle.Api.Services;
using SQLitePCL;

namespace PokemonBattle.Api.Services;

public class BattleService : IBattleService
{
    private readonly IPokemonService PokeService;

    public BattleService(IPokemonService pokemonService)
    {
        PokeService = pokemonService;
    }
    public async Task<BattleResultDto?> SimulateBattle(string identifier1, string identifier2)
    {
        BattleResultDto battleLog = new();

        PokemonDataDto? pokemon1 = await PokeService.GetPokemonFromDb(identifier1);
        PokemonDataDto? pokemon2 = await PokeService.GetPokemonFromDb(identifier2);

        if (pokemon1 == null || pokemon2 == null) throw new Exception("Pokemon not found");

        pokemon1.Moves = pokemon1.Moves.OrderBy(x => Random.Shared.Next()).Take(4).ToList();
        pokemon2.Moves = pokemon2.Moves.OrderBy(x => Random.Shared.Next()).Take(4).ToList();
        
        while (pokemon1.Hp > 0 && pokemon2.Hp > 0)
        {
            //p1 == pokemon1
            //p2 == pokemon2

            var p1Move = pokemon1.Moves[Random.Shared.Next(4)];
            var p2Move = pokemon2.Moves[Random.Shared.Next(4)];

            PokemonDataDto first;
            PokemonDataDto second;
            MoveDataDto firstMove;
            MoveDataDto secondMove;

            if (pokemon1.Speed > pokemon2.Speed)
            {
                first = pokemon1;
                firstMove = p1Move;
                second = pokemon2;
                secondMove = p2Move;

                battleLog.BattleLog.Add($"{first.Name} was faster than {second.Name}");
            }
            else if (pokemon2.Speed > pokemon1.Speed)
            {
                first = pokemon2;
                firstMove = p2Move;
                second = pokemon1;
                secondMove = p1Move;

                battleLog.BattleLog.Add($"{first.Name} was faster than {second.Name}");

            }
            else
            {
                bool p1Starts = Random.Shared.Next(2) == 0;
                first = p1Starts ? pokemon1 : pokemon2;
                firstMove = p1Starts ? p1Move : p2Move;
                second = p1Starts ? pokemon2 : pokemon1;
                secondMove = p1Starts ? p2Move : p1Move;

                battleLog.BattleLog.Add($"It's a speed tie! However, {first.Name} got luckier and will attack first!");
            }

            //first attack
            var damageDealt = CalculateDamage(first, second, firstMove);
            second.Hp -= damageDealt;
            battleLog.BattleLog.Add($"{first.Name} dealt {damageDealt} damage to {second.Name} using {firstMove.MoveName}");
            battleLog.BattleLog.Add($"Current HP: {pokemon1.Name}: {pokemon1.Hp}, {pokemon2.Name}: {pokemon2.Hp}");

            //second attack
            if (second.Hp > 0)
            {
                damageDealt = CalculateDamage(second, first, secondMove);
                first.Hp -= damageDealt;
                battleLog.BattleLog.Add($"{second.Name} dealt {damageDealt} damage to {first.Name} using {secondMove.MoveName}");
                battleLog.BattleLog.Add($"Current HP: {pokemon1.Name}: {pokemon1.Hp}, {pokemon2.Name}: {pokemon2.Hp}");
            }
        }

        if (pokemon1.Hp > 0 && pokemon2.Hp <= 0)
        {
            battleLog.Winner = pokemon1;
            battleLog.Loser = pokemon2;
        }
        if (pokemon2.Hp > 0 && pokemon1.Hp <= 0)
        {
            battleLog.Winner = pokemon2;
            battleLog.Loser = pokemon1;
        }
        if (pokemon1.Hp < 0 && pokemon2.Hp < 0)
        {
            battleLog.BattleLog.Add($"It's a tie! Both Pokemons perished during combat");
        }

        return battleLog;
    }

    private int CalculateDamage(PokemonDataDto attacker, PokemonDataDto defender, MoveDataDto move)
    {
        if (AttackHits(move) == false) return 0;

        var baseDamage = BaseDamage(attacker, defender, move);

        int totalDamage = (int)(baseDamage * SameTypeAttackBonus(attacker, move) * IsCritical(attacker) * TypeComparision(defender, move));

        return totalDamage;
    }


    //Base Damage

    private bool AttackHits(MoveDataDto move)
    {
        return (Random.Shared.Next(101) > move.MoveAccuracy) ? false : true;
    }

    private double BaseDamage(PokemonDataDto attacker, PokemonDataDto defender, MoveDataDto move)
    {
        double damageReductionFactor = 0.1;

        switch (move.MoveDamageClass)
        {
            case DamageClass.Physical:
                {
                    return ((move.MovePower * ((double)attacker.Attack / defender.Defense)) * damageReductionFactor) + 2;
                }
            case DamageClass.Special:
                {
                    return ((move.MovePower * ((double)attacker.SpecialAttack / defender.SpecialDefense)) * damageReductionFactor) + 2;
                }
            default: return 2;
        }
    }

    //Modifiers
    private double SameTypeAttackBonus(PokemonDataDto attacker, MoveDataDto move)
    {

        if (attacker.Types.Any(t => t == move.MoveType)) return 1.5;

        return 1;
    }

    private double IsCritical(PokemonDataDto attacker)
    {
        int randomRoll = Random.Shared.Next(512);

        if (attacker.Speed > randomRoll) return 2;

        return 1;

    }

    private double TypeComparision(PokemonDataDto defender, MoveDataDto move)
    {
        double multiplier = 1;

        foreach (var type in defender.Types)
        {
            multiplier *= TypeChart.GetEffectivenes(move.MoveType, type);
        }

        return multiplier;
    }
}
