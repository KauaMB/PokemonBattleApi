using PokemonBattle.Api.Database;
using PokemonBattle.Api.Dtos;
using PokemonBattle.Api.Enums;
using PokemonBattle.Api.Models;

namespace PokemonBattle.Api.Services;

public class PokeApiService : IPokeApiService
{
    private readonly HttpClient _httpClient;
    private readonly ApplicationDbContext _dbContext;

    public PokeApiService(HttpClient httpclient, ApplicationDbContext context)
    {
        _dbContext = context;
        _httpClient = httpclient;
    }

    public async Task<int> GetPokemon()
    {
        if (_dbContext.Pokemons.Any())
        {
            return 0;
        }

        List<Pokemon> DetailedPokemons = new();

        var response = await _httpClient.GetFromJsonAsync<PokeApiResponse>("pokemon?limit=151");

        Dictionary<string, Move> AddedMoves = new Dictionary<string, Move>();

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

                Types = parsedTypes,
                Moves = new List<Move>()          
            };

            foreach (var move in detailResponse.Moves)
            {
                var MoveName = move.MoveNameClass.Name;

                if (!AddedMoves.ContainsKey(MoveName))
                {
                    AddedMoves.Add(MoveName, new Move{Name = MoveName});
                }

                definitivePokemon.Moves.Add(AddedMoves[MoveName]);
            }
            
            DetailedPokemons.Add(definitivePokemon);
        }

        await _dbContext.Pokemons.AddRangeAsync(DetailedPokemons);
        await _dbContext.SaveChangesAsync();

        return DetailedPokemons.Count;


    }


}