namespace MarketWeight.Core.Persistencia;

public interface IRepoListadoAsync<T>
{
    Task<IEnumerable<T>> ObtenerAsync();
    
    
}
