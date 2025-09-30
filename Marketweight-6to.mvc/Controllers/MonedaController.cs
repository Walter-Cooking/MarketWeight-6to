using Microsoft.AspNetCore.Mvc;
using MarketWeight_6to.mvc.ViewModel;
using MarketWeight.Ado.Dapper;
using MarketWeight.Core.Persistencia;
using MarketWeight.Core;

namespace Marketweight_6to.mvc.Controllers
{
    public class MonedaController : Controller
    {
        private readonly IRepoMoneda _repoMoneda;

        public MonedaController(IRepoMoneda repoMoneda)
        {
            _repoMoneda = repoMoneda;
        }

        // Lista todas las monedas
        public IActionResult ObtenerMoneda()
        {
            var monedas = _repoMoneda.Obtener();
            return View(monedas);
        }


        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Crear(MonedaVM modelo)
        {
            if (!ModelState.IsValid)
                return View(modelo);

            try
            {
                var nuevaMoneda = new Moneda
                {
                    IdMoneda = 0,
                    Nombre = modelo.Nombre,
                    Precio = modelo.Precio,
                    Cantidad = modelo.Cantidad
                };

                _repoMoneda.Alta(nuevaMoneda);

                TempData["Mensaje"] = "Moneda creada con éxito.";
                return RedirectToAction("ObtenerMoneda");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al crear la moneda: {ex.Message}");
                return View(modelo);
            }
        }
    }
}
