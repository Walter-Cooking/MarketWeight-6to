using MarketWeight.Core;

namespace MinimalAPI.DTOs;

public record struct DTOListadoUsuarios
{
    public  uint Id { get; init; }
    public string Nombre { get; set; }
    public  string Apellido { get; set; }
    public  string Email { get; set; }
    public decimal Saldo { get; set; }
    public DTOListadoUsuarios(Usuario usuario) =>
        (Id,Nombre, Apellido, Email, Saldo) = (usuario.IdUsuario, usuario.Nombre, usuario.Apellido, usuario.Email, usuario.Saldo);
}