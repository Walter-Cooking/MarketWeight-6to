namespace MarketWeight.Core.Persistencia;

public interface IRepoHistorial :
    IRepoAlta<Historial>,
    IRepoAltaAsync<Historial>,
    IRepoListado<Historial>,
    IRepoListadoAsync<Historial>,
    IRepoDetalle<Historial, uint>
{}
