// using System;
// using System.Runtime.ExceptionServices;
// using Microsoft.VisualBasic;
// using PokemonBattle.Api.Dtos;
// using PokemonBattle.Api.Enums;
// using PokemonBattle.Api.Models;

// namespace PokemonBattle.Api.Services;

// public class BattleService
// {
//     private readonly IPokemonService PokeService;

//     public BattleService(IPokemonService pokemonService)
//     {
//         PokeService = pokemonService;
//     }
//     public async Task<BattleResultDto?> SimulateBattle(string identifier1, string identifier2)
//     {
//         List<string> battleLog = new();

//         PokemonDataDto? pokemon1 = await PokeService.GetPokemonFromDb(identifier1);
//         PokemonDataDto? pokemon2 = await PokeService.GetPokemonFromDb(identifier2);

//         if (pokemon1 == null || pokemon2 == null) throw new Exception("Pokemon not found");

//         pokemon1.Moves = pokemon1.Moves.OrderBy(x => Random.Shared.Next()).Take(4).ToList();
//         pokemon2.Moves = pokemon2.Moves.OrderBy(x => Random.Shared.Next()).Take(4).ToList();


//         while (pokemon1.Hp > 0 && pokemon2.Hp > 0)
//         {
//             //p1 == pokemon1
//             //p2 == pokemon2

//             var p1Move = pokemon1.Moves[Random.Shared.Next(4)];
//             var p2Move = pokemon2.Moves[Random.Shared.Next(4)];

//             PokemonDataDto first;
//             PokemonDataDto second;

//             if (pokemon1.Speed > pokemon2.Speed) { first = pokemon1; second = pokemon2; }
//             else if (pokemon2.Speed > pokemon1.Speed) { first = pokemon2; second = pokemon1; }
//             else
//             {
//                 bool p1Starts = Random.Shared.Next(2) == 0;
//                 first = p1Starts ? pokemon1 : pokemon2;
//                 second = p1Starts ? pokemon2 : pokemon1;
//             }



//         }

//     }

//     private int CalculateDamage(PokemonDataDto attacker, PokemonDataDto defender, MoveDataDto move)
//     {
//         if (AttackHits(move) == false) return 0;

//     }

//     private bool AttackHits(MoveDataDto move)
//     {
//         return (Random.Shared.Next(101) > move.MoveAccuracy) ? false : true;
//     }

//     private double BaseDamage(PokemonDataDto attacker, PokemonDataDto defender, MoveDataDto move)
//     {
//         double damageReductionFactor = 0.1;

//         switch (move.MoveDamageClass)
//         {
//             case DamageClass.Physical: {
//                     return (move.MovePower * ((double)attacker.Attack / defender.Defense)) * damageReductionFactor;
//                     break;
//                 }
//             case DamageClass.Special: {
//                     return (move.MovePower * ((double)attacker.SpecialAttack / defender.SpecialDefense)) * damageReductionFactor;
//                     break;
//                 }
//             default: return 0;
//         }
//     }
// }
