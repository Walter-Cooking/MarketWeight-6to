using Microsoft.AspNetCore.Mvc;
using MarketWeight_6to.mvc.ViewModel;
using MarketWeight.Ado.Dapper;
using MarketWeight.Core.Persistencia;
using Marketweight_6to.mvc.Filters;
using MarketWeight.Core;

namespace Marketweight_6to.mvc.Controllers;

[Authorize]
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

[HttpGet]
    public IActionResult DetalleUsuario()
    {
        var email = HttpContext.Session.GetString("Email");
        if (string.IsNullOrEmpty(email))
        {
            return NotFound();
        }
        var detalle = _repoUsuario.DetalleEmail(email);

        if (detalle == null)
        {
            return NotFound();
        }
        return View(detalle);
    }
        

        
  
    }