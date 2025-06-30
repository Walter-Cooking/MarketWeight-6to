namespace MarketWeight.Core.Persistencia;

public interface IRepoUsuarioAsync :
    IRepoAlta<Usuario>,
    IRepoListado<Usuario>,
    IRepoDetalle<Usuario, uint>
{
    Task CompraAsync(uint idusuario, decimal cantidad, uint idmoneda);


    Task VenderAsync(uint idusuario, decimal cantidad, uint idmoneda);

    Task IngresoAsync(uint idusuario, decimal saldo);
    Task TransferenciaAsync(uint idmoneda, decimal cantidad, uint idusuarioTransfiere, uint idusuarioTransferido);

    public Task<IEnumerable<Usuario>> ObtenerPorCondicionAsync(string condicion);

    public Task<IEnumerable<UsuarioMoneda>> ObtenerUsuarioMonedaAsync();

    public Task<IEnumerable<UsuarioMoneda>> ObtenerPorCondicionUsuarioMonedaAsync(uint? userid, decimal? cantidad);

    public Task<Usuario?> DetalleCompletoAsync(uint idUsuario);

}
