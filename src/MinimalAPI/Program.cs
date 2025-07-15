using MarketWeight.Core;
using MarketWeight.Core.Persistencia;
using MarketWeight.Ado.Dapper;
using MySqlConnector;
using System.Data;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("MySQL");


builder.Services.AddScoped<IDbConnection>(_ => new MySqlConnection(connectionString));




var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


//Usuario
app.MapGet("/usuarios", async (IRepoUsuario repo) =>
    await repo.ObtenerAsync());

app.MapGet("/usuarios/nombre/{nombre}", async (string nombre, IRepoUsuario repo) =>
{
    var usuarios = await repo.ObtenerPorCondicionAsync($"nombre = '{nombre}'");
    var usuario = usuarios.FirstOrDefault();
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
