namespace MarketWeight.Core.Persistencia;

public interface IRepoMoneda :
    IRepoAlta<Moneda>,
    IRepoAltaAsync<Moneda>,
    IRepoListado<Moneda>,
    IRepoListadoAsync<Moneda>,
    IRepoDetalle<Moneda, uint>
{
    public IEnumerable<Moneda> ObtenerConCondicion(string condicion);

    public Task<IEnumerable<Moneda>> ObtenerConCondicionAsync(string condicion);
}
