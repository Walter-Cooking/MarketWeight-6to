namespace MarketWeight.Core.Persistencia;

public interface IRepoUsuarioAsync :
    IRepoAlta<Usuario>,
    IRepoListado<Usuario>,
    IRepoDetalle<Usuario, uint>
{
    public async Task CompraAsync(uint idusuario, decimal cantidad, uint idmoneda)
    {
    }

    public async Task VenderAsync(uint idusuario, decimal cantidad, uint idmoneda)
    {}

    public async Task IngresoAsync(uint idusuario, decimal saldo)
    {}
    public async Task Transferencia( uint idmoneda, decimal cantidad, uint idusuarioTransfiere, uint idusuarioTransferido)
    {}

    public Task<Usuario> ObtenerPorCondicion (string condicion);

    public Task<UsuarioMoneda> ObtenerUsuarioMoneda();

    public Task<UsuarioMoneda> ObtenerPorCondicionUsuarioMoneda (uint? userid, decimal? cantidad);

    public Task<Usuario?> DetalleCompleto(uint idUsuario);

}
