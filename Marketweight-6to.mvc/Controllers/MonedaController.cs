using Microsoft.AspNetCore.Mvc;
using MarketWeight_6to.mvc.ViewModel;
using MarketWeight.Ado.Dapper;
using MarketWeight.Core.Persistencia;
using Marketweight_6to.mvc.Filters;
using MarketWeight.Core;
using Microsoft.Extensions.Options; 

namespace Marketweight_6to.mvc.Controllers
{
    [Authorize]
    public class MonedaController : Controller
    {
        private readonly IRepoMoneda _repoMoneda;
        private readonly List<string> _adminEmails;

        public MonedaController(IRepoMoneda repoMoneda, IOptions<List<string>> adminEmails)
        {
            _repoMoneda = repoMoneda;
            _adminEmails = adminEmails.Value;
        }

        public IActionResult ObtenerMoneda()
        {
            var monedas = _repoMoneda.Obtener();
            return View(monedas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            var email = HttpContext.Session.GetString("Email");

            if (string.IsNullOrEmpty(email) || !_adminEmails.Contains(email))
            {
                TempData["Error"] = "No tenés permisos para crear monedas.";
                return RedirectToAction("ObtenerMoneda");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Crear(MonedaVM modelo)
        {
            var email = HttpContext.Session.GetString("Email");

            if (string.IsNullOrEmpty(email) || !_adminEmails.Contains(email))
            {
                TempData["Error"] = "No tenés permisos para crear monedas.";
                return RedirectToAction("ObtenerMoneda");
            }

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
