using MarketWeight.Core;

namespace MinimalAPI.DTOs;

public record struct DTOListadoUsuarios
{
    public uint Id {get; init;}
    public DTOListadoUsuarios(Usuario usuario) =>
        (Id) = (usuario.IdUsuario);
}