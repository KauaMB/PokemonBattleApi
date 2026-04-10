using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using PokemonBattle.Api.Enums;

namespace PokemonBattle.Api.Models;

public class Pokemon
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int MaxHP { get; set; }

    public int Attack { get; set; }

    public int Defense { get; set; }

    public List<TypesEnum> Types { get; set; }

    public List<Move> Moves { get; set; }
}
