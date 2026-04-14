using Microsoft.EntityFrameworkCore;
using PokemonBattle.Api.Database;
using PokemonBattle.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IPokeApiService, PokeApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["PokeApi:BaseURL"]);
});

builder.Services.AddScoped<IPokemonService, PokemonService>();

builder.Services.AddScoped<IBattleService, BattleService>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source = PokeBattle.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.UseHttpsRedirection();



app.Run();

