using PokemonBattle.Api.Dtos;
using PokemonBattle.Api.Enums;
using PokemonBattle.Api.Models;

namespace PokemonBattle.Api.Services;

public class PokeApiService : IPokeApiService
{
    private readonly HttpClient _httpClient;

    public PokeApiService(HttpClient httpclient)
    {
        _httpClient = httpclient;
    }

    public async Task<List<Pokemon>> GetPokemon()
    {
        List<Pokemon> DetailedPokemons = new();

        var response = await _httpClient.GetFromJsonAsync<PokeApiResponse>("pokemon?limit=151");

        foreach (var pokemon in response.Results)
        {

            PokemonDetailsDto? detailResponse = await _httpClient.GetFromJsonAsync<PokemonDetailsDto>($"pokemon/{pokemon.name}");

            List<TypesEnum> parsedTypes = new List<TypesEnum>();
            foreach (var type in detailResponse.Types)
            {
                if (Enum.TryParse<TypesEnum>(type.Type.Name, true, out var ParseResult))
                {
                    parsedTypes.Add(ParseResult);
                }
            }

            Pokemon definitivePokemon = new Pokemon
            {
                Name = detailResponse.Name,
                Id = detailResponse.Id,

                Attack = detailResponse.Stats.Find(x => x.StatName.Name == "attack")?.StatValue ?? 0,
                Defense = detailResponse.Stats.Find(x => x.StatName.Name == "defense")?.StatValue ?? 0,
                MaxHP = detailResponse.Stats.Find(x => x.StatName.Name == "hp")?.StatValue ?? 0,

                Types = parsedTypes
            };
            DetailedPokemons.Add(definitivePokemon);
        }

        return DetailedPokemons;


    


    }


}