using System;
using PokemonBattle.Api.Dtos;
using PokemonBattle.Api.Models;

namespace PokemonBattle.Api.Services;

public class PokeApiService : IPokeApiService
{
    private readonly HttpClient _httpClient;

    public PokeApiService(HttpClient httpclient)
    {
        _httpClient = httpclient;
    }

    public async Task<List<PokemonDto>> GetPokemon()
    {

        var response = await _httpClient.GetFromJsonAsync<PokeApiResponse>("pokemon?limit=151");

        if (response == null)
        {
            return new List<PokemonDto>();
        }

        return response.Results;



    }


}