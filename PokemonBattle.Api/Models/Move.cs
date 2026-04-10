using System;
using System.ComponentModel.DataAnnotations;
using PokemonBattle.Api.Enums;

namespace PokemonBattle.Api.Models;

public class Move
{
    public int Id { get; set; }

    public string Name { get; set; }

    public TypesEnum Type { get; set; }

    public int Power { get; set; }
    
    public int Accuracy { get; set; }

    public List<Pokemon> LearnedBy { get; set; }
}
