using System;
using System.ComponentModel.DataAnnotations;
using PokemonBattle.Api.Enums;

namespace PokemonBattle.Api.Models;

public class Move
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public TypesEnum Type { get; set; }

    [Required]
    public int Power { get; set; }
    
    [Required]
    public int Accuracy { get; set; }
}
