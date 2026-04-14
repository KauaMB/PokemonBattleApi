using System;
using PokemonBattle.Api.Enums;

namespace PokemonBattle.Api.Services;

public static class TypeChart
{
    public static Dictionary<TypesEnum, Dictionary<TypesEnum, double>> Chart = new Dictionary<TypesEnum, Dictionary<TypesEnum, double>>
    {
        [TypesEnum.Normal] = new()
        {
            [TypesEnum.Rock] = .5,
            [TypesEnum.Ghost] = 0
        },
        [TypesEnum.Fire] = new()
        {
            [TypesEnum.Fire] = .5,
            [TypesEnum.Water] = .5,
            [TypesEnum.Grass] = 2,
            [TypesEnum.Ice] = 2,
            [TypesEnum.Bug] = 2,
            [TypesEnum.Rock] = .5,
            [TypesEnum.Dragon] = .5
        },
        [TypesEnum.Water] = new()
        {
            [TypesEnum.Fire] = 2,
            [TypesEnum.Water] = .5,
            [TypesEnum.Grass] = .5,
            [TypesEnum.Ground] = 2,
            [TypesEnum.Rock] = 2,
            [TypesEnum.Dragon] = .5
        },
        [TypesEnum.Grass] = new()
        {
            [TypesEnum.Fire] = .5,
            [TypesEnum.Water] = 2,
            [TypesEnum.Grass] = .5,
            [TypesEnum.Poison] = .5,
            [TypesEnum.Ground] = 2,
            [TypesEnum.Flying] = .5,
            [TypesEnum.Bug] = .5,
            [TypesEnum.Rock] = 2,
            [TypesEnum.Dragon] = .5
        },
        [TypesEnum.Electric] = new()
        {
            [TypesEnum.Water] = 2,
            [TypesEnum.Grass] = .5,
            [TypesEnum.Electric] = .5,
            [TypesEnum.Ground] = 0,
            [TypesEnum.Flying] = 2,
            [TypesEnum.Dragon] = .5
        },
        [TypesEnum.Ice] = new()
        {
            [TypesEnum.Fire] = .5,
            [TypesEnum.Water] = .5,
            [TypesEnum.Grass] = 2,
            [TypesEnum.Ice] = .5,
            [TypesEnum.Ground] = 2,
            [TypesEnum.Flying] = 2,
            [TypesEnum.Dragon] = 2
        },
        [TypesEnum.Fighting] = new()
        {
            [TypesEnum.Normal] = 2,
            [TypesEnum.Ice] = 2,
            [TypesEnum.Poison] = .5,
            [TypesEnum.Flying] = .5,
            [TypesEnum.Psychic] = .5,
            [TypesEnum.Bug] = .5,
            [TypesEnum.Rock] = 2,
            [TypesEnum.Ghost] = 0,
            [TypesEnum.Fairy] = .5
        },
        [TypesEnum.Poison] = new()
        {
            [TypesEnum.Grass] = 2,
            [TypesEnum.Poison] = .5,
            [TypesEnum.Ground] = .5,
            [TypesEnum.Bug] = 2,
            [TypesEnum.Rock] = .5,
            [TypesEnum.Ghost] = .5,
            [TypesEnum.Fairy] = 2
        },
        [TypesEnum.Ground] = new()
        {
            [TypesEnum.Fire] = 2,
            [TypesEnum.Grass] = .5,
            [TypesEnum.Electric] = 2,
            [TypesEnum.Poison] = 2,
            [TypesEnum.Flying] = 0,
            [TypesEnum.Bug] = .5,
            [TypesEnum.Rock] = 2
        },
        [TypesEnum.Flying] = new()
        {
            [TypesEnum.Grass] = 2,
            [TypesEnum.Electric] = .5,
            [TypesEnum.Fighting] = 2,
            [TypesEnum.Bug] = 2,
            [TypesEnum.Rock] = .5
        },
        [TypesEnum.Psychic] = new()
        {
            [TypesEnum.Fighting] = 2,
            [TypesEnum.Poison] = 2,
            [TypesEnum.Psychic] = .5
        },
        [TypesEnum.Bug] = new()
        {
            [TypesEnum.Fire] = .5,
            [TypesEnum.Grass] = 2,
            [TypesEnum.Fighting] = .5,
            [TypesEnum.Poison] = 2,
            [TypesEnum.Flying] = .5,
            [TypesEnum.Psychic] = 2,
            [TypesEnum.Ghost] = .5,
            [TypesEnum.Fairy] = .5
        },
        [TypesEnum.Rock] = new()
        {
            [TypesEnum.Fire] = 2,
            [TypesEnum.Ice] = 2,
            [TypesEnum.Fighting] = .5,
            [TypesEnum.Ground] = .5,
            [TypesEnum.Flying] = 2,
            [TypesEnum.Bug] = 2
        },
        [TypesEnum.Ghost] = new()
        {
            [TypesEnum.Normal] = 0,
            [TypesEnum.Psychic] = 0,
            [TypesEnum.Ghost] = 2
        },
        [TypesEnum.Dragon] = new()
        {
            [TypesEnum.Dragon] = 2,
            [TypesEnum.Fairy] = 0
        },
        [TypesEnum.Fairy] = new()
        {
            [TypesEnum.Fighting] = 2,
            [TypesEnum.Poison] = .5,
            [TypesEnum.Dragon] = 2,
            [TypesEnum.Fire] = .5
        }

    };

    public static double GetEffectivenes(TypesEnum attackType, TypesEnum defenderType)
    {
        if (Chart[attackType].ContainsKey(defenderType)) return Chart[attackType][defenderType];
        return 1;
    }
}
