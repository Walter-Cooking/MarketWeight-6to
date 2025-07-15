using MarketWeight.Core;
using MarketWeight.Core.Persistencia;
using MarketWeight.Ado.Dapper;
using MySqlConnector;
using System.Data;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("MySQL");


builder.Services.AddScoped<IDbConnection>(_ => new MySqlConnection(connectionString));
builder.Services.AddScoped<IRepoUsuario, RepoUsuario>();
builder.Services.AddScoped<IRepoMoneda, RepoMoneda>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "/openapi/{documentName}.json";
    });
    app.MapScalarApiReference();
}


//Usuario
app.MapGet("/usuarios", async (IRepoUsuario repo) =>
    await repo.ObtenerAsync());

app.MapGet("/usuarios/{id:int}", async (int id, IRepoUsuario repo) =>
{
    var usuario = await repo.DetalleCompletoAsync((uint)id);
    return usuario is not null ? Results.Ok(usuario) : Results.NotFound();
});

app.MapPost("/usuarios", async (Usuario usuario, IRepoUsuario repo) =>
{
    await repo.AltaAsync(usuario);
    return Results.Created($"/usuarios/{usuario.Nombre}", usuario);
});

//Moneda
app.MapGet("/monedas", async (IRepoMoneda repo) =>
    await repo.ObtenerAsync());

app.MapGet("/monedas/nombre/{nombre}", async (string nombre, IRepoMoneda repo) =>
{
    var monedas = await repo.ObtenerConCondicionAsync($"nombre = '{nombre}'");
    var moneda = monedas.FirstOrDefault();
    return moneda is not null ? Results.Ok(moneda) : Results.NotFound();
});

app.MapPost("/monedas", async (Moneda moneda, IRepoMoneda repo) =>
{
    await repo.AltaAsync(moneda);
    return Results.Created($"/monedas/{moneda.Nombre}", moneda);
});
app.Run();
