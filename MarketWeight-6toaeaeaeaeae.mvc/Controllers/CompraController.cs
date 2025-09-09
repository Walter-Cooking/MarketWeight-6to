using Microsoft.AspNetCore.Mvc;
using MarketWeight_6toaeaeeaeaeeaea.ViewModel;
using MarketWeight.Ado.Dapper; 
using MarketWeight.Core;       

namespace MarketWeight_6toaeaeeaeaeeaea.Controllers
{
    public class CompraController : Controller
    {
        private readonly RepoMoneda _repoMoneda;
        private readonly RepoUsuario _repoUsuario;

        public CompraController(RepoMoneda repoMoneda, RepoUsuario repoUsuario)
        {
            _repoMoneda = repoMoneda;
            _repoUsuario = repoUsuario;
        }


        public IActionResult Index(int usuarioId)
        {
            var viewModel = new CompraViewModel
            {
                UsuarioId = usuarioId,
                MonedasDisponibles = _repoMoneda.Obtener().ToList()
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Comprar(CompraViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _repoUsuario.Compra((uint)model.UsuarioId, model.Cantidad, (uint)model.MonedaId);

                    ViewBag.Mensaje = $"{model.UsuarioId} compro {model.Cantidad} {model.MonedaId}";
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = $"hahhahahahahahahahah{ex.Message}";
                }
            }

            model.MonedasDisponibles = _repoMoneda.Obtener().ToList();

            return View("Index", model);
        }
    }
}
