using Microsoft.AspNetCore.Mvc;
using MarketWeight_6to.mvc.ViewModel;
using MarketWeight.Ado.Dapper;
using MarketWeight.Core.Persistencia;
using MarketWeight.Core;

namespace Marketweight_6to.mvc;

public class UsuarioController : Controller
{
    private readonly IRepoUsuario _repoUsuario;

    public UsuarioController(IRepoUsuario repoUsuario)
    {
        _repoUsuario = repoUsuario;
    }


    public IActionResult ObtenerUsuario()
    {
        var usuarios = _repoUsuario.Obtener();
        return View(usuarios);
    }


    public IActionResult DetalleUsuario(uint id)
    {
        var usuario = _repoUsuario.Detalle(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return View(usuario);
    }
        
            public IActionResult Crear()
        {
            return View(); 
        }
        
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Alta(Usuario usuario)
    {
        if (ModelState.IsValid)
        {
            _repoUsuario.Alta(usuario);
            return RedirectToAction(nameof(Index));
        }

        return View(usuario);   
            
        }
    }