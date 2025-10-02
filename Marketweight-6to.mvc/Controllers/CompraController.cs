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
            var usuarioIdStr = HttpContext.Session.GetString("UsuarioId");
            if (string.IsNullOrEmpty(usuarioIdStr))
                return RedirectToAction("Login", "Home");

            var monedas = _repoMoneda.Obtener().ToList();
            var usuarioId = uint.Parse(usuarioIdStr);

            var vm = new CompraVM
            {
                idUsuario = usuarioId,
                Monedas = monedas
            };

            return View("Compra", vm); 
        }

        [HttpPost]
        public IActionResult Comprar(CompraVM model)
        {
            var usuarioIdStr = HttpContext.Session.GetString("UsuarioId");
            if (string.IsNullOrEmpty(usuarioIdStr))
                return RedirectToAction("Login", "Home");

            model.idUsuario = uint.Parse(usuarioIdStr);
            
            if (ModelState.IsValid)
            {
                try
                {
                    _repoUsuario.Compra(model.idUsuario, model.Cantidad, model.idMoneda);
                    HttpContext.Session.GetString("UsuarioNombre");
                    TempData["Mensaje"] = $"Compraste exitosamente.";
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
