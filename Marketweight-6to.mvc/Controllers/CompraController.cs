using Microsoft.AspNetCore.Mvc;
using MarketWeight_6to.mvc.ViewModel;
using MarketWeight.Ado.Dapper;
using MarketWeight.Core.Persistencia;
using MarketWeight.Core;

namespace MarketWeight_6to.mvc.Controllers
{
    public class CompraController : Controller
    {
        private readonly IRepoMoneda _repoMoneda;
        private readonly IRepoUsuario _repoUsuario;

        public CompraController(IRepoMoneda repoMoneda, IRepoUsuario repoUsuario)
        {
            _repoMoneda = repoMoneda;
            _repoUsuario = repoUsuario;
        }

        [HttpGet]
        public IActionResult Comprar()
        {
            var monedas = _repoMoneda.Obtener().ToList();

            var vm = new CompraVM
            {
                Monedas = monedas
            };

            return View("Compra", vm); 
        }

        [HttpPost]
        public IActionResult Comprar(CompraVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repoUsuario.Compra(model.idMoneda, model.Cantidad, model.idUsuario);
                    TempData["Mensaje"] = $"{model.idUsuario} compró {model.Cantidad} de idmoneda: {model.idUsuario}.";
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Error en la compra: " + ex.Message;
                }
            }

            model.Monedas = _repoMoneda.Obtener().ToList();
            return View("Compra", model);
        }
    }
}
