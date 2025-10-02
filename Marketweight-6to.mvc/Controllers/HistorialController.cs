using Microsoft.AspNetCore.Mvc;
using MarketWeight_6to.mvc.ViewModel;
using MarketWeight.Ado.Dapper;
using MarketWeight.Core;
using MarketWeight.Core.Persistencia;
using Marketweight_6to.mvc.Filters;

namespace Marketweight_6to.mvc.Controllers;

[Authorize]
public class HistorialController : Controller
{
    private readonly IRepoHistorial _repoHistorial;

    public HistorialController(IRepoHistorial repoHistorial)
    {
        _repoHistorial = repoHistorial;
    }

public IActionResult ObtenerHistorial()
{
    var registros = _repoHistorial.Obtener()
        .OrderByDescending(h => h.FechaHora); 
    return View(registros);
}



    [HttpGet]
    public IActionResult Crear()
    {
        return View();
    }

}
