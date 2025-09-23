using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Marketweight_6to.mvc.Models;
using MarketWeight_6to.mvc.ViewModel;
using MarketWeight.Core.Persistencia;

namespace Marketweight_6to.mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepoMoneda _repoMoneda;

    public HomeController(ILogger<HomeController> logger, IRepoMoneda repoMoneda)
    {
        _logger = logger;
        _repoMoneda = repoMoneda;
    }

    public async Task<IActionResult> Index()
    {
        var compraVM = new CompraVM();
        compraVM.Monedas = (await _repoMoneda.ObtenerAsync()).ToList();
        return View(compraVM); 
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
