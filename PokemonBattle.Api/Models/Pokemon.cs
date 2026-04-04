using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using PokemonBattle.Api.Enums;

namespace PokemonBattle.Api.Models;

public class Pokemon
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public PokemonTypes Type { get; set; }

    public PokemonTypes? SecondType { get; set; }

    [Required]
    public int Attack { get; set; }

    [Required]
    public int Defense { get; set; }

    [Required]
    public int MaxHP { get; set; }

    [Required]
    public List<Move> Moves { get; set; }
}
