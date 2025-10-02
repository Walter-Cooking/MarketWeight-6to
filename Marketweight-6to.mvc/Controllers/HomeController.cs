using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Marketweight_6to.mvc.Models;
using MarketWeight.Core.Persistencia;
using MarketWeight.Core;
using MarketWeight.Ado.Dapper;

namespace Marketweight_6to.mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepoUsuario _repoUsuario;

public HomeController(ILogger<HomeController> logger, IRepoUsuario repoUsuario)
{
    _logger = logger;
    _repoUsuario = repoUsuario;
}

private string HashPassword(string password)
{
    using (var sha256 = SHA256.Create())
    {
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToHexString(hashedBytes).ToLower();
    }
}

[HttpGet]
public IActionResult Registro()
{
    return View();
}

    [HttpPost]
    public IActionResult Registro(RegistroVM modelo)
    {
        if (!ModelState.IsValid)
            return View(modelo);

        try
        {
            var nuevoUsuario = new Usuario
            {
                IdUsuario = 0,
                Nombre = modelo.Nombre,
                Apellido = modelo.Apellido,
                Email = modelo.Email,
                Password = modelo.Password,
                Saldo = 0,

            };

            _repoUsuario.Alta(nuevoUsuario);

            TempData["Mensaje"] = "Usuario registrado con éxito";
            return RedirectToAction("Login");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Error al registrar usuario: {ex.Message}");
            return View(modelo);
        }
    }

[HttpGet]
public IActionResult Login()
{
    return View();
}


[HttpPost]
public IActionResult Login(LoginVM modelo)
{
    if (!ModelState.IsValid)
        return View(modelo);


    var hashedPassword = HashPassword(modelo.Password);
    
    var usuario = _repoUsuario
        .Obtener()
        .FirstOrDefault(u => u.Email == modelo.Email && u.Password == hashedPassword);

    if (usuario == null)
    {
        ModelState.AddModelError("", "Email o contraseña incorrectos");
        return View(modelo);
    }

    HttpContext.Session.SetString("UsuarioId", usuario.IdUsuario.ToString());
    HttpContext.Session.SetString("UsuarioNombre", usuario.Nombre);
    HttpContext.Session.SetString("Email", usuario.Email);

    return RedirectToAction("Comprar", "Compra");
}



    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Home");
    }

/*    public IActionResult Index()
    {
        return View();
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
*/
}

